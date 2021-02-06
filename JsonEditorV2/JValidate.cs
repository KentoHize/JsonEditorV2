using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public static class JValidate
    {
        public const string FileNameRegex = @"^[\w\-. ]+$";
        public const string ColumnNameRegex = @"^[\w][\w\-]{0,49}$";
        public const string DatabaseRegex = @"^[\w][\w\-. ]{0,49}$";
    }
}
