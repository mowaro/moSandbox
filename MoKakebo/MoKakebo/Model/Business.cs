using System;
using MoKakebo.Framework.Model.Interface;

namespace MoKakebo.Model {
    /// <summary>
    /// 取引
    /// </summary>
    public class Business : IHasIdObject {
        /// <summary>ID</summary>
        public long id { get; protected set; }
        /// <summary>摘要</summary>
        public Summary summary { get; protected set; }
        /// <summary>取引日時</summary>
        public DateTime date { get; protected set; }
        /// <summary>金額</summary>
        public double amount { get; protected set; }
        /// <summary>注釈</summary>
        public string comment { get; protected set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="summary">摘要</param>
        /// <param name="date">取引日時</param>
        /// <param name="amount">金額</param>
        /// <param name="comment">コメント</param>
        public Business(long id, Summary summary, DateTime date, double amount, string comment) {
            this.id = id;
            this.summary = summary;
            this.date = date;
            this.amount = amount;
            this.comment = comment;
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
