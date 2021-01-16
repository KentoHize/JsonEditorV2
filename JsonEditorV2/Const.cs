using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditorV2
{
    public static class Const
    {
        public const string FileNameRegex = @"^[\w\-. ]+$";
        public const string ColumnNameRegex = @"^[A-Za-z_][\w\-]{0,49}$";
        public const string NumberOfRowsRegex = @"^\d{1,2}$";
    }
}
