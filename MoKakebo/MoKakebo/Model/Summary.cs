using System;
using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Model {
    /// <summary>
    /// 摘要
    /// </summary>
    public class Summary : IHasIdObject {
        /// <summary>ID</summary>
        public long id { get; protected set; }
        /// <summary>名称</summary>
        public string name { get; protected set; }
        /// <summary>勘定科目</summary>
        public Subaccount subaccount { get; protected set; }
        /// <summary>最終使用日</summary>
        public DateTime latestUsed { get; protected set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <param name="subaccount">勘定科目</param>
        /// <param name="latestUsed">最終使用日</param>
        public Summary(long id, string name, Subaccount subaccount, DateTime latestUsed) {
            this.id = id;
            this.name = name;
            this.subaccount = subaccount;
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
