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
        public string CalendarEra { get; set; }
        public string Description { get; set; }
        public List<JTableInfo> TablesInfo { get; set; }

        [JsonIgnore]
        public bool Changed { get; set; }

        [JsonIgnore]
        public string DirectoryPath { get; set; }

        [JsonIgnore]
        public string FileInfoPath { get => Path.Combine(DirectoryPath, FilesInfoName); }

        [JsonIgnore]
        public string InvalidFileName { get; set; }

        [JsonIgnore]
        public string InvalidColumnName { get; set; }

        [JsonIgnore]
        public JColumnInvalidReasons InvalidReason { get; set; }


        private JColumnInvalidReasons SetInvalidReason(string filename, string columnName, JColumnInvalidReasons reason)
        {
            InvalidFileName = filename;
            InvalidColumnName = columnName;
            InvalidReason = reason;
            return InvalidReason;
        }

        public JColumnInvalidReasons CheckColumnValid(JColumn jc)
        {
            try {
                if(!string.IsNullOrEmpty(jc.RegularExpression))
                    Regex.IsMatch("_", jc.RegularExpression);
            }
            catch { return JColumnInvalidReasons.IllegalRegularExpression; }

            if (!Regex.IsMatch(jc.Name, JValidate.ColumnNameRegex))
                return JColumnInvalidReasons.IllegalName;
            else if (jc.IsKey && jc.IsNullable)
                return JColumnInvalidReasons.IsKeyAndIsNullable;
            else if (!string.IsNullOrEmpty(jc.FKTable) && string.IsNullOrEmpty(jc.FKColumn))
                return JColumnInvalidReasons.ForeignKeyColumnMissing;
            else if (string.IsNullOrEmpty(jc.FKTable) && !string.IsNullOrEmpty(jc.FKColumn))
                return JColumnInvalidReasons.ForeignKeyTableMissing;
            else if (jc.NumberOfRows < 0 || jc.NumberOfRows > Setting.NumberOfRowsMaxValue)
                return JColumnInvalidReasons.NumberOfRowsIsNegativeOrTooBig;
            else if (!string.IsNullOrEmpty(jc.RegularExpression) && (jc.Type.IsNumber() || jc.Type.IsDateTime()))
                return JColumnInvalidReasons.NumberOrDateTimeHasRegularExpression;
            else if (!string.IsNullOrEmpty(jc.MinValue) && !jc.Type.IsNumber() && !jc.Type.IsDateTime())
                return JColumnInvalidReasons.NotNumberOrDateTimeHaveMinValue;
            else if (!string.IsNullOrEmpty(jc.MaxValue) && !jc.Type.IsNumber() && !jc.Type.IsDateTime())
                return JColumnInvalidReasons.NotNumberOrDateTimeHaveMaxValue;
            else if (!jc.MinValue.TryParseJType(jc.Type, Setting.UICI, out object min) && !string.IsNullOrEmpty(jc.MinValue))
                return JColumnInvalidReasons.MinValueTypeCastFailed;
            else if (!jc.MaxValue.TryParseJType(jc.Type, Setting.UICI, out object max) && !string.IsNullOrEmpty(jc.MaxValue))
                return JColumnInvalidReasons.MaxValueTypeCastFailed;
            else if (min != null && max != null && min.ToString() != "" && max.ToString() != "" && min.CompareTo(max, jc.Type) == 1)
                return JColumnInvalidReasons.MinValueGreaterThanMaxValue;
            else if (jc.MaxLength < 0)
                return JColumnInvalidReasons.MaxLengthIsNegative;
            else if (jc.AutoGenerateKey && (!string.IsNullOrEmpty(jc.MinValue) || !string.IsNullOrEmpty(jc.MaxValue) || !string.IsNullOrEmpty(jc.RegularExpression) || jc.MaxLength != 0))
                return JColumnInvalidReasons.AutoGenerateKeyWithRestrict;
            else if (jc.AutoGenerateKey && !jc.Type.IsNumber() && jc.Type != JType.String && jc.Type != JType.Guid)
                return JColumnInvalidReasons.AutoGenerateKeyWithInappropriateType;
            else if (jc.Type == JType.Choice && (jc.Choices == null || jc.Choices.Count == 0))
                return JColumnInvalidReasons.ChoiceTypeChoicesNotExist;
            return JColumnInvalidReasons.None;
        }

        public JColumnInvalidReasons CheckValid()
        {
            JColumnInvalidReasons result = JColumnInvalidReasons.None;
            for(int i = 0; i < TablesInfo.Count; i++)
            {
                for (int j = 0; j < TablesInfo[i].Columns.Count; j++)
                {
                    result = CheckColumnValid(TablesInfo[i].Columns[j]);
                    if (result != JColumnInvalidReasons.None)
                        return SetInvalidReason(TablesInfo[i].Name, TablesInfo[i].Columns[j].Name, result);
                    
                    if (!string.IsNullOrEmpty(TablesInfo[i].Columns[j].FKTable))
                    {
                        JTableInfo fkJti = TablesInfo.Find(m => m.Name == TablesInfo[i].Columns[j].FKTable);                        
                        if (fkJti == null)
                            return SetInvalidReason(TablesInfo[i].Name, TablesInfo[i].Columns[j].Name, JColumnInvalidReasons.ForeignKeyTableNotExist);
                        JColumn fkJc = fkJti.Columns.Find(m => m.Name == TablesInfo[i].Columns[j].FKColumn);
                        if (fkJc == null)
                            return SetInvalidReason(TablesInfo[i].Name, TablesInfo[i].Columns[j].Name, JColumnInvalidReasons.ForeignKeyColumnNotExist);

                        if (fkJc.Type != TablesInfo[i].Columns[j].Type)
                            return SetInvalidReason(TablesInfo[i].Name, TablesInfo[i].Columns[j].Name, JColumnInvalidReasons.ForeignKeyColumnTypeNotMatch);
                    }
                }                    
            }
            return JColumnInvalidReasons.None;          
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
