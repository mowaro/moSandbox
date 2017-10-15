using System.Collections.Generic;
using MoKakebo.Framework.Model.Abstract;

namespace MoKakebo.Model {
    /// <Summary>
    /// 摘要マスタ
    /// </Summary>
    public class SummaryCollection : HasIdNameList<Summary> {
        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        public SummaryCollection() {
            this.list = new List<Summary>();
        }

        /// <Summary>
        /// 最後に使用した摘要を取得する
        /// </Summary>
        /// <returns>最後に使用した摘要</returns>
        public Summary getLatestUsed() {
            if(this.list == null || this.list.Count == 0) {
                return null;
            }

            List<Summary> temp = new List<Summary>();
            temp.AddRange(this.list.ToArray());
            LatestUsedDateDescSorter sorter = new LatestUsedDateDescSorter();
            temp.Sort(sorter);
            return temp[0];
        }

        /// <summary>
        /// 指定した比較クラスに従いソートする
        /// </summary>
        /// <param name="comparer"></param>
        public void sort(IComparer<Summary> comparer) {
            this.list.Sort(comparer);
        }

        /// <Summary>
        /// 最終使用日 降順ソート用比較クラス
        /// </Summary>
        public class LatestUsedDateDescSorter : IComparer<Summary> {
            public int Compare(Summary x, Summary y) {
                return y.LatestUsed.CompareTo(x.LatestUsed);
            }
        }
    }
}
