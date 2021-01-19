using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

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
        }

        public JTable(string name, object jArray, bool isNew = false)
        {
            Name = name;
            Loaded = isNew;
            LoadJson(jArray, true);
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
                    line.Add(Columns[i].Name, jl[i].Value);
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

                foreach (KeyValuePair<string, JToken> kvp in jo)
                {
                    if (produceColumnInfo)
                    {
                        if (isFirstFirst)
                        {
                            JColumn jc = new JColumn(kvp.Key, kvp.Value.ToJType(), kvp.Key == "ID", true,
                                Math.Abs(kvp.Value.ToString().Length / 50) + 1);
                            Columns.Add(jc);
                            isFirstFirst = false;
                        }
                        else if (isFirst)
                            Columns.Add(new JColumn(kvp.Key, kvp.Value.ToJType(), kvp.Key == "ID", false,
                                Math.Abs(kvp.Value.ToString().Length / 50) + 1));
                    }

                    switch (kvp.Value.Type)
                    {
                        case JTokenType.Integer:
                            items.Add(JValue.FromObject(Convert.ToInt64(kvp.Value)));
                            break;
                        case JTokenType.Float:
                            items.Add(JValue.FromObject(Convert.ToDouble(kvp.Value)));
                            break;
                        case JTokenType.Guid:
                            items.Add(JValue.FromObject(Guid.Parse(kvp.Value.ToString())));
                            break;
                        case JTokenType.Null:
                            items.Add(JValue.FromObject(null));
                            break;
                        case JTokenType.Boolean:
                            items.Add(JValue.FromObject(Convert.ToBoolean(kvp.Value)));
                            break;
                        case JTokenType.Date:
                            items.Add(JValue.FromObject(DateTime.Parse(kvp.Value.ToString())));
                            break;
                        default:
                            items.Add(JValue.FromObject(kvp.Value.ToString()));
                            break;
                    }
                }

                //新增加值
                while (items.Count < Columns.Count)
                    items.Add(new JValue());

                isFirst = false;
                Lines.Add(items);
            }
            Loaded = true;
        }


        /// <summary>
        /// 用欄位資訊確認末端值的型別並進行轉換
        /// </summary>
        /// <param name="inputValue">輸入值</param>
        /// <param name="columnName">欄位名</param>
        /// <returns>轉換後的值</returns>
        //public object ParseValue(object inputValue, string columnName)
        //{
        //    JType jt = Columns.Find(m => m.Name == columnName).Type;
        //    switch (jt)
        //    {
        //        case JType.Boolean:
        //            return Convert.ToBoolean(inputValue);
        //        case JType.Long:
        //            return Convert.ToInt64(inputValue);
        //        case JType.Integer:
        //            return Convert.ToInt32(inputValue);
        //        case JType.Double:
        //            return Convert.ToDouble(inputValue);
        //        case JType.Byte:
        //            return Convert.ToByte(inputValue);
        //        case JType.Date:
        //            return Convert.ToDateTime(inputValue).ToShortDateString();
        //        case JType.Time:
        //            return Convert.ToDateTime(inputValue).TimeOfDay.ToString();
        //        case JType.DateTime:
        //            return Convert.ToDateTime(inputValue);
        //        case JType.String:
        //            return Convert.ToString(inputValue);
        //        case JType.Guid:
        //            return Guid.Parse(inputValue.ToString());
        //        default:
        //            return Convert.ChangeType(inputValue, Type.GetType(jt.ToString()));
        //    }
        //}

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
