using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public enum JValueInvalidReasons
    {
        None = 0,
        NullValue,
        WrongType,
        LessThenMinValue,
        GreaterThenMaxValue,
        LongerThenMaxLength,
        RegularExpressionNotMatch,
        DuplicateKey,
        NotUnique,
        FoeignKeyValueNotExists
    }
}
