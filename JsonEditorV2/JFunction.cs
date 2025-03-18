using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public static class JFunction
    {
        public static string ParseFunction(string s, bool useArinaYear = false)
        {   
            //NOW
            if(useArinaYear)
                s = s.Replace("{NOW()}", DateTime.Now.AddYears(-2017).ToString());
            else
                s = s.Replace("{NOW()}", DateTime.Now.ToString());
            //GUID
            s = s.Replace("{GUID()}", Guid.NewGuid().ToString());
            return s;
        }
    }
}
