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
        //public const string ColumnNameRegex = @"^[\w][\w\-]{0,49}$";
        public const string DatabaseRegex = @"^[\w][\w\-. ]{0,49}$";

        public const string ColumnNameRegex = @"^[A-Za-z_\xC0-\xD6\xD8-\xF6\xF8-\u02FF\u0370-\u037D\u037F-\u1FFF\u200C-\u200D\u2070-\u218F\u2C00-\u2FEF\u2C00-\u2FEF\u3001-\uD7FF\uF900-\uFDCF\uFDF0-\uFFFD][A-Za-z_\xC0-\xD6\xD8-\xF6\xF8-\u02FF\u0370-\u037D\u037F-\u1FFF\u200C-\u200D\u2070-\u218F\u2C00-\u2FEF\u2C00-\u2FEF\u3001-\uD7FF\uF900-\uFDCF\uFDF0-\uFFFD-.\d\xB7\u0300-\u036F\u203F-\u2040]{0,49}$";

        private const string ColumnNameFirstCharRegexString = @"A-Za-z_\xC0-\xD6\xD8-\xF6\xF8-\u{2FF}\u{370}-\u{37D}\u{37F}-\u{1FFF}\u{200C}-\u{200D}\u{2070}-\u{218F}\u{2C00}-\u{2FEF}\u{2C00}-\u{2FEF}\u{3001}-\u{D7FF}\u{F900}-\u{FDCF}\u{FDF0}-\u{FFFD}";

        private const string ColumnNameCharRegexString = @"-.\d\xB7\u{0300}-\u{036F}\u{203F}-\u{2040}";
    }

    //NameStartChar    ::=    ":" | [A-Z] | "_" | [a-z] | [#xC0-#xD6] |
    //    [#xD8-#xF6] | [#xF8-#x2FF] | [#x370-#x37D] |
    //                        [#x37F-#x1FFF] | [#x200C-#x200D] | [#x2070-#x218F] |
    //                        [#x2C00-#x2FEF] | [#x3001-#xD7FF] | [#xF900-#xFDCF] |
    //                        [#xFDF0-#xFFFD] | [#x10000-#xEFFFF] 

    //NameChar::=    NameStartChar | "-" | "." | [0-9] | #xB7 |
    //                        [#x0300-#x036F] | [#x203F-#x2040] 

    //Name::=    NameStartChar(NameChar)* 
}
