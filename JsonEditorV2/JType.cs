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
        JSONObject
    }

    public static class JTypeExtentions
    {   

        public static object InitialValue(this JType type)
        {
            switch (type)
            {
                case JType.Boolean:
                    return false;
                case JType.Byte:
                    return 0;
                case JType.Date:
                case JType.Time:
                case JType.DateTime:
                    return new DateTime();
                case JType.Double:
                    return 0.0;
                case JType.Guid:
                    return Guid.Empty;
                case JType.Integer:
                case JType.Long:
                case JType.Decimal:
                    return 0;
                case JType.None:
                case JType.JSONObject:
                    return null;
                case JType.TimeSpan:
                    return new TimeSpan();
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
        /// 以JType為目標轉換值的型態，空值設為初始值，否則引發InvalidCast錯誤訊息
        /// </summary>
        /// <param name="value">輸入值</param>
        /// <param name="type">JType</param>
        /// <returns>輸出值</returns>
        public static object ParseJType(this object value, JType type)
        {
            if (value == null || value.ToString() == new object().ToString())
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
                    break;                
                case JType.TimeSpan:
                    if (TimeSpan.TryParse(value.ToString(), out TimeSpan r9))
                        return r9;
                    break;
                case JType.Uri:
                    if (Uri.TryCreate(value.ToString(), UriKind.RelativeOrAbsolute, out Uri r10))
                        return r10;
                    break;
                case JType.Decimal:
                    if (decimal.TryParse(value.ToString(), out decimal r11))
                        return r11;
                    break;
                case JType.JSONObject:
                    return value.ToString();
                case JType.String:
                    return value.ToString();                    
                default:
                    return value.ToString();
            }            

            throw new InvalidCastException();
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
                    return JType.JSONObject;
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
                    return JType.DateTime;
                case JTokenType.TimeSpan:
                    return JType.TimeSpan;
                case JTokenType.Uri:
                    return JType.Uri;
                default:
                    return JType.JSONObject;
            }
        }        
    }
}
