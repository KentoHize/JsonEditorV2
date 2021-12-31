using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class SortInfo
    {
        public JColumn Column { get; set; }
        public bool Descending { get; set; }
        public SortInfo()
        { }
        public SortInfo(JColumn column, bool desending = false)
        {
            Column = column;
            Descending = desending;
        }
    }
}
