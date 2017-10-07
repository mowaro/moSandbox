using System.Collections.Generic;

using MoKakebo.Framework.Model.Abstract;

namespace MoKakebo.Model {
    /// <summary>
    /// 勘定科目コレクション
    /// </summary>
    public class SubaccountCollection :  HasIdObjectList<Subaccount>{
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SubaccountCollection() {
            this.list = new List<Subaccount>();
        }
    }
}
