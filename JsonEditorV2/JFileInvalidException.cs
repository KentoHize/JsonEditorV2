using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class JFileInvalidException : Exception
    {
        public JFileInvalidReasons Reason { get; set; }        
        public int LineIndex { get; set; }

        public JFileInvalidException(JFileInvalidReasons reason, int lineIndex = -1)
        {
            Reason = reason;            
            LineIndex = lineIndex;
                
        }
    }
}
