using Newtonsoft.Json;
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

        [JsonIgnore]
        public bool Valid { get; set; } = true;

        [JsonIgnore]
        public JValueInvalidReasons InvalidReason { get; set; } = JValueInvalidReasons.None;

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
