using System;
using System.Collections.Generic;

using MoKakebo.Model;

namespace MoKakebo.Dao.Interface {
    /// <Summary>
    /// 摘要DAOインタフェース
    /// </Summary>
    public interface ISummaryDao {
        /// <Summary>
        /// レコード登録
        /// </Summary>
        /// <param Name="obj">登録対象アイテム</param>
        /// <returns>登録件数</returns>
        int register(Summary obj);

        /// <Summary>
        /// レコード登録
        /// </Summary>
        /// <param Name="objCollection">登録対象アイテムリスト</param>
        /// <returns>登録件数</returns>
        int register(SummaryCollection objCollection);

        /// <Summary>
        /// レコード削除
        /// </Summary>
        /// <param Name="id">削除対象ID</param>
        /// <returns>削除件数</returns>
        int delete(long id);

        /// <Summary>
        /// レコード削除
        /// </Summary>
        /// <param Name="idList">削除対象IDリスト</param>
        /// <returns>削除件数</returns>
        int delete(List<long> idList);

        /// <Summary>
        /// レコード更新
        /// </Summary>
        /// <param Name="obj">更新対象アイテム</param>
        /// <returns>更新件数</returns>
        int update(Summary obj);

        /// <Summary>
        /// レコード更新
        /// </Summary>
        /// <param Name="objCollection">更新対象アイテムリスト</param>
        /// <returns>更新件数</returns>
        int update(SummaryCollection objCollection);

        /// <Summary>
        /// テーブル全件取得する
        /// </Summary>
        /// <returns>テーブル全件</returns>
        SummaryCollection selectAll();

        /// <Summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </Summary>
        /// <param Name="start">開始日付</param>
        /// <param Name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        SummaryCollection selectWhereLatestDateBetween(DateTime start, DateTime end);

        /// <Summary>
        /// 指定された勘定科目に紐づくレコードを取得する
        /// </Summary>
        /// <param Name="subaccountCollection">指定する勘定科目</param>
        /// <returns>指定された勘定科目に紐づくレコード</returns>
        SummaryCollection selectWhereSubaccountIn(SubaccountCollection subaccountCollection);

    }
}
