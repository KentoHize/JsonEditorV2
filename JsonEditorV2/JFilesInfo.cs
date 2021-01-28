using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using JsonEditorV2;
using Newtonsoft.Json;

namespace JsonEditor
{
    public class JFilesInfo : IDisposable
    {
        public const string FilesInfoName = "JFilesInfo.json";

        public string Name { get; set; }
        public List<JTableInfo> TablesInfo { get; set; }

        [JsonIgnore]
        public bool Changed { get; set; }

        [JsonIgnore]
        public string DirectoryPath { get; set; }

        [JsonIgnore]
        public string FileInfoPath { get => Path.Combine(DirectoryPath, FilesInfoName); }

        [JsonIgnore]
        public int InvalidTableIndex { get; set; }

        [JsonIgnore]
        public string InvalidColumnName { get; set; }

        [JsonIgnore]
        public JColumnInvalidReason InvalidReason { get; set; }


        private JColumnInvalidReason SetInvalidReason(int tableIndex, string columnName, JColumnInvalidReason reason)
        {
            InvalidTableIndex = tableIndex;
            InvalidColumnName = columnName;
            InvalidReason = reason;
            return InvalidReason;
        }

        public JColumnInvalidReason CheckColumnValid(JColumn jc)
        {
            try { Regex.IsMatch("_", jc.RegularExpression); }
            catch { return JColumnInvalidReason.IllegalRegularExpression; }

            if (!Regex.IsMatch(jc.Name, Const.ColumnNameRegex))
                return JColumnInvalidReason.IllegalName;
            else if (jc.IsKey && jc.IsNullable)
                return JColumnInvalidReason.IsKeyAndIsNullable;
            else if (!string.IsNullOrEmpty(jc.FKTable) && string.IsNullOrEmpty(jc.FKColumn))
                return JColumnInvalidReason.ForeignKeyColumnMissing;
            else if (string.IsNullOrEmpty(jc.FKTable) && !string.IsNullOrEmpty(jc.FKColumn))
                return JColumnInvalidReason.ForeignKeyTableMissing;
            else if (jc.NumberOfRows < 0 || jc.NumberOfRows > Const.NumberOfRowsMaxValue)
                return JColumnInvalidReason.NumberOfRowsIsNegativeOrTooBig;
            else if (!string.IsNullOrEmpty(jc.RegularExpression) && (jc.Type.IsNumber() || jc.Type.IsDateTime()))
                return JColumnInvalidReason.NumberOrDateTimeHaveRegularExpression;
            else if (!string.IsNullOrEmpty(jc.MinValue) && !jc.Type.IsNumber() && !jc.Type.IsDateTime())
                return JColumnInvalidReason.NotNumberOrDateTimeHaveMinValue;
            else if (!string.IsNullOrEmpty(jc.MaxValue) && !jc.Type.IsNumber() && !jc.Type.IsDateTime())
                return JColumnInvalidReason.NotNumberOrDateTimeHaveMaxValue;
            else if (!jc.MinValue.TryParseJType(jc.Type, out object min))
                return JColumnInvalidReason.MinValueTypeCastFailed;
            else if (!jc.MinValue.TryParseJType(jc.Type, out object max))
                return JColumnInvalidReason.MaxValueTypeCastFailed;
            else if (min.CompareTo(max, jc.Type) == 1)
                return JColumnInvalidReason.MinValueGreaterThanMaxValue;
            else if (jc.TextMaxLength < 0)
                return JColumnInvalidReason.MaxLengthIsNegative;
            return JColumnInvalidReason.None;
        }

        public JColumnInvalidReason CheckValid()
        {
            JColumnInvalidReason result = JColumnInvalidReason.None;
            for(int i = 0; i < TablesInfo.Count; i++)
            {
                for (int j = 0; j < TablesInfo[i].Columns.Count; j++)
                {
                    result = CheckColumnValid(TablesInfo[i].Columns[j]);
                    if (result != JColumnInvalidReason.None)
                        return SetInvalidReason(i, TablesInfo[i].Columns[j].Name, result);
                    
                    if (!string.IsNullOrEmpty(TablesInfo[i].Columns[j].FKTable))
                    {
                        JTableInfo fkJti = TablesInfo.Find(m => m.Name == TablesInfo[i].Columns[j].FKTable);                        
                        if (fkJti == null)
                            return SetInvalidReason(i, TablesInfo[i].Columns[j].Name, JColumnInvalidReason.ForeignKeyTableMissing);
                        JColumn fkJc = fkJti.Columns.Find(m => m.Name == TablesInfo[i].Columns[j].FKColumn);
                        if (fkJc == null)
                            return SetInvalidReason(i, TablesInfo[i].Columns[j].Name, JColumnInvalidReason.ForeignKeyColumnNotExist);

                        if (fkJc.Type != TablesInfo[i].Columns[j].Type)
                            return SetInvalidReason(i, TablesInfo[i].Columns[j].Name, JColumnInvalidReason.ForeignKeyColumnTypeNotMatch);
                    }
                }                    
            }
            return JColumnInvalidReason.None;          
        }

        public JFilesInfo()
            : this("")
        { }

        public JFilesInfo(string directoryPath)
            : this(directoryPath.Substring(directoryPath.LastIndexOf("\\") + 1), directoryPath)
        { }

        public JFilesInfo(string name, string directoryPath)
        {
            Name = name;
            DirectoryPath = directoryPath;
            TablesInfo = new List<JTableInfo>();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~JDirectoryInfo() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
