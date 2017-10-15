using System;
using System.Collections.Generic;

using MoKakebo.Framework.Model.Abstract;

namespace MoKakebo.Model {
    /// <Summary>
    /// 勘定科目コレクション
    /// </Summary>
    public class SubaccountCollection :  HasIdNameList<Subaccount> {
        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        public SubaccountCollection() {
            this.list = new List<Subaccount>();
        }

        /// <Summary>
        /// 最後に使用した勘定科目を取得する
        /// </Summary>
        /// <returns>最後に使用した勘定科目</returns>
        public Subaccount getLatestUsed() {
            if (this.list == null || this.list.Count == 0) {
                return null;
            }

            List<Subaccount> temp = new List<Subaccount>();
            temp.AddRange(this.list.ToArray());
            LatestUsedDateDescSorter sorter = new LatestUsedDateDescSorter();
            temp.Sort(sorter);
            return temp[0];
        }

        /// <summary>
        /// 指定した比較クラスに従いソートする
        /// </summary>
        /// <param name="comparer"></param>
        public void sort(IComparer<Subaccount> comparer) {
            this.list.Sort(comparer);
        }

        /// <Summary>
        /// 最終使用日 降順ソート用比較クラス
        /// </Summary>
        public class LatestUsedDateDescSorter : IComparer<Subaccount> {
            public int Compare(Subaccount x, Subaccount y) {
                return y.LatestUsed.CompareTo(x.LatestUsed);
            }
        }
    }
}
