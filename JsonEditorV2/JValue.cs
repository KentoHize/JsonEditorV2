using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class JValue
    {
        public object Value { get; set; }

        public JValue()
            : this(null)
        { }

        public JValue(object value)
        {
            Value = value;
        }

        public static JValue FromObject(object value)
            => new JValue(value);
    }
}
