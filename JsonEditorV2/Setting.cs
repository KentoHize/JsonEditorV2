using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditorV2
{
    public static class Setting
    {
        public static bool UseQuickCheck { get; set; }
        public static CultureInfo CI { get; set; }
        public static long DontLoadFileBytesThreshold { get; set; } //bytes

        public static int NumberOfRowsMaxValue { get; set; }
    }
}
