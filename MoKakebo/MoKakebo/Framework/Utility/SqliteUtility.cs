using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MoKakebo.Const;

namespace MoKakebo.Framework.Utility {
    /// <Summary>
    /// SQLiteユーティリティ
    /// </Summary>
    class SqliteUtility {
        /// <Summary>
        /// SQLiteコネクションを取得する
        /// </Summary>
        /// <returns>SQLiteコネクション</returns>
        public static SQLiteConnection getConnection() {
            return new SQLiteConnection("Data Source=" + Config.SQLITE_PATH);
        }

        /// <Summary>
        /// SQLを実行する
        /// </Summary>
        /// <param Name="cmdList">SQLiteコマンドリスト</param>
        /// <returns>コマンド実行により、影響があった行数</returns>
        public static int executeNonQuery(List<Command> cmdList) {
            int result = -1;

            using(SQLiteConnection con = SqliteUtility.getConnection()) {
                con.Open();
                using(SQLiteTransaction tran = con.BeginTransaction()) {
                    foreach(Command cmd in cmdList) {
                        using(SQLiteCommand sqliteCmd = cmd.createCommand(con)) {
                            LogUtility.Print(sqliteCmd);
                            result = sqliteCmd.ExecuteNonQuery();
                        }
                    }
                    tran.Commit();
                }
                con.Close();
            }

            return result;
        }

        /// <Summary>
        /// SQLを実行し、抽出結果を取得する
        /// </Summary>
        /// <param Name="cmd">SQLiteコマンド</param>
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

        /// <Summary>
        /// SQLiteコマンド
        /// </Summary>
        public class Command {
            private string command;
            private List<SQLiteParameter> paramList;

            /// <Summary>
            /// コンストラクタ
            /// </Summary>
            /// <param Name="command">SQL（パラメタ付）</param>
            /// <param Name="paramList">SQLiteパラメタリスト</param>
            public Command(string command, List<SQLiteParameter> paramList) {
                this.command = command;
                this.paramList = paramList;
            }

            /// <Summary>
            /// SQLiteコマンド生成
            /// </Summary>
            /// <param Name="con">SQLiteコネクション</param>
            /// <returns>SQLiteコマンド</returns>
            public SQLiteCommand createCommand(SQLiteConnection con) {
                SQLiteCommand cmd = con.CreateCommand();
                cmd.CommandText = this.command;
                this.paramList.ForEach(param => cmd.Parameters.Add(param));
                return cmd;
            }
        }

        /// <Summary>
        /// データ行コンバータ
        /// </Summary>
        public static class DataRowConverter {
            /// <Summary>
            /// DataRowから値を取得する
            /// </Summary>
            /// <typeparam Name="T">変換する型</typeparam>
            /// <param Name="dr">DataRow</param>
            /// <param Name="columnName">カラム名</param>
            /// <returns>値</returns>
            public static T getValue<T>(DataRow dr, string columnName) {
                T result = default(T);

                if(dr.IsNull(columnName) || string.IsNullOrWhiteSpace(dr[columnName].ToString())) {
                    result = default(T);
                }
                else if(typeof(T).IsPrimitive) {
                    result = dr.Field<T>(columnName);
                }
                else if(typeof(T).Equals(typeof(string))) {
                    result = dr.Field<T>(columnName);
                }
                else {
                    result = (T)typeof(T).InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod, null, null, new object[] { dr[columnName] });
                }

                return result;
            }
        }

    }
}
