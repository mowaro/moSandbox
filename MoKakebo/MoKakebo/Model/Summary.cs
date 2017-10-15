using System;
using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Model {
    /// <Summary>
    /// 摘要
    /// </Summary>
    public class Summary : IHasIdName, IHasLatestUsed {
        /// <Summary>ID</Summary>
        public long Id { get; protected set; }
        /// <Summary>名称</Summary>
        public string Name { get; protected set; }
        /// <Summary>勘定科目</Summary>
        public Subaccount Subaccount { get; protected set; }
        /// <Summary>最終使用日</Summary>
        public DateTime LatestUsed { get; protected set; }

        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        /// <param Name="id">ID</param>
        /// <param Name="name">名称</param>
        /// <param Name="subaccount">勘定科目</param>
        /// <param Name="latestUsed">最終使用日</param>
        public Summary(long id, string name, Subaccount subaccount, DateTime latestUsed) {
            this.Id = id;
            this.Name = name;
            this.Subaccount = subaccount;
            this.LatestUsed = latestUsed;
        }
        
        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        public Summary() {
            this.Id = Const.DefaultValue.LONG;
            this.Name = Const.DefaultValue.STRING;
            this.Subaccount = new Subaccount();
            this.LatestUsed = Const.DefaultValue.DATE;
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
