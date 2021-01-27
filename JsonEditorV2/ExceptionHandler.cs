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
                jt.Name, kvp1.Key, jt.Columns[kvp2.Key].Name);

            //To Do

            switch (kvp2.Value)
            {
                case JValueInvalidReasons.NullValue:
                    result.AppendFormat(Res.JE_VAL_NOT_NULLABLE, jt[kvp1.Key][kvp2.Key].Value ?? "");
                    break;
                default:
                    result.Append(Res.JE_ERR_UNKNOWN_ERROR);
                    break;
            }
            RabbitCouriers.SentErrorMessage(result.ToString(), Res.JE_TMI_SAVE_JSON_FILES);

            
        }
    }
}
