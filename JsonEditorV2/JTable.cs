using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text.RegularExpressions;

namespace JsonEditor
{
    public class JTable : IList<JLine>
    {
        public string Name { get; set; }
        public List<JColumn> Columns { get; set; } = new List<JColumn>();
        public List<JLine> Lines { get; set; } = new List<JLine>();

        public bool HasKey { get => Columns.Exists(m => m.IsKey); }
        public bool Loaded { get; set; }
        public bool Changed { get; set; }
        public bool Valid { get; set; }

        public Dictionary<long, Dictionary<int, JValueInvalidReasons>> InvalidRecords { get; set; } = new Dictionary<long, Dictionary<int, JValueInvalidReasons>>();

        public int Count => ((IList<JLine>)Lines).Count;

        public bool IsReadOnly => ((IList<JLine>)Lines).IsReadOnly;

        public JLine this[int index] { get => ((IList<JLine>)Lines)[index]; set => ((IList<JLine>)Lines)[index] = value; }

        public JTable()
            : this("")
        { }

        public JTable(string name, bool isNew = false)
        {
            Name = name;
            Loaded = isNew;
            Valid = true;
        }

        public JTable(string name, object jArray, bool isNew = false)
        {
            Name = name;
            Loaded = isNew;
            LoadJson(jArray, true);
        }

        public List<dynamic> ToListItems()
        {
            List<dynamic> result = new List<object>();
            foreach (JLine jl in Lines)
            {
                var l = new ExpandoObject() as IDictionary<string, object>;
                for (int i = 0; i < Columns.Count; i++)
                {
                    l.Add(Columns[i].Name, jl[i].Value);
                }
                result.Add(l);
            }
            return result;
        }

        /// <summary>
        /// 轉換成一般的資料表
        /// </summary>
        /// <returns>資料表</returns>
        public DataTable ToDataTable()
        {
            DataTable dt = new DataTable(Name);
            for (int i = 0; i < Columns.Count; i++)
                dt.Columns.Add(Columns[i].Name, Columns[i].Type.ToType());

            foreach (JLine jl in Lines)
            {
                List<object> lo = new List<object>();
                for (int i = 0; i < Columns.Count; i++)
                    lo.Add(jl[i].Value);
                dt.LoadDataRow(lo.ToArray(), true);
            }
            return dt;
        }

        /// <summary>
        /// 讀取JFileInfo檔案設定
        /// </summary>
        /// <param name="jfi"></param>
        public void LoadFileInfo(JTableInfo jfi)
        {
            //檢查一下是否正確
            if (jfi == null)
                throw new ArgumentException($"LoadFileInfo:{Name},");
            if (Name != jfi.Name)
                throw new MissingMemberException($"LoadFileInfo:{Name},{jfi.Name}");
            if (Columns.Count != 0)
            {
                if (Columns.Count != jfi.Columns.Count)
                    throw new IndexOutOfRangeException($"LoadFileInfo:{Columns.Count},{jfi.Columns.Count}");
                for (int i = 0; i < jfi.Columns.Count; i++)
                    if (Columns[i].Name != jfi.Columns[i].Name)
                        throw new MissingFieldException($"LoadFileInfo:{Columns[i].Name},{jfi.Columns[i].Name}");
            }
            Columns = jfi.Columns;
        }

        /// <summary>
        /// 擷取JFileInfo檔案內容
        /// </summary>
        /// <returns></returns>
        public JTableInfo GetJTableInfo()
        {
            JTableInfo jfi = new JTableInfo();
            List<JColumn> jcs = new List<JColumn>(Columns);
            jfi.Name = Name;
            jfi.Columns = jcs;
            return jfi;
        }

        /// <summary>
        /// 擷取存檔用的Data Object
        /// </summary>
        /// <returns></returns>
        public object GetJsonObject()
        {
            List<object> result = new List<object>();
            foreach (JLine jl in Lines)
            {
                var line = new ExpandoObject() as IDictionary<string, object>;
                for (int i = 0; i < Columns.Count; i++)
                    line.Add(Columns[i].Name, jl[i].Value == null ? null : jl[i].Value.ToString(Columns[i].Type));
                result.Add(line);
            }
            return result;
        }

