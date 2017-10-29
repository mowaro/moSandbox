using System;
using System.Windows.Forms;
using MoKakebo.Model;
using MoKakebo.Const;
using MoKakebo.Dao;
using MoKakebo.Framework.Model.Interface;
using System.Collections.Generic;

namespace MoKakebo {
    /// <Summary>
    /// 入力画面
    /// </Summary>
    public partial class NewBusiness : Form {

        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        public NewBusiness() {
            InitializeComponent();
        }

        #region Event
        /// <Summary>
        /// 画面ロード時
        /// </Summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void Main_Load(object sender, EventArgs e) {
            // default values
            this.dtpDate.Value = DateTime.Today;
            this.txtAmount.Text = string.Empty;
            this.txtComment.Text = string.Empty;
            try {
                loadLstBase(this.lstAccount2, Account.getList());
            }
            catch (Exception ex) {
                throw ex;
            }

            // default focus
            this.txtAmount.Focus();
        }

        private void lstAccount2_SelectedIndexChanged(object sender, EventArgs e) {
            ListView lst = (ListView)sender;
            if (lst.SelectedItems.Count == 0) { return; }
            List<Account> terms = new List<Account>() { (Account)lst.SelectedItems[0].Tag };

            SubaccountCollection collection = Factory.getSubaccountDao().select(terms);
            collection.sort(new SubaccountCollection.LatestUsedDateDescSorter());
            loadLstBase(this.lstSubaccount2, collection);
        }

        private void listSubaccount2_SelectedIndexChanged(object sender, EventArgs e) {
            ListView lst = (ListView)sender;
            if(lst.SelectedItems.Count == 0) { return; }
            SubaccountCollection terms = new SubaccountCollection() { (Subaccount)lst.SelectedItems[0].Tag };

            SummaryCollection collection = Factory.getSummaryDao().select(terms);
            collection.sort(new SummaryCollection.LatestUsedDateDescSorter());
            loadLstBase(this.lstSummary2, collection);
        }

        private void btnClear_Click(object sender, EventArgs e) {
            this.Main_Load(sender, e);
        }

        private void btnRegister_Click(object sender, EventArgs e) {
            Business newBusiness = new Business(
                0, getSelectedSummary(), this.dtpDate.Value, getAmount(), this.txtComment.Text);

            Factory.getBusinessDao().register(newBusiness);
            Main_Load(sender, e);
        }

        private void txtAmount_Leave(object sender, EventArgs e) {
            double amount = getAmount();
            TextBox target = (TextBox)sender;
            target.Text = string.Format("{0:C}", amount);
        }

        private void btnHistory_Click(object sender, EventArgs e) {
            Aggregation dlg = new Aggregation();
            dlg.Show(this);
        }
        #endregion

        #region private method
        private void loadLstBase<T>(ListView target, IList<T> dataSource) where T: IHasIdName {
            target.Columns.Clear();
            target.Columns.Add("Name");
            target.HeaderStyle = ColumnHeaderStyle.None;

            target.Items.Clear();
            foreach(IHasIdName item in dataSource) {
                ListViewItem lvi = target.Items.Add(new ListViewItem() { Text = item.Name, Tag = item });
            }

            target.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            if(target.Items.Count > 0 && target.SelectedIndices.Count == 0) { target.Items[0].Selected = true; }
        }

        private Summary getSelectedSummary() {
            return (Summary)this.lstSummary2.SelectedItems[0].Tag;
        }

        private double getAmount() {
            return double.Parse(this.txtAmount.Text, System.Globalization.NumberStyles.Currency);
        }
        #endregion

        private void button1_Click(object sender, EventArgs e) {
            sample sample = new sample();
            sample.Show();
        }

    }
}
