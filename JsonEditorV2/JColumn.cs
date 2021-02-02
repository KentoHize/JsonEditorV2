using Newtonsoft.Json;
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
        public bool IsNullable { get; set; }
        public JType Type { get; set; }
        public List<string> Choices { get; set; }
        public string FKTable { get; set; }
        public string FKColumn { get; set; }
        public int NumberOfRows { get; set; }
        public bool Display { get; set; }
        public string RegularExpression { get; set; }
        public string Description { get; set; }
        public string MinValue { get; set; }
        public string MaxValue { get; set; }
        public long MaxLength { get; set; }
        public bool AutoGenerateKey { get; set; }
        public bool IsUnique { get; set; }

        [JsonIgnore]
        public bool Valid { get; set; } = true;

        [JsonIgnore]
        public JValueInvalidReasons InvalidReason { get; set; } = JValueInvalidReasons.None;        

        public JColumn()
            : this("")
        { }

        public JColumn(string name)
            : this(name, JType.String)
        { }

        public JColumn(string name, JType type, bool isKey = false, bool display = false, int numberOfRows = 1, string regex = null, string fkTable = null, string fkColumn = null)
        {
            Name = name;
            IsKey = isKey;
            Type = type;
            Display = display;
            NumberOfRows = numberOfRows;
            FKTable = fkTable;
            FKColumn = fkColumn;
            RegularExpression = regex;            
            Choices = new List<string>();
        }
    }
}
