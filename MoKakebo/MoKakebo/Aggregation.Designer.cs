namespace MoKakebo {
    partial class Aggregation {
        /// <Summary>
        /// Required designer variable.
        /// </Summary>
        private System.ComponentModel.IContainer components = null;

        /// <Summary>
        /// Clean up any resources being used.
        /// </Summary>
        /// <param Name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <Summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </Summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grpAggregate = new System.Windows.Forms.GroupBox();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.dtpCurrentMonth = new System.Windows.Forms.DateTimePicker();
            this.cht = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstHistory = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubaccount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSummary = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpAggregate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAggregate
            // 
            this.grpAggregate.Controls.Add(this.cmbGroup);
            this.grpAggregate.Controls.Add(this.dtpCurrentMonth);
            this.grpAggregate.Controls.Add(this.cht);
            this.grpAggregate.Controls.Add(this.lstHistory);
            this.grpAggregate.Location = new System.Drawing.Point(12, 12);
            this.grpAggregate.Name = "grpAggregate";
            this.grpAggregate.Size = new System.Drawing.Size(534, 316);
            this.grpAggregate.TabIndex = 11;
            this.grpAggregate.TabStop = false;
            this.grpAggregate.Text = "集計";
            // 
            // cmbGroup
            // 
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(124, 17);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(198, 20);
            this.cmbGroup.TabIndex = 11;
            this.cmbGroup.SelectedIndexChanged += new System.EventHandler(this.cmbGroup_SelectedIndexChanged);
            // 
            // dtpCurrentMonth
            // 
            this.dtpCurrentMonth.CustomFormat = "yyyy年 MM月";
            this.dtpCurrentMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentMonth.Location = new System.Drawing.Point(6, 18);
            this.dtpCurrentMonth.Name = "dtpCurrentMonth";
            this.dtpCurrentMonth.Size = new System.Drawing.Size(112, 19);
            this.dtpCurrentMonth.TabIndex = 10;
            this.dtpCurrentMonth.ValueChanged += new System.EventHandler(this.dtpCurrentMonth_ValueChanged);
            // 
            // cht
            // 
            chartArea3.Name = "ChartArea1";
            this.cht.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.cht.Legends.Add(legend3);
            this.cht.Location = new System.Drawing.Point(282, 44);
            this.cht.Name = "cht";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.cht.Series.Add(series3);
            this.cht.Size = new System.Drawing.Size(242, 266);
            this.cht.TabIndex = 1;
            this.cht.Text = "chart1";
            // 
            // lstHistory
            // 
            this.lstHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colSubaccount,
            this.colSummary,
            this.colAmount,
            this.colComment});
            this.lstHistory.Location = new System.Drawing.Point(6, 43);
            this.lstHistory.Name = "lstHistory";
            this.lstHistory.Size = new System.Drawing.Size(270, 267);
            this.lstHistory.TabIndex = 0;
            this.lstHistory.UseCompatibleStateImageBehavior = false;
            this.lstHistory.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "日付";
            // 
            // colSubaccount
            // 
            this.colSubaccount.Text = "勘定科目";
            // 
            // colSummary
            // 
            this.colSummary.Text = "摘要";
            // 
            // colAmount
            // 
            this.colAmount.Text = "金額";
            // 
            // colComment
            // 
            this.colComment.Text = "コメント";
            // 
            // Aggregation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 340);
            this.Controls.Add(this.grpAggregate);
            this.Name = "Aggregation";
            this.Text = "Aggregation";
            this.grpAggregate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cht)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAggregate;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht;
        private System.Windows.Forms.ListView lstHistory;
        private System.Windows.Forms.DateTimePicker dtpCurrentMonth;
        private System.Windows.Forms.ComboBox cmbGroup;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colSubaccount;
        private System.Windows.Forms.ColumnHeader colSummary;
        private System.Windows.Forms.ColumnHeader colAmount;
        private System.Windows.Forms.ColumnHeader colComment;
    }
}