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
    /// <Summary>取引DAO SQLite実装クラス</Summary>
    public class BusinessDaoImpl : IBusinessDao {
        /// <Summary>テーブル名</Summary>
        private static string TABLE_NAME = "TRAN_BUSINESS";
        /// <Summary>カラム名_ID</Summary>
        private static string COL_ID = "ID";
        /// <Summary>カラム名_摘要</Summary>
        private static string COL_SUMMARY = "SUMMARY_ID";
        /// <Summary>カラム名_日付</Summary>
        private static string COL_DATE = "DATE";
        /// <Summary>カラム名_金額</Summary>
        private static string COL_AMOUNT = "AMOUNT";
        /// <Summary>カラム名_備考</Summary>
        private static string COL_COMMENT = "COMMENT";
        /// <Summary>並び順</Summary>
        private static string ORDER = $"ORDER BY {COL_DATE} DESC";

        /// <Summary>
        /// 条件に従いDB問い合わせ、取引コレクションを返す
        /// </Summary>
        /// <param Name="cmd">SQLiteコマンド</param>
        /// <returns>取引コレクション</returns>
        private BusinessCollection select(SqliteUtility.Command cmd) {
            BusinessCollection result = new BusinessCollection();
            DataTable dt = SqliteUtility.select(cmd);
            foreach(DataRow row in dt.Rows) {
                Summary summary
                    = AppCache.getSummaryMaster().get(
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

        /// <summary>
        /// 摘要に使用した痕跡を残す
        /// </summary>
        /// <param name="obj">使用した取引</param>
        /// <returns>更新件数</returns>
        private int setTraceUsing(Business obj) {
            BusinessCollection collection = new BusinessCollection();
            collection.Add(obj);
            return setTraceUsing(collection);
        }

        /// <summary>
        /// 摘要に使用した痕跡を残す
        /// </summary>
        /// <param name="collection">使用した取引</param>
        /// <returns>更新件数</returns>
        private int setTraceUsing(BusinessCollection collection) {
            SummaryCollection traces = new SummaryCollection();
            foreach(Business obj in collection) {
                traces.Add(new Summary(obj.Summary.Id, obj.Summary.Name, obj.Summary.Subaccount, DateTime.Now));
            }

            SummaryDaoImpl dao = new SummaryDaoImpl();
            return dao.update(traces);
        }

        #region BusinessDao implement
        /// <Summary>
        /// レコード削除
        /// </Summary>
        /// <param Name="idList">削除対象IDリスト</param>
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
                prmList.Add(new SQLiteParameter($"@{COL_ID}", null));
                prmList.Add(new SQLiteParameter($"@{COL_SUMMARY}", obj.Summary.Id));
                prmList.Add(new SQLiteParameter($"@{COL_DATE}", obj.Date.ToString("yyyy/MM/dd")));
                prmList.Add(new SQLiteParameter($"@{COL_AMOUNT}", obj.Amount));
                prmList.Add(new SQLiteParameter($"@{COL_COMMENT}", obj.Comment));

                cmdList.Add(new SqliteUtility.Command(
                    sql.ToString(),
                    prmList));
            }

            int result = -1;
            result = SqliteUtility.executeNonQuery(cmdList);
            setTraceUsing(objCollection);
            return result;
        }

        /// <Summary>
        /// レコード登録
        /// </Summary>
        /// <param Name="obj">登録対象アイテム</param>
        /// <returns>登録件数</returns>
        public int register(Business obj) {
            return register(new BusinessCollection() { obj });
        }

        /// <Summary>
        /// レコード更新
        /// </Summary>
        /// <param Name="objCollection">更新対象アイテムリスト</param>
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
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.Id));
                prmList.Add(new SQLiteParameter($"@{COL_SUMMARY}", obj.Summary.Id));
                prmList.Add(new SQLiteParameter($"@{COL_DATE}", obj.Date.ToString("yyyy/MM/dd")));
                prmList.Add(new SQLiteParameter($"@{COL_AMOUNT}", obj.Amount));
                prmList.Add(new SQLiteParameter($"@{COL_COMMENT}", obj.Comment));

                cmdList.Add(new SqliteUtility.Command(
                    sql.ToString(),
                    prmList));
            }

            int result = -1;
            result = SqliteUtility.executeNonQuery(cmdList);
            setTraceUsing(objCollection);
            return result;
        }

        /// <Summary>
        /// レコード更新
        /// </Summary>
        /// <param Name="obj">更新対象アイテム</param>
        /// <returns>更新件数</returns>
        public int update(Business obj) {
            return update(new BusinessCollection() { obj });
        }

        /// <Summary>
        /// テーブル全件取得する
        /// </Summary>
        /// <returns>テーブル全件</returns>
        public BusinessCollection selectAll() {
            return selectWhereDateBetween(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <Summary>
        /// 指定された摘要に紐づくレコードを取得する
        /// </Summary>
        /// <param Name="summaryCollection">指定する摘要</param>
        /// <returns>指定された摘要に紐づくレコード</returns>
        public BusinessCollection selectWhereSummaryIn(SummaryCollection summaryCollection) {
            BusinessCollection result = new BusinessCollection();
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_SUMMARY}=@{COL_SUMMARY} {ORDER}";

            foreach(Summary targetSummary in summaryCollection) {
                result.AddRange(select(
                    new SqliteUtility.Command(
                        sql,
                        new List<SQLiteParameter>() { new SQLiteParameter($"@{COL_SUMMARY}", targetSummary.Id) })));
            }

            return result;
        }

        /// <Summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </Summary>
        /// <param Name="start">開始日付</param>
        /// <param Name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        public BusinessCollection selectWhereDateBetween(DateTime start, DateTime end) {
            string startParam = "@start";
            string endParam = "@end";
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_DATE} BETWEEN {startParam} and {endParam} {ORDER}";

            string dateFormat = "yyyy/MM/dd";
            List<SQLiteParameter> prmList = new List<SQLiteParameter>();
            prmList.Add(new SQLiteParameter(startParam, start.ToString(dateFormat)));
            prmList.Add(new SQLiteParameter(endParam, end.ToString(dateFormat)));

            return select(new SqliteUtility.Command(sql, prmList));
        }

        #endregion
    }

}
