using System.Collections.Generic;
using MoKakebo.Framework.Model.Abstract;

namespace MoKakebo.Model {
    public class BusinessCollection : HasIdObjectList<Business> {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BusinessCollection() {
            this.list = new List<Business>();
        }
    }
}
