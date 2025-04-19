using Aritiafel;
using Aritiafel.Organizations.ArinaOrganization;
using Aritiafel.Organizations.RaeriharUniversity;
using JsonEditorV2;
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
        //改為可以傳入值
        public static string ParseFunction(string s, params object[] args)
        {
            //NOW
            s = s.Replace("{NOW()}", ArDateTime.Now.ToString("a"));
            s = s.Replace("{NOW('D')}", ArDateTime.Now.ToString("B"));
            s = s.Replace("{NOW('T')}", ArDateTime.Now.ToString("C"));            
            //COUNT
            s = s.Replace("{COUNT()}", args[0].ToString());
            //GUID
            s = s.Replace("{GUID()}", Guid.NewGuid().ToString());
            return s;
        }
    }
}
