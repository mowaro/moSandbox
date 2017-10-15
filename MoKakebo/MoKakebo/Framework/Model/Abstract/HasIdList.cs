using System;
using System.Collections;
using System.Collections.Generic;

using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Framework.Model.Abstract{
    abstract public class HasIdList<T> : IList, IList<T> where T : IHasId {
        protected List<T> list;

        public HasIdList() {
            this.list = new List<T>();
        }

        public bool Remove(long id) {
            return list.Remove(list.Find(item => item.Id.Equals(id)));
        }

        public T get(long id) {
            return list.Find(item => item.Id.Equals(id));
        }

        public void AddRange(HasIdList<T> array) {
            this.list.AddRange(array);
        }

        #region IList<T> implement
        public T this[int index] {
            get { return this.list[index]; }
            set { this.list[index] = value; }
        }

        public int Count { get { return this.list.Count; } }
        public bool IsReadOnly { get { return this.list.ToArray().IsReadOnly; } }
        
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

        #region IList Implement

        object IList.this[int index] {
            get { return this.list[index]; }
            set { this.list[index] = (T)value; }
        }

        public bool IsFixedSize { get { return this.list.ToArray().IsFixedSize; } }
        public object SyncRoot { get { return this.list.ToArray().SyncRoot; } }
        public bool IsSynchronized { get { return this.list.ToArray().IsSynchronized; } }

        public int Add(object value) {
            if (!(value is T)) { throw new NotSupportedException(); }

            this.list.Add((T)value);
            return this.list.IndexOf((T)value);
        }

        public bool Contains(object value) {
            if(!(value is T)) { throw new NotSupportedException(); }

            return this.list.Contains((T)value);
        }

        public int IndexOf(object value) {
            if(!(value is T)) { throw new NotSupportedException(); }

            return this.list.IndexOf((T)value);
        }

        public void Insert(int index, object value) {
            if(!(value is T)) { throw new NotSupportedException(); }

            this.list.Insert(index, (T)value);
        }

        public void Remove(object value) {
            if(!(value is T)) { throw new NotSupportedException(); }

            this.list.Remove((T)value);
        }

        public void CopyTo(Array array, int index) {
            if(!(array is T[])) { throw new NotSupportedException(); }

            this.list.CopyTo((T[])array);
        }
        #endregion
    }

}
