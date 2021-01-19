using JsonEditor;
using System;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public class InputControlSet
    {
        public string Name { get; set; }
        public JType Type { get; set; }
        public int NumberOfRows { get; set; }

        public Control ValueControl { get; set; }
        public CheckBox NullCheckBox { get; set; }
        public Label NameLabel { get; set; }

        public InputControlSet(string name, JType type, int numberOfRows)
        {
            Name = name;
            Type = type;
            NumberOfRows = numberOfRows;
        }

        public void DrawControl(Panel pnlMain, int lineIndex)
        {
            if (string.IsNullOrEmpty(Name))
                throw new MissingMemberException();

            NameLabel = new Label();
            NameLabel.Name = $"lbl{Name}";
            NameLabel.Text = Name;
            NameLabel.Left = 10;
            NameLabel.Top = 30 * lineIndex;

            pnlMain.Controls.Add(NameLabel);

            ValueControl = GetControlFromJType(Type, Name);

            if (ValueControl == null)
                return;

            ValueControl.Left = 200;
            ValueControl.Top = 30 * lineIndex;

            if (ValueControl is TextBox)
            {
                ValueControl.Width = 200;
                ValueControl.Height = 27 * NumberOfRows;
            }

            pnlMain.Controls.Add(ValueControl);

            NullCheckBox = new CheckBox { Name = $"ckbNull{Name}" };
            NullCheckBox.Text = "Null";
            NullCheckBox.Left = 410;
            NullCheckBox.Top = 30 * lineIndex;
            NullCheckBox.Width = 60;
            NullCheckBox.CheckedChanged += CkbCheckBox_CheckedChanged;

            pnlMain.Controls.Add(NullCheckBox);
        }

        public object GetValue()
        {
            if (NullCheckBox.Checked)
                return null;

            if (ValueControl is TextBox)
                return (ValueControl as TextBox).Text.ParseJType(Type);
            else if (ValueControl is CheckBox)
                return (ValueControl as CheckBox).Checked.ParseJType(Type);

            throw new Exception();
        }

        public void SetValue(object value)
        {
            NullCheckBox.Checked = value == null;
            if (NullCheckBox.Checked)
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
                case JType.Undefied:
                    return null;
                default:
                    return null;
            }
        }
    }
}
