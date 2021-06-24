using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class JDatabase : IList<JTable>
    {
        public JTable this[int index] { get => ((IList<JTable>)Tables)[index]; set => ((IList<JTable>)Tables)[index] = value; }

        public string Name { get => JFI?.Name; }

        public string Description { get => JFI?.Description; }

        public List<JTable> Tables { get; set; } = new List<JTable>();

        public JFilesInfo JFI { get; set; }

        public bool Valid { get; set; }

        public int Count => ((IList<JTable>)Tables).Count;

        public bool IsReadOnly => ((IList<JTable>)Tables).IsReadOnly;

        public void Add(JTable item)
        {
            ((IList<JTable>)Tables).Add(item);
        }

        public JDatabase()
        {
            Valid = true;
        }   

        public bool CheckAllTablesValid(ValueCheckMethod vcm = ValueCheckMethod.OneInvalidCheck)
        {
            foreach (JTable jt in Tables)
                if (!CheckTableValid(jt, vcm))
                    return false;
            return true;
        }

        public bool CheckTableValid(JTable jt, ValueCheckMethod vcm = ValueCheckMethod.OneInvalidCheck)
        {            
            Valid = true;            
            if (!jt.CehckValid(vcm))
            { 
                Valid = false;
                if (vcm == ValueCheckMethod.OneInvalidCheck)
                    return false;
            }

            if (vcm == ValueCheckMethod.NoCheck)
                return Valid;

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
                        if (jt[j][i] != null && !fkTable.Lines.Exists(m => m.Values[fkColumnIndex].CompareTo(jt[j][i], jt.Columns[i].Type) == 0))
                        {
                            jt.AddInvalidRecord(j, i, JValueInvalidReasons.FoeignKeyValueNotExists);
                            jt.Valid = Valid = false;                            
                            if(vcm == ValueCheckMethod.OneInvalidCheck)
                                return false;
                        }
                    }
                }
            }
            return Valid;
        }

        public void Clear()
        {
            ((IList<JTable>)Tables).Clear();
        }

        public bool Contains(JTable item)
        {
            return ((IList<JTable>)Tables).Contains(item);
        }

        public void CopyTo(JTable[] array, int arrayIndex)
        {
            ((IList<JTable>)Tables).CopyTo(array, arrayIndex);
        }

        public IEnumerator<JTable> GetEnumerator()
        {
            return ((IList<JTable>)Tables).GetEnumerator();
        }

        public int IndexOf(JTable item)
        {
            return ((IList<JTable>)Tables).IndexOf(item);
        }

        public void Insert(int index, JTable item)
        {
            ((IList<JTable>)Tables).Insert(index, item);
        }

        public bool Remove(JTable item)
        {
            return ((IList<JTable>)Tables).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<JTable>)Tables).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<JTable>)Tables).GetEnumerator();
        }
    }
}
