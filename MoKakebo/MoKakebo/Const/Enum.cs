using System.Collections.Generic;

namespace MoKakebo.Const {
    /// <summary>列挙型</summary>
    public class Enum {
        /// <summary>科目</summary>
        public enum Account {
            /// <summary>デフォルト</summary>
            Default,
            /// <summary>収益</summary>
            Profit,
            /// <summary>費用</summary>
            Loss,
        }

        /// <summary>集計タイプ</summary>
        public enum GroupingType {
            /// <summary>日付</summary>
            Date,
            /// <summary>科目</summary>
            Account,
            /// <summary>勘定科目</summary>
            Subaccount,
        }

        /// <summary>ソートキー</summary>
        public enum SortKey {
            /// <summary>ID</summary>
            Id,
            /// <summary>最終使用日</summary>
            LatestUsed,
        }

    }
}
