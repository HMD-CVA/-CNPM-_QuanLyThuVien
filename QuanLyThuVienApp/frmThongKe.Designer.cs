namespace QuanLyThuVienApp
{
    partial class frmThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lbThongKeSach = new System.Windows.Forms.Label();
            this.cbThongKe = new System.Windows.Forms.ComboBox();
            this.lbTieuDe = new System.Windows.Forms.Label();
            this.pnTieuDe = new System.Windows.Forms.Panel();
            this.pnTabControl = new System.Windows.Forms.Panel();
            this.tpDocGia = new System.Windows.Forms.TabPage();
            this.pnLeftDocGia = new System.Windows.Forms.Panel();
            this.gbDocGia = new System.Windows.Forms.GroupBox();
            this.lbDGDangMuon = new System.Windows.Forms.Label();
            this.lbDGViPham = new System.Windows.Forms.Label();
            this.lbTongDG = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartDocGia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tpTaiLieu = new System.Windows.Forms.TabPage();
            this.pnLeft = new System.Windows.Forms.Panel();
            this.gbTaiLieu = new System.Windows.Forms.GroupBox();
            this.lbTLQuaHan = new System.Windows.Forms.Label();
            this.lbTLCoSan = new System.Windows.Forms.Label();
            this.lbTLDangMuon = new System.Windows.Forms.Label();
            this.lbTongTL = new System.Windows.Forms.Label();
            this.pnRight = new System.Windows.Forms.Panel();
            this.chartTopSach = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tab = new System.Windows.Forms.TabControl();
            this.pnTieuDe.SuspendLayout();
            this.pnTabControl.SuspendLayout();
            this.tpDocGia.SuspendLayout();
            this.pnLeftDocGia.SuspendLayout();
            this.gbDocGia.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDocGia)).BeginInit();
            this.tpTaiLieu.SuspendLayout();
            this.pnLeft.SuspendLayout();
            this.gbTaiLieu.SuspendLayout();
            this.pnRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSach)).BeginInit();
            this.tab.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbThongKeSach
            // 
            this.lbThongKeSach.AutoSize = true;
            this.lbThongKeSach.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongKeSach.Location = new System.Drawing.Point(953, 42);
            this.lbThongKeSach.Name = "lbThongKeSach";
            this.lbThongKeSach.Size = new System.Drawing.Size(139, 23);
            this.lbThongKeSach.TabIndex = 4;
            this.lbThongKeSach.Text = "Thống kê theo:";
            // 
            // cbThongKe
            // 
            this.cbThongKe.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbThongKe.FormattingEnabled = true;
            this.cbThongKe.Items.AddRange(new object[] {
            "Tất cả",
            "Tuần ",
            "Tháng"});
            this.cbThongKe.Location = new System.Drawing.Point(1098, 35);
            this.cbThongKe.Name = "cbThongKe";
            this.cbThongKe.Size = new System.Drawing.Size(121, 31);
            this.cbThongKe.TabIndex = 3;
            // 
            // lbTieuDe
            // 
            this.lbTieuDe.AutoSize = true;
            this.lbTieuDe.Font = new System.Drawing.Font("Times New Roman", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTieuDe.ForeColor = System.Drawing.Color.Navy;
            this.lbTieuDe.Location = new System.Drawing.Point(539, 13);
            this.lbTieuDe.Name = "lbTieuDe";
            this.lbTieuDe.Size = new System.Drawing.Size(220, 42);
            this.lbTieuDe.TabIndex = 1;
            this.lbTieuDe.Text = "THỐNG KÊ";
            // 
            // pnTieuDe
            // 
            this.pnTieuDe.BackColor = System.Drawing.Color.AliceBlue;
            this.pnTieuDe.Controls.Add(this.cbThongKe);
            this.pnTieuDe.Controls.Add(this.lbThongKeSach);
            this.pnTieuDe.Controls.Add(this.lbTieuDe);
            this.pnTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnTieuDe.Name = "pnTieuDe";
            this.pnTieuDe.Size = new System.Drawing.Size(1219, 68);
            this.pnTieuDe.TabIndex = 2;
            // 
            // pnTabControl
            // 
            this.pnTabControl.Controls.Add(this.tab);
            this.pnTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTabControl.Location = new System.Drawing.Point(0, 68);
            this.pnTabControl.Name = "pnTabControl";
            this.pnTabControl.Padding = new System.Windows.Forms.Padding(3);
            this.pnTabControl.Size = new System.Drawing.Size(1219, 656);
            this.pnTabControl.TabIndex = 3;
            // 
            // tpDocGia
            // 
            this.tpDocGia.Controls.Add(this.panel1);
            this.tpDocGia.Controls.Add(this.pnLeftDocGia);
            this.tpDocGia.Location = new System.Drawing.Point(4, 36);
            this.tpDocGia.Name = "tpDocGia";
            this.tpDocGia.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocGia.Size = new System.Drawing.Size(1205, 610);
            this.tpDocGia.TabIndex = 1;
            this.tpDocGia.Text = "Độc giả";
            this.tpDocGia.UseVisualStyleBackColor = true;
            // 
            // pnLeftDocGia
            // 
            this.pnLeftDocGia.Controls.Add(this.gbDocGia);
            this.pnLeftDocGia.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeftDocGia.Location = new System.Drawing.Point(3, 3);
            this.pnLeftDocGia.Name = "pnLeftDocGia";
            this.pnLeftDocGia.Size = new System.Drawing.Size(278, 604);
            this.pnLeftDocGia.TabIndex = 0;
            // 
            // gbDocGia
            // 
            this.gbDocGia.Controls.Add(this.lbTongDG);
            this.gbDocGia.Controls.Add(this.lbDGViPham);
            this.gbDocGia.Controls.Add(this.lbDGDangMuon);
            this.gbDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDocGia.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDocGia.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gbDocGia.Location = new System.Drawing.Point(0, 0);
            this.gbDocGia.Name = "gbDocGia";
            this.gbDocGia.Size = new System.Drawing.Size(278, 604);
            this.gbDocGia.TabIndex = 0;
            this.gbDocGia.TabStop = false;
            this.gbDocGia.Text = "Thông tin tổng quan";
            // 
            // lbDGDangMuon
            // 
            this.lbDGDangMuon.AutoSize = true;
            this.lbDGDangMuon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDGDangMuon.Location = new System.Drawing.Point(6, 67);
            this.lbDGDangMuon.Name = "lbDGDangMuon";
            this.lbDGDangMuon.Size = new System.Drawing.Size(141, 21);
            this.lbDGDangMuon.TabIndex = 8;
            this.lbDGDangMuon.Text = "Đang mượn sách:";
            this.lbDGDangMuon.Click += new System.EventHandler(this.lbDGDangMuon_Click);
            // 
            // lbDGViPham
            // 
            this.lbDGViPham.AutoSize = true;
            this.lbDGViPham.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDGViPham.Location = new System.Drawing.Point(6, 104);
            this.lbDGViPham.Name = "lbDGViPham";
            this.lbDGViPham.Size = new System.Drawing.Size(139, 21);
            this.lbDGViPham.TabIndex = 9;
            this.lbDGViPham.Text = "Vi phạm quá hạn:";
            // 
            // lbTongDG
            // 
            this.lbTongDG.AutoSize = true;
            this.lbTongDG.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongDG.Location = new System.Drawing.Point(6, 31);
            this.lbTongDG.Name = "lbTongDG";
            this.lbTongDG.Size = new System.Drawing.Size(137, 21);
            this.lbTongDG.TabIndex = 6;
            this.lbTongDG.Text = "Tổng số độc giả:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chartDocGia);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(281, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(921, 604);
            this.panel1.TabIndex = 0;
            // 
            // chartDocGia
            // 
            chartArea2.Name = "ChartArea1";
            this.chartDocGia.ChartAreas.Add(chartArea2);
            this.chartDocGia.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartDocGia.Legends.Add(legend2);
            this.chartDocGia.Location = new System.Drawing.Point(0, 0);
            this.chartDocGia.Name = "chartDocGia";
            this.chartDocGia.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartDocGia.Series.Add(series2);
            this.chartDocGia.Size = new System.Drawing.Size(921, 604);
            this.chartDocGia.TabIndex = 0;
            this.chartDocGia.Text = "chart1";
            title2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Tỉ lệ độc giả vi phạm";
            this.chartDocGia.Titles.Add(title2);
            // 
            // tpTaiLieu
            // 
            this.tpTaiLieu.Controls.Add(this.pnRight);
            this.tpTaiLieu.Controls.Add(this.pnLeft);
            this.tpTaiLieu.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTaiLieu.Location = new System.Drawing.Point(4, 36);
            this.tpTaiLieu.Name = "tpTaiLieu";
            this.tpTaiLieu.Padding = new System.Windows.Forms.Padding(3);
            this.tpTaiLieu.Size = new System.Drawing.Size(1205, 610);
            this.tpTaiLieu.TabIndex = 0;
            this.tpTaiLieu.Text = "Tài liệu";
            this.tpTaiLieu.UseVisualStyleBackColor = true;
            // 
            // pnLeft
            // 
            this.pnLeft.Controls.Add(this.gbTaiLieu);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(3, 3);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Padding = new System.Windows.Forms.Padding(5);
            this.pnLeft.Size = new System.Drawing.Size(293, 604);
            this.pnLeft.TabIndex = 1;
            // 
            // gbTaiLieu
            // 
            this.gbTaiLieu.Controls.Add(this.lbTongTL);
            this.gbTaiLieu.Controls.Add(this.lbTLDangMuon);
            this.gbTaiLieu.Controls.Add(this.lbTLCoSan);
            this.gbTaiLieu.Controls.Add(this.lbTLQuaHan);
            this.gbTaiLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbTaiLieu.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTaiLieu.Location = new System.Drawing.Point(5, 5);
            this.gbTaiLieu.Name = "gbTaiLieu";
            this.gbTaiLieu.Size = new System.Drawing.Size(283, 594);
            this.gbTaiLieu.TabIndex = 11;
            this.gbTaiLieu.TabStop = false;
            this.gbTaiLieu.Text = "Thông tin tổng quan";
            // 
            // lbTLQuaHan
            // 
            this.lbTLQuaHan.AutoSize = true;
            this.lbTLQuaHan.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTLQuaHan.Location = new System.Drawing.Point(6, 159);
            this.lbTLQuaHan.Name = "lbTLQuaHan";
            this.lbTLQuaHan.Size = new System.Drawing.Size(131, 21);
            this.lbTLQuaHan.TabIndex = 5;
            this.lbTLQuaHan.Text = "Tài liệu quá hạn:";
            // 
            // lbTLCoSan
            // 
            this.lbTLCoSan.AutoSize = true;
            this.lbTLCoSan.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTLCoSan.Location = new System.Drawing.Point(6, 117);
            this.lbTLCoSan.Name = "lbTLCoSan";
            this.lbTLCoSan.Size = new System.Drawing.Size(122, 21);
            this.lbTLCoSan.TabIndex = 2;
            this.lbTLCoSan.Text = "Tài liệu có sẵn:";
            // 
            // lbTLDangMuon
            // 
            this.lbTLDangMuon.AutoSize = true;
            this.lbTLDangMuon.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTLDangMuon.Location = new System.Drawing.Point(6, 76);
            this.lbTLDangMuon.Name = "lbTLDangMuon";
            this.lbTLDangMuon.Size = new System.Drawing.Size(201, 21);
            this.lbTLDangMuon.TabIndex = 1;
            this.lbTLDangMuon.Text = "Tài liệu đang được mượn:";
            // 
            // lbTongTL
            // 
            this.lbTongTL.AutoSize = true;
            this.lbTongTL.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTL.Location = new System.Drawing.Point(6, 34);
            this.lbTongTL.Name = "lbTongTL";
            this.lbTongTL.Size = new System.Drawing.Size(129, 21);
            this.lbTongTL.TabIndex = 0;
            this.lbTongTL.Text = "Tổng số tài liệu:";
            // 
            // pnRight
            // 
            this.pnRight.Controls.Add(this.chartTopSach);
            this.pnRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnRight.Location = new System.Drawing.Point(296, 3);
            this.pnRight.Name = "pnRight";
            this.pnRight.Size = new System.Drawing.Size(906, 604);
            this.pnRight.TabIndex = 2;
            // 
            // chartTopSach
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisY.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.chartTopSach.ChartAreas.Add(chartArea1);
            this.chartTopSach.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartTopSach.Legends.Add(legend1);
            this.chartTopSach.Location = new System.Drawing.Point(0, 0);
            this.chartTopSach.Name = "chartTopSach";
            this.chartTopSach.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            series1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.ChartArea = "ChartArea1";
            series1.CustomProperties = "PointWidth=0.4";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTopSach.Series.Add(series1);
            this.chartTopSach.Size = new System.Drawing.Size(906, 604);
            this.chartTopSach.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Top 5 tài liệu được mượn nhiều nhất";
            this.chartTopSach.Titles.Add(title1);
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tpTaiLieu);
            this.tab.Controls.Add(this.tpDocGia);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab.Location = new System.Drawing.Point(3, 3);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1213, 650);
            this.tab.TabIndex = 0;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 724);
            this.Controls.Add(this.pnTabControl);
            this.Controls.Add(this.pnTieuDe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmThongKe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmThongKe_Load);
            this.pnTieuDe.ResumeLayout(false);
            this.pnTieuDe.PerformLayout();
            this.pnTabControl.ResumeLayout(false);
            this.tpDocGia.ResumeLayout(false);
            this.pnLeftDocGia.ResumeLayout(false);
            this.gbDocGia.ResumeLayout(false);
            this.gbDocGia.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDocGia)).EndInit();
            this.tpTaiLieu.ResumeLayout(false);
            this.pnLeft.ResumeLayout(false);
            this.gbTaiLieu.ResumeLayout(false);
            this.gbTaiLieu.PerformLayout();
            this.pnRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopSach)).EndInit();
            this.tab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbTieuDe;
        private System.Windows.Forms.Panel pnTieuDe;
        private System.Windows.Forms.Panel pnTabControl;
        private System.Windows.Forms.ComboBox cbThongKe;
        private System.Windows.Forms.Label lbThongKeSach;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tpTaiLieu;
        private System.Windows.Forms.Panel pnRight;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopSach;
        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.GroupBox gbTaiLieu;
        private System.Windows.Forms.Label lbTongTL;
        private System.Windows.Forms.Label lbTLDangMuon;
        private System.Windows.Forms.Label lbTLCoSan;
        private System.Windows.Forms.Label lbTLQuaHan;
        private System.Windows.Forms.TabPage tpDocGia;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDocGia;
        private System.Windows.Forms.Panel pnLeftDocGia;
        private System.Windows.Forms.GroupBox gbDocGia;
        private System.Windows.Forms.Label lbTongDG;
        private System.Windows.Forms.Label lbDGViPham;
        private System.Windows.Forms.Label lbDGDangMuon;
    }
}