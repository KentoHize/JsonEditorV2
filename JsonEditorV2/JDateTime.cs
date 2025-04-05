using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.Hosting;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace JsonEditor
{
    //用毫秒為單位
    //0:1年1月1日0時0分0秒
    //-1000:-1年12月31日23時59分59秒

    //可填負值與零的DateTime
    [Serializable]
    [StructLayout(LayoutKind.Auto)]
    public struct JDateTime //: IComparable, IFormattable, IConvertible, ISerializable, IComparable<DateTime>, IEquatable<DateTime>
    {
        private long _data;
        public long Ticks { get => _data; set => _data = value; }

        internal static char[] allStandardFormats = new char[19]
        {
            'd', 'D', 'f', 'F', 'g', 'G', 'm', 'M', 'o', 'O',
            'r', 'R', 's', 't', 'T', 'u', 'U', 'y', 'Y'
        };

        private const long TicksPerMillisecond = 10000L;

        private const long TicksPerSecond = 10000000L;

        private const long TicksPerMinute = 600000000L;

        private const long TicksPerHour = 36000000000L;

        private const long TicksPerDay = 864000000000L;
        //9223372036854775807L
        //3153284640000000000

        private const int MillisPerSecond = 1000;

        private const int MillisPerMinute = 60000;

        private const int MillisPerHour = 3600000;

        private const int MillisPerDay = 86400000;

        private const int DaysPerYear = 365;

        private const int DaysPer4Years = 1461;

        private const int DaysPer100Years = 36524;

        private const int DaysPer400Years = 146097;

        internal const long MinTicks = -3155378975999999999L;

        internal const long MaxTicks = 3155378975999999999L;

        private const long MaxMillis = 315537897600000L;
        
        

        internal static string DateTimeReplaceYearToString(DateTime dateTime, int newYear, string format = "", CultureInfo cultureInfo = null)
        {
            //IFormatProvider provider = null;
            //(provider


             //(provider) .DateTimeFormat = dateTime;
            if (cultureInfo == null)
                cultureInfo = CultureInfo.CurrentCulture;
            if (string.IsNullOrEmpty(format))
                format = "G";
            if (format.Length == 1 && format.IndexOfAny(allStandardFormats) != -1)
                format = cultureInfo.DateTimeFormat.GetAllDateTimePatterns(format[0])[0];
            format = format.Replace("%yyyyy", newYear.ToString("00000"))
                .Replace("yyyyy", newYear.ToString("00000"))
                .Replace("%yyyy", newYear.ToString("0000"))
                .Replace("yyyy", newYear.ToString("0000"))
                .Replace("%yyy", newYear.ToString("000"))
                .Replace("yyy", newYear.ToString("000"))
                .Replace("%yy", (newYear % 100).ToString("00"))
                .Replace("yy", (newYear % 100).ToString("00"))
                .Replace("%y", (newYear % 100).ToString("0"))
                .Replace("y", (newYear % 100).ToString("0"));
            return dateTime.ToString(format, cultureInfo);
        }



        public string ToString(string format, IFormatProvider provider)
        {   
            if (_data >= 0)
                return new DateTime(_data).ToString(format, provider);
            else
            {
                long t400 = TicksPerDay * DaysPer400Years;
                DateTime dt = new DateTime(_data % t400 + t400);
                return DateTimeReplaceYearToString(dt, (int)(_data / t400 + 399 - dt.Year), format, CultureInfo.CurrentCulture);
            }
            //formula
            //year = _data / t400 + 399 - dt.Year
            //others = new DateTime(_data % t400 + t400);
        }

        public string ToString(string format)
            => ToString(format, null);

        public string ToString(IFormatProvider provider)
            => ToString(null, provider);

        public override string ToString()
            => ToString(null, null);

        public string ToLongDateString()
            => ToString("D", null);
        public string ToLongTimeString()
            => ToString("T", null);
        public string ToShortDateString()
            => ToString("d", null);
        public string ToShortTimeString()
            => ToString("t", null);
     
        //=> _data >= 0 ? new DateTime(_data).ToString() : string.Concat('-', new DateTime(( _data + 1)).ToString());
        //public string ToLongDateString()
        //    => _data >= 0 ? new DateTime(_data).ToLongDateString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToLongDateString());
        //public string ToShortDateString()
        //    => _data >= 0 ? new DateTime(_data).ToShortDateString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToShortDateString());
        //public string ToLongTimeString()
        //    => _data >= 0 ? new DateTime(_data).ToLongTimeString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToLongTimeString());
        //public string ToShortTimeString()
        //    => _data >= 0 ? new DateTime(_data).ToShortTimeString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToShortTimeString());
        //public double ToOADate()
        //    => _data >= 0 ? new DateTime(_data).ToOADate() : -new DateTime(Math.Abs(_data + 1)).ToOADate();

        public JDateTime(long ticks)
            => _data = ticks;

        public JDateTime(DateTime datetime)
            => _data = datetime.Ticks;

        //public JDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind)
        //    : this(false, year, month, day, hour, minute, second, millisecond, calendar, kind)
        //{ } 

        //year can negative
        public JDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind)
        {

            if (year == 0 || month == 0 || day == 0 ||
                year > 9999 || month > 12 || day > 31)
                new DateTime(year, month, day); //Out of Range

            _data = 0;
            if (year < 0)
            {
                //_data = GetMinusDate()
                int y = year % 400 + 400;
                _data = -new DateTime(y + 1, 1, 1, 0, 0, 0, 0, calendar, kind).Subtract(new DateTime(y, month, day, hour, minute, second, millisecond, calendar, kind)).Ticks;
                //GetMinusDate()
            }
            else
                _data = new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind).Ticks;
        }

        //formula
        //year = _data / t400 + 399 - dt.Year
        //others = new DateTime(_data % t400 + t400);

        //private int getYear()
        //{
        //    long t400 = TicksPerDay * DaysPer400Years;
        //    _data / t400
        //}

        //public int Year
        //    => 

        //public int Millisecond
        //    => _data >= 0 ? (int)(_data / 10000 % 1000) : (int)((_data) / 10000 % 1000 + 1000);
            
        //public int Second
        //    => _data >= 0 ? (int)(_data / 10000000 % 60) : (int)-(-(_data + 1) / 10000000 % 60);
        //public int Minute
        //    => _data >= 0 ? (int)(_data / 600000000 % 60) : (int)-(-(_data + 1) / 600000000 % 60);
        //public int Hour
        //    => _data >= 0 ? (int)(_data / 36000000000L % 24) : (int)-(-(_data + 1) / 36000000000L % 24);
        //public int Day
        //    => _data >= 0 ? new DateTime(_data).Day : -new DateTime(-(_data + 1)).Day;
        //public int Month
        //    => new DateTime(_data).Month;
        //public int Year
        //    => new DateTime(_data).Year;
        //public DayOfWeek DayOfWeek
        //    => _data >= 0 ? (DayOfWeek)((_data / 864000000000L + 1) % 7) : (DayOfWeek)(((_data + 1) / 864000000000L + 1) % 7 + 7);
            

        //private DateTime GetMinusDate()
        //{
        //400 years Ticks
        //long t400 = TicksPerDay * DaysPer400Years;
        //int y = _data % t400 + t400;
        //_data = -new DateTime(y + 1, 1, 1, 0, 0, 0, 0, calendar, kind).Subtract(new DateTime(y, month, day, hour, minute, second, millisecond, calendar, kind)).Ticks;
        //}

        //return (int) (InternalTicks / 10000000 % 60);

        //public int Year
        //{
        //    get => new DateTime(_data).Year;
        //}



        //public DateTime(int year)
        //{
        //    DateTime dd = new DateTime()
        //}

        //public int Year
        //{
        //    //get { }

        //    set
        //    {
        //        _data
        //    }
        //}
    }
}
