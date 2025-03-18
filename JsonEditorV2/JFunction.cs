using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public static class JFunction
    {
        public static string ParseFunction(string s)
        {   
            //NOW
            s = s.Replace("{NOW()}", DateTime.Now.ToString());
            //GUID
            s = s.Replace("{GUID()}", Guid.NewGuid().ToString());
            return s;
        }
    }
}
