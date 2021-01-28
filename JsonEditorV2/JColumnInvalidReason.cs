using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public enum JColumnInvalidReason
    {
        None = 0,
        IllegalName,        
        NumberOfRowsIsNegativeOrTooBig,
        MaxLengthIsNegative,
        IsKeyAndIsNullable,
        ForeignKeyTableNotExist,
        ForeignKeyColumnNotExist,
        ForeignKeyTableMissing,
        ForeignKeyColumnMissing,
        ForeignKeyColumnTypeNotMatch,
        NumberOrDateTimeHasRegularExpression,
        NotNumberOrDateTimeHaveMinValue,
        NotNumberOrDateTimeHaveMaxValue,
        MinValueTypeCastFailed,
        MinValueLessThanTypeMinValue,
        MaxValueTypeCastFailed,
        MaxValueGreaterThanTypeMaxValue,
        MinValueGreaterThanMaxValue,
        IllegalRegularExpression
    }
}