        /// <summary>
        /// 讀取Json物件
        /// </summary>
        /// <param name="jArray">JArray</param>
        /// <param name="produceColumnInfo">是否更新欄位</param>
        public void LoadJson(object jArray, bool produceColumnInfo = false)
        {
            bool isFirst = true;
            bool isFirstFirst = true;

            if (jArray == null)
                return;

            JArray jr = jArray as JArray;
            if (jr == null)
                throw new ArgumentNullException();

            if (produceColumnInfo)
                Columns.Clear();

            foreach (JToken jt in jr)
            {
                JLine items = new JLine();
                JObject jo = jt as JObject;
                JColumn jc = null;

                int i = 0;
                foreach (KeyValuePair<string, JToken> kvp in jo)
                {
                    if (produceColumnInfo) //Scan
                    {
                        if (isFirstFirst)
                        {
                            jc = new JColumn(kvp.Key, kvp.Value.ToJType(), kvp.Key == "ID", true,
                                Math.Abs(kvp.Value.ToString().Length / 50) + 1);
                            Columns.Add(jc);
                            isFirstFirst = false;
                        }
                        else if (isFirst)
                        {
                            jc = new JColumn(kvp.Key, kvp.Value.ToJType(), kvp.Key == "ID", false,
                                Math.Abs(kvp.Value.ToString().Length / 50) + 1);
                            Columns.Add(jc);
                        }
                        else
                            jc = Columns[i];

                        if (kvp.Value.Type == JTokenType.Null)
                        {
                            jc.IsNullable = true;
                            items.Add(JValue.FromObject(null));
                        }
                        else
                        {
                            items.Add(JValue.FromObject(kvp.Value.ToString().ParseJType(jc.Type)));
                        }
                    }
                    else //Load
                    {
                        jc = Columns[i];
                        if (kvp.Value.Type == JTokenType.Null)
                            items.Add(JValue.FromObject(null));
                        else
                            items.Add(JValue.FromObject(kvp.Value.ToString().ParseJType(jc.Type)));
                    }
                    i++;
                }
                isFirst = false;
                Lines.Add(items);
            }
            Loaded = true;
            Valid = false;
        }

        protected void AddInvalidRecord(int indexOfLine, int indexOfColumn, JValueInvalidReasons reason)
        {
            if (indexOfLine == -1)
                return;

            if (!InvalidRecords.ContainsKey(indexOfLine))
                InvalidRecords.Add(indexOfLine, new Dictionary<int, JValueInvalidReasons>());

            if (!InvalidRecords[indexOfLine].ContainsKey(indexOfColumn))
                InvalidRecords[indexOfLine].Add(indexOfColumn, reason);
            else
                InvalidRecords[indexOfLine][indexOfColumn] = reason;
        }

        public bool CheckLineValid(int index)
            => CheckLineValid(Lines[index], index);

