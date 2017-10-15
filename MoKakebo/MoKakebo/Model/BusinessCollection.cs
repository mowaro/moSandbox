using System.Collections.Generic;
using MoKakebo.Framework.Model.Abstract;

namespace MoKakebo.Model {
    public class BusinessCollection : HasIdList<Business> {

        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        public BusinessCollection() {
            this.list = new List<Business>();
        }

        /// <summary>
        /// 指定した比較クラスに従いソートする
        /// </summary>
        /// <param name="comparer"></param>
        public void sort(IComparer<Business> comparer) {
            this.list.Sort(comparer);
        }

        /// <Summary>
        /// 日付 降順ソート用比較クラス
        /// </Summary>
        public class DateDescSorter : IComparer<Business> {
            public int Compare(Business x, Business y) {
                return y.Date.CompareTo(x.Date);
            }
        }


    }
}
