namespace MoKakebo {
    partial class Main {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cmbSummary = new System.Windows.Forms.ComboBox();
            this.cmbSubaccount = new System.Windows.Forms.ComboBox();
            this.cmbAccount = new System.Windows.Forms.ComboBox();
            this.lblAccount = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.grpAggregate = new System.Windows.Forms.GroupBox();
            this.lblCurrentMonth = new System.Windows.Forms.Label();
            this.lblNextMonth = new System.Windows.Forms.Label();
            this.lblPrevMonth = new System.Windows.Forms.Label();
            this.cht = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstTable = new System.Windows.Forms.ListView();
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.profitLoss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.account = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.subaccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpInput.SuspendLayout();
            this.grpAggregate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht)).BeginInit();
            this.SuspendLayout();
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.label1);
            this.grpInput.Controls.Add(this.txtComment);
            this.grpInput.Controls.Add(this.txtAmount);
            this.grpInput.Controls.Add(this.lblAmount);
            this.grpInput.Controls.Add(this.dtpDate);
            this.grpInput.Controls.Add(this.lblDate);
            this.grpInput.Controls.Add(this.cmbSummary);
            this.grpInput.Controls.Add(this.cmbSubaccount);
            this.grpInput.Controls.Add(this.cmbAccount);
            this.grpInput.Controls.Add(this.lblAccount);
            this.grpInput.Controls.Add(this.btnClear);
            this.grpInput.Controls.Add(this.btnRegister);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(534, 134);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "入力";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(41, 69);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(165, 19);
            this.txtAmount.TabIndex = 9;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(6, 72);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(29, 12);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "金額";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(41, 44);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(121, 19);
            this.dtpDate.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 49);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 12);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "日付";
            // 
            // cmbSummary
            // 
            this.cmbSummary.FormattingEnabled = true;
            this.cmbSummary.Items.AddRange(new object[] {
            "費用",
            "収益"});
            this.cmbSummary.Location = new System.Drawing.Point(311, 18);
            this.cmbSummary.Name = "cmbSummary";
            this.cmbSummary.Size = new System.Drawing.Size(213, 20);
            this.cmbSummary.TabIndex = 5;
            // 
            // cmbSubaccount
            // 
            this.cmbSubaccount.FormattingEnabled = true;
            this.cmbSubaccount.Items.AddRange(new object[] {
            "費用",
            "収益"});
            this.cmbSubaccount.Location = new System.Drawing.Point(152, 18);
            this.cmbSubaccount.Name = "cmbSubaccount";
            this.cmbSubaccount.Size = new System.Drawing.Size(153, 20);
            this.cmbSubaccount.TabIndex = 4;
            // 
            // cmbAccount
            // 
            this.cmbAccount.FormattingEnabled = true;
            this.cmbAccount.Items.AddRange(new object[] {
            "費用",
            "収益"});
            this.cmbAccount.Location = new System.Drawing.Point(41, 18);
            this.cmbAccount.Name = "cmbAccount";
            this.cmbAccount.Size = new System.Drawing.Size(105, 20);
            this.cmbAccount.TabIndex = 3;
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(6, 21);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(29, 12);
            this.lblAccount.TabIndex = 2;
            this.lblAccount.Text = "科目";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(425, 83);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 40);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "クリア";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(320, 83);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(99, 40);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "登録";
            this.btnRegister.UseVisualStyleBackColor = true;
            // 
            // grpAggregate
            // 
            this.grpAggregate.Controls.Add(this.lblCurrentMonth);
            this.grpAggregate.Controls.Add(this.lblNextMonth);
            this.grpAggregate.Controls.Add(this.lblPrevMonth);
            this.grpAggregate.Controls.Add(this.cht);
            this.grpAggregate.Controls.Add(this.lstTable);
            this.grpAggregate.Location = new System.Drawing.Point(12, 152);
            this.grpAggregate.Name = "grpAggregate";
            this.grpAggregate.Size = new System.Drawing.Size(534, 316);
            this.grpAggregate.TabIndex = 10;
            this.grpAggregate.TabStop = false;
            this.grpAggregate.Text = "集計";
            // 
            // lblCurrentMonth
            // 
            this.lblCurrentMonth.AutoSize = true;
            this.lblCurrentMonth.Location = new System.Drawing.Point(89, 15);
            this.lblCurrentMonth.Name = "lblCurrentMonth";
            this.lblCurrentMonth.Size = new System.Drawing.Size(69, 12);
            this.lblCurrentMonth.TabIndex = 9;
            this.lblCurrentMonth.Text = "2017年 09月";
            // 
            // lblNextMonth
            // 
            this.lblNextMonth.AutoSize = true;
            this.lblNextMonth.Location = new System.Drawing.Point(164, 15);
            this.lblNextMonth.Name = "lblNextMonth";
            this.lblNextMonth.Size = new System.Drawing.Size(29, 12);
            this.lblNextMonth.TabIndex = 8;
            this.lblNextMonth.Text = "＞＞";
            // 
            // lblPrevMonth
            // 
            this.lblPrevMonth.AutoSize = true;
            this.lblPrevMonth.Location = new System.Drawing.Point(54, 15);
            this.lblPrevMonth.Name = "lblPrevMonth";
            this.lblPrevMonth.Size = new System.Drawing.Size(29, 12);
            this.lblPrevMonth.TabIndex = 7;
            this.lblPrevMonth.Text = "＜＜";
            // 
            // cht
            // 
            chartArea2.Name = "ChartArea1";
            this.cht.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.cht.Legends.Add(legend2);
            this.cht.Location = new System.Drawing.Point(282, 44);
            this.cht.Name = "cht";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.cht.Series.Add(series2);
            this.cht.Size = new System.Drawing.Size(242, 266);
            this.cht.TabIndex = 1;
            this.cht.Text = "chart1";
            // 
            // lstTable
            // 
            this.lstTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.date,
            this.profitLoss,
            this.account,
            this.subaccount,
            this.amount});
            this.lstTable.Location = new System.Drawing.Point(6, 44);
            this.lstTable.Name = "lstTable";
            this.lstTable.Size = new System.Drawing.Size(270, 266);
            this.lstTable.TabIndex = 0;
            this.lstTable.UseCompatibleStateImageBehavior = false;
            // 
            // date
            // 
            this.date.DisplayIndex = 3;
            this.date.Text = "日付";
            // 
            // profitLoss
            // 
            this.profitLoss.DisplayIndex = 0;
            this.profitLoss.Text = "収支";
            // 
            // account
            // 
            this.account.DisplayIndex = 1;
            this.account.Text = "科目1";
            // 
            // subaccount
            // 
            this.subaccount.DisplayIndex = 2;
            this.subaccount.Text = "科目2";
            // 
            // amount
            // 
            this.amount.Text = "金額";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(41, 94);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(264, 29);
            this.txtComment.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "注釈";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 480);
            this.Controls.Add(this.grpAggregate);
            this.Controls.Add(this.grpInput);
            this.Name = "Main";
            this.Text = "MoKakebo";
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.grpAggregate.ResumeLayout(false);
            this.grpAggregate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cmbSummary;
        private System.Windows.Forms.ComboBox cmbSubaccount;
        private System.Windows.Forms.ComboBox cmbAccount;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.GroupBox grpAggregate;
        private System.Windows.Forms.Label lblCurrentMonth;
        private System.Windows.Forms.Label lblNextMonth;
        private System.Windows.Forms.Label lblPrevMonth;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht;
        private System.Windows.Forms.ListView lstTable;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader profitLoss;
        private System.Windows.Forms.ColumnHeader account;
        private System.Windows.Forms.ColumnHeader subaccount;
        private System.Windows.Forms.ColumnHeader amount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComment;
    }
}

