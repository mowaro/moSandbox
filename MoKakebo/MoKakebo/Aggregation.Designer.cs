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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.grpAggregate = new System.Windows.Forms.GroupBox();
            this.cht = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lstTable = new System.Windows.Forms.ListView();
            this.dtpCurrentMonth = new System.Windows.Forms.DateTimePicker();
            this.cmbGroup = new System.Windows.Forms.ComboBox();
            this.grpAggregate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cht)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAggregate
            // 
            this.grpAggregate.Controls.Add(this.cmbGroup);
            this.grpAggregate.Controls.Add(this.dtpCurrentMonth);
            this.grpAggregate.Controls.Add(this.cht);
            this.grpAggregate.Controls.Add(this.lstTable);
            this.grpAggregate.Location = new System.Drawing.Point(12, 12);
            this.grpAggregate.Name = "grpAggregate";
            this.grpAggregate.Size = new System.Drawing.Size(534, 316);
            this.grpAggregate.TabIndex = 11;
            this.grpAggregate.TabStop = false;
            this.grpAggregate.Text = "集計";
            // 
            // cht
            // 
            chartArea1.Name = "ChartArea1";
            this.cht.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cht.Legends.Add(legend1);
            this.cht.Location = new System.Drawing.Point(282, 44);
            this.cht.Name = "cht";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.cht.Series.Add(series1);
            this.cht.Size = new System.Drawing.Size(242, 266);
            this.cht.TabIndex = 1;
            this.cht.Text = "chart1";
            // 
            // lstTable
            // 
            this.lstTable.Location = new System.Drawing.Point(6, 43);
            this.lstTable.Name = "lstTable";
            this.lstTable.Size = new System.Drawing.Size(270, 267);
            this.lstTable.TabIndex = 0;
            this.lstTable.UseCompatibleStateImageBehavior = false;
            this.lstTable.View = System.Windows.Forms.View.Details;
            // 
            // dtpCurrentMonth
            // 
            this.dtpCurrentMonth.CustomFormat = "yyyy年 MM月";
            this.dtpCurrentMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCurrentMonth.Location = new System.Drawing.Point(6, 18);
            this.dtpCurrentMonth.Name = "dtpCurrentMonth";
            this.dtpCurrentMonth.Size = new System.Drawing.Size(112, 19);
            this.dtpCurrentMonth.TabIndex = 10;
            // 
            // cmbGroup
            // 
            this.cmbGroup.FormattingEnabled = true;
            this.cmbGroup.Location = new System.Drawing.Point(124, 17);
            this.cmbGroup.Name = "cmbGroup";
            this.cmbGroup.Size = new System.Drawing.Size(198, 20);
            this.cmbGroup.TabIndex = 11;
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
        private System.Windows.Forms.ListView lstTable;
        private System.Windows.Forms.DateTimePicker dtpCurrentMonth;
        private System.Windows.Forms.ComboBox cmbGroup;
    }
}