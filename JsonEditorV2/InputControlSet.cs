using JsonEditor;
using JsonEditorV2.Resources;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public class InputControlSet
    {
        public JTable JTable { get; set; }
        public JColumn JColumn { get; set; }

        public Control ValueControl { get; set; }
        public Button ButtonControl { get; set; }
        public ErrorProvider ValidControl { get; set; }
        public CheckBox NullCheckBox { get; set; }
        public Label NameLabel { get; set; }

        private Control errPositionControl;
        private Control ownerWindow;
        private object parsedValue;

        public InputControlSet(JTable sourceTable, JColumn sourceColumn)
        {
            JTable = sourceTable;
            JColumn = sourceColumn;
        }

        public void DrawControl(Panel pnlMain, int lineIndex)
        {
            if (string.IsNullOrEmpty(JColumn.Name))
                throw new MissingMemberException();

            ownerWindow = pnlMain.Parent;

            NameLabel = new Label();
            NameLabel.Name = $"lbl{JColumn.Name}";
            NameLabel.Text = JColumn.Name;
            NameLabel.Left = 10;
            NameLabel.Top = 30 * lineIndex + 5;
            NameLabel.Width = 190;

            pnlMain.Controls.Add(NameLabel);

            ValueControl = GetValueControlFromJType(JColumn.Type, JColumn.Name);
            errPositionControl = ValueControl;

            if (ValueControl == null)
                return;

            ValueControl.Left = 200;
            ValueControl.Top = 30 * lineIndex + 5;

            if (ValueControl is TextBox TextControl)
            {
                ValueControl.Width = 200;
                if (JColumn.NumberOfRows == 0)
                {
                    ValueControl.Left += 100;
                    ValueControl.Width = 100;
                }
                if (JColumn.NumberOfRows > 1)
                    (ValueControl as TextBox).ScrollBars = ScrollBars.Vertical;
                ValueControl.Height = 30 * (JColumn.NumberOfRows == 0 ? 1 : JColumn.NumberOfRows) - 4;
                NameLabel.Height = 30 * (JColumn.NumberOfRows == 0 ? 1 : JColumn.NumberOfRows);
                TextControl.TextChanged += ValueControl_TextChanged;                
                TextControl.GotFocus += TextControl_GotFocus;
            }

            pnlMain.Controls.Add(ValueControl);

            ButtonControl = GetButtonControlFromJType(JColumn.Type, JColumn.Name);

            if (ButtonControl != null && 
                (JColumn.FKTable == null || JColumn.FKColumn == null))
            {
                ValueControl.Width = 150;
                ButtonControl.Left = 350;
                ButtonControl.Width = 50;
                ButtonControl.Top = 30 * lineIndex + 5;
                pnlMain.Controls.Add(ButtonControl);
                errPositionControl = ButtonControl;
            }

            ValidControl = new ErrorProvider();

            NullCheckBox = new CheckBox { Name = $"ckbNull{JColumn.Name}" };
            NullCheckBox.Text = "Null";
            NullCheckBox.Left = 430;
            NullCheckBox.Top = 30 * lineIndex + 5;
            NullCheckBox.Width = 60;
            NullCheckBox.CheckedChanged += NullCheckBox_CheckedChanged;

            if (!JColumn.IsNullable)
                NullCheckBox.Enabled = false;

            pnlMain.Controls.Add(NullCheckBox);
        }

        private void TextControl_GotFocus(object sender, EventArgs e)
        {
            if (!JColumn.IsNullable)
                NullCheckBox.Checked = false;
            if (!string.IsNullOrEmpty(JColumn.FKTable) && !string.IsNullOrEmpty(JColumn.FKColumn))
            {
                NameLabel.Focus();
                JTable fkTable = Var.Tables.Find(m => m.Name == JColumn.FKTable);

                object newValue = frmFKTable.Show(ownerWindow, JColumn.Name, fkTable, JColumn.FKColumn, ValueControl.Text);
                if (newValue != null)
                    SetValueToString(newValue);
            }
        }

        private void ValueControl_TextChanged(object sender, EventArgs e)
        {
            ValidControl.SetError(errPositionControl, "");
        }

        public bool CheckValid(int lineIndex)
        {
            ValidControl.SetError(errPositionControl, "");

            //確認Null
            if (JColumn.IsNullable && NullCheckBox.Checked)
                return true;
            else if (!JColumn.IsNullable && NullCheckBox.Checked)
            {
                ValidControl.SetError(NullCheckBox, string.Format(Res.JE_VAL_NOT_NULLABLE));
                return false;
            }
   
            //確定型態符合
            if (ValueControl is TextBox)
                if (!ChangeTextToString(ValueControl.Text).TryParseJType(JColumn.Type, out parsedValue))
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_INVALID_CAST, ValueControl.Text));
                    return false;
                }

            if (ValueControl is CheckBox)
                if (!(ValueControl as CheckBox).Checked.TryParseJType(JColumn.Type, out parsedValue))
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_INVALID_CAST, ValueControl.Text));
                    return false;
                }

            //確認Regex正確
            if (JColumn.Type == JType.String)
                if (!string.IsNullOrEmpty(JColumn.RegularExpression))
                    if (!Regex.IsMatch(ChangeTextToString(ValueControl.Text), JColumn.RegularExpression))
                    {
                        ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_REGEX_IS_NOT_MATCH, ValueControl.Text));
                        return false;
                    }

            //確認MinMax正確
            if (JColumn.Type.IsNumber() || JColumn.Type.IsDateTime())
            {
                if (!string.IsNullOrEmpty(JColumn.MinValue) && parsedValue.CompareTo(JColumn.MinValue.ParseJType(JColumn.Type), JColumn.Type) == -1)
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_LESS_THEN_MIN_VALUE, ValueControl.Text, JColumn.MinValue));
                    return false;
                }
                if (!string.IsNullOrEmpty(JColumn.MaxValue) && parsedValue.CompareTo(JColumn.MaxValue.ParseJType(JColumn.Type), JColumn.Type) == 1)
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_GREATER_THEN_MAX_VALUE, ValueControl.Text, JColumn.MaxValue));
                    return false;
                }
            }

            //確認MaxLength正確
            if(JColumn.TextMaxLength != 0)
            {
                if(parsedValue.ToString().Length > JColumn.TextMaxLength)
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_TEXT_MAXIMUM_LENGTH_OVER, JColumn.TextMaxLength));
                    return false;
                }
            }

            //確認唯一值
            if(JColumn.IsUnique)
            {
                int columnIndex = JTable.Columns.IndexOf(JColumn);
                for(int i = 0; i < JTable.Count; i++)
                {
                    if(i != lineIndex && parsedValue.CompareTo(JTable[i][columnIndex].Value, JColumn.Type) == 0)
                    {
                        ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_VALUE_IS_NOT_UNIQUE, parsedValue));
                        return false;
                    }
                }
            }

            //跳過Key檢查

            //外部驗證 - FK驗證
            if(JColumn.FKTable != null && JColumn.FKColumn != null)
            {   
                //有錯表示有欄位錯誤
                JTable jt = Var.Tables.Find(m => m.Name == JColumn.FKTable);
                int columnIndex = jt.Columns.FindIndex(m => m.Name == JColumn.FKColumn);
                //結束

                if (!jt.Loaded)
                    MainForm.LoadOrScanJsonFile(jt);
                
                if(!jt.Lines.Exists(m => ChangeStringToText(m.Values[columnIndex].Value.ToString(jt.Columns[columnIndex].Type)) == ValueControl.Text))
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_FK_IS_NOT_FOUND, ValueControl.Text));
                    return false;
                }
            }
            return true;
        }

        public object GetValueValidated()
        {
            if (NullCheckBox.Checked)
                return null;
            return parsedValue;
        }

        public void SetValueToString(object value)
        {
            NullCheckBox.Checked = value == null;

            if (value == null)
                return;

            if (ValueControl is TextBox TextControl)
                TextControl.Text = ChangeStringToText(value.ToString(JColumn.Type));
            else if (ValueControl is CheckBox CheckControl)
                CheckControl.Checked = (bool)value;
        }

        public string ChangeTextToString(string text)
            => text.Replace("\r\n", "\n");

        public string ChangeStringToText(string s)
            => s.Replace("\n", "\r\n");

        private void NullCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ValueControl.Enabled = !NullCheckBox.Checked || !JColumn.IsNullable;
            ValidControl.SetError(errPositionControl, "");
            ValidControl.SetError(NullCheckBox, "");
        }

        private Button GetButtonControlFromJType(JType type, string name)
        {
            switch (type)
            {
                case JType.Guid:
                    Button btn = new Button { Name = $"btn{name}", Text = Res.JE_BTN_NEW_GUID }; ;
                    btn.Click += BtnNewGUID_Click;
                    return btn;
                default:
                    return null;
            }
        }

        private void BtnNewGUID_Click(object sender, EventArgs e)
        {
            ValueControl.Text = Guid.NewGuid().ToString();
        }

        private Control GetValueControlFromJType(JType type, string name)
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
                //case JType.TimeSpan:
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
                case JType.Object:
                default:
                    return new Label { Name = $"lvl{name}" };

            }
        }
    }
}
