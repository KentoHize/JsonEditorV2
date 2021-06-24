using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditorV2
{
    public static class Const
    {
        public const string VersionString = "Version 0.34";

        public const string NumberOfRowsRegex = @"^\d{1,2}$";

        public const string NullString = "(null)";

        public const string HiddenColumnItemIndex = "{0D58183F-E5B5-4AF4-9A00-E3F56CB91142}";
        public const string HiddenColumnStat = "{72FF197D-4019-43F7-A3D7-D4E4C488DC22}";

        public static string BackupFolder { get => Path.Combine(Application.UserAppDataPath, "Backup"); }
        public static string ApplicationDataFolder { get => Path.Combine(Application.UserAppDataPath); }
        public static string BackupRecoverFile { get => Path.Combine(BackupFolder, "Recover.ini"); }
    }
}
