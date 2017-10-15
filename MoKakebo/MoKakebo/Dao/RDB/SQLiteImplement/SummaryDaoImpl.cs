using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using MoKakebo.Framework.Utility;

using MoKakebo.Dao.Interface;
using MoKakebo.Model;
using System.Text;

namespace MoKakebo.Dao.RDB.SQLiteImplement {
    /// <Summary>摘要DAO SQLite実装クラス</Summary>
    public class SummaryDaoImpl : ISummaryDao {
        /// <Summary>テーブル名</Summary>
        private static string TABLE_NAME = "MASTER_SUMMARY";
        /// <Summary>カラム名_ID</Summary>
        private static string COL_ID = "ID";
        /// <Summary>カラム名_名前</Summary>
        private static string COL_NAME = "NAME";
        /// <Summary>カラム名_勘定科目</Summary>
        private static string COL_SUBACCOUNT = "SUBACCOUNT_ID";
        /// <Summary>カラム名_最終使用日</Summary>
        private static string COL_LATEST_USED = "LATEST_USED";
        /// <Summary>並び順</Summary>
        private static string ORDER = $"ORDER BY {COL_LATEST_USED} DESC";

        /// <Summary>
        /// 条件に従いDB問い合わせ、摘要コレクションを返す
        /// </Summary>
        /// <param Name="cmd">SQLiteコマンド</param>
        /// <returns>摘要コレクション</returns>
        private SummaryCollection select(SqliteUtility.Command cmd) {
            SummaryCollection result = new SummaryCollection();
            DataTable dt = SqliteUtility.select(cmd);
            foreach(DataRow row in dt.Rows) {
                try { 
                    Subaccount subaccount 
                        = AppCache.getSubaccountMaster().get(
                            SqliteUtility.DataRowConverter.getValue<long>(row, COL_SUBACCOUNT));

                    result.Add(new Summary(
                        SqliteUtility.DataRowConverter.getValue<long>(row, COL_ID),
                        SqliteUtility.DataRowConverter.getValue<string>(row, COL_NAME),
                        subaccount,
                        SqliteUtility.DataRowConverter.getValue<DateTime>(row, COL_LATEST_USED)));
                } catch (Exception ex) {
                    throw ex;
                }
            }
            return result;
        }

        /// <summary>
        /// 勘定科目に使用した痕跡を残す
        /// </summary>
        /// <param name="obj">使用した摘要</param>
        /// <returns>更新件数</returns>
        private int setTraceUsing(Summary obj) {
            SummaryCollection collection = new SummaryCollection();
            collection.Add(obj);
            return setTraceUsing(collection);
        }

        /// <summary>
        /// 勘定科目に使用した痕跡を残す
        /// </summary>
        /// <param name="objCollection">使用した摘要</param>
        /// <returns>更新件数</returns>
        private int setTraceUsing(SummaryCollection objCollection) {
            SubaccountCollection traces = new SubaccountCollection();
            foreach (Summary obj in objCollection) {
                traces.Add(new Subaccount(obj.Subaccount.Id, obj.Subaccount.Name, obj.Subaccount.Account, DateTime.Now));
            }

            SubaccountDaoImpl dao = new SubaccountDaoImpl();
            return dao.update(traces);
        }

        #region SummaryDao implement
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
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.Id));
                prmList.Add(new SQLiteParameter($"@{COL_NAME}", obj.Name));
                prmList.Add(new SQLiteParameter($"@{COL_SUBACCOUNT}", obj.Subaccount.Id));
                prmList.Add(new SQLiteParameter($"@{COL_LATEST_USED}", obj.LatestUsed.ToString("yyyy/MM/dd")));

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
        public int register(Summary obj) {
            return register(new SummaryCollection() { obj });
        }

        /// <Summary>
        /// レコード更新
        /// </Summary>
        /// <param Name="objCollection">更新対象アイテムリスト</param>
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
                prmList.Add(new SQLiteParameter($"@{COL_ID}", obj.Id));
                prmList.Add(new SQLiteParameter($"@{COL_NAME}", obj.Name));
                prmList.Add(new SQLiteParameter($"@{COL_SUBACCOUNT}", obj.Subaccount.Id));
                prmList.Add(new SQLiteParameter($"@{COL_LATEST_USED}", obj.LatestUsed.ToString("yyyy/MM/dd")));

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
        public int update(Summary obj) {
            return update(new SummaryCollection() { obj });
        }

        /// <Summary>
        /// テーブル全件取得する
        /// </Summary>
        /// <returns>テーブル全件</returns>
        public SummaryCollection selectAll() {
            return selectWhereLatestDateBetween(DateTime.MinValue, DateTime.MaxValue);
        }

        /// <Summary>
        /// 指定された勘定科目に紐づくレコードを取得する
        /// </Summary>
        /// <param Name="subaccountCollection">指定する勘定科目</param>
        /// <returns>指定された勘定科目に紐づくレコード</returns>
        public SummaryCollection selectWhereSubaccountIn(SubaccountCollection subaccountCollection) {
            SummaryCollection result = new SummaryCollection();
            string sql = $"SELECT * FROM {TABLE_NAME} WHERE {COL_SUBACCOUNT}=@{COL_SUBACCOUNT} {ORDER}";

            foreach(Subaccount targetSubaccount in subaccountCollection) {
                result.AddRange(select(
                    new SqliteUtility.Command(
                        sql, 
                        new List<SQLiteParameter>() { new SQLiteParameter($"@{COL_SUBACCOUNT}", targetSubaccount.Id) })));
            }

            return result;
        }

        /// <Summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </Summary>
        /// <param Name="start">開始日付</param>
        /// <param Name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        public SummaryCollection selectWhereLatestDateBetween(DateTime start, DateTime end) {
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

        class Sorter : IComparer<Summary> {
            public int Compare(Summary x, Summary y) {
                return y.LatestUsed.CompareTo(x.LatestUsed);
            }
        }
    }
}
