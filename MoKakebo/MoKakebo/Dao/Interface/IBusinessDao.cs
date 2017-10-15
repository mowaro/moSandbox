using System;
using System.Collections.Generic;

using MoKakebo.Model;

namespace MoKakebo.Dao.Interface {
    /// <Summary>
    /// 取引DAOインタフェース
    /// </Summary>
    public interface IBusinessDao {
        /// <Summary>
        /// レコード登録
        /// </Summary>
        /// <param Name="obj">登録対象アイテム</param>
        /// <returns>登録件数</returns>
        int register(Business obj);

        /// <Summary>
        /// レコード登録
        /// </Summary>
        /// <param Name="objCollection">登録対象アイテムリスト</param>
        /// <returns>登録件数</returns>
        int register(BusinessCollection objCollection);

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
        int update(Business obj);

        /// <Summary>
        /// レコード更新
        /// </Summary>
        /// <param Name="objCollection">更新対象アイテムリスト</param>
        /// <returns>更新件数</returns>
        int update(BusinessCollection objCollection);

        /// <Summary>
        /// テーブル全件取得する
        /// </Summary>
        /// <returns>テーブル全件</returns>
        BusinessCollection selectAll();

        /// <Summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </Summary>
        /// <param Name="start">開始日付</param>
        /// <param Name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        BusinessCollection selectWhereDateBetween(DateTime start, DateTime end);

        /// <Summary>
        /// 指定された摘要に紐づくレコードを取得する
        /// </Summary>
        /// <param Name="summaryCollection">指定する摘要</param>
        /// <returns>指定された摘要に紐づくレコード</returns>
        BusinessCollection selectWhereSummaryIn(SummaryCollection summaryCollection);
    }
}
