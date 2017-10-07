using System;
using System.Collections.Generic;

using MoKakebo.Model;

namespace MoKakebo.Dao.Interface {
    /// <summary>
    /// 取引DAOインタフェース
    /// </summary>
    public interface IBusinessDao {
        /// <summary>
        /// レコード登録
        /// </summary>
        /// <param name="obj">登録対象アイテム</param>
        /// <returns>登録件数</returns>
        int register(Business obj);

        /// <summary>
        /// レコード登録
        /// </summary>
        /// <param name="objCollection">登録対象アイテムリスト</param>
        /// <returns>登録件数</returns>
        int register(BusinessCollection objCollection);

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
        int update(Business obj);

        /// <summary>
        /// レコード更新
        /// </summary>
        /// <param name="objCollection">更新対象アイテムリスト</param>
        /// <returns>更新件数</returns>
        int update(BusinessCollection objCollection);

        /// <summary>
        /// テーブル全件取得する
        /// </summary>
        /// <returns>テーブル全件</returns>
        BusinessCollection selectAll();

        /// <summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </summary>
        /// <param name="start">開始日付</param>
        /// <param name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        BusinessCollection selectWhereDateBetween(DateTime start, DateTime end);

        /// <summary>
        /// 指定された摘要に紐づくレコードを取得する
        /// </summary>
        /// <param name="summaryCollection">指定する摘要</param>
        /// <returns>指定された摘要に紐づくレコード</returns>
        BusinessCollection selectWhereSummaryIn(SummaryCollection summaryCollection);
    }
}
