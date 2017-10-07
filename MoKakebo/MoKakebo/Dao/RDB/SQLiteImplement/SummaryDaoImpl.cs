using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MoKakebo.Framework.Utility;

using MoKakebo.Dao.Interface;
using MoKakebo.Model;
using System.Text;

namespace MoKakebo.Dao.RDB.SQLiteImplement {
    /// <summary>摘要DAO SQLite実装クラス</summary>
    public class SummaryDaoImpl : ISummaryDao {
        /// <summary>テーブル名</summary>
        private static string TABLE_NAME = "MASTER_SUMMARY";
        /// <summary>カラム名_ID</summary>
        private static string COL_ID = "ID";
        /// <summary>カラム名_名前</summary>
        private static string COL_NAME = "NAME";
        /// <summary>カラム名_勘定科目</summary>
        private static string COL_SUBACCOUNT = "SUBACCOUNT";
        /// <summary>カラム名_最終使用日</summary>
        private static string COL_LATEST_USED = "LATEST_USED";
        
        /// <summary>
        /// 条件に従いDB問い合わせ、摘要コレクションを返す
        /// </summary>
        /// <param name="cmd">SQLiteコマンド</param>
        /// <returns>摘要コレクション</returns>
        private SummaryCollection select(SqliteUtility.Command cmd) {
            SummaryCollection result = new SummaryCollection();
            DataTable dt = SqliteUtility.select(cmd);
            foreach(DataRow row in dt.Rows) {
                Subaccount subaccount 
                    = AppCache.getInstance().getSubaccountMaster().get(
                        SqliteUtility.DataRowConverter.getValue<long>(row, COL_SUBACCOUNT));

                result.Add(new Summary(
                    SqliteUtility.DataRowConverter.getValue<long>(row, COL_ID),
                    SqliteUtility.DataRowConverter.getValue<string>(row, COL_NAME),
                    subaccount,
                    SqliteUtility.DataRowConverter.getValue<DateTime>(row, COL_LATEST_USED)));
            }
            return result;
        }

        #region SummaryDao implement
        /// <summary>
        /// レコード削除
        /// </summary>
        /// <param name="idList">削除対象IDリスト</param>
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

        /// <summary>
        /// レコード削除
        /// </summary>
        /// <param name="id">削除対象ID</param>
        /// <returns>削除件数</returns>
        public int delete(long id) {
            return this.delete(new List<long>() { id });
        }

        /// <summary>
        /// レコード登録
        /// </summary>
        /// <param name="objCollection">登録対象アイテムリスト</param>
        /// <returns>登録件数</returns>
        public int register(SummaryCollection objCollection) {
            if (objCollection.Count == 0) {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"INSERT");
            sql.AppendLine($"INTO {TABLE_NAME} (");
            sql.AppendLine($"{COL_ID}, ");
            sql.AppendLine($"{COL_NAME}, ");
            sql.AppendLine($"{COL_SUBACCOUNT}, ");
            sql.AppendLine($"{COL_LATEST_USED}) ");
            sql.AppendLine($"VALUES (");
            sql.AppendLine($"@{COL_ID}, ");
            sql.AppendLine($"@{COL_NAME}, ");
            sql.AppendLine($"@{COL_SUBACCOUNT}, ");
            sql.AppendLine($"@{COL_LATEST_USED}) ");
            List<SqliteUtility.Command> cmdList = new List<SqliteUtility.Command>();

            foreach(Summary obj in objCollection) {
                List<SQLiteParameter> prmList = new List<SQLiteParameter>();
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.id));
                prmList.Add(new SQLiteParameter($"@{COL_NAME}", obj.name));
                prmList.Add(new SQLiteParameter($"@{COL_SUBACCOUNT}", obj.subaccount));
                prmList.Add(new SQLiteParameter($"@{COL_LATEST_USED}", obj.latestUsed.ToString("yyyy/MM/dd")));

