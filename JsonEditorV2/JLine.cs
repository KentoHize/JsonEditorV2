using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class JLine : IList<JValue>
    {
        public JValue this[int index] { get => ((IList<JValue>)Value)[index]; set => ((IList<JValue>)Value)[index] = value; }

        public List<JValue> Value { get; set; } = new List<JValue>();

        public int Count => ((IList<JValue>)Value).Count;

        public bool IsReadOnly => ((IList<JValue>)Value).IsReadOnly;

        public void Add(JValue item)
        {
            ((IList<JValue>)Value).Add(item);
        }

        public void Clear()
        {
            ((IList<JValue>)Value).Clear();
        }

        public bool Contains(JValue item)
        {
            return ((IList<JValue>)Value).Contains(item);
        }

        public void CopyTo(JValue[] array, int arrayIndex)
        {
            ((IList<JValue>)Value).CopyTo(array, arrayIndex);
        }

        public IEnumerator<JValue> GetEnumerator()
        {
            return ((IList<JValue>)Value).GetEnumerator();
        }

        public int IndexOf(JValue item)
        {
            return ((IList<JValue>)Value).IndexOf(item);
        }

        public void Insert(int index, JValue item)
        {
            ((IList<JValue>)Value).Insert(index, item);
        }

        public bool Remove(JValue item)
        {
            return ((IList<JValue>)Value).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<JValue>)Value).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<JValue>)Value).GetEnumerator();
        }
    }
}
