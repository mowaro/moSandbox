using System.Collections.Generic;

namespace MoKakebo.Const {
    /// <Summary>列挙型</Summary>
    public class Enum {
        /// <Summary>科目</Summary>
        public enum Account {
            /// <Summary>デフォルト</Summary>
            Default,
            /// <Summary>収益</Summary>
            Profit,
            /// <Summary>費用</Summary>
            Loss,
        }

        public enum InputMode {
            /// <Summary>デフォルト</Summary>
            Default,
            /// <Summary>新規追加</Summary>
            Register,
            /// <Summary>変更</Summary>
            Edit,
        }


    }
}
