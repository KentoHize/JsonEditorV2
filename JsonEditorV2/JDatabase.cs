using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class JDatabase
    {
        public string Name { get => JFI != null ? JFI.Name : null; }

        public List<JTable> Tables { get; set; } = new List<JTable>();

        public JFilesInfo JFI { get; set; }

        public bool Valid { get; set; }

        public bool CheckAllTablesValid()
        {
            foreach (JTable jt in Tables)
                if (!CheckTableValid(jt))
                    return false;
            return true;
        }

        public bool CheckTableValid(JTable jt, bool quickCheck = false)
        {
            Valid = true;
            if(!jt.CehckValid(quickCheck))
            { 
                Valid = false;
                if (quickCheck)
                    return false;
            }

            //FK Value Check
            for (int i = 0; i < jt.Columns.Count; i++)
            {
                JTable fkTable = Tables.Find(m => m.Name == jt.Columns[i].FKTable);
                if (!string.IsNullOrEmpty(jt.Columns[i].FKTable) &&
                   !string.IsNullOrEmpty(jt.Columns[i].FKColumn) &&
                   fkTable != null && fkTable.Loaded)
                {   
                    int fkColumnIndex = fkTable.Columns.FindIndex(m => m.Name == jt.Columns[i].FKColumn);

                    for (int j = 0; j < jt.Count; j++)
                    {
                        if (jt[j][i].Value != null && !fkTable.Lines.Exists(m => m.Values[fkColumnIndex].Value.CompareTo(jt[j][i].Value, jt.Columns[i].Type) == 0))
                        {
                            jt.AddInvalidRecord(j, i, JValueInvalidReasons.FoeignKeyValueNotExists);
                            jt.Valid = Valid = false;
                            
                            if(quickCheck)
                                return false;
                        }
                    }
                }
            }
            return Valid;
        }
    }
}
