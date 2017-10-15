using System;

using MoKakebo.Dao.Interface;
using MoKakebo.Dao.RDB.SQLiteImplement;

namespace MoKakebo.Dao {
    /// <Summary>
    /// DAOファクトリ
    /// </Summary>
    public static class Factory {
        /// <Summary>
        /// 取引DAO取得
        /// </Summary>
        /// <returns></returns>
        public static IBusinessDao getBusinessDao() {
            return new BusinessDaoImpl();
        }

        /// <Summary>
        /// 摘要DAO取得
        /// </Summary>
        /// <returns></returns>
        public static ISummaryDao getSummaryDao() {
            return new SummaryDaoImpl();
        }

        /// <Summary>
        /// 勘定科目DAO取得
        /// </Summary>
        /// <returns></returns>
        public static ISubaccountDao getSubaccountDao() {
            return new SubaccountDaoImpl();
        }
    }
}
