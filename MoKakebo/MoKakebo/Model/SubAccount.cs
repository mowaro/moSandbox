using System;
using MoKakebo.Framework.Model.Interface;
using MoKakebo.Const;

namespace MoKakebo.Model {
    /// <Summary>
    /// 勘定科目
    /// </Summary>
    public class Subaccount : IHasIdName, IHasLatestUsed{
        /// <Summary>ID</Summary>
        public long Id { get; protected set; }
        /// <Summary>名称</Summary>
        public string Name { get; protected set; }
        /// <Summary>科目</Summary>
        public Account Account { get; protected set; }
        /// <Summary>最終使用日</Summary>
        public DateTime LatestUsed { get; protected set; }

        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        /// <param Name="id">ID</param>
        /// <param Name="Name">名称</param>
        /// <param Name="Account">科目</param>
        /// <param Name="LatestUsed">最終使用日</param>
        public Subaccount(long id, string name, Account account, DateTime latestUsed) {
            this.Id = id;
            this.Name = name;
            this.Account = account;
            this.LatestUsed = latestUsed;
        }

        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        public Subaccount() {
            this.Id = DefaultValue.LONG;
            this.Name = DefaultValue.STRING;
            this.Account = new Account(Account.VALUE_DEFAULT);
            this.LatestUsed = DefaultValue.DATE;
        }

        #region IHasIdName implement
        public bool Equals(IHasId obj) {
            return this.Equals(obj.Id);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }
        #endregion

    }
}
