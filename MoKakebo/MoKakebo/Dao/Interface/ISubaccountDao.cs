using System;
using System.Collections.Generic;

using MoKakebo.Model;

namespace MoKakebo.Dao.Interface {
    /// <summary>
    /// 勘定科目DAOインタフェース
    /// </summary>
    public interface ISubaccountDao {

        /// <summary>
        /// レコード登録
        /// </summary>
        /// <param name="obj">登録対象アイテム</param>
        /// <returns>登録件数</returns>
        int register(Subaccount obj);

        /// <summary>
        /// レコード登録
        /// </summary>
        /// <param name="objCollection">登録対象アイテムリスト</param>
        /// <returns>登録件数</returns>
        int register(SubaccountCollection objCollection);

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
        int update(Subaccount obj);

        /// <summary>
        /// レコード更新
        /// </summary>
        /// <param name="objCollection">更新対象アイテムリスト</param>
        /// <returns>更新件数</returns>
        int update(SubaccountCollection objCollection);

        /// <summary>
        /// テーブル全件取得する
        /// </summary>
        /// <returns>テーブル全件</returns>
        SubaccountCollection selectAll();

        /// <summary>
        /// 指定された日付の範囲内のレコードを取得する
        /// </summary>
        /// <param name="start">開始日付</param>
        /// <param name="end">終了日付</param>
        /// <returns>指定された日付の範囲内のレコード</returns>
        SubaccountCollection selectWhereLatestDateBetween(DateTime start, DateTime end);

        /// <summary>
        /// 指定された科目に紐づくレコードを取得する
        /// </summary>
        /// <param name="accountCollection">指定する科目</param>
        /// <returns>指定された科目に紐づくレコード</returns>
        SubaccountCollection selectWhereAccountIn(List<Const.Enum.Account> accountCollection);
    }
}
