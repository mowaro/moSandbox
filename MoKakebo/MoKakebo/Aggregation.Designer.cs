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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.grpAggregate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAggregate
            // 
            this.grpAggregate.Controls.Add(this.lblCurrentMonth);
            this.grpAggregate.Controls.Add(this.lblNextMonth);
            this.grpAggregate.Controls.Add(this.lblPrevMonth);
            this.grpAggregate.Controls.Add(this.cht);
            this.grpAggregate.Controls.Add(this.lstTable);
            this.grpAggregate.Location = new System.Drawing.Point(12, 12);
            this.grpAggregate.Name = "grpAggregate";
            this.grpAggregate.Size = new System.Drawing.Size(534, 316);
            this.grpAggregate.TabIndex = 11;
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
            // Date
            // 
            this.date.DisplayIndex = 3;
            this.date.Text = "日付";
            // 
            // profitLoss
            // 
            this.profitLoss.DisplayIndex = 0;
            this.profitLoss.Text = "収支";
            // 
            // Account
            // 
            this.account.DisplayIndex = 1;
            this.account.Text = "科目1";
            // 
            // Subaccount
            // 
            this.subaccount.DisplayIndex = 2;
            this.subaccount.Text = "科目2";
            // 
            // Amount
            // 
            this.amount.Text = "金額";
            this.amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.grpAggregate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

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
    }
}