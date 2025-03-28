using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace JsonEditor
{
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


        public override string ToString()
            => _data >= 0 ? new DateTime(_data).ToString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToString());
        public string ToLongDateString()
            => _data >= 0 ? new DateTime(_data).ToLongDateString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToLongDateString());
        public string ToShortDateString()
            => _data >= 0 ? new DateTime(_data).ToShortDateString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToShortDateString());
        public string ToLongTimeString()
            => _data >= 0 ? new DateTime(_data).ToLongTimeString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToLongTimeString());
        public string ToShortTimeString()
            => _data >= 0 ? new DateTime(_data).ToShortTimeString() : string.Concat('-', new DateTime(Math.Abs(_data + 1)).ToShortTimeString());
        public double ToOADate()
            => _data >= 0 ? new DateTime(_data).ToOADate() : -new DateTime(Math.Abs(_data + 1)).ToOADate();

        public JDateTime(long ticks)
            => _data = ticks;

        public JDateTime(DateTime datetime)
            => _data = datetime.Ticks;

        public JDateTime(bool isNegative, DateTime datetime)            
        {   
            _data = datetime.Ticks;
            if (isNegative)
                _data = -(_data + 1);
        }

        public JDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind)
            : this(false, year, month, day, hour, minute, second, millisecond, calendar, kind)
        { } 

        public JDateTime(bool isNegative, int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind)
        {
            _data = new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind).Ticks;
            if(isNegative)
                _data = -(_data + 1);
        }

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
