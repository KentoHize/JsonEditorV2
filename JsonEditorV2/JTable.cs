using Newtonsoft.Json.Linq;
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

        public Dictionary<int, Dictionary<int, JValueInvalidReasons>> InvalidRecords { get; set; } = new Dictionary<int, Dictionary<int, JValueInvalidReasons>>();

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

        #region Type Upgrade Logic
        // Type Family

        // None Boolean

        // None Byte Integer Long Decimal
        // None Byte Integer Long Double

        // None Time String
        // None Date DateTime String        
        // None Uri String
        // None Guid String
        // None String

        // None Object
        // None Array

        /// <summary>
        /// 與欄位做型別比對，欄位型別不變或升級傳回true，型別轉換失敗傳回false
        /// </summary>
        /// <param name="jt">待檢查型別</param>
        /// <param name="jc">欄位</param>
        /// <returns>型別測試成功</returns>
        private bool ParseTypeToColumn(JType jt, JColumn jc)
        {
            if (jc.Type == jt)
                return true;
            else if (jt == JType.None)
                return true;

            switch (jc.Type)
            {
                case JType.None:
                    jc.Type = jt;
                    return true;
                case JType.Boolean:
                    return false;
                case JType.Byte:
                    if (jt == JType.Integer || jt == JType.Long ||
                        jt == JType.Decimal || jt == JType.Double)
                    {
                        jc.Type = jt;
                        return true;
                    }
                    else
                        return false;
                case JType.Integer:
                    if (jt == JType.Byte)
                        return true;
                    else if (jt == JType.Long || jt == JType.Decimal ||
                             jt == JType.Double)
                    {
                        jc.Type = jt;
                        return true;
                    }
                    else
                        return false;
                case JType.Long:
                    if (jt == JType.Byte || jt == JType.Integer)
                        return true;
                    else if (jt == JType.Decimal || jt == JType.Double)
                    {
                        jc.Type = jt;
                        return true;
                    }
                    else
                        return false;
                case JType.Decimal:
                case JType.Double:
                    if (jt == JType.Byte || jt == JType.Integer ||
                        jt == JType.Long)
                        return true;
                    else
                        return false;
                case JType.Time:
                    if (jt.IsStringFamily())
                    {
                        jc.Type = JType.String;
                        return true;
                    }
                    else
                        return false;
                case JType.Date:
                    if (jt == JType.DateTime)
                    {
                        jc.Type = jt;
                        return true;
                    }
                    else if (jt.IsStringFamily())
                    {
                        jc.Type = JType.String;
                        return true;
                    }
                    else
                        return false;
                case JType.DateTime:
                case JType.Uri:
                case JType.Guid:
                    if (jt.IsStringFamily())
                    {
                        jc.Type = JType.String;
                        return true;
                    }
                    else
                        return false;
                default:
                    return false;
            }
        }
        #endregion

        private string ParseJToken(string key, JToken jToken)
        {
            JColumn jc = Columns.Find(m => m.Name == key);

            if (jc == null)
            {
                jc = new JColumn(key, JType.None);
                Columns.Add(jc);
            }

            if (jToken.Type == JTokenType.Null)
            {
                jc.IsNullable = true;
                return null;
            }
            else
            {
                JType jType = jToken.ToJType();
                if (!ParseTypeToColumn(jType, jc))
                    throw new JFileInvalidException(JFileInvalidReasons.ChildColumnTypeVary);
                return jToken.ToString();
            }
        }

        /// <summary>
        /// 掃描Json物件
        /// </summary>
        /// <param name="jArray">物件化的Json String(從JsonConvert傳來)</param>
        public void ScanJson(object jArray, int numberOfRowsMaxValue = 20)
        {
            Lines.Clear();
            Columns.Clear();

            JArray jr = jArray as JArray;

            if (jr == null)
                throw new JFileInvalidException(JFileInvalidReasons.RootElementNotArray);

            //掃描jArray
            List<Dictionary<string, string>> scannedResult = new List<Dictionary<string, string>>();
            for (int i = 0; i < jr.Count; i++)
            {
                JObject jo = jr[i] as JObject;
                scannedResult.Add(new Dictionary<string, string>());

                if (jo == null)
                    throw new JFileInvalidException(JFileInvalidReasons.ChildElementNotObject, i);

                foreach (KeyValuePair<string, JToken> kvp in jo)
                {
                    try
                    {
                        scannedResult[i].Add(kvp.Key, ParseJToken(kvp.Key, kvp.Value));
                    }
                    catch (JFileInvalidException ex)
                    {
                        ex.LineIndex = i;
                        throw ex;
                    }
                }
            }

            Valid = true;

            //long 有可能不夠大 Warning
            Dictionary<int, long> charsCountDivide10 = new Dictionary<int, long>();

            //設定Column
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].Type == JType.None)
                    Columns[i].Type = JType.String;
                if (Columns[i].Name == "ID" && !Columns[i].IsNullable)
                {
                    Columns[i].IsKey = true;
                    Columns[i].Display = true;
                    Valid = false;
                }
                Columns[i].Display = i == 0;

                if (Columns[i].Type == JType.String)
                    charsCountDivide10.Add(i, 0);
            }

            //放入Table
            foreach (Dictionary<string, string> line in scannedResult)
            {
                JLine jl = new JLine();
                for (int i = 0; i < Columns.Count; i++)
                {
                    if (line.ContainsKey(Columns[i].Name))
                    {
                        jl.Add(JValue.FromObject(line[Columns[i].Name].ParseJType(Columns[i].Type)));
                        if (Columns[i].Type == JType.String)
                            if (line[Columns[i].Name] != null)
                                charsCountDivide10[i] += line[Columns[i].Name].Length / 10;
                    }
                    else
                    {
                        Columns[i].IsNullable = true;
                        jl.Add(JValue.FromObject(null));
                    }
                }
                Lines.Add(jl);
            }

            //最後設定
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].Type == JType.String)
                {
                    //設定行長依照字數平均值
                    int avageOfLines = (int)(charsCountDivide10[i] / Lines.Count);
                    if (avageOfLines > 20)
                        avageOfLines = (avageOfLines + 20) / 3;
                    else if (avageOfLines > 10)
                        avageOfLines = (avageOfLines + 10) / 2;
                    Columns[i].NumberOfRows = avageOfLines + 1 > numberOfRowsMaxValue ? numberOfRowsMaxValue : avageOfLines + 1;
                }
            }
            Loaded = true;
        }

        /// <summary>
        /// 讀取Json物件
        /// </summary>
        /// <param name="jArray">物件化的Json String(從JsonConvert傳來)</param>
        public void LoadJson(object jArray)
        {
            Lines.Clear();

            JArray jr = jArray as JArray;

            if (jr == null)
                throw new JFileInvalidException(JFileInvalidReasons.RootElementNotArray);

            for (int i = 0; i < jr.Count; i++)
            {
                JLine jl = new JLine();
                JObject jo = jr[i] as JObject;

                if (jo == null)
                    throw new JFileInvalidException(JFileInvalidReasons.ChildElementNotObject, i);

                if (jo.Count != Columns.Count)
                    throw new JFileInvalidException(JFileInvalidReasons.ChildColumnCountVary, i);

                int j = 0;
                foreach (KeyValuePair<string, JToken> kvp in jo)
                {
                    if (Columns[j].Name != kvp.Key)
                        if (Columns.Find(m => m.Name == kvp.Key) != null)
                            throw new JFileInvalidException(JFileInvalidReasons.ChildColumnOrderVary, i);
                        else
                            throw new JFileInvalidException(JFileInvalidReasons.ChildColumnNameVary, i);

                    if (kvp.Value.Type == JTokenType.Null)
                        jl.Add(JValue.FromObject(null));
                    else if (kvp.Value.ToString().TryParseJType(Columns[j].Type, out object parsedObj))
                    {
                        jl.Add(JValue.FromObject(parsedObj));
                        if (!Changed)
                            Changed = kvp.Value.ToString() != parsedObj.ToString(Columns[j].Type);
                    }
                    else
                    {
                        //資料損毀通知
                        jl.Add(JValue.FromObject(parsedObj));
                        Changed = true;
                    }
                    j++;
                }

                Lines.Add(jl);
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
                if (!string.IsNullOrEmpty(Columns[i].RegularExpression) &&
                    !Regex.IsMatch(jl[i].Value.ToString(Columns[i].Type), Columns[i].RegularExpression))
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
            for (int i = 0; i < Columns.Count; i++)
            {
                if (Columns[i].IsUnique)
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
