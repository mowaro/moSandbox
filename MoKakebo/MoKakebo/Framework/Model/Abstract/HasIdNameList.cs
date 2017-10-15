using System.Collections.Generic;
using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Framework.Model.Abstract {
    abstract public class HasIdNameList<T> : HasIdList<T> where T : IHasIdName {

        public HasIdNameList():base() {
        }

        public bool Remove(string name) {
            return list.Remove(list.Find(item => item.Name.Equals(name)));
        }

        public T get(string name) {
            return list.Find(item => item.Name.Equals(name));
        }

        public void AddRange(HasIdNameList<T> array) {
            this.list.AddRange(array);
        }
    }
}
