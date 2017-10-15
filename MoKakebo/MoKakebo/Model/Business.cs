using System;
using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Model {
    /// <Summary>
    /// 取引
    /// </Summary>
    public class Business : IHasId, IHasDate {
        /// <Summary>ID</Summary>
        public long Id { get; protected set; }
        /// <Summary>摘要</Summary>
        public Summary Summary { get; protected set; }
        /// <Summary>取引日時</Summary>
        public DateTime Date { get; protected set; }
        /// <Summary>金額</Summary>
        public double Amount { get; protected set; }
        /// <Summary>注釈</Summary>
        public string Comment { get; protected set; }

        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        /// <param Name="id">ID</param>
        /// <param Name="summary">摘要</param>
        /// <param Name="date">取引日時</param>
        /// <param Name="amount">金額</param>
        /// <param Name="comment">コメント</param>
        public Business(long id, Summary summary, DateTime date, double amount, string comment) {
            this.Id = id;
            this.Summary = summary;
            this.Date = date;
            this.Amount = amount;
            this.Comment = comment;
        }

        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        public Business() {
            this.Id = Const.DefaultValue.LONG;
            this.Summary = new Summary();
            this.Date = Const.DefaultValue.DATE;
            this.Amount = Const.DefaultValue.DOUBLE;
            this.Comment = Const.DefaultValue.STRING;
        }

        #region IHasIdObject implement
        public bool Equals(IHasId obj) {
            return this.Equals(obj.Id);
        }

        public override int GetHashCode() {
            return this.Id.GetHashCode();
        }

        #endregion
    }
}
