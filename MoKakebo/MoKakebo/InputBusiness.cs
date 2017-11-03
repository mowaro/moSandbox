using System;
using System.Windows.Forms;
using MoKakebo.Model;
using MoKakebo.Const;
using MoKakebo.Dao;
using MoKakebo.Framework.Model.Interface;
using System.Collections.Generic;
using static MoKakebo.Const.Enum;

namespace MoKakebo {
    /// <Summary>
    /// 入力画面
    /// </Summary>
    public partial class InputBusiness : Form {

        public InputMode inputMode { get; private set; }
        public Business business { get; private set; }

        /// <Summary>
        /// コンストラクタ
        /// </Summary>
        public InputBusiness() {
            InitializeComponent();
        }

        public InputBusiness(InputMode inputMode, Business business) {
            InitializeComponent();
            this.inputMode = inputMode;
            this.business = business;

            string btnRegisterText = string.Empty;
            if (this.inputMode.Equals(InputMode.Register)) {
                btnRegisterText = "新規追加(&S)";
            } else {
                btnRegisterText = "変更保存(&S)";
            }
            this.btnRegister.Text = btnRegisterText;
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
                loadLstBase(this.lstAccount2, Const.Account.getList());
            }
            catch (Exception ex) {
                throw ex;
            }

            // default focus
            this.txtAmount.Focus();

            if (this.inputMode.Equals(InputMode.Edit)) {
                this.dtpDate.Value = this.business.Date;
                this.txtAmount.Text = this.business.Amount.ToString("C");
                this.txtComment.Text = this.business.Comment;
                this.lstAccount2.SelectedItems.Clear();
                this.lstAccount2.Items[this.business.Summary.Subaccount.Account.Id.ToString()].Selected = true;
                this.lstSubaccount2.SelectedItems.Clear();
                this.lstSubaccount2.Items[this.business.Summary.Subaccount.Id.ToString()].Selected = true;
                this.lstSummary2.SelectedItems.Clear();
                this.lstSummary2.Items[this.business.Summary.Id.ToString()].Selected = true;
            }
        }

        private void lstAccount2_SelectedIndexChanged(object sender, EventArgs e) {
            ListView lst = (ListView)sender;
            if (lst.SelectedItems.Count == 0) { return; }
            List<Const.Account> terms = new List<Const.Account>() { (Const.Account)lst.SelectedItems[0].Tag };

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
            if (this.inputMode.Equals(InputMode.Register)) {
                Business newBusiness = new Business(
                    0, getSelectedSummary(), this.dtpDate.Value, getAmount(), this.txtComment.Text);
                Factory.getBusinessDao().register(newBusiness);
            } else {
                Business newBusiness = new Business(
                    this.business.Id, getSelectedSummary(), this.dtpDate.Value, getAmount(), this.txtComment.Text);
                Factory.getBusinessDao().update(newBusiness);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtAmount_Leave(object sender, EventArgs e) {
            double amount = getAmount();
            TextBox target = (TextBox)sender;
            target.Text = string.Format("{0:C}", amount);
        }
        
        #endregion

        #region private method
        private void loadLstBase<T>(ListView target, IList<T> dataSource) where T: IHasIdName {
            target.Columns.Clear();
            target.Columns.Add("Name");
            target.HeaderStyle = ColumnHeaderStyle.None;

            target.Items.Clear();
            foreach(IHasIdName item in dataSource) {
                ListViewItem lvi = target.Items.Add(new ListViewItem() { Name = item.Id.ToString(), Text = item.Name, Tag = item });
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

    }
}
