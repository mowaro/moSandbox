using System.Collections.Generic;

using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Const {
    public class Account: IHasIdName {
        public static readonly int VALUE_DEFAULT = -1;
        public static readonly int VALUE_LOSS = 0;
        public static readonly int VALUE_PROFIT = 1;

        public static List<Account> getList() {
            List<Account> list = new List<Account>() {
                new Account(VALUE_LOSS, "費用") ,
                new Account(VALUE_PROFIT, "収益") ,};

            return list;
        }

        private Account(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        public Account(long value) {
            long tempId;
            string tempName;
            List<Account> temp = getList();
            List<Account> matches = temp.FindAll(item => item.Id.Equals(value));
            if (matches == null || matches.Count == 0) {
                tempId = temp[0].Id;
                tempName = temp[0].Name; 
            } else {
                tempId = matches[0].Id;
                tempName = matches[0].Name;
            }

            this.Id = tempId;
            this.Name = tempName;
        }

        #region IHasIdName Implement
        public long Id { get; private set; }
        public string Name { get; private set; }

        public bool Equals(IHasId other) {
            return this.Id.Equals(other.Id);
        }
        #endregion
    }
}
