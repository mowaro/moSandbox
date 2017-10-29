using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MoKakebo.Framework.Utility;

using MoKakebo.Dao.Interface;
using MoKakebo.Model;
using System.Text;
using MoKakebo.Const;

namespace MoKakebo.Dao.RDB.SQLiteImplement {
    /// <Summary>勘定科目DAO SQLite実装クラス</Summary>
    public class SubaccountDaoImpl : ISubaccountDao {
        /// <Summary>テーブル名</Summary>
        private static string TABLE_NAME = "MASTER_SUBACCOUNT";
        /// <Summary>カラム名_ID</Summary>
        private static string COL_ID = "ID";
        /// <Summary>カラム名_名前</Summary>
        private static string COL_NAME = "NAME";
        /// <Summary>カラム名_科目</Summary>
        private static string COL_ACCOUNT = "ACCOUNT";
        /// <Summary>カラム名_最終使用日</Summary>
        private static string COL_LATEST_USED = "LATEST_USED";
        /// <Summary>並び順</Summary>
        private static string ORDER = $"ORDER BY {COL_LATEST_USED} DESC";

        /// <Summary>
        /// 条件に従いDB問い合わせ、勘定科目コレクションを返す
        /// </Summary>
        /// <param Name="cmd">SQLiteコマンド</param>
        /// <returns>勘定科目コレクション</returns>
        private SubaccountCollection select(SqliteUtility.Command cmd) {
            SubaccountCollection result = new SubaccountCollection();
            DataTable dt = SqliteUtility.select(cmd);
            foreach(DataRow row in dt.Rows) {
                try {
                    Account account = new Account(SqliteUtility.DataRowConverter.getValue<long>(row, COL_ACCOUNT));
                    DateTime latestUsed = DateTime.Parse(SqliteUtility.DataRowConverter.getValue<string>(row, COL_LATEST_USED));
                    Subaccount subaccount = new Subaccount(
                        SqliteUtility.DataRowConverter.getValue<long>(row, COL_ID),
                        SqliteUtility.DataRowConverter.getValue<string>(row, COL_NAME),
                        account,
                        latestUsed);
                    result.Add(subaccount);
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
            return result;
        }

        #region SubaccountDao implement
        /// <Summary>
        /// レコード削除
        /// </Summary>
        /// <param Name="idList">削除対象IDリスト</param>
        /// <returns>削除件数</returns>
        public int delete(List<long> idList) {
            string sql = $"delete {TABLE_NAME} where {COL_ID}=@{COL_ID}";
            List<SqliteUtility.Command> cmdList = new List<SqliteUtility.Command>(); 

            foreach (long id in idList) {
                cmdList.Add(new SqliteUtility.Command(
                    sql,
                    new List<SQLiteParameter>() { new SQLiteParameter($"@{COL_ID}", id) }));
            }

            return SqliteUtility.executeNonQuery(cmdList);
        }

        /// <Summary>
        /// レコード削除
        /// </Summary>
        /// <param Name="id">削除対象ID</param>
        /// <returns>削除件数</returns>
        public int delete(long id) {
            return this.delete(new List<long>() { id });
        }

        /// <Summary>
        /// レコード登録
        /// </Summary>
        /// <param Name="objCollection">登録対象アイテムリスト</param>
        /// <returns>登録件数</returns>
        public int register(SubaccountCollection objCollection) {
            if (objCollection.Count == 0) {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"INSERT");
            sql.AppendLine($"INTO {TABLE_NAME} (");
            sql.AppendLine($"{COL_ID}, ");
            sql.AppendLine($"{COL_NAME}, ");
            sql.AppendLine($"{COL_ACCOUNT}, ");
            sql.AppendLine($"{COL_LATEST_USED}) ");
            sql.AppendLine($"VALUES (");
            sql.AppendLine($"@{COL_ID}, ");
            sql.AppendLine($"@{COL_NAME}, ");
            sql.AppendLine($"@{COL_ACCOUNT}, ");
            sql.AppendLine($"@{COL_LATEST_USED}) ");
            List<SqliteUtility.Command> cmdList = new List<SqliteUtility.Command>();

            foreach(Subaccount obj in objCollection) {
                List<SQLiteParameter> prmList = new List<SQLiteParameter>();
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.Id));
                prmList.Add(new SQLiteParameter($"@{COL_NAME}", obj.Name));
                prmList.Add(new SQLiteParameter($"@{COL_ACCOUNT}", obj.Account.Id));
                prmList.Add(new SQLiteParameter($"@{COL_LATEST_USED}", obj.LatestUsed.ToString("yyyy/MM/dd")));

                cmdList.Add(new SqliteUtility.Command(
                    sql.ToString(),
                    prmList));
            }

            return SqliteUtility.executeNonQuery(cmdList);
        }