                cmdList.Add(new SqliteUtility.Command(
                    sql.ToString(),
                    prmList));
            }

            return SqliteUtility.executeNonQuery(cmdList);
        }

        /// <summary>
        /// レコード登録
        /// </summary>
        /// <param name="obj">登録対象アイテム</param>
        /// <returns>登録件数</returns>
        public int register(Summary obj) {
            return register(new SummaryCollection() { obj });
        }

        /// <summary>
        /// レコード更新
        /// </summary>
        /// <param name="objCollection">更新対象アイテムリスト</param>
        /// <returns>更新件数</returns>
        public int update(SummaryCollection objCollection) {
            if(objCollection.Count == 0) {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"UPDATE ");
            sql.AppendLine($"{TABLE_NAME} ");
            sql.AppendLine($"SET ");
            sql.AppendLine($"{COL_NAME}=@{COL_NAME}, ");
            sql.AppendLine($"{COL_SUBACCOUNT}=@{COL_SUBACCOUNT}, ");
            sql.AppendLine($"{COL_LATEST_USED}=@{COL_LATEST_USED} ");
            sql.AppendLine($"WHERE ");
            sql.AppendLine($"{COL_ID}=@{COL_ID}");
            List<SqliteUtility.Command> cmdList = new List<SqliteUtility.Command>();

            foreach(Summary obj in objCollection) {
                List<SQLiteParameter> prmList = new List<SQLiteParameter>();
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.id));
                prmList.Add(new SQLiteParameter($"@{COL_NAME}", obj.name));
                prmList.Add(new SQLiteParameter($"@{COL_SUBACCOUNT}", obj.subaccount));
                prmList.Add(new SQLiteParameter($"@{COL_LATEST_USED}", obj.latestUsed.ToString("yyyy/MM/dd")));

                cmdList.Add(new SqliteUtility.Command(
                    sql.ToString(),
                    prmList));
            }

            return SqliteUtility.executeNonQuery(cmdList);
        }

        /// <summary>
        /// レコード更新
        /// </summary>
        /// <param name="obj">更新対象アイテム</param>
        /// <returns>更新件数</returns>
        public int update(Summary obj) {
            return update(new SummaryCollection() { obj });
        }

        /// <summary>
        /// テーブル全件取得する
        /// </summary>
        /// <returns>テーブル全件</returns>
        public SummaryCollection selectAll() {
            return selectWhereLatestDateBetween(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// 指定された勘定科目に紐づくレコードを取得する
        /// </summary>
        /// <param name="subaccountCollection">指定する勘定科目</param>
        /// <returns>指定された勘定科目に紐づくレコード</returns>
        public SummaryCollection selectWhereSubaccountIn(SubaccountCollection subaccountCollection) {
            SummaryCollection result = new SummaryCollection();
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_SUBACCOUNT}=@{COL_SUBACCOUNT}";

            foreach(Subaccount targetSubaccount in subaccountCollection) {
                result.AddRange(select(
                    new SqliteUtility.Command(
                        sql, 
                        new List<SQLiteParameter>() { new SQLiteParameter($"@{COL_SUBACCOUNT}", targetSubaccount.id) })));
            }

            return result;
        }

        /// <summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </summary>
        /// <param name="start">開始日付</param>
        /// <param name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        public SummaryCollection selectWhereLatestDateBetween(DateTime start, DateTime end) {
            string startParam = "@start";
            string endParam = "@end";
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_LATEST_USED} BETWEEN {startParam} and {endParam}";

            string dateFormat = "yyyy/MM/dd";
            List<SQLiteParameter> prmList = new List<SQLiteParameter>();
            prmList.Add(new SQLiteParameter(startParam, start.ToString(dateFormat)));
            prmList.Add(new SQLiteParameter(endParam, end.ToString(dateFormat)));

            return select(new SqliteUtility.Command(sql, prmList));
        }

        #endregion
    }
}
