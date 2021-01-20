using JsonEditor;
using System;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public class InputControlSet
    {
        public JColumn JColumn { get; set; }

        public Control ValueControl { get; set; }
        public CheckBox NullCheckBox { get; set; }
        public Label NameLabel { get; set; }

        public InputControlSet(JColumn sourceColumn)
        {
            JColumn = sourceColumn;
        }

        public void DrawControl(Panel pnlMain, int lineIndex)
        {
            if (string.IsNullOrEmpty(JColumn.Name))
                throw new MissingMemberException();

            NameLabel = new Label();
            NameLabel.Name = $"lbl{JColumn.Name}";
            NameLabel.Text = JColumn.Name;
            NameLabel.Left = 10;
            NameLabel.Top = 30 * lineIndex;
            NameLabel.Width = 190;

            pnlMain.Controls.Add(NameLabel);

            ValueControl = GetControlFromJType(JColumn.Type, JColumn.Name);

            if (ValueControl == null)
                return;

            ValueControl.Left = 200;
            ValueControl.Top = 30 * lineIndex;

            if (ValueControl is TextBox)
            {
                ValueControl.Width = 200;
                if(JColumn.NumberOfRows > 1)
                    (ValueControl as TextBox).ScrollBars = ScrollBars.Vertical;
                ValueControl.Height = 30 * JColumn.NumberOfRows - 4;
                NameLabel.Height = 30 * JColumn.NumberOfRows;
            }

            pnlMain.Controls.Add(ValueControl);

            NullCheckBox = new CheckBox { Name = $"ckbNull{JColumn.Name}" };
            NullCheckBox.Text = "Null";
            NullCheckBox.Left = 410;
            NullCheckBox.Top = 30 * lineIndex;
            NullCheckBox.Width = 60;
            NullCheckBox.CheckedChanged += CkbCheckBox_CheckedChanged;

            if (!JColumn.IsNullable)
                NullCheckBox.Enabled = false;

            pnlMain.Controls.Add(NullCheckBox);
        }

        public object GetValue()
        {
            if (NullCheckBox.Checked)
                return null;

            if (ValueControl is TextBox)
                return (ValueControl as TextBox).Text.ParseJType(JColumn.Type);
            else if (ValueControl is CheckBox)
                return (ValueControl as CheckBox).Checked.ParseJType(JColumn.Type);

            throw new Exception();
        }
        
        public void SetValue(object value)
        {
            if (JColumn.IsNullable)
                NullCheckBox.Checked = value == null;
            else if (!JColumn.IsNullable)
                NullCheckBox.Checked = false;
            if (value == null)
                return;            
            if (ValueControl is TextBox)
                (ValueControl as TextBox).Text = value.ToString();
            else if (ValueControl is CheckBox)
                (ValueControl as CheckBox).Checked = (bool)value;
        }

        private void CkbCheckBox_CheckedChanged(object sender, EventArgs e)
            => ValueControl.Enabled = !NullCheckBox.Checked;

        private Control GetControlFromJType(JType type, string name)
        {
            switch (type)
            {
                case JType.Boolean:
                    return new CheckBox { Name = $"ckb{name}" };
                case JType.Byte:
                case JType.Double:
                case JType.Guid:
                case JType.Integer:
                case JType.Long:
                case JType.Decimal:
                case JType.TimeSpan:
                case JType.Uri:
                case JType.String:

                case JType.Date:
                case JType.Time:
                case JType.DateTime:
                    return new TextBox { Name = $"txt{name}", Multiline = true };
                //case JType.Date:
                //    return new DateTimePicker { Name = $"dtp{name}", Format = DateTimePickerFormat.Short };
                //case JType.Time:
                //    return new DateTimePicker { Name = $"dtp{name}", Format = DateTimePickerFormat.Time, ShowUpDown = true };
                //case JType.DateTime:                    
                //    return new DateTimePicker { Name = $"dtp{name}", Format = DateTimePickerFormat.Long, ShowUpDown = true };
                case JType.None:
                case JType.JSONObject:
                default:
                    return new Label { Name = $"lvl{name}" };
                    
            }
        }
    }
}
