using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MoKakebo.Const;

namespace MoKakebo.Framework.Utility {
    /// <summary>
    /// SQLiteユーティリティ
    /// </summary>
    class SqliteUtility {
        /// <summary>
        /// SQLiteコネクションを取得する
        /// </summary>
        /// <returns>SQLiteコネクション</returns>
        public static SQLiteConnection getConnection() {
            return new SQLiteConnection("Data Source=" + Config.SQLITE_PATH);
        }

        /// <summary>
        /// SQLを実行する
        /// </summary>
        /// <param name="cmdList">SQLiteコマンドリスト</param>
        /// <returns>コマンド実行により、影響があった行数</returns>
        public static int executeNonQuery(List<Command> cmdList) {
            int result = -1;

            using(SQLiteConnection con = SqliteUtility.getConnection()) {
                con.Open();
                using(SQLiteTransaction tran = con.BeginTransaction()) {
                    foreach(Command cmd in cmdList) {
                        using(SQLiteCommand sqliteCmd = cmd.createCommand(con)) {
                            result = sqliteCmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                con.Close();
            }

            return result;
        }

        /// <summary>
        /// SQLを実行し、抽出結果を取得する
        /// </summary>
        /// <param name="cmd">SQLiteコマンド</param>
        /// <returns>抽出結果</returns>
        public static DataTable select(Command cmd) {
            DataTable result = new DataTable();

            using(SQLiteConnection con = SqliteUtility.getConnection()) {
                con.Open();
                using(SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd.createCommand(con))) {
                    adp.Fill(result);
                }
                con.Clone();
            }
            return result;
        }

        /// <summary>
        /// SQLiteコマンド
        /// </summary>
        public class Command {
            private string command;
            private List<SQLiteParameter> paramList;

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="command">SQL（パラメタ付）</param>
            /// <param name="paramList">SQLiteパラメタリスト</param>
            public Command(string command, List<SQLiteParameter> paramList) {
                this.command = command;
                this.paramList = paramList;
            }

            /// <summary>
            /// SQLiteコマンド生成
            /// </summary>
            /// <param name="con">SQLiteコネクション</param>
            /// <returns>SQLiteコマンド</returns>
            public SQLiteCommand createCommand(SQLiteConnection con) {
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = this.command;
                this.paramList.ForEach(param => cmd.Parameters.Add(param));
                return cmd;
            }
        }

        /// <summary>
        /// データ行コンバータ
        /// </summary>
        public static class DataRowConverter {
            /// <summary>
            /// DataRowから値を取得する
            /// </summary>
            /// <typeparam name="T">変換する型</typeparam>
            /// <param name="dr">DataRow</param>
            /// <param name="columnName">カラム名</param>
            /// <returns>値</returns>
            public static T getValue<T>(DataRow dr, string columnName) {
                return dr.IsNull(columnName) ? default(T) : dr.Field<T>(columnName);
            }
        }

    }
}
