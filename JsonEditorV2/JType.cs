using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace JsonEditor
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum JType
    {
        None = 0,
        Byte,
        Integer,
        Long,
        Double,
        String,
        Choice,
        Boolean,
        Date,
        Time,
        DateTime,
        Guid,
        Uri,
        Decimal,
        Object,
        Array
    }

    public static class JTypeExtentions
    {
        /// <summary>
        /// JType轉換成字串
        /// </summary>
        /// <param name="instance">實體</param>
        /// <param name="type">JType</param>
        /// <returns>字串</returns>
        public static string ToString(this object instance, JType type)
        {
            switch(type)
            {
                case JType.Date:
                    return ((DateTime)instance).ToShortDateString();
                case JType.Time:
                    return ((DateTime)instance).Millisecond == 0 ? ((DateTime)instance).ToLongTimeString() : ((DateTime)instance).ToString("HH:mm:ss.ffff");
                default:
                    return instance.ToString();
            }
        }

        /// <summary>
        /// 比較JType物件的大小
        /// </summary>
        /// <param name="instance">值</param>
        /// <param name="type">JType</param>
        /// <returns>0:實體等於比較值 1:實體大於比較值 -1:實體小於比較值</returns>
        public static int CompareTo(this object instance, object value, JType type)
        {
            switch (type)
            {
                case JType.Boolean:
                case JType.Byte:
                    return Convert.ToByte(instance).CompareTo(Convert.ToByte(value));                                    
                case JType.Time:
                    return Convert.ToDateTime(instance).TimeOfDay.CompareTo(Convert.ToDateTime(value).TimeOfDay);
                case JType.Date:
                case JType.DateTime:
                    return Convert.ToDateTime(instance).CompareTo(Convert.ToDateTime(value));
                case JType.Double:
                    return Convert.ToDouble(instance).CompareTo(Convert.ToDouble(value));
                case JType.Integer:
                    return Convert.ToInt32(instance).CompareTo(Convert.ToInt32(value));
                case JType.Long:
                    return Convert.ToInt64(instance).CompareTo(Convert.ToInt64(value));
                case JType.Decimal:
                    return Convert.ToDecimal(instance).CompareTo(Convert.ToDecimal(value));
                case JType.String:
                case JType.Choice:
                case JType.Uri:
                case JType.Guid:
                    if(value != null)
                        return instance.ToString().CompareTo(value.ToString());
                    return 1;
                case JType.None:
                case JType.Object:
                case JType.Array:
                default:
                    throw new InvalidCastException();
            }
        }

        /// <summary>
        /// 取得JType的最小值
        /// </summary>
        /// <param name="type">jtype</param>
        /// <returns>結果</returns>
        public static object GetMinValue(this JType type)
        {
            switch (type)
            {
                case JType.Boolean:
                    return false;
                case JType.Byte:
                    return byte.MinValue;
                case JType.Date:
                case JType.Time:
                case JType.DateTime:
                    return DateTime.MinValue;
                case JType.Double:
                    return double.MinValue;
                case JType.Integer:
                    return int.MinValue;
                case JType.Long:
                    return long.MinValue;
                case JType.Decimal:
                    return decimal.MinValue;
                case JType.String:
                case JType.Choice:
                case JType.Uri:
                case JType.Guid:
                case JType.None:
                case JType.Object:
                case JType.Array:
                    return null;
                default:
                    throw new InvalidCastException();
            }
        }

        /// <summary>
        /// 取得JType的最大值
        /// </summary>
        /// <param name="type">jtype</param>
        /// <returns>結果</returns>
        public static object GetMaxValue(this JType type)
        {
            switch (type)
            {
                case JType.Boolean:
                    return true;
                case JType.Byte:
                    return byte.MaxValue;
                case JType.Date:
                    return DateTime.MaxValue.Date;
                case JType.Time:
                    return DateTime.MinValue.AddDays(1).AddTicks(-1); //可研究
                case JType.DateTime:
                    return DateTime.MaxValue;
                case JType.Double:
                    return double.MaxValue;
                case JType.Integer:
                    return int.MaxValue;
                case JType.Long:
                    return long.MaxValue;
                case JType.Decimal:
                    return decimal.MaxValue;
                case JType.String:
                case JType.Choice:
                case JType.Uri:
                case JType.Guid:
                case JType.None:
                case JType.Object:
                case JType.Array:
                    return null;
                default:
                    throw new InvalidCastException();
            }
        }


        /// <summary>
        /// 確認JType是數字
        /// </summary>
        /// <param name="type">JType</param>
        /// <returns>結果</returns>
        public static bool IsNumber(this JType type)
            => type == JType.Byte || type == JType.Integer ||
            type == JType.Long || type == JType.Decimal ||
            type == JType.Double; /*|| type == JType.TimeSpan;*/

        /// <summary>
        /// 確認JType是日期或時間
        /// </summary>
        /// <param name="type">JType</param>
        /// <returns>結果</returns>
        public static bool IsDateTime(this JType type)
            => type == JType.Date || type == JType.Time || type == JType.DateTime;

        /// <summary>
        /// 確認JType是一種字串
        /// </summary>
        /// <param name="type">JType</param>
        /// <returns>結果</returns>
        public static bool IsStringFamily(this JType type)
            => IsDateTime(type) || type == JType.Guid || type == JType.Uri || type == JType.String || type== JType.Choice;

        /// <summary>
        /// 回傳JType的初始值
        /// </summary>
        /// <param name="type">jtype</param>
        /// <returns>初始值</returns>
        public static object InitialValue(this JType type)
        {   
            switch (type)
            {
                case JType.Boolean:
                    return false;
                case JType.Byte:
                    return (byte)0;
                case JType.Date:
                case JType.Time:
                case JType.DateTime:
                    return new DateTime();
                case JType.Double:
                    return (double)0;
                case JType.Guid:
                    return Guid.Empty;
                case JType.Integer:
                    return (int)0;
                case JType.Long:
                    return (long)0;
                case JType.Decimal:
                    return (decimal)0;
                case JType.None:
                case JType.Object:
                case JType.Choice:
                case JType.Array:
                    return null;
                case JType.Uri:
                    return null;
                case JType.String:
                    return "";
                default:
                    return new object();
            }
        }

        /// <summary>
        /// JType的TryParse版本
        /// </summary>
        /// <param name="value">輸入值</param>
        /// <param name="type">JType</param>
        /// <param name="result">失敗回傳初始值</param>
        /// <returns>是否成功</returns>
        public static bool TryParseJType(this object value, JType type, out object result)
        {
            try
            {
                result = value.ParseJType(type);
                return true;
            }
            catch
            {
                result = new object().ParseJType(type);
                return false;
            }
        }

        /// <summary>
        /// 以JType為目標轉換值的型態，new object設為初始值，否則引發InvalidCast錯誤訊息
        /// </summary>
        /// <param name="value">輸入值</param>
        /// <param name="type">JType</param>
        /// <returns>輸出值</returns>
        public static object ParseJType(this object value, JType type)
        {
            if (value == null)
                return null;
            if (value.ToString() == new object().ToString())
                return type.InitialValue();

            switch (type)
            {
                case JType.Boolean:
                    if (bool.TryParse(value.ToString(), out bool r1))
                        return r1;
                    break;
                case JType.Byte:
                    if (byte.TryParse(value.ToString(), out byte r2))
                        return r2;
                    break;
                case JType.Date:
                    if (DateTime.TryParse(value.ToString(), out DateTime r3) &&
                        r3.TimeOfDay.TotalSeconds == 0)
                        return r3;
                    break;
                case JType.Time:
                case JType.DateTime:
                    if (DateTime.TryParse(value.ToString(), out DateTime r4))
                        return r4;
                    break;
                case JType.Double:
                    if (double.TryParse(value.ToString(), out double r5))
                        return r5;
                    break;
                case JType.Guid:
                    if (Guid.TryParse(value.ToString(), out Guid r6))
                        return r6;
                    break;
                case JType.Integer:
                    if (int.TryParse(value.ToString(), out int r7))
                        return r7;
                    break;
                case JType.Long:
                    if (long.TryParse(value.ToString(), out long r8))
                        return r8;
                    break;
                case JType.None:
                case JType.Array:
                    return null;
                case JType.Uri:
                    if (Uri.TryCreate(value.ToString(), UriKind.RelativeOrAbsolute, out Uri r10))
                        return r10;
                    break;
                case JType.Decimal:
                    if (decimal.TryParse(value.ToString(), out decimal r11))
                        return r11;
                    break;
                case JType.Object:
                    return value.ToString();
                case JType.Choice:
                case JType.String:
                    return value.ToString();
                default:
                    return value.ToString();
            }

            throw new InvalidCastException();
        }

#region TempClosed
        public static JType ToJType(this JsonToken jtn)
        {
            switch (jtn)
            {
                case JsonToken.StartObject:
                    return JType.Object;
                case JsonToken.StartArray:
                    return JType.Array; // Not Valid
                //case JsonToken.StartConstructor:
                //case JsonToken.EndArray:
                //case JsonToken.EndConstructor:
                //case JsonToken.EndObject:
                //case JsonToken.Comment:
                //case JsonToken.PropertyName:
                //case JsonToken.Undefined:
                //    return JType.Undefied;
                case JsonToken.None:
                    return JType.None;
                case JsonToken.Boolean:
                    return JType.Boolean;
                case JsonToken.Date:
                    return JType.Date;
                case JsonToken.Integer:
                    return JType.Long;
                case JsonToken.Raw:
                case JsonToken.Bytes:
                case JsonToken.String:
                case JsonToken.Null:
                    return JType.String;
                case JsonToken.Float:
                    return JType.Double;
                
                default:
                    return JType.None;
            }
        }
        #endregion

        public static Type ToType(this JType type)
        {
            switch (type)
            {
                case JType.Boolean:
                    return typeof(bool);
                case JType.Byte:
                    return typeof(byte);
                case JType.Date:
                case JType.Time:
                case JType.DateTime:
                    return typeof(DateTime);
                case JType.Double:
                    return typeof(double);
                case JType.Guid:
                    return typeof(Guid);
                case JType.Integer:
                    return typeof(int);
                case JType.Long:
                    return typeof(long);
                case JType.Decimal:
                    return typeof(decimal);                    
                case JType.None:
                    return null;
                case JType.Object:
                case JType.Array:
                    return typeof(object);
                case JType.Uri:
                    return typeof(Uri);
                case JType.String:
                case JType.Choice:
                    return typeof(string);
                default:
                    return null;
            }
        }

        public static JType ToJType(this JToken jt)
        {
            switch (jt.Type)
            {
                case JTokenType.None:
                    return JType.None;
                case JTokenType.Boolean:
                    return JType.Boolean;
                case JTokenType.Integer:
                    if (jt.ToString().Length > 28) //decimal.MaxValue.ToString().Length - 1
                        return JType.String;
                    else if (jt.ToString().Length > 18) //long.MaxValue.ToString().Length - 1
                        return JType.Decimal;
                    else if (jt.ToString().Length > 9) //int.MaxValue.ToString().Length - 1
                        return JType.Long;
                    else if (int.TryParse(jt.ToString(), out int r) && (r < 0 || r > byte.MaxValue))
                        return JType.Integer;
                    else
                        return JType.Byte;
                case JTokenType.Float:                    
                    return JType.Double;
                case JTokenType.String:
                    if (Guid.TryParse(jt.ToString(), out Guid guid))
                        return JType.Guid;
                    else if (DateTime.TryParse(jt.ToString(), out DateTime datetime))
                    {   
                        if (jt.ToString().Length > 10)
                            return JType.DateTime;
                        else if (datetime.Date == DateTime.Today  && datetime.TimeOfDay.Ticks != 0)
                            return JType.Time;
                        else if (datetime.TimeOfDay.Ticks == 0)
                            return JType.Date;
                        else
                            return JType.Time;
                    }
                    return JType.String;
                case JTokenType.Null:
                    return JType.String;
                case JTokenType.Guid:
                    return JType.Guid;
                case JTokenType.Date:
                    return JType.DateTime;
                case JTokenType.Uri:
                    return JType.Uri;
                case JTokenType.Object:
                    return JType.Object;
                case JTokenType.Array:
                    return JType.Array;
                default:
                    return JType.Object;
            }
        }
    }
}
