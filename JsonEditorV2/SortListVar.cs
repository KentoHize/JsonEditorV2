using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonEditor;

namespace JsonEditorV2
{
    public class SortListVar
    {
        public JColumn Column { get; set; }
        public bool Desending { get; set; }
        public SortListVar(JColumn column, bool desending = false)
        {
            Column = column;
            Desending = desending;
        }

    }
}
