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
        public JValue this[int index] { get => ((IList<JValue>)Values)[index]; set => ((IList<JValue>)Values)[index] = value; }        

        public List<JValue> Values { get; set; } = new List<JValue>();

        public int Count => ((IList<JValue>)Values).Count;

        public bool IsReadOnly => ((IList<JValue>)Values).IsReadOnly;

        public void Add(JValue item)
        {
            ((IList<JValue>)Values).Add(item);
        }

        public void Clear()
        {
            ((IList<JValue>)Values).Clear();
        }

        public bool Contains(JValue item)
        {
            return ((IList<JValue>)Values).Contains(item);
        }

        public void CopyTo(JValue[] array, int arrayIndex)
        {
            ((IList<JValue>)Values).CopyTo(array, arrayIndex);
        }

        public IEnumerator<JValue> GetEnumerator()
        {
            return ((IList<JValue>)Values).GetEnumerator();
        }

        public int IndexOf(JValue item)
        {
            return ((IList<JValue>)Values).IndexOf(item);
        }

        public void Insert(int index, JValue item)
        {
            ((IList<JValue>)Values).Insert(index, item);
        }

        public bool Remove(JValue item)
        {
            return ((IList<JValue>)Values).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<JValue>)Values).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<JValue>)Values).GetEnumerator();
        }
    }
}
