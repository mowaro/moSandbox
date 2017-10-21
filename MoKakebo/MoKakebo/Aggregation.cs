using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MoKakebo.Dao;
using MoKakebo.Dao.Interface;
using MoKakebo.Model;

namespace MoKakebo {
    public partial class Aggregation : Form {

        /// <summary>取引履歴</summary>
        private BusinessCollection histories;
        /// <summary>月</summary>
        private Month period;
        /// <summary>集計グループリスト</summary>
        private List<string> groupList;

        public Aggregation() {
            InitializeComponent();
            period = new Month(DateTime.Now);
            RefreshHistories(period);
        }


        private void RefreshHistories(Month period) {
            IBusinessDao dao = Factory.getBusinessDao();
            histories = dao.selectWhereDateBetween(period.getFirstDay(), period.getLastDay());
        }
    }
}
