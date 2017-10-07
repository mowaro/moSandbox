using System;

using MoKakebo.Dao.Interface;
using MoKakebo.Dao.RDB.SQLiteImplement;

namespace MoKakebo.Dao {
    /// <summary>
    /// DAOファクトリ
    /// </summary>
    public static class Factory {
        /// <summary>
        /// 取引DAO取得
        /// </summary>
        /// <returns></returns>
        public static IBusinessDao getBusinessDao() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 摘要DAO取得
        /// </summary>
        /// <returns></returns>
        public static ISummaryDao getSummaryDao() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 勘定科目DAO取得
        /// </summary>
        /// <returns></returns>
        public static ISubaccountDao getSubaccountDao() {
            return new SubaccountDaoImpl();
        }
    }
}
