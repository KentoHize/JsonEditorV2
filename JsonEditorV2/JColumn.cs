using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class JColumn
    {
        public string Name { get; set; }
        public bool IsKey { get; set; }        
        public JType Type { get; set; }
        public string ForeignKey { get; set; }
        public int NumberOfRows { get; set; }
        public bool Display { get; set; }

        public JColumn()
            : this("")
        { }

        public JColumn(string name)
            : this(name, JType.String)
        { }

        public JColumn(string name, JType type, bool isKey = false, bool display = false, int numberOfRows = 1, string fk = null)
        {
            Name = name;
            IsKey = isKey;
            Type = type;
            Display = display;
            NumberOfRows = numberOfRows;
            ForeignKey = fk;
        }
    }
}
