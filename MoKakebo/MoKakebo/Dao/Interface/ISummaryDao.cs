using System;
using System.Collections.Generic;

using MoKakebo.Model;

namespace MoKakebo.Dao.Interface {
    /// <summary>
    /// 摘要DAOインタフェース
    /// </summary>
    public interface ISummaryDao {
        /// <summary>
        /// レコード登録
        /// </summary>
        /// <param name="obj">登録対象アイテム</param>
        /// <returns>登録件数</returns>
        int register(Summary obj);

        /// <summary>
        /// レコード登録
        /// </summary>
        /// <param name="objCollection">登録対象アイテムリスト</param>
        /// <returns>登録件数</returns>
        int register(SummaryCollection objCollection);

        /// <summary>
        /// レコード削除
        /// </summary>
        /// <param name="id">削除対象ID</param>
        /// <returns>削除件数</returns>
        int delete(long id);

        /// <summary>
        /// レコード削除
        /// </summary>
        /// <param name="idList">削除対象IDリスト</param>
        /// <returns>削除件数</returns>
        int delete(List<long> idList);

        /// <summary>
        /// レコード更新
        /// </summary>
        /// <param name="obj">更新対象アイテム</param>
        /// <returns>更新件数</returns>
        int update(Summary obj);

        /// <summary>
        /// レコード更新
        /// </summary>
        /// <param name="objCollection">更新対象アイテムリスト</param>
        /// <returns>更新件数</returns>
        int update(SummaryCollection objCollection);

        /// <summary>
        /// テーブル全件取得する
        /// </summary>
        /// <returns>テーブル全件</returns>
        SummaryCollection selectAll();

        /// <summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </summary>
        /// <param name="start">開始日付</param>
        /// <param name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        SummaryCollection selectWhereLatestDateBetween(DateTime start, DateTime end);

        /// <summary>
        /// 指定された勘定科目に紐づくレコードを取得する
        /// </summary>
        /// <param name="subaccountCollection">指定する勘定科目</param>
        /// <returns>指定された勘定科目に紐づくレコード</returns>
        SummaryCollection selectWhereSubaccountIn(SubaccountCollection subaccountCollection);

    }
}
