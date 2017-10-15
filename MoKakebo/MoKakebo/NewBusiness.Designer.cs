namespace MoKakebo {
    partial class NewBusiness {
        /// <Summary>
        /// 必要なデザイナー変数です。
        /// </Summary>
        private System.ComponentModel.IContainer components = null;

        /// <Summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </Summary>
        /// <param Name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <Summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </Summary>
        private void InitializeComponent() {
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lstSummary2 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lstSubaccount2 = new System.Windows.Forms.ListView();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lstAccount2 = new System.Windows.Forms.ListView();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAmount = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAccount = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grpInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpInput
            // 
            this.grpInput.Controls.Add(this.lstSummary2);
            this.grpInput.Controls.Add(this.label1);
            this.grpInput.Controls.Add(this.lstSubaccount2);
            this.grpInput.Controls.Add(this.txtComment);
            this.grpInput.Controls.Add(this.lstAccount2);
            this.grpInput.Controls.Add(this.txtAmount);
            this.grpInput.Controls.Add(this.lblAmount);
            this.grpInput.Controls.Add(this.dtpDate);
            this.grpInput.Controls.Add(this.lblDate);
            this.grpInput.Controls.Add(this.lblAccount);
            this.grpInput.Controls.Add(this.btnClear);
            this.grpInput.Controls.Add(this.btnRegister);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(534, 298);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "入力";
            // 
            // lstSummary2
            // 
            this.lstSummary2.HideSelection = false;
            this.lstSummary2.Location = new System.Drawing.Point(311, 18);
            this.lstSummary2.Name = "lstSummary2";
            this.lstSummary2.Size = new System.Drawing.Size(213, 172);
            this.lstSummary2.TabIndex = 15;
            this.lstSummary2.UseCompatibleStateImageBehavior = false;
            this.lstSummary2.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "注釈";
            // 
            // lstSubaccount2
            // 
            this.lstSubaccount2.HideSelection = false;
            this.lstSubaccount2.Location = new System.Drawing.Point(152, 18);
            this.lstSubaccount2.Name = "lstSubaccount2";
            this.lstSubaccount2.Size = new System.Drawing.Size(153, 172);
            this.lstSubaccount2.TabIndex = 14;
            this.lstSubaccount2.UseCompatibleStateImageBehavior = false;
            this.lstSubaccount2.View = System.Windows.Forms.View.Details;
            this.lstSubaccount2.SelectedIndexChanged += new System.EventHandler(this.listSubaccount2_SelectedIndexChanged);
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(41, 246);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(264, 46);
            this.txtComment.TabIndex = 10;
            // 
            // lstAccount2
            // 
            this.lstAccount2.HideSelection = false;
            this.lstAccount2.Location = new System.Drawing.Point(41, 18);
            this.lstAccount2.Name = "lstAccount2";
            this.lstAccount2.Size = new System.Drawing.Size(105, 172);
            this.lstAccount2.TabIndex = 13;
            this.lstAccount2.UseCompatibleStateImageBehavior = false;
            this.lstAccount2.View = System.Windows.Forms.View.Details;
            this.lstAccount2.SelectedIndexChanged += new System.EventHandler(this.lstAccount2_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(41, 221);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(165, 19);
            this.txtAmount.TabIndex = 9;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.Leave += new System.EventHandler(this.txtAmount_Leave);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(6, 224);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(29, 12);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "金額";
            // 
            // dtpDate
            // 
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(41, 196);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(121, 19);
            this.dtpDate.TabIndex = 7;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(6, 201);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 12);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "日付";
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
            this.btnClear.Location = new System.Drawing.Point(425, 252);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 40);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "クリア(&E)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(320, 252);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(99, 40);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "登録(&S)";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(437, 316);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(99, 40);
            this.btnHistory.TabIndex = 12;
            this.btnHistory.Text = "履歴...(&H)";
            this.btnHistory.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(279, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 39);
            this.button1.TabIndex = 13;
            this.button1.Text = "sample";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NewBusiness
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 368);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.grpInput);
            this.Name = "NewBusiness";
            this.Text = "MoKakebo";
            this.Load += new System.EventHandler(this.Main_Load);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAccount;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.ListView lstAccount2;
        private System.Windows.Forms.ListView lstSubaccount2;
        private System.Windows.Forms.ListView lstSummary2;
        private System.Windows.Forms.Button button1;
    }
}

