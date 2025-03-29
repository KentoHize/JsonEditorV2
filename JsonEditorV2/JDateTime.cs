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

        public string ToString(string format, IFormatProvider provider)
        {
            //To Do
            return ToString();
            //改掉format            
            //CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();            
            //return DateTimeFormat.Format(this, format, DateTimeFormatInfo.GetInstance(provider));
        }

        public override string ToString()
        {
            


            if (_data >= 0)
            {
                return new DateTime(_data).ToString();
            }   
            else
            {
                long t400 = TicksPerDay * DaysPer400Years;
                var n1 = _data / t400;
                var n2 = _data % t400 + t400;
                var n3 = new DateTime(n2); //月日以下可用

                //var n4 = new DateTime(1, n3.Month, n3.Day, n3.)
                return n3.ToString();
                //改掉全部yyyy與yyy與yy或y即可
                //CultureInfo.CurrentCulture.DateTimeFormat.GetAllDateTimePatterns();
                //DateTimeFormat
            }
        }
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

        //public JDateTime(bool isNegative, DateTime datetime)            
        //{   
        //    _data = datetime.Ticks;
        //    if (isNegative)
        //        _data = -(_data + 1);
        //}

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
        public int Millisecond
            => _data >= 0 ? (int)(_data / 10000 % 1000) : (int)-(-(_data + 1) / 10000 % 1000);
        public int Second
            => _data >= 0 ? (int)(_data / 10000000 % 60) : (int)-(-(_data + 1) / 10000000 % 60);
        public int Minute
            => _data >= 0 ? (int)(_data / 600000000 % 60) : (int)-(-(_data + 1) / 600000000 % 60);
        public int Hour
            => _data >= 0 ? (int)(_data / 36000000000L % 24) : (int)-(-(_data + 1) / 36000000000L % 24);
        public int Day
            => _data >= 0 ? new DateTime(_data).Day : -new DateTime(-(_data + 1)).Day;
        public int Month
            => new DateTime(_data).Month;
        public int Year
            => new DateTime(_data).Year;

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
