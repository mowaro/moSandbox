using System;
using System.Collections;
using System.Collections.Generic;
using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Model {
    /// <summary>
    /// 勘定科目
    /// </summary>
    public class Subaccount : IHasIdObject{
        /// <summary>ID</summary>
        public long id { get; protected set; }
        /// <summary>名称</summary>
        public string name { get; protected set; }
        /// <summary>科目</summary>
        public Const.Enum.Account account { get; protected set; }
        /// <summary>最終使用日</summary>
        public DateTime latestUsed { get; protected set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <param name="account">科目</param>
        /// <param name="latestUsed">最終使用日</param>
        public Subaccount(long id, string name, Const.Enum.Account account, DateTime latestUsed) {
            this.id = id;
            this.name = name;
            this.account = account;
            this.latestUsed = latestUsed;
        }

        #region IHasIdObject implement
        public bool Equals(IHasIdObject obj) {
            return this.Equals(obj.id);
        }

        public bool Equals(long id) {
            return this.id.Equals(id);
        }

        public override int GetHashCode() {
            return this.id.GetHashCode();
        }

        #endregion

    }
}