        /// <Summary>
        /// レコード登録
        /// </Summary>
        /// <param Name="obj">登録対象アイテム</param>
        /// <returns>登録件数</returns>
        public int register(Subaccount obj) {
            return register(new SubaccountCollection() { obj });
        }

        /// <Summary>
        /// レコード更新
        /// </Summary>
        /// <param Name="objCollection">更新対象アイテムリスト</param>
        /// <returns>更新件数</returns>
        public int update(SubaccountCollection objCollection) {
            if(objCollection.Count == 0) {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"UPDATE ");
            sql.AppendLine($"{TABLE_NAME} ");
            sql.AppendLine($"SET ");
            sql.AppendLine($"{COL_NAME}=@{COL_NAME}, ");
            sql.AppendLine($"{COL_ACCOUNT}=@{COL_ACCOUNT}, ");
            sql.AppendLine($"{COL_LATEST_USED}=@{COL_LATEST_USED} ");
            sql.AppendLine($"WHERE ");
            sql.AppendLine($"{COL_ID}=@{COL_ID}");
            List<SqliteUtility.Command> cmdList = new List<SqliteUtility.Command>();

            foreach(Subaccount obj in objCollection) {
                List<SQLiteParameter> prmList = new List<SQLiteParameter>();
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.Id));
                prmList.Add(new SQLiteParameter($"@{COL_NAME}", obj.Name));
                prmList.Add(new SQLiteParameter($"@{COL_ACCOUNT}", obj.Account.Id));
                prmList.Add(new SQLiteParameter($"@{COL_LATEST_USED}", obj.LatestUsed.ToString("yyyy/MM/dd")));

                cmdList.Add(new SqliteUtility.Command(
                    sql.ToString(),
                    prmList));
            }

            return SqliteUtility.executeNonQuery(cmdList);
        }

        /// <Summary>
        /// レコード更新
        /// </Summary>
        /// <param Name="obj">更新対象アイテム</param>
        /// <returns>更新件数</returns>
        public int update(Subaccount obj) {
            return update(new SubaccountCollection() { obj });
        }

        /// <Summary>
        /// テーブル全件取得する
        /// </Summary>
        /// <returns>テーブル全件</returns>
        public SubaccountCollection selectAll() {
            return select(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <Summary>
        /// 指定された科目に紐づくレコードを取得する
        /// </Summary>
        /// <param Name="accountCollection">指定する科目</param>
        /// <returns>指定された科目に紐づくレコード</returns>
        public SubaccountCollection select(List<Account> accountCollection) {
            SubaccountCollection result = new SubaccountCollection();
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_ACCOUNT}=@{COL_ACCOUNT} {ORDER}";

            foreach(Account targetAccount in accountCollection) {
                result.AddRange(select(
                    new SqliteUtility.Command(
                        sql,
                        new List<SQLiteParameter>() { new SQLiteParameter($"@{COL_ACCOUNT}", targetAccount.Id) })));
            }

            return result;
        }

        /// <Summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </Summary>
        /// <param Name="start">開始日付</param>
        /// <param Name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        public SubaccountCollection select(DateTime start, DateTime end) {
            string startParam = "@start";
            string endParam = "@end";
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_LATEST_USED} BETWEEN {startParam} and {endParam} {ORDER}";

            string dateFormat = "yyyy/MM/dd";
            List<SQLiteParameter> prmList = new List<SQLiteParameter>();
            prmList.Add(new SQLiteParameter(startParam, start.ToString(dateFormat)));
            prmList.Add(new SQLiteParameter(endParam, end.ToString(dateFormat)));

            return select(new SqliteUtility.Command(sql, prmList));
        }

        #endregion
    }
}
