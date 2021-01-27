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
        public static void OpenJFIFileFailed(string filePath, Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_LOAD_JFI_FILE_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, filePath);
        }

        public static void OpenJsonFileFailed(string filePath, Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_LOAD_JSON_FILE_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, filePath);
        }

        //JFI, Table File 
        public static void JsonConvertDeserializeObjectFailed(string fileName, Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_JSONCONVERT_DESERIALIZE_OBJECT_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, fileName, ex.Message);
        }

        public static void JTableLoadJsonFailed(JTable jt, Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_TABLE_LOAD_JSON_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, jt.Name);
        }

        public static bool HandleException(Exception ex, string content = null, string title = null)
        {
            if (string.IsNullOrEmpty(content))
                content = Res.JE_ERR_DEFAULT_MESSAGE;
            if (string.IsNullOrEmpty(title))
                title = Res.JE_ERR_DEFAULT_TITLE;

            //JFI檢查失敗處理
            if (ex.Message.Contains("LoadFileInfo"))
            {
                string p1 = ex.Message.Substring(13).Split(',')[0];
                string p2 = ex.Message.Substring(13).Split(',')[1];
                if (ex is ArgumentNullException)
                    content = Res.JE_ERR_JFI_IS_EMPTY;
                else if (ex is MissingMemberException)
                    content = string.Format(Res.JE_ERR_TABLE_NAME_UNMATCH, p1, p2);
                else if (ex is IndexOutOfRangeException)
                    content = string.Format(Res.JE_ERR_COLUMN_COUNT_UNMATCH, p1, p2);
                else if (ex is MissingFieldException)
                    content = string.Format(Res.JE_ERR_COLUMN_NAME_UNMATCH, p1, p2);
            }

            RabbitCouriers.SentErrorMessage(string.Format(content, ex.Message), title);
            return false;
        }

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
