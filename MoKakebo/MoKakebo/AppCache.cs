using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoKakebo.Dao;
using MoKakebo.Dao.Interface;
using MoKakebo.Model;

namespace MoKakebo {
    /// <Summary>
    /// アプリケーションキャッシュ
    /// </Summary>
    public sealed class AppCache {
        #region Singleton Member
        /// <Summary>アプリケーションキャッシュ</Summary>
        private static AppCache cache;

        /// <Summary>コンストラクタ</Summary>
        private AppCache() {
        }

        /// <Summary>
        /// アプリケーションキャッシュ取得
        /// </Summary>
        /// <returns>アプリケーションキャッシュ</returns>
        public static AppCache getInstance() {
            if (cache == null) {
                cache = new AppCache();
                reloadSubaccountMaster();
                reloadSummaryMaster();
            }
            return cache;
        }
        #endregion

        #region Subaccount Master
        /// <Summary>勘定科目マスタ</Summary>
        private static SubaccountCollection subaccountMaster;

        /// <Summary>勘定科目マスタ取得</Summary>
        /// <returns>勘定科目マスタ</returns>
        public static SubaccountCollection getSubaccountMaster() {
            AppCache.getInstance();
            return subaccountMaster;
        }
        
        /// <Summary>勘定科目マスタ再読み込み</Summary>
        public static void reloadSubaccountMaster() {
            ISubaccountDao subaccountDao = Factory.getSubaccountDao();
            subaccountMaster = subaccountDao.selectAll();
        }
        #endregion

        #region Summary Master
        /// <Summary>摘要マスタ</Summary>
        private static SummaryCollection summaryMaster;

        /// <Summary>摘要マスタ取得</Summary>
        /// <returns>摘要マスタ</returns>
        public static SummaryCollection getSummaryMaster() {
            AppCache.getInstance();
            return summaryMaster;
        }
        
        /// <Summary>摘要マスタ再読み込み</Summary>
        public static void reloadSummaryMaster() {
            ISummaryDao summaryDao = Factory.getSummaryDao();
            summaryMaster = summaryDao.selectAll();
        }
        #endregion
    }
}
