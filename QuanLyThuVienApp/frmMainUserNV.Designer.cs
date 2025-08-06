namespace QuanLyThuVienApp
{
    partial class frmMainUserNV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainUserNV));
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnGuiMail = new FontAwesome.Sharp.IconButton();
            this.btnQLDocGia = new FontAwesome.Sharp.IconButton();
            this.btnQLPhieuMuon = new FontAwesome.Sharp.IconButton();
            this.btnLichSuMuon = new FontAwesome.Sharp.IconButton();
            this.metroPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.btnCaNhan.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnInfor.Padding = new System.Windows.Forms.Padding(8);
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
            this.btnTroGiup.Margin = new System.Windows.Forms.Padding(2);
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
            this.btnThongKe.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.btnThongKe.IconColor = System.Drawing.Color.Black;
            this.btnThongKe.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThongKe.IconSize = 40;
            this.btnThongKe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThongKe.Location = new System.Drawing.Point(0, 268);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.btnThongKe.Size = new System.Drawing.Size(127, 67);
            this.btnThongKe.TabIndex = 1;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.Controls.Add(this.btnThongKe);
            this.panel2.Controls.Add(this.btnGuiMail);
            this.panel2.Controls.Add(this.btnQLDocGia);
            this.panel2.Controls.Add(this.btnQLPhieuMuon);
            this.panel2.Controls.Add(this.btnLichSuMuon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(8, 131);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(127, 481);
            this.panel2.TabIndex = 4;
            // 
            // btnGuiMail
            // 
            this.btnGuiMail.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnGuiMail.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGuiMail.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGuiMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiMail.IconChar = FontAwesome.Sharp.IconChar.Google;
            this.btnGuiMail.IconColor = System.Drawing.Color.Black;
            this.btnGuiMail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuiMail.IconSize = 40;
            this.btnGuiMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuiMail.Location = new System.Drawing.Point(0, 201);
            this.btnGuiMail.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuiMail.Name = "btnGuiMail";
            this.btnGuiMail.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnGuiMail.Size = new System.Drawing.Size(127, 67);
            this.btnGuiMail.TabIndex = 5;
            this.btnGuiMail.Text = "            Quản lý \r\n            \r\n  ";
            this.btnGuiMail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuiMail.UseVisualStyleBackColor = false;
            this.btnGuiMail.Click += new System.EventHandler(this.btnGuiEmail_Click);
            // 
            // btnQLDocGia
            // 
            this.btnQLDocGia.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQLDocGia.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQLDocGia.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLDocGia.IconChar = FontAwesome.Sharp.IconChar.Person;
            this.btnQLDocGia.IconColor = System.Drawing.Color.Black;
            this.btnQLDocGia.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLDocGia.IconSize = 40;
            this.btnQLDocGia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDocGia.Location = new System.Drawing.Point(0, 134);
            this.btnQLDocGia.Margin = new System.Windows.Forms.Padding(2);
            this.btnQLDocGia.Name = "btnQLDocGia";
            this.btnQLDocGia.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnQLDocGia.Size = new System.Drawing.Size(127, 67);
            this.btnQLDocGia.TabIndex = 4;
            this.btnQLDocGia.Text = "            Quản lý\r\n            độc giả\r\n";
            this.btnQLDocGia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLDocGia.UseVisualStyleBackColor = false;
            this.btnQLDocGia.Click += new System.EventHandler(this.btnQLDocGia_Click);
            // 
            // btnQLPhieuMuon
            // 
            this.btnQLPhieuMuon.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnQLPhieuMuon.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnQLPhieuMuon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnQLPhieuMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQLPhieuMuon.IconChar = FontAwesome.Sharp.IconChar.Bookmark;
            this.btnQLPhieuMuon.IconColor = System.Drawing.Color.Black;
            this.btnQLPhieuMuon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQLPhieuMuon.IconSize = 40;
            this.btnQLPhieuMuon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLPhieuMuon.Location = new System.Drawing.Point(0, 67);
            this.btnQLPhieuMuon.Margin = new System.Windows.Forms.Padding(2);
            this.btnQLPhieuMuon.Name = "btnQLPhieuMuon";
            this.btnQLPhieuMuon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnQLPhieuMuon.Size = new System.Drawing.Size(127, 67);
            this.btnQLPhieuMuon.TabIndex = 1;
            this.btnQLPhieuMuon.Text = "            Quản lý\r\n              phiếu \r\n              mượn";
            this.btnQLPhieuMuon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQLPhieuMuon.UseVisualStyleBackColor = false;
            this.btnQLPhieuMuon.Click += new System.EventHandler(this.btnMuonSach_Click);
            // 
            // btnLichSuMuon
            // 
            this.btnLichSuMuon.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnLichSuMuon.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnLichSuMuon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLichSuMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichSuMuon.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btnLichSuMuon.IconColor = System.Drawing.Color.Black;
            this.btnLichSuMuon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLichSuMuon.IconSize = 40;
            this.btnLichSuMuon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichSuMuon.Location = new System.Drawing.Point(0, 0);
            this.btnLichSuMuon.Margin = new System.Windows.Forms.Padding(2);
            this.btnLichSuMuon.Name = "btnLichSuMuon";
            this.btnLichSuMuon.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnLichSuMuon.Size = new System.Drawing.Size(127, 67);
            this.btnLichSuMuon.TabIndex = 3;
            this.btnLichSuMuon.Text = "            Quản lý\r\n             tài liệu";
            this.btnLichSuMuon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLichSuMuon.UseVisualStyleBackColor = false;
            this.btnLichSuMuon.Click += new System.EventHandler(this.btnLichSuMuon_Click);
            // 
            // frmMainUserNV
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
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmMainUserNV";
            this.Padding = new System.Windows.Forms.Padding(8, 30, 8, 8);
            this.Resizable = false;
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
        private FontAwesome.Sharp.IconButton btnQLPhieuMuon;
        private FontAwesome.Sharp.IconButton btnThongKe;
        private FontAwesome.Sharp.IconButton btnLichSuMuon;
        private FontAwesome.Sharp.IconButton btnQLDocGia;
        private FontAwesome.Sharp.IconButton btnGuiMail;
    }
}

