using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoKakebo.Dao.Interface;
using MoKakebo.Framework.Utility;
using MoKakebo.Model;

namespace MoKakebo.Dao.RDB.SQLiteImplement {
    /// <summary>取引DAO SQLite実装クラス</summary>
    public class BusinessDaoImpl : IBusinessDao {
        /// <summary>テーブル名</summary>
        private static string TABLE_NAME = "TRAN_BUSINESS";
        /// <summary>カラム名_ID</summary>
        private static string COL_ID = "ID";
        /// <summary>カラム名_摘要</summary>
        private static string COL_SUMMARY = "SUMMARY";
        /// <summary>カラム名_日付</summary>
        private static string COL_DATE = "DATE";
        /// <summary>カラム名_金額</summary>
        private static string COL_AMOUNT = "AMOUNT";
        /// <summary>カラム名_備考</summary>
        private static string COL_COMMENT = "COMMENT";

        /// <summary>
        /// 条件に従いDB問い合わせ、取引コレクションを返す
        /// </summary>
        /// <param name="cmd">SQLiteコマンド</param>
        /// <returns>取引コレクション</returns>
        private BusinessCollection select(SqliteUtility.Command cmd) {
            BusinessCollection result = new BusinessCollection();
            DataTable dt = SqliteUtility.select(cmd);
            foreach(DataRow row in dt.Rows) {
                Summary summary
                    = AppCache.getInstance().getSummaryMaster().get(
                        SqliteUtility.DataRowConverter.getValue<long>(row, COL_SUMMARY));

                result.Add(new Business(
                    SqliteUtility.DataRowConverter.getValue<long>(row, COL_ID),
                    summary,
                    SqliteUtility.DataRowConverter.getValue<DateTime>(row, COL_DATE),
                    SqliteUtility.DataRowConverter.getValue<double>(row, COL_AMOUNT),
                    SqliteUtility.DataRowConverter.getValue<string>(row, COL_COMMENT)));
            }
            return result;
        }

        #region BusinessDao implement
        /// <summary>
        /// レコード削除
        /// </summary>
        /// <param name="idList">削除対象IDリスト</param>
        /// <returns>削除件数</returns>
        public int delete(List<long> idList) {
            string sql = $"delete {TABLE_NAME} where {COL_ID}=@{COL_ID}";
            List<SqliteUtility.Command> cmdList = new List<SqliteUtility.Command>();

            foreach(long id in idList) {
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
        public int register(BusinessCollection objCollection) {
            if(objCollection.Count == 0) {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"INSERT");
            sql.AppendLine($"INTO {TABLE_NAME} (");
            sql.AppendLine($"{COL_ID}, ");
            sql.AppendLine($"{COL_SUMMARY}, ");
            sql.AppendLine($"{COL_DATE}, ");
            sql.AppendLine($"{COL_AMOUNT}, ");
            sql.AppendLine($"{COL_COMMENT}) ");
            sql.AppendLine($"VALUES (");
            sql.AppendLine($"@{COL_ID}, ");
            sql.AppendLine($"@{COL_SUMMARY}, ");
            sql.AppendLine($"@{COL_DATE}, ");
            sql.AppendLine($"@{COL_AMOUNT}, ");
            sql.AppendLine($"@{COL_COMMENT}) ");
            List<SqliteUtility.Command> cmdList = new List<SqliteUtility.Command>();

            foreach(Business obj in objCollection) {
                List<SQLiteParameter> prmList = new List<SQLiteParameter>();
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.id));
                prmList.Add(new SQLiteParameter($"@{COL_SUMMARY}", obj.summary.id));
                prmList.Add(new SQLiteParameter($"@{COL_DATE}", obj.date.ToString("yyyy/MM/dd")));
                prmList.Add(new SQLiteParameter($"@{COL_AMOUNT}", obj.amount));
                prmList.Add(new SQLiteParameter($"@{COL_COMMENT}", obj.comment));

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
        public int register(Business obj) {
            return register(new BusinessCollection() { obj });
        }

        /// <summary>
        /// レコード更新
        /// </summary>
        /// <param name="objCollection">更新対象アイテムリスト</param>
        /// <returns>更新件数</returns>
        public int update(BusinessCollection objCollection) {
            if(objCollection.Count == 0) {
                throw new ArgumentOutOfRangeException();
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"UPDATE ");
            sql.AppendLine($"{TABLE_NAME} ");
            sql.AppendLine($"SET ");
            sql.AppendLine($"{COL_SUMMARY}=@{COL_SUMMARY}, ");
            sql.AppendLine($"{COL_DATE}=@{COL_DATE}, ");
            sql.AppendLine($"{COL_AMOUNT}=@{COL_AMOUNT}, ");
            sql.AppendLine($"{COL_COMMENT}=@{COL_COMMENT} ");
            sql.AppendLine($"WHERE ");
            sql.AppendLine($"{COL_ID}=@{COL_ID}");
            List<SqliteUtility.Command> cmdList = new List<SqliteUtility.Command>();

            foreach(Business obj in objCollection) {
                List<SQLiteParameter> prmList = new List<SQLiteParameter>();
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.id));
                prmList.Add(new SQLiteParameter($"@{COL_SUMMARY}", obj.summary.id));
                prmList.Add(new SQLiteParameter($"@{COL_DATE}", obj.date.ToString("yyyy/MM/dd")));
                prmList.Add(new SQLiteParameter($"@{COL_AMOUNT}", obj.amount));
                prmList.Add(new SQLiteParameter($"@{COL_COMMENT}", obj.comment));

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
        public int update(Business obj) {
            return update(new BusinessCollection() { obj });
        }

        /// <summary>
        /// テーブル全件取得する
        /// </summary>
        /// <returns>テーブル全件</returns>
        public BusinessCollection selectAll() {
            return selectWhereDateBetween(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// 指定された摘要に紐づくレコードを取得する
        /// </summary>
        /// <param name="summaryCollection">指定する摘要</param>
        /// <returns>指定された摘要に紐づくレコード</returns>
        public BusinessCollection selectWhereSummaryIn(SummaryCollection summaryCollection) {
            BusinessCollection result = new BusinessCollection();
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_SUMMARY}=@{COL_SUMMARY}";

            foreach(Summary targetSummary in summaryCollection) {
                result.AddRange(select(
                    new SqliteUtility.Command(
                        sql,
                        new List<SQLiteParameter>() { new SQLiteParameter($"@{COL_SUMMARY}", targetSummary.id) })));
            }

            return result;
        }

        /// <summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </summary>
        /// <param name="start">開始日付</param>
        /// <param name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        public BusinessCollection selectWhereDateBetween(DateTime start, DateTime end) {
            string startParam = "@start";
            string endParam = "@end";
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_DATE} BETWEEN {startParam} and {endParam}";

            string dateFormat = "yyyy/MM/dd";
            List<SQLiteParameter> prmList = new List<SQLiteParameter>();
            prmList.Add(new SQLiteParameter(startParam, start.ToString(dateFormat)));
            prmList.Add(new SQLiteParameter(endParam, end.ToString(dateFormat)));

            return select(new SqliteUtility.Command(sql, prmList));
        }

        #endregion
    }

}
