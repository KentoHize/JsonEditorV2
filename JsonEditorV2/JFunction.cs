using Aritiafel;
using Aritiafel.Organizations.RaeriharUniversity;
using System;
using System.Collections.Generic;
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

        public static string ParseFunction(string s, bool useArDate = false, params object[] args)
        {
            //NOW
            if (useArDate)
                s = s.Replace("{NOW()}", ArDateTime.Now.ToString(ArinaOrganization.ArinaCultureInfo));
            else
                s = s.Replace("{NOW()}", ArDateTime.Now.ToString());
            if (useArDate)
                s = s.Replace("{NOW('T')}", ArDateTime.Now.ToLongTimeString(ArinaOrganization.ArinaCultureInfo));
            else
                s = s.Replace("{NOW('T')}", ArDateTime.Now.ToLongTimeString());
            if (useArDate)
                s = s.Replace("{NOW('D')}", ArDateTime.Now.ToShortDateString(ArinaOrganization.ArinaCultureInfo));
            else
                s = s.Replace("{NOW('D')}", ArDateTime.Now.ToShortDateString());
            //COUNT
            s = s.Replace("{COUNT()}", args[0].ToString());
            //GUID
            s = s.Replace("{GUID()}", Guid.NewGuid().ToString());

            //DateTime d;
            
            return s;
        }
    }
}
