using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonEditor
{
    public class JLine : IList<object>
    {
        public object this[int index] { get => ((IList<object>)Values)[index]; set => ((IList<object>)Values)[index] = value; }

        public List<object> Values { get; set; } = new List<object>();

        public int Count => ((IList<object>)Values).Count;

        public bool IsReadOnly => ((IList<object>)Values).IsReadOnly;

        public void Add(object item)
        {
            ((IList<object>)Values).Add(item);
        }

        public void Clear()
        {
            ((IList<object>)Values).Clear();
        }

        public bool Contains(object item)
        {
            return ((IList<object>)Values).Contains(item);
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            ((IList<object>)Values).CopyTo(array, arrayIndex);
        }

        public IEnumerator<object> GetEnumerator()
        {
            return ((IList<object>)Values).GetEnumerator();
        }

        public int IndexOf(object item)
        {
            return ((IList<object>)Values).IndexOf(item);
        }

        public void Insert(int index, object item)
        {
            ((IList<object>)Values).Insert(index, item);
        }

        public bool Remove(object item)
        {
            return ((IList<object>)Values).Remove(item);
        }

        public void RemoveAt(int index)
        {
            ((IList<object>)Values).RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<object>)Values).GetEnumerator();
        }
    }
}
