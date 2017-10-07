using System.Collections.Generic;
using MoKakebo.Framework.Model.Abstract;

namespace MoKakebo.Model {
    /// <summary>
    /// 摘要マスタ
    /// </summary>
    public class SummaryCollection : HasIdObjectList<Summary> {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SummaryCollection() {
            this.list = new List<Summary>();
        }
    }
}
