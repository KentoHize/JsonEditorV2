using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonEditor;

namespace JsonEditorV2
{
    public static class Setting
    {
        public static ValueCheckMethod TableCheckMethod { get; set; }
        public static CultureInfo CI { get; set; }
        public static long DontLoadFileBytesThreshold { get; set; } //bytes
        public static int NumberOfRowsMaxValue { get; set; }
        public static Color InvalidLineBackColor { get; set; }
        public static int DgvLinesColumnStandardWidth { get; set; }
        public static string LatestFolder1 { get; set; }
        public static string LatestFolder2 { get; set; }
        public static string LatestFolder3 { get; set; }
        public static string LatestFolder4 { get; set; }
    }
}
