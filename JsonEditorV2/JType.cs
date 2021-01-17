using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Boolean,        
        Date,
        Time,
        DateTime,
        Guid,
        Uri,
        TimeSpan,
        Decimal,        
        Undefied
    }

    public static class Extentions
    {
        /// <summary>
        /// 以JType為目標轉換值的型態，失敗時設為初始值(無錯誤訊息)
        /// </summary>
        /// <param name="value">輸入值</param>
        /// <param name="type">J型別</param>
        /// <returns>輸出值</returns>
        public static object ParseJType(this object value, JType type)
        {  
            switch(type)
            {
                case JType.Boolean:
                    if (bool.TryParse(value.ToString(), out bool r1))
                        return r1;
                    else
                        return false;                    
                case JType.Byte:
                    if (byte.TryParse(value.ToString(), out byte r2))
                        return r2;
                    else
                        return 0;
                case JType.Date:
                    if (DateTime.TryParse(value.ToString(), out DateTime r3) &&
                        r3.TimeOfDay.TotalSeconds == 0)
                            return r3;
                    else
                        return new DateTime();
                case JType.Time:
                case JType.DateTime:
                    if (DateTime.TryParse(value.ToString(), out DateTime r4))
                        return r4;
                    else
                        return new DateTime();
                case JType.Double:
                    if (double.TryParse(value.ToString(), out double r5))
                        return r5;
                    else
                        return 0.0;
                case JType.Guid:
                    if (Guid.TryParse(value.ToString(), out Guid r6))
                        return r6;
                    else
                        return Guid.Empty;
                case JType.Integer:
                    if (int.TryParse(value.ToString(), out int r7))
                        return r7;
                    else
                        return 0;
                case JType.Long:
                    if (long.TryParse(value.ToString(), out long r8))
                        return r8;
                    else
                        return 0;
                case JType.None:
                case JType.Undefied:
                    return value;
                case JType.TimeSpan:
                    if (TimeSpan.TryParse(value.ToString(), out TimeSpan r9))
                        return r9;
                    else
                        return new TimeSpan();
                case JType.Uri:
                    if (Uri.TryCreate(value.ToString(), UriKind.RelativeOrAbsolute, out Uri r10))
                        return r10;
                    else
                        return null;
                case JType.Decimal:
                    if (decimal.TryParse(value.ToString(), out decimal r11))
                        return r11;
                    else
                        return 0;
                case JType.String:
                default:
                    return value.ToString();
            }
        }

        public static JType ToJType(this JsonToken jtn)
        {
            switch (jtn)
            {
                //case JsonToken.StartObject:
                //case JsonToken.StartArray:
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
                    return JType.Undefied;
            }
        }

        public static JType ToJType(this JToken jt)
        {
            switch (jt.Type)
            {
                case JTokenType.None:
                    return JType.None;
                case JTokenType.Integer:
                    //To do 不嚴謹
                    if (jt.ToString().Length > 18)
                        return JType.Decimal;
                    else
                        return JType.Long;
                case JTokenType.Float:
                    //To do
                    return JType.Double;
                case JTokenType.String:
                    if (Guid.TryParse(jt.ToString(), out Guid guid))
                        return JType.Guid;
                    else if (DateTime.TryParse(jt.ToString(), out DateTime datetime))
                    {
                        //To do 不嚴謹
                        if (jt.ToString().Length > 10)
                            return JType.DateTime;
                        else if (datetime.TimeOfDay.TotalSeconds == 0)
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
                    return JType.Date;
                case JTokenType.TimeSpan:
                    return JType.TimeSpan;
                case JTokenType.Uri:
                    return JType.Uri;
                default:
                    return JType.Undefied;
            }
        }        
    }
}