        //確認某一筆資料符合欄位定義
        public bool CheckLineValid(JLine jl, int indexOfLine = -1)
        {
            for (int i = 0; i < Columns.Count; i++)
            {
                //IsNull
                if (jl[i].Value == null && Columns[i].IsNullable)
                    return true;
                    
                else if (jl[i].Value == null && !Columns[i].IsNullable)
                {   
                    AddInvalidRecord(indexOfLine, i, JValueInvalidReasons.NullValue);                    
                    return false;
                }                    

                //Type
                if (jl[i].Value.GetType() != Columns[i].Type.ToType())
                {
                    AddInvalidRecord(indexOfLine, i, JValueInvalidReasons.WrongType);                    
                    return false;
                }                    

                //MinMax
                if (Columns[i].Type.IsNumber() || Columns[i].Type.IsDateTime())
                {
                    if (!string.IsNullOrEmpty(Columns[i].MinValue) && jl[i].Value.CompareTo(Columns[i].MinValue, Columns[i].Type) == -1)
                    {
                        AddInvalidRecord(indexOfLine, i, JValueInvalidReasons.LessThenMinValue);                        
                        return false;
                    }
                        
                    if (!string.IsNullOrEmpty(Columns[i].MaxValue) && jl[i].Value.CompareTo(Columns[i].MaxValue, Columns[i].Type) == 1)
                    {
                        AddInvalidRecord(indexOfLine, i, JValueInvalidReasons.GreaterThenMaxValue);                        
                        return false;
                    }                        
                }

                //MaxLength
                if (Columns[i].TextMaxLength != 0 &&
                    jl[i].Value.ToString(Columns[i].Type).Length > Columns[i].TextMaxLength)
                {
                    AddInvalidRecord(indexOfLine, i, JValueInvalidReasons.LongerThenMaxLength);                    
                    return false;
                }                    

                //Regex
                if (!string.IsNullOrEmpty(Columns[i].Regex) &&
                    !Regex.IsMatch(jl[i].Value.ToString(Columns[i].Type), Columns[i].Regex))
                {
                    AddInvalidRecord(indexOfLine, i, JValueInvalidReasons.RegularExpressionNotMatch);                    
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// 確認所有資料符合欄位定義
        /// </summary>
        /// <param name="quickCheck">快速檢查(遇到單欄錯誤即跳出)</param>
        /// <returns></returns>
        public bool CehckValid(bool quickCheck = false)
        {
            Valid = true;

            //刪除Valid資料
            InvalidRecords.Clear();

            //Key
            List<int> keyIndex = new List<int>();
            for (int i = 0; i < Columns.Count; i++)
                if (Columns[i].IsKey)
                    keyIndex.Add(i);

            //從最底端開始查起
            Dictionary<string, int> keyCheckSet = new Dictionary<string, int>();
            string checkString;
            for (int i = Lines.Count - 1; i > -1; i--)
            {
                if (!CheckLineValid(i))
                {
                    Valid = false;
                    if (quickCheck)
                        return false;
                }
                    

                if (keyIndex.Count != 0)
                {
                    checkString = "";
                    for (int j = 0; j < keyIndex.Count; j++)
                        if (Lines[i][keyIndex[j]].Value != null)
                            checkString = string.Concat(checkString, Lines[i][keyIndex[j]].Value.ToString(Columns[keyIndex[j]].Type));
                    if (keyCheckSet.ContainsKey(checkString))
                    {
                        for (int j = 0; j < keyIndex.Count; j++)
                        {
                            AddInvalidRecord(i, keyIndex[j], JValueInvalidReasons.DuplicateKey);
                            AddInvalidRecord(keyCheckSet[checkString], keyIndex[j], JValueInvalidReasons.DuplicateKey);
                        }   
                        Valid = false;
                        if (quickCheck)
                            return false;
                    }
                    else
                        keyCheckSet.Add(checkString, i);
                }
            }
            
            //Unique
            for(int i = 0; i < Columns.Count; i++)
            {
                if(Columns[i].IsUnique)
                {
                    Dictionary<object, int> uniqueCheckDictionary = new Dictionary<object, int>();
                    for (int j = Lines.Count - 1; j > -1; j--)
                    {
                        if (uniqueCheckDictionary.ContainsKey(Lines[j][i].Value))
                        {
                            AddInvalidRecord(j, i, JValueInvalidReasons.NotUnique);
                            AddInvalidRecord(uniqueCheckDictionary[Lines[j][i].Value], i, JValueInvalidReasons.NotUnique);
                            Valid = false;
                            if (quickCheck)
                                return false;
                        }
                        else
                            uniqueCheckDictionary.Add(Lines[j][i].Value, j);
                    }
                }
            }
            return Valid;
        }

        public int IndexOf(JLine item)
        {
            return ((IList<JLine>)Lines).IndexOf(item);
        }

        public void Insert(int index, JLine item)
        {
            ((IList<JLine>)Lines).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<JLine>)Lines).RemoveAt(index);
        }

        public void Add(JLine item)
        {
            ((IList<JLine>)Lines).Add(item);
        }

        public void Clear()
        {
            ((IList<JLine>)Lines).Clear();
        }

        public bool Contains(JLine item)
        {
            return ((IList<JLine>)Lines).Contains(item);
        }

        public void CopyTo(JLine[] array, int arrayIndex)
        {
            ((IList<JLine>)Lines).CopyTo(array, arrayIndex);
        }

        public bool Remove(JLine item)
        {
            return ((IList<JLine>)Lines).Remove(item);
        }

        public IEnumerator<JLine> GetEnumerator()
        {
            return ((IList<JLine>)Lines).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<JLine>)Lines).GetEnumerator();
        }
    }
}
