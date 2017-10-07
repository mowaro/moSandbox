using System.Collections;
using System.Collections.Generic;

using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Framework.Model.Abstract{
    abstract public class HasIdObjectList<T> : IList<T> where T : IHasIdObject {
        protected List<T> list;

        public HasIdObjectList() {
            this.list = new List<T>();
        }

        public bool Remove(long id) {
            return list.Remove(list.Find(item => item.Equals(id)));
        }

        public T get(long id) {
            return list.Find(item => item.id == id);
        }

        public void AddRange(HasIdObjectList<T> array) {
            this.list.AddRange(array);
        }

        #region IList<T> implement
        public T this[int index] {
            get { return this.list[index]; }
            set { this.list[index] = value; }
        }
        public int Count { get { return this.list.Count; } }
        public bool IsReadOnly { get { return false; } }
        public void Add(T item) { this.list.Add(item); }
        public void Clear() { this.list.Clear(); }
        public bool Contains(T item) { return this.list.Contains(item); }
        public void CopyTo(T[] array, int arrayIndex) { this.list.CopyTo(array, arrayIndex); }
        public IEnumerator<T> GetEnumerator() { return this.list.GetEnumerator(); }
        public int IndexOf(T item) { return this.list.IndexOf(item); }
        public void Insert(int index, T item) { this.list.Insert(index, item); }
        public bool Remove(T item) { return this.list.Remove(item); }
        public void RemoveAt(int index) { this.list.RemoveAt(index); }
        IEnumerator IEnumerable.GetEnumerator() { return this.list.GetEnumerator(); }
        #endregion
    }


}
