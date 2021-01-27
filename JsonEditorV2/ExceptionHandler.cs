using Aritiafel.Organizations;
using JsonEditor;
using JsonEditorV2.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditorV2
{
    public static class ExceptionHandler
    {
        public static void SentTableInvalidMessage(JTable jt)
        {
            var kvp1 = jt.InvalidRecords.First();
            var kvp2 = jt.InvalidRecords.First().Value.First();

            StringBuilder result = new StringBuilder();
            result.AppendFormat(Res.JE_ERR_TABLE_INVALID_MESSAGE_PARTIAL,
                jt.Name, kvp1.Key + 1, jt.Columns[kvp2.Key].Name);

            //To Do

            switch (kvp2.Value)
            {
                case JValueInvalidReasons.NullValue:
                    result.AppendFormat(Res.JE_VAL_NOT_NULLABLE, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                case JValueInvalidReasons.WrongType:
                    result.AppendFormat(Res.JE_VAL_INVALID_CAST, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                case JValueInvalidReasons.LessThenMinValue:
                    result.AppendFormat(Res.JE_VAL_LESS_THEN_MIN_VALUE, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                case JValueInvalidReasons.GreaterThenMaxValue:
                    result.AppendFormat(Res.JE_VAL_GREATER_THEN_MAX_VALUE, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                case JValueInvalidReasons.LongerThenMaxLength:
                    result.AppendFormat(Res.JE_VAL_TEXT_MAXIMUM_LENGTH_OVER, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                case JValueInvalidReasons.RegularExpressionNotMatch:
                    result.AppendFormat(Res.JE_VAL_REGEX_IS_NOT_MATCH, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                case JValueInvalidReasons.NotUnique:
                    result.AppendFormat(Res.JE_VAL_VALUE_IS_NOT_UNIQUE, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                case JValueInvalidReasons.DuplicateKey:
                    result.AppendFormat(Res.JE_VAL_DUPLICATE_KEY, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                default:
                    result.Append(Res.JE_ERR_UNKNOWN_ERROR);
                    break;
            }
            RabbitCouriers.SentErrorMessage(result.ToString(), Res.JE_TMI_SAVE_JSON_FILES);

            
        }
    }
}
