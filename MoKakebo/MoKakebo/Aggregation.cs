using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MoKakebo.Dao;
using MoKakebo.Dao.Interface;
using MoKakebo.Framework.Model.Interface;
using MoKakebo.Model;

namespace MoKakebo {
    public partial class Aggregation : Form {

        /// <summary>取引履歴</summary>
        private BusinessCollection histories;
        /// <summary>月</summary>
        private Month period;

        public Aggregation() {
            InitializeComponent();
            this.dtpCurrentMonth.Value = DateTime.Now;
            RefreshGroup();
            refresh();
        }

        private void refresh() {
            period = new Month(this.dtpCurrentMonth.Value);
            RefreshHistories(period);
            RefreshLstHistory();
            refreshChart();
        }

        private void refreshChart() {
            this.cht.Series.Clear();

            string title = "title";
            this.cht.Series.Add(title);

            double total = 0;
            foreach(Business business in histories) {
                total += business.Amount;
            }

            Dictionary<IHasIdName, double> subTotals = new Dictionary<IHasIdName, double>();
            if (this.cmbGroup.Text.Equals(string.Empty)) {
                subTotals = GetSubaccountAgggregation();
            } else {
                subTotals = GetSummaryAgggregation();
            }

            foreach (KeyValuePair<IHasIdName, double> subTotal in subTotals) {
                double rate = (subTotal.Value / total) * 100.0;
                DataPoint dp = new DataPoint(0, rate) { LegendText = $"{subTotal.Key.Name}\r\n{subTotal.Value.ToString("C")}" };
                this.cht.Series[title].Points.Add(dp);
            }

            this.cht.Series[title]["PieStartAngle"] = "270";
            this.cht.Series[title].ChartType = SeriesChartType.Doughnut;


        }

        private Dictionary<IHasIdName, double> GetSubaccountAgggregation() {
            Dictionary<IHasIdName, double> result = new Dictionary<IHasIdName, double>();
            foreach (Business business in histories) {
                if (!result.ContainsKey(business.Summary.Subaccount)) {
                    result.Add(business.Summary.Subaccount, 0);
                }
                result[business.Summary.Subaccount] += business.Amount;
            }
            return result;
        }

        private Dictionary<IHasIdName, double> GetSummaryAgggregation() {
            Dictionary<IHasIdName, double> result = new Dictionary<IHasIdName, double>();
            foreach(Business business in histories) {
                if(!result.ContainsKey(business.Summary)) {
                    result.Add(business.Summary, 0);
                }
                result[business.Summary] += business.Amount;
            }
            return result;
        }

        private void RefreshHistories(Month period) {
            SummaryCollection summaries = new SummaryCollection();
            foreach (Subaccount subaccount in AppCache.getSubaccountMaster()) {
                if (subaccount.Name.Equals(this.cmbGroup.Text)) {
                    foreach (Summary summary in AppCache.getSummaryMaster()) {
                        if (subaccount.Equals(summary.Subaccount)) {
                            summaries.Add(summary);
                        }
                    }
                }
            }

            IBusinessDao dao = Factory.getBusinessDao();
            if (summaries.Count.Equals(0)) {
                histories = dao.select(period.getFirstDay(), period.getLastDay());
            }
            else {
                histories = dao.select(period.getFirstDay(), period.getLastDay(), summaries);
            }
        }

        private void RefreshLstHistory() {
            this.lstHistory.Items.Clear();
            foreach (Business business in histories) {
                string[] subItems = {
                    business.Date.ToShortDateString(),
                    business.Summary.Subaccount.Name,
                    business.Summary.Name,
                    business.Amount.ToString("C"),
                    business.Comment};
                ListViewItem item = new ListViewItem(subItems);
                item.Tag = business;
                this.lstHistory.Items.Add(item);
            }
            this.lstHistory.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void dtpCurrentMonth_ValueChanged(object sender, EventArgs e) {
            refresh();
        }

        private void RefreshGroup() {
            this.cmbGroup.Items.Clear();
            this.cmbGroup.Items.Add(string.Empty);
            foreach (Subaccount subaccount in AppCache.getSubaccountMaster()) {
                this.cmbGroup.Items.Add(subaccount.Name);
            }
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e) {
            refresh();
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            InputBusiness dlg = new InputBusiness(Const.Enum.InputMode.Register, null);
            DialogResult result = dlg.ShowDialog(this);
            if (result.Equals(DialogResult.OK)) {
                refresh();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            if (this.lstHistory.SelectedItems.Count == 0) {
                MessageBox.Show(this, "編集したい履歴を選択してね！", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Business src = new Business();
            foreach (ListViewItem item in lstHistory.SelectedItems) {
                src = (Business)item.Tag;
            }

            InputBusiness dlg = new InputBusiness(Const.Enum.InputMode.Edit, src);
            DialogResult result = dlg.ShowDialog(this);
            if(result.Equals(DialogResult.OK)) {
                refresh();
            }
        }

        private void lstHistory_MouseDoubleClick(object sender, MouseEventArgs e) {
            btnEdit_Click(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            if(this.lstHistory.SelectedItems.Count == 0) {
                MessageBox.Show(this, "削除したい履歴を選択してね！", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Business src = new Business();
            foreach(ListViewItem item in lstHistory.SelectedItems) {
                src = (Business)item.Tag;
            }

            StringBuilder message = new StringBuilder();
            message.AppendLine($"この取引を削除してOK？");
            message.AppendLine($"----------------------");
            message.AppendLine($"日付　　：{src.Date.ToShortDateString()}");
            message.AppendLine($"勘定科目：{src.Summary.Subaccount.Name}");
            message.AppendLine($"摘要　　：{src.Summary.Name}");
            message.AppendLine($"金額　　：{src.Amount.ToString("C")}");
            message.AppendLine($"コメント：{src.Comment}");

            DialogResult dr
                = MessageBox.Show(this, message.ToString(), "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(dr.Equals(DialogResult.Cancel)) {
                return;
            }


            Factory.getBusinessDao().delete(src.Id);
        }

        private void lstHistory_KeyPress(object sender, KeyPressEventArgs e) {

        }

        private void lstHistory_KeyUp(object sender, KeyEventArgs e) {
            if(!e.KeyCode.Equals(Keys.Delete)) {
                return;
            }
            if(this.lstHistory.SelectedItems.Count == 0) {
                return;
            }

            btnDelete_Click(sender, e);
        }
    }
}
