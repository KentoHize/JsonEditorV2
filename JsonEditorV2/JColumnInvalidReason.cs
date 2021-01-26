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
        MaxLengthIsNegativeOrTooBig,
        IsKeyAndIsNullable,
        ForeignKeyTableNotExist,
        ForeignKeyColumnNotExist,
        ForeignKeyTableMissing,
        ForeignKeyColumnMissing,
        ForeignKeyColumnTypeNotMatch,
        NumberOrDateTimeHaveRegularExpression,
        NotNumberOrDateTimeHaveMinValue,
        NotNumberOrDateTimeHaveMaxValue,
        MinValueLessThanTypeMinValue,
        MaxValueGreaterThanTypeMaxValue,
        MinValueGreaterThanMaxValue,
        IllegalRegularExpression
    }
}
