using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JsonEditorV2Tests
{
    public enum ColumnAttributeNames
    {
        ColumnName,
        ColumnType,
        ColumnNumberOfRows,
        ColumnIsKey,
        ColumnIsNullable,
        ColumnDisplay,
        ColumnMinValue,
        ColumnMaxValue,
        ColumnRegex,
        ColumnMaxLength,
        ColumnIsUnique,
        ColumnFKTable,
        ColumnFKColumn,
        ColumnDescription,
        ColumnAutoGenerateKey
    }

    public class ColumnAttributeInfo
    {
        public Type ValueControlType { get; set; }
        public string ValueControlName {get; set;}

        public ColumnAttributeInfo(ColumnAttributeNames attributeName, Type valueControlType)
        {
            ValueControlType = valueControlType;
            if (valueControlType == typeof(TextBox))
                ValueControlName = $"txt{attributeName}";
            else if (valueControlType == typeof(ComboBox))
                ValueControlName = $"cob{attributeName}";
            else if (valueControlType == typeof(CheckBox))
                ValueControlName = $"ckb{attributeName}";
            else
                throw new ArgumentException();
        }
    }

    public static class TestConst
    {
        public static Dictionary<ColumnAttributeNames, ColumnAttributeInfo> ColumnAttributesInfo { get; set; } =
            new Dictionary<ColumnAttributeNames, ColumnAttributeInfo>
            {
              { ColumnAttributeNames.ColumnName, new ColumnAttributeInfo(ColumnAttributeNames.ColumnName, typeof(TextBox)) },
              { ColumnAttributeNames.ColumnType, new ColumnAttributeInfo(ColumnAttributeNames.ColumnType, typeof(ComboBox)) },
              { ColumnAttributeNames.ColumnNumberOfRows, new ColumnAttributeInfo(ColumnAttributeNames.ColumnNumberOfRows, typeof(TextBox)) },
              { ColumnAttributeNames.ColumnIsKey, new ColumnAttributeInfo(ColumnAttributeNames.ColumnIsKey, typeof(CheckBox)) },
              { ColumnAttributeNames.ColumnIsNullable, new ColumnAttributeInfo(ColumnAttributeNames.ColumnIsNullable, typeof(CheckBox)) },
              { ColumnAttributeNames.ColumnDisplay, new ColumnAttributeInfo(ColumnAttributeNames.ColumnDisplay, typeof(CheckBox)) },
              { ColumnAttributeNames.ColumnMinValue, new ColumnAttributeInfo(ColumnAttributeNames.ColumnMinValue, typeof(TextBox)) },
              { ColumnAttributeNames.ColumnMaxValue, new ColumnAttributeInfo(ColumnAttributeNames.ColumnMaxValue, typeof(TextBox)) },
              { ColumnAttributeNames.ColumnRegex, new ColumnAttributeInfo(ColumnAttributeNames.ColumnRegex, typeof(TextBox)) },
              { ColumnAttributeNames.ColumnMaxLength, new ColumnAttributeInfo(ColumnAttributeNames.ColumnMaxLength, typeof(TextBox)) },
              { ColumnAttributeNames.ColumnIsUnique, new ColumnAttributeInfo(ColumnAttributeNames.ColumnIsUnique, typeof(CheckBox)) },
              { ColumnAttributeNames.ColumnFKTable, new ColumnAttributeInfo(ColumnAttributeNames.ColumnFKTable, typeof(ComboBox)) },
              { ColumnAttributeNames.ColumnFKColumn, new ColumnAttributeInfo(ColumnAttributeNames.ColumnFKColumn, typeof(ComboBox)) },
              { ColumnAttributeNames.ColumnDescription, new ColumnAttributeInfo(ColumnAttributeNames.ColumnDescription, typeof(TextBox)) },
              { ColumnAttributeNames.ColumnAutoGenerateKey, new ColumnAttributeInfo(ColumnAttributeNames.ColumnAutoGenerateKey, typeof(CheckBox)) }
            };
    }

}
