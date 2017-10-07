using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoKakebo.Dao;
using MoKakebo.Dao.Interface;
using MoKakebo.Model;

namespace MoKakebo {
    /// <summary>
    /// アプリケーションキャッシュ
    /// </summary>
    public sealed class AppCache {
        #region Singleton Member
        /// <summary>アプリケーションキャッシュ</summary>
        private static AppCache cache = new AppCache();

        /// <summary>コンストラクタ</summary>
        private AppCache() {
            reloadSubaccountMaster();
            reloadSummaryMaster();
        }

        /// <summary>
        /// アプリケーションキャッシュ取得
        /// </summary>
        /// <returns>アプリケーションキャッシュ</returns>
        public static AppCache getInstance() { return cache; }
        #endregion

        #region Subaccount Master
        /// <summary>勘定科目マスタ</summary>
        private SubaccountCollection subaccountMaster = new SubaccountCollection();

        /// <summary>勘定科目マスタ取得</summary>
        /// <returns>勘定科目マスタ</returns>
        public SubaccountCollection getSubaccountMaster() { return subaccountMaster; }
        
        /// <summary>勘定科目マスタ再読み込み</summary>
        public void reloadSubaccountMaster() {
            ISubaccountDao subaccountDao = Factory.getSubaccountDao();
            this.subaccountMaster = subaccountDao.selectAll();
        }
        #endregion

        #region Summary Master
        /// <summary>摘要マスタ</summary>
        private SummaryCollection summaryMaster = new SummaryCollection();

        /// <summary>摘要マスタ取得</summary>
        /// <returns>摘要マスタ</returns>
        public SummaryCollection getSummaryMaster() { return summaryMaster; }
        
        /// <summary>摘要マスタ再読み込み</summary>
        public void reloadSummaryMaster() {
            ISummaryDao summaryDao = Factory.getSummaryDao();
            this.summaryMaster = summaryDao.selectAll();
        }
        #endregion
    }
}
