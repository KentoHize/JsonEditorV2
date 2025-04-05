using Aritiafel.Organizations.RaeriharUniversity;
using JsonEditorV2.Resources;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public enum DateTimePickerStyle
    {
        DateTime = 0,
        Date,
        Time
    }

    public partial class SimpleDateTimePicker : UserControl
    {
        private static readonly byte[] years100inverse = {
                    99, 98, 97, 96, 95, 94, 93, 92, 91, 90,
                    89, 88, 87, 86, 85, 84, 83, 82, 81, 80,
                    79, 78, 77, 76, 75, 74, 73, 72, 71, 70,
                    69, 68, 67, 66, 65, 64, 63, 62, 61, 60,
                    59, 58, 57, 56, 55, 54, 53, 52, 51, 50,
                    49, 48, 47, 46, 45, 44, 43, 42, 41, 40,
                    39, 38, 37, 36, 35, 34, 33, 32, 31, 30,
                    29, 28, 27, 26, 25, 24, 23, 22, 21, 20,
                    19, 18, 17, 16, 15, 14, 13, 12, 11, 10,
                    9, 8, 7, 6, 5, 4, 3, 2, 1, 0
                };

        private static readonly byte[] years100 = {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                    31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                    41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
                    51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
                    61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
                    71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
                    81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
                    91, 92, 93, 94, 95, 96, 97, 98, 99
                };

        private static readonly byte[] years99 = {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                    31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                    41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
                    51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
                    61, 62, 63, 64, 65, 66, 67, 68, 69, 70,
                    71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
                    81, 82, 83, 84, 85, 86, 87, 88, 89, 90,
                    91, 92, 93, 94, 95, 96, 97, 98, 99,
                };

        private static readonly byte[] months = {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12
                };

        private static readonly byte[] days28 = {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28
                };

        private static readonly byte[] days29 = {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28, 29
                };

        private static readonly byte[] days30 = {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28, 29, 30
                };

        private static readonly byte[] days31 = {
                    1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31
                };

        private static readonly byte[] hours = {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23
                };

        private static readonly byte[] minutes = {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                    31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                    41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
                    51, 52, 53, 54, 55, 56, 57, 58, 59
                };

        private static readonly byte[] seconds = {
                    0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                    11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                    31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                    41, 42, 43, 44, 45, 46, 47, 48, 49, 50,
                    51, 52, 53, 54, 55, 56, 57, 58, 59
                };

        private static readonly char[] sign = { '+', '-' };

        [Description("顯示型態")]
        public DateTimePickerStyle Style { get => _Style; set => _Style = value; }

        private DateTimePickerStyle _Style;
        //[Description("值")]
        //public DateTime Value {
        //    get
        //    {
        //                 if (DesignMode && Parent != null)
        //        {
        //            Parent.Refresh();
        //        }
        //    }
        //}

        public event EventHandler ValueChanged;

        public TextBox BindingControl { get; set; }

        [Description("閏年調整")]
        public int LeapYearAdjust { get; set; }        

        [Description("可使用負數")]
        public bool CanNegative { get; set; }

        public ArDateTime GetValue()
        {
            if (!int.TryParse(txtMillisecond.Text, out int milsec))
                milsec = 0;
            //0年

            //Negative
            return new ArDateTime(cobSign.SelectedIndex == 0 ? 1 : -1 * (byte)dud100Year.SelectedItem * 100 + (byte)cobYear.SelectedItem,
               (byte)cobMonth.SelectedItem, (byte)cobDay.SelectedItem,
               (byte)cobHour.SelectedItem, (byte)cobMinute.SelectedItem,
               (byte)cobSecond.SelectedItem, milsec, true);
        }

        public void SetValue(ArDateTime value)
        {
            if(Style != DateTimePickerStyle.Time)
            {
                cobSign.SelectedIndex = value.Ticks >= 0 ? 0 : 1;
                int year = value.Year, n1, n2;
                if(year >= 0)
                {
                    n1 = Math.DivRem(year, 100, out n2);
                }
                else
                {
                    n1 = Math.DivRem(year, 100, out n2);
                    if (n2 != 0)
                    {
                        n1 -= 1;
                        n2 += 100;
                    }   
                }
                dud100Year.SelectedItem = Convert.ToByte(n1);
                cobYear.SelectedItem = Convert.ToByte(n2);

                cobMonth.SelectedItem = Convert.ToByte(value.Month);            
                SetDays(value.Year, value.Month);
                cobDay.SelectedItem = Convert.ToByte(value.Day);
            }
            if(Style != DateTimePickerStyle.Date)
            { 
                cobHour.SelectedItem = Convert.ToByte(value.Hour);
                cobMinute.SelectedItem = Convert.ToByte(value.Minute);
                cobSecond.SelectedItem = Convert.ToByte(value.Second);
            }
            if(Style == DateTimePickerStyle.Time)
                txtMillisecond.Text = value.Millisecond.ToString().PadRight(3, '0');
        }

        public void PatchTextFromResource()
        {
            lblYear.Text = Res.JE_DATETIME_YEAR;
            lblMonth.Text = Res.JE_DATETIME_MONTH;
            lblDay.Text = Res.JE_DATETIME_DAY;
            lblHour.Text = Res.JE_DATETIME_HOUR;
            lblMinute.Text = Res.JE_DATETIME_MINUTE;
            lblSecond.Text = Res.JE_DATETIME_SECOND;
        }

        public SimpleDateTimePicker()
        {
            InitializeComponent();
            PatchTextFromResource();

            dud100Year.Items.AddRange(years100inverse);
            cobYear.DataSource = years99;
            cobMonth.DataSource = months;
            cobDay.DataSource = days31;
            cobHour.DataSource = hours;
            cobMinute.DataSource = minutes;
            cobSecond.DataSource = seconds;
            cobSign.DataSource = sign;
        }


        public void Clear()
        {
            dud100Year.SelectedIndex = dud100Year.Items.Count - 1;
            cobYear.SelectedIndex = cobMonth.SelectedIndex =
            cobDay.SelectedIndex = cobHour.SelectedIndex = cobMinute.SelectedIndex =
            cobSecond.SelectedIndex = cobSign.SelectedIndex = 0;            
            txtMillisecond.Text = "000";
            dud100Year.Enabled = cobYear.Enabled = cobMonth.Enabled = cobDay.Enabled =
            cobHour.Enabled = cobMinute.Enabled = cobSecond.Enabled = txtMillisecond.Enabled =
            false;
        }

        public void SetType(DateTimePickerStyle type)
        {
            Style = type;
            Clear();
            if (type == DateTimePickerStyle.Date || type == DateTimePickerStyle.DateTime)
                cobSign.Enabled = dud100Year.Enabled = cobYear.Enabled = cobMonth.Enabled = cobDay.Enabled = true;
            if (type == DateTimePickerStyle.Time || type == DateTimePickerStyle.DateTime)
                cobHour.Enabled = cobMinute.Enabled = cobSecond.Enabled = true;
            if (type == DateTimePickerStyle.Time)
                txtMillisecond.Enabled = true;            
            cobSign.Enabled = CanNegative;
        }

        //private int ModYear(int x, int y, bool withoutZero = false)
        //{
        //    x %= y;
        //    if (x < 0 || (x == 0 && withoutZero))
        //        x += y;
        //    return x;
        //}

        public void SetDays(int year, int month, byte? day = 1)
        {   
            switch (ArDateTime.DaysInMonth(year, month))
            {
                case 31:
                    cobDay.DataSource = days31;                   
                    break;
                case 30:
                    cobDay.DataSource = days30;
                    break;
                case 28:
                    cobDay.DataSource = days28;
                    break;
                case 29:
                    cobDay.DataSource = days29;
                    break;
            }

            if (day == null)
                return;

            int i = cobDay.Items.IndexOf((byte)day);
            if (i != -1)
                cobDay.SelectedIndex = i;
        }

        private void dud100Year_SelectedItemChanged(object sender, EventArgs e)
        {  
            if(dud100Year.SelectedIndex != dud100Year.Items.Count - 1)
                cobYear.DataSource = years100;
            else
                cobYear.DataSource = years99;
            ValueChanged(sender, EventArgs.Empty);
        }

        private void cobYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobYear.DataSource == null || cobMonth.DataSource == null)
                return;
            SetDays(Convert.ToInt16(dud100Year.SelectedItem) * 100 + Convert.ToInt16(cobYear.SelectedItem), (byte)cobMonth.SelectedItem, (byte?)cobDay.SelectedItem);
            ValueChanged?.Invoke(sender, EventArgs.Empty);

        }

        private void cobMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobYear.DataSource == null || cobMonth.DataSource == null)
                return;
            SetDays(Convert.ToInt16(dud100Year.SelectedItem) * 100 + Convert.ToInt16(cobYear.SelectedItem), (byte)cobMonth.SelectedItem, (byte?)cobDay.SelectedItem);
            ValueChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void cobDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void cobHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void cobMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void cobSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void txtMillisecond_TextChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, EventArgs.Empty);
        }

        private void txtMillisecond_Click(object sender, EventArgs e)
        {
            txtMillisecond.SelectAll();
        }
    }
}
