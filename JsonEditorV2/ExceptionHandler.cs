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
        public static void JFIFileIsInvalid(JFilesInfo JFI)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat(Res.JE_VAL_JFI_FILE_INVALID_MESSAGE_PARTIAL,
                JFI.InvalidFileName, JFI.InvalidColumnName);

            switch (JFI.InvalidReason)
            {
                case JColumnInvalidReasons.IllegalRegularExpression:
                    result.AppendFormat(Res.JE_VAL_COLUMN_ILLEGAL_REGULAR_EXPRESSION);
                    break;
                case JColumnInvalidReasons.IllegalName:
                    result.AppendFormat(Res.JE_VAL_COLUMN_ILLEGAL_NAME);
                    break;
                case JColumnInvalidReasons.IsKeyAndIsNullable:
                    result.AppendFormat(Res.JE_VAL_COLUMN_IS_KEY_AND_IS_NULL);
                    break;
                case JColumnInvalidReasons.ForeignKeyColumnMissing:
                    result.AppendFormat(Res.JE_VAL_COLUMN_FK_COLUMN_MISSING);
                    break;
                case JColumnInvalidReasons.ForeignKeyTableMissing:
                    result.AppendFormat(Res.JE_VAL_COLUMN_FK_TABLE_MISSING);
                    break;
                case JColumnInvalidReasons.NumberOfRowsIsNegativeOrTooBig:
                    result.AppendFormat(Res.JE_VAL_COLUMN_NUMBER_OF_ROWS_IS_NEGATIVE_OR_TOO_BIG);
                    break;
                case JColumnInvalidReasons.NumberOrDateTimeHasRegularExpression:
                    result.AppendFormat(Res.JE_VAL_COLUMN_NUMBER_OR_DATETIME_HAS_REGULAR_EXPRESSION);
                    break;
                case JColumnInvalidReasons.NotNumberOrDateTimeHaveMinValue:
                    result.AppendFormat(Res.JE_VAL_COLUMN_NOT_NUMBER_OR_DATETIME_HAVE_MIN_VALUE);
                    break;
                case JColumnInvalidReasons.NotNumberOrDateTimeHaveMaxValue:
                    result.AppendFormat(Res.JE_VAL_COLUMN_NOT_NUMBER_OR_DATETIME_HAVE_MAX_VALUE);
                    break;
                case JColumnInvalidReasons.MinValueTypeCastFailed:
                    result.AppendFormat(Res.JE_VAL_COLUMN_MIN_VALUE_CAST_FAILED, 
                        Var.JFI.TablesInfo.Find(m => m.Name == Var.JFI.InvalidFileName)
                        .Columns.Find(m => m.Name == Var.JFI.InvalidColumnName).MinValue);
                    break;
                case JColumnInvalidReasons.MaxValueTypeCastFailed:
                    result.AppendFormat(Res.JE_VAL_COLUMN_MAX_VALUE_CAST_FAILED,
                        Var.JFI.TablesInfo.Find(m => m.Name == Var.JFI.InvalidFileName)
                        .Columns.Find(m => m.Name == Var.JFI.InvalidColumnName).MaxValue);
                    break;
                case JColumnInvalidReasons.MinValueGreaterThanMaxValue:
                    result.AppendFormat(Res.JE_VAL_COLUMN_MIN_VALUE_GREATER_THAN_MAX_VALUE,
                        Var.JFI.TablesInfo.Find(m => m.Name == Var.JFI.InvalidFileName)
                        .Columns.Find(m => m.Name == Var.JFI.InvalidColumnName).MinValue,
                        Var.JFI.TablesInfo.Find(m => m.Name == Var.JFI.InvalidFileName)
                        .Columns.Find(m => m.Name == Var.JFI.InvalidColumnName).MaxValue);
                    break;
                case JColumnInvalidReasons.MaxLengthIsNegative:
                    result.AppendFormat(Res.JE_VAL_COLUMN_MAX_LEGNTH_IS_NEGATIVE);
                    break;
                case JColumnInvalidReasons.ForeignKeyTableNotExist:
                    result.AppendFormat(Res.JE_VAL_COLUMN_FK_TABLE_NOT_EXIST);
                    break;
                case JColumnInvalidReasons.ForeignKeyColumnNotExist:
                    result.AppendFormat(Res.JE_VAL_COLUMN_FK_COLUMN_NOT_EXIST);
                    break;
                case JColumnInvalidReasons.ForeignKeyColumnTypeNotMatch:
                    result.AppendFormat(Res.JE_VAL_COLUMN_FK_COLUMN_TYPE_NOT_MATCH);
                    break;
            }
            RabbitCouriers.SentErrorMessage(result.ToString(), Res.JE_TMI_LOAD_JSON_FILES);
        }

        public static void OpenJFIFileFailed(string filePath, Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_LOAD_JFI_FILE_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, filePath);
        }

        public static void OpenJsonFileFailed(string filePath, Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_LOAD_JSON_FILE_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, filePath);
        }

        public static void JsonConvertDeserializeObjectFailed(string fileName, Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_JSONCONVERT_DESERIALIZE_OBJECT_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, fileName, ex.Message);
        }

        public static void JTableLoadJsonFailed(JTable jt, Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_TABLE_LOAD_JSON_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, jt.Name);
        }

        public static void JsonConvertDeserializeJFIFailed(Exception ex)
        {
            RabbitCouriers.SentErrorMessageByResource("JE_ERR_JSONCONVERT_DESERIALIZE_JFI_FAILED_DEFAULT", Res.JE_ERR_DEFAULT_TITLE, ex.Message);
        }



        public static bool HandleException(Exception ex, string content = null, string title = null)
        {
            if (string.IsNullOrEmpty(content))
                content = Res.JE_ERR_DEFAULT_MESSAGE;
            if (string.IsNullOrEmpty(title))
                title = Res.JE_ERR_DEFAULT_TITLE;

            //JFI檢查失敗處理 (待註解)
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
                //To Do
                default:
                    result.Append(Res.JE_ERR_UNKNOWN_ERROR);
                    break;
            }
            RabbitCouriers.SentErrorMessage(result.ToString(), Res.JE_TMI_SAVE_JSON_FILES);
        }
    }
}
