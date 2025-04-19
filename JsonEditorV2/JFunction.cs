using Aritiafel;
using Aritiafel.Organizations.ArinaOrganization;
using Aritiafel.Organizations.RaeriharUniversity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonEditor
{
    internal class JFunc
    {
        public string Name { get; set; }
        public string[] Args { get; set; }
    }

    public static class JFunction
    {
        //List<JFunc>

        //internal static string 

        public static string ParseFunction(string s, params object[] args)
        {
            //NOW
            s = s.Replace("{NOW()}", ArDateTime.Now.ToStandardString());
            s = s.Replace("{NOW('T')}", ArDateTime.Now.ToStandardString(ArStandardDateTimeType.Time));
            s = s.Replace("{NOW('D')}", ArDateTime.Now.ToStandardString(ArStandardDateTimeType.Date));
            //COUNT
            s = s.Replace("{COUNT()}", args[0].ToString());
            //GUID
            s = s.Replace("{GUID()}", Guid.NewGuid().ToString());
            return s;
        }
    }
}
