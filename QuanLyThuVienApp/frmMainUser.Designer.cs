﻿namespace QuanLyThuVienApp
{
    partial class frmMainUser
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainUser));
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCaNhan = new FontAwesome.Sharp.IconButton();
            this.btnDangXuat = new FontAwesome.Sharp.IconButton();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnInfor = new FontAwesome.Sharp.IconButton();
            this.btnTroGiup = new FontAwesome.Sharp.IconButton();
            this.tslbTimer = new System.Windows.Forms.ToolStripLabel();
            this.tslbThongTin = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThongKe = new FontAwesome.Sharp.IconButton();
            this.btnSach = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLichSuMuon = new FontAwesome.Sharp.IconButton();
            this.btnMuonSach = new FontAwesome.Sharp.IconButton();
            this.metroPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(426, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUẢN LÝ THƯ VIỆN";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCaNhan
            // 
            this.btnCaNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCaNhan.BackColor = System.Drawing.SystemColors.Info;
            this.btnCaNhan.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnCaNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaNhan.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCaNhan.IconChar = FontAwesome.Sharp.IconChar.User;
            this.btnCaNhan.IconColor = System.Drawing.Color.IndianRed;
            this.btnCaNhan.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCaNhan.IconSize = 24;
            this.btnCaNhan.Location = new System.Drawing.Point(984, 0);
            this.btnCaNhan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCaNhan.Name = "btnCaNhan";
            this.btnCaNhan.Size = new System.Drawing.Size(28, 28);
            this.btnCaNhan.TabIndex = 3;
            this.btnCaNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaNhan.UseVisualStyleBackColor = false;
            this.btnCaNhan.Click += new System.EventHandler(this.btnThongTin_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.BackColor = System.Drawing.SystemColors.Info;
            this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangXuat.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnDangXuat.IconColor = System.Drawing.Color.IndianRed;
            this.btnDangXuat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangXuat.IconSize = 25;
            this.btnDangXuat.Location = new System.Drawing.Point(1021, 0);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(28, 28);
            this.btnDangXuat.TabIndex = 4;
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.White;
            this.metroPanel1.Controls.Add(this.btnInfor);
            this.metroPanel1.Controls.Add(this.btnTroGiup);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.btnDangXuat);
            this.metroPanel1.Controls.Add(this.btnCaNhan);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 8;
            this.metroPanel1.Location = new System.Drawing.Point(8, 30);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1049, 34);
            this.metroPanel1.TabIndex = 1;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 8;
            // 
            // btnInfor
            // 
            this.btnInfor.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnInfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfor.IconChar = FontAwesome.Sharp.IconChar.Info;
            this.btnInfor.IconColor = System.Drawing.Color.Black;
            this.btnInfor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnInfor.IconSize = 20;
            this.btnInfor.Location = new System.Drawing.Point(34, 0);
            this.btnInfor.Margin = new System.Windows.Forms.Padding(38, 41, 38, 41);
            this.btnInfor.Name = "btnInfor";
            this.btnInfor.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnInfor.Size = new System.Drawing.Size(28, 28);
            this.btnInfor.TabIndex = 6;
            this.btnInfor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInfor.UseVisualStyleBackColor = true;
            this.btnInfor.Click += new System.EventHandler(this.btnGioiThieu_Click);
            // 
            // btnTroGiup
            // 
            this.btnTroGiup.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTroGiup.IconChar = FontAwesome.Sharp.IconChar.CircleQuestion;
            this.btnTroGiup.IconColor = System.Drawing.Color.Black;
            this.btnTroGiup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTroGiup.IconSize = 25;
            this.btnTroGiup.Location = new System.Drawing.Point(0, 0);
            this.btnTroGiup.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTroGiup.Name = "btnTroGiup";
            this.btnTroGiup.Size = new System.Drawing.Size(28, 28);
            this.btnTroGiup.TabIndex = 5;
            this.btnTroGiup.UseVisualStyleBackColor = true;
            this.btnTroGiup.Click += new System.EventHandler(this.btnTroGiup_Click);
            // 
            // tslbTimer
            // 
            this.tslbTimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslbTimer.Name = "tslbTimer";
            this.tslbTimer.Size = new System.Drawing.Size(86, 22);
            this.tslbTimer.Text = "toolStripLabel1";
            // 
            // tslbThongTin
            // 
            this.tslbThongTin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslbThongTin.Name = "tslbThongTin";
            this.tslbThongTin.Size = new System.Drawing.Size(86, 22);
            this.tslbThongTin.Text = "toolStripLabel1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbTimer,
            this.tslbThongTin});
            this.toolStrip1.Location = new System.Drawing.Point(8, 612);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1049, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.Controls.Add(this.btnThongKe);
            this.panel1.Controls.Add(this.btnSach);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(8, 64);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1049, 67);
            this.panel1.TabIndex = 3;
            // 
            // btnThongKe
            // 
            this.btnThongKe.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.btnThongKe.IconColor = System.Drawing.Color.Black;
            this.btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKe.IconSize = 40;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThongKe.Location = new System.Drawing.Point(127, 0);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnThongKe.Size = new System.Drawing.Size(127, 67);
            this.btnThongKe.TabIndex = 1;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnSach
            // 
            this.btnSach.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSach.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSach.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSach.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnSach.IconColor = System.Drawing.Color.Black;
            this.btnSach.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSach.IconSize = 40;
            this.btnSach.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSach.Location = new System.Drawing.Point(0, 0);
            this.btnSach.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSach.Name = "btnSach";
            this.btnSach.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnSach.Size = new System.Drawing.Size(127, 67);
            this.btnSach.TabIndex = 0;
            this.btnSach.Text = "Thông tin sách";
            this.btnSach.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSach.UseVisualStyleBackColor = false;
            this.btnSach.Click += new System.EventHandler(this.btnSach_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.btnLichSuMuon);
            this.panel2.Controls.Add(this.btnMuonSach);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(8, 131);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 481);
            this.panel2.TabIndex = 4;
            // 
            // btnLichSuMuon
            // 
            this.btnLichSuMuon.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLichSuMuon.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLichSuMuon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLichSuMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSuMuon.IconChar = FontAwesome.Sharp.IconChar.History;
            this.btnLichSuMuon.IconColor = System.Drawing.Color.Black;
            this.btnLichSuMuon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLichSuMuon.IconSize = 40;
            this.btnLichSuMuon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichSuMuon.Location = new System.Drawing.Point(0, 67);
            this.btnLichSuMuon.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLichSuMuon.Name = "btnLichSuMuon";
            this.btnLichSuMuon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnLichSuMuon.Size = new System.Drawing.Size(127, 67);
            this.btnLichSuMuon.TabIndex = 3;
            this.btnLichSuMuon.Text = "            Lịch sử\r\n            mượn";
            this.btnLichSuMuon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichSuMuon.UseVisualStyleBackColor = false;
            this.btnLichSuMuon.Click += new System.EventHandler(this.btnLichSuMuon_Click);
            // 
            // btnMuonSach
            // 
            this.btnMuonSach.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMuonSach.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnMuonSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMuonSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuonSach.IconChar = FontAwesome.Sharp.IconChar.Bookmark;
            this.btnMuonSach.IconColor = System.Drawing.Color.Black;
            this.btnMuonSach.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMuonSach.IconSize = 40;
            this.btnMuonSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuonSach.Location = new System.Drawing.Point(0, 0);
            this.btnMuonSach.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMuonSach.Name = "btnMuonSach";
            this.btnMuonSach.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnMuonSach.Size = new System.Drawing.Size(127, 67);
            this.btnMuonSach.TabIndex = 1;
            this.btnMuonSach.Text = "            Mượn\r\n            sách";
            this.btnMuonSach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuonSach.UseVisualStyleBackColor = false;
            this.btnMuonSach.Click += new System.EventHandler(this.btnMuonSach_Click);
            // 
            // frmMainUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 645);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "frmMainUser";
            this.Padding = new System.Windows.Forms.Padding(8, 30, 8, 8);
            this.Resizable = false;
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private FontAwesome.Sharp.IconButton btnCaNhan;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private FontAwesome.Sharp.IconButton btnInfor;
        private FontAwesome.Sharp.IconButton btnTroGiup;
        private System.Windows.Forms.ToolStripLabel tslbTimer;
        private System.Windows.Forms.ToolStripLabel tslbThongTin;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnLichSuMuon;
        private FontAwesome.Sharp.IconButton btnMuonSach;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private FontAwesome.Sharp.IconButton btnSach;
    }
}

