using Aritiafel;
using Aritiafel.Organizations;
using JsonEditor;
using JsonEditorV2.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        private MainForm ownerWindow;
        private object parsedValue;

        public InputControlSet(JTable sourceTable, JColumn sourceColumn)
        {
            JTable = sourceTable;
            JColumn = sourceColumn;
        }

        public void DrawControl(Panel pnlMain, ToolTip toolTipComponent, int lineIndex)
        {
            if (string.IsNullOrEmpty(JColumn.Name))
                throw new MissingMemberException();

            ownerWindow = pnlMain.Parent as MainForm;

            NameLabel = new Label
            {
                Name = $"lbl{JColumn.Name}",
                Text = JColumn.Name,
                Left = 10,
                Top = 30 * lineIndex + 5,
                Width = 190,
                Font = pnlMain.Font
            };

            pnlMain.Controls.Add(NameLabel);

            ValueControl = GetValueControlFromJType(JColumn);
            ValueControl.Font = pnlMain.Font;

            if (ValueControl == null)
                return;

            ValueControl.Left = 200;
            ValueControl.Top = 30 * lineIndex + 5;

            switch (ValueControl)
            {
                case Label LabelControl:
                    LabelControl.Width = 200;
                    LabelControl.Height = 30 * (JColumn.NumberOfRows == 0 ? 1 : JColumn.NumberOfRows);
                    break;
                case CheckBox CheckControl:
                    CheckControl.CheckedChanged += CheckControl_CheckedChanged;
                    CheckControl.GotFocus += CheckControl_GotFocus;
                    break;
                case ComboBox ComboControl:
                    ComboControl.Width = 200;
                    ComboControl.SelectedIndexChanged += ComboControl_SelectedIndexChanged;
                    ComboControl.GotFocus += ComboControl_GotFocus;
                    break;
                case TextBox TextControl:
                    TextControl.Width = 200;
                    if (JColumn.NumberOfRows == 0)
                    {
                        TextControl.Left += 100;
                        TextControl.Width = 100;
                    }
                    else if (JColumn.NumberOfRows > 1)
                    {
                        TextControl.ScrollBars = ScrollBars.Vertical;
                        TextControl.Multiline = true;
                    }

                    TextControl.Height = 30 * (JColumn.NumberOfRows == 0 ? 1 : JColumn.NumberOfRows) - 4;
                    NameLabel.Height = 30 * (JColumn.NumberOfRows == 0 ? 1 : JColumn.NumberOfRows);
                    TextControl.TextChanged += TextControl_TextChanged;
                    TextControl.Click += TextControl_Click;
                    TextControl.GotFocus += TextControl_GotFocus;
                    break;
            }

            pnlMain.Controls.Add(ValueControl);

            ButtonControl = GetButtonControl(JColumn.Type, toolTipComponent, JColumn.Name, JColumn.FKTable != null && JColumn.FKColumn != null);
            if (ButtonControl != null)
            {
                ButtonControl.Font = pnlMain.Font;
                ValueControl.Width = ValueControl.Width - ButtonControl.Width;
                ButtonControl.Left = 400 - ButtonControl.Width; 
                ButtonControl.Top = 30 * lineIndex + 5;
                pnlMain.Controls.Add(ButtonControl);
            }

            ValidControl = new ErrorProvider();

            NullCheckBox = new CheckBox
            {
                Name = $"ckbNull{JColumn.Name}",
                Text = "Null",
                Left = 410,
                Top = 30 * lineIndex + 5,
                Width = 60,
                Font = pnlMain.Font
            };
            NullCheckBox.CheckedChanged += NullCheckBox_CheckedChanged;
            errPositionControl = NullCheckBox;

            if (!JColumn.IsNullable)
                NullCheckBox.Enabled = false;

            pnlMain.Controls.Add(NullCheckBox);
        }

        private void TextControl_Click(object sender, EventArgs e)
        {
            if((ValueControl as TextBox).Multiline != true)
                (ValueControl as TextBox).SelectAll();
        }

        private void CheckControl_GotFocus(object sender, EventArgs e)
        {
            if (!JColumn.IsNullable)
                NullCheckBox.Checked = false;
        }

        private void ComboControl_GotFocus(object sender, EventArgs e)
        {
            if (!JColumn.IsNullable)
                NullCheckBox.Checked = false;
        }

        private void ComboControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidControl.SetError(errPositionControl, "");
        }

        private void CheckControl_CheckedChanged(object sender, EventArgs e)
        {
            ValidControl.SetError(errPositionControl, "");
        }

        private void TextControl_GotFocus(object sender, EventArgs e)
        {
            if (!JColumn.IsNullable)
                NullCheckBox.Checked = false;
            if (!string.IsNullOrEmpty(JColumn.FKTable) && !string.IsNullOrEmpty(JColumn.FKColumn))
            {                
                NameLabel.Focus();
                JTable fkTable = Var.Tables.Find(m => m.Name == JColumn.FKTable);

                if (!fkTable.Loaded)
                    if (!MainForm.LoadOrScanJsonFile(fkTable))
                        return;
                    else
                        ownerWindow.RefreshTrvJsonFiles();

                if (fkTable.Lines.Count == 0)
                {
                    RabbitCouriers.SentWarningMessageByResource("JE_ERR_EMPTY_FK_TABLE", Res.JE_ERR_DEFAULT_TITLE, fkTable.Name);
                    return;
                }                    

                object newValue = frmFKTable.Show(ownerWindow, JColumn.Name, fkTable, JColumn.FKColumn, ValueControl.Text);
                if (newValue != null)
                    SetValueToString(newValue);
            }
            else if (JColumn.Type == JType.Date || JColumn.Type == JType.Time || JColumn.Type == JType.DateTime)
            {
                DateTimePickerStyle style = DateTimePickerStyle.DateTime;
                switch (JColumn.Type)
                {
                    case JType.Date:
                        style = DateTimePickerStyle.Date;
                        break;
                    case JType.Time:
                        style = DateTimePickerStyle.Time;
                        break;
                }
                ownerWindow.ShowDateTimePicker(ValueControl as TextBox, style);
            }
        }

        private void TextControl_TextChanged(object sender, EventArgs e)
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
            IFormatProvider fp = Setting.UseArinaDate ? ArinaOrganization.ArinaCultureInfo : null;
            if (ValueControl is Label)
                return true;
            else if (ValueControl is TextBox)
            {   
                if (!ChangeTextToString(ValueControl.Text).TryParseJType(JColumn.Type, fp, out parsedValue))
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_INVALID_CAST, ValueControl.Text));
                    return false;
                }
            }
            else if (ValueControl is CheckBox)
            {
                if (!(ValueControl as CheckBox).Checked.TryParseJType(JColumn.Type, fp, out parsedValue))
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_INVALID_CAST, ValueControl.Text));
                    return false;
                }
            }
            else if (ValueControl is ComboBox) //確認Choice 正確
            {
                if ((ValueControl as ComboBox).SelectedIndex == -1 || !(ValueControl as ComboBox).SelectedItem.TryParseJType(JColumn.Type, fp, out parsedValue))
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_CHOICE_VALUE_NOT_EXIST, (ValueControl as ComboBox).SelectedItem ?? Const.NullString));
                    return false;
                }
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
            if (JColumn.MaxLength != 0)
            {
                if (parsedValue.ToString().Length > JColumn.MaxLength)
                {
                    ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_TEXT_MAXIMUM_LENGTH_OVER, JColumn.MaxLength));
                    return false;
                }
            }

            //確認唯一值
            if (JColumn.IsUnique)
            {
                int columnIndex = JTable.Columns.IndexOf(JColumn);
                for (int i = 0; i < JTable.Count; i++)
                {
                    if (i != lineIndex && parsedValue == JTable[i][columnIndex])
                    {
                        ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_VALUE_IS_NOT_UNIQUE, parsedValue));
                        return false;
                    }
                }
            }

            //跳過Key檢查

            //外部驗證 - FK驗證 跳過
            //if (JColumn.FKTable != null && JColumn.FKColumn != null)
            //{
            //    //有錯表示有欄位錯誤
            //    JTable jt = Var.Tables.Find(m => m.Name == JColumn.FKTable);
            //    int columnIndex = jt.Columns.FindIndex(m => m.Name == JColumn.FKColumn);
            //    //結束

            //    if (!jt.Loaded)
            //        if (!MainForm.LoadOrScanJsonFile(jt))
            //            return false;

            //    if (!jt.Lines.Exists(m => ChangeStringToText(m.Values[columnIndex].ToString(jt.Columns[columnIndex].Type)) == ValueControl.Text))
            //    {
            //        ValidControl.SetError(errPositionControl, string.Format(Res.JE_VAL_FK_VALUE_NOT_FOUND, ValueControl.Text));
            //        return false;
            //    }
            //}
            return true;
        }

        public object GetValueValidated()
        {
            if (NullCheckBox.Checked)
                return null;
            return parsedValue;
        }

        public void ClearValue()
        {
            NullCheckBox.Checked = false;
            ValidControl.SetError(errPositionControl, "");
            ValueControl.Text = "";
            if (ValueControl is ComboBox ComboControl)
                ComboControl.SelectedIndex = -1;
            else if (ValueControl is CheckBox CheckBox)
                CheckBox.Checked = false;
        }

        public void SetValueToString(object value)
        {
            NullCheckBox.Checked = value == null;

            if (value == null)
                return;

            switch (ValueControl)
            {
                case TextBox TextControl:
                    TextControl.Text = ChangeStringToText(value.ToString(JColumn.Type, Setting.UseArinaDate ? ArinaOrganization.ArinaCultureInfo : null));
                    break;
                case CheckBox CheckControl:
                    CheckControl.Checked = (bool)value;
                    break;
                case ComboBox ComboControl:
                    ComboControl.SelectedItem = value;
                    break;
                case Label LabelControl:
                    LabelControl.Text = value.ToString().Replace("\n", "").Replace("\r", "");
                    break;
            }
        }

        public string ChangeTextToString(string text)
            => text.Replace("\r\n", "\n");

        public string ChangeStringToText(string s)
            => s.Replace("\n", "\r\n");

        private void NullCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ValueControl.Enabled = !NullCheckBox.Checked || !JColumn.IsNullable;
            ValidControl.SetError(errPositionControl, "");
        }

        private Button GetButtonControl(JType type, ToolTip toolTip, string name, bool isFK = false)
        {
            Button btn;
            if (isFK)
            {
                btn = new Button { Name = $"btn{name}", Width = 40 };
                btn.ImageList = (ownerWindow.Controls.Find("btnCopyLine", false)[0] as Button).ImageList;
                btn.ImageIndex = 7;
                toolTip.SetToolTip(btn, Res.JE_BTN_COPY);
                btn.Click += BtnCopyText_Click; ;
                return btn;
            }
            switch (type)
            {
                case JType.Guid:
                    btn = new Button { Name = $"btn{name}", Width = 50, Text = Res.JE_BTN_NEW_GUID };
                    toolTip.SetToolTip(btn, Res.JE_BTN_NEW_GUID);
                    btn.Click += BtnNewGUID_Click;
                    
                    return btn;
                case JType.Date:
                case JType.Time:
                case JType.DateTime:
                    btn = new Button { Name = $"btn{name}", Width = 40 };
                    btn.ImageList = (ownerWindow.Controls.Find("btnCopyLine", false)[0] as Button).ImageList;
                    btn.ImageIndex = 7;
                    toolTip.SetToolTip(btn, Res.JE_BTN_COPY);
                    btn.Click += BtnCopyText_Click;
                    return btn;
                default:
                    return null;
            }
        }

        private void BtnCopyText_Click(object sender, EventArgs e)
        {
            if (ValueControl.Text != "")
                Clipboard.SetText(ValueControl.Text);
        }

        public void BtnNewGUID_Click(object sender, EventArgs e)
        {
            ValueControl.Text = Guid.NewGuid().ToString();
        }

        private Control GetValueControlFromJType(JColumn column)
        {
            switch (column.Type)
            {
                case JType.Boolean:
                    return new CheckBox { Name = $"ckb{column.Name}" };
                case JType.Byte:
                case JType.Double:
                case JType.Guid:
                case JType.Integer:
                case JType.Long:
                case JType.Decimal:
                case JType.Uri:
                case JType.String:
                case JType.Date:
                case JType.Time:
                case JType.DateTime:
                    return new TextBox { Name = $"txt{column.Name}" };
                case JType.Choice:
                    if(string.IsNullOrEmpty(column.FKTable) || string.IsNullOrEmpty(column.FKColumn))
                        return new ComboBox { Name = $"cob{column.Name}", DropDownStyle = ComboBoxStyle.DropDownList, DataSource = column.Choices };
                    else
                        return new TextBox { Name = $"txt{column.Name}" };
                case JType.Object:
                case JType.Array:
                    return new Label { Name = $"txt{column.Name}" };
                case JType.None:
                default:
                    return new Label { Name = $"txt{column.Name}", Text = $"({column.Type.ToString()})" };
            }
        }
    }
}
