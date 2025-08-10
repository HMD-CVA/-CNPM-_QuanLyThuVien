namespace QuanLyThuVienApp
{
    partial class frmMainAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainAdmin));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tslbTimer = new System.Windows.Forms.ToolStripLabel();
            this.tslbThongTin = new System.Windows.Forms.ToolStripLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.menuContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnInfoNhanVien = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCaNhan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnTroGiup = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnInfor = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.menuTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.sidebar.SuspendLayout();
            this.menuContainer.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslbTimer,
            this.tslbThongTin});
            this.toolStrip1.Location = new System.Drawing.Point(8, 797);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1464, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
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
            // metroPanel1
            // 
            this.metroPanel1.BackColor = System.Drawing.Color.White;
            this.metroPanel1.Controls.Add(this.btnHam);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 8;
            this.metroPanel1.Location = new System.Drawing.Point(8, 30);
            this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1464, 34);
            this.metroPanel1.TabIndex = 5;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 8;
            // 
            // btnHam
            // 
            this.btnHam.Image = global::QuanLyThuVienApp.Properties.Resources.png_transparent_computer_icons_hamburger_button_menu_symbol_exquisite_option_button_rectangle_black_interface;
            this.btnHam.Location = new System.Drawing.Point(0, 0);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(67, 34);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHam.TabIndex = 11;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(69, 7);
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
            // sidebar
            // 
            this.sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.sidebar.Controls.Add(this.menuContainer);
            this.sidebar.Controls.Add(this.panel1);
            this.sidebar.Controls.Add(this.panel2);
            this.sidebar.Controls.Add(this.panel3);
            this.sidebar.Controls.Add(this.panel4);
            this.sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebar.Location = new System.Drawing.Point(8, 64);
            this.sidebar.Name = "sidebar";
            this.sidebar.Size = new System.Drawing.Size(236, 733);
            this.sidebar.TabIndex = 10;
            // 
            // menuContainer
            // 
            this.menuContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.menuContainer.Controls.Add(this.panel5);
            this.menuContainer.Controls.Add(this.panel7);
            this.menuContainer.Location = new System.Drawing.Point(3, 3);
            this.menuContainer.Name = "menuContainer";
            this.menuContainer.Size = new System.Drawing.Size(233, 58);
            this.menuContainer.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.menu);
            this.panel5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(233, 58);
            this.panel5.TabIndex = 9;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.menu.ForeColor = System.Drawing.Color.White;
            this.menu.Image = global::QuanLyThuVienApp.Properties.Resources.Menhu_removebg_preview;
            this.menu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu.Location = new System.Drawing.Point(-52, -14);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.menu.Size = new System.Drawing.Size(319, 87);
            this.menu.TabIndex = 8;
            this.menu.Text = "                       Menu";
            this.menu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menu.UseVisualStyleBackColor = false;
            this.menu.Click += new System.EventHandler(this.menu_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnInfoNhanVien);
            this.panel7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(3, 67);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(233, 58);
            this.panel7.TabIndex = 10;
            // 
            // btnInfoNhanVien
            // 
            this.btnInfoNhanVien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnInfoNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnInfoNhanVien.Image = global::QuanLyThuVienApp.Properties.Resources.images__1__removebg_preview;
            this.btnInfoNhanVien.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfoNhanVien.Location = new System.Drawing.Point(-52, -14);
            this.btnInfoNhanVien.Name = "btnInfoNhanVien";
            this.btnInfoNhanVien.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnInfoNhanVien.Size = new System.Drawing.Size(319, 87);
            this.btnInfoNhanVien.TabIndex = 8;
            this.btnInfoNhanVien.Text = "                       Quản lý nhân viên";
            this.btnInfoNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfoNhanVien.UseVisualStyleBackColor = false;
            this.btnInfoNhanVien.Click += new System.EventHandler(this.btnInfoNhanVien_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCaNhan);
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 58);
            this.panel1.TabIndex = 7;
            // 
            // btnCaNhan
            // 
            this.btnCaNhan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnCaNhan.ForeColor = System.Drawing.Color.White;
            this.btnCaNhan.Image = global::QuanLyThuVienApp.Properties.Resources.person;
            this.btnCaNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaNhan.Location = new System.Drawing.Point(-52, -14);
            this.btnCaNhan.Name = "btnCaNhan";
            this.btnCaNhan.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnCaNhan.Size = new System.Drawing.Size(319, 87);
            this.btnCaNhan.TabIndex = 8;
            this.btnCaNhan.Text = "                       Thông tin cá nhân";
            this.btnCaNhan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCaNhan.UseVisualStyleBackColor = false;
            this.btnCaNhan.Click += new System.EventHandler(this.btnCaNhan_Click_1);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnTroGiup);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 58);
            this.panel2.TabIndex = 9;
            // 
            // btnTroGiup
            // 
            this.btnTroGiup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnTroGiup.ForeColor = System.Drawing.Color.White;
            this.btnTroGiup.Image = global::QuanLyThuVienApp.Properties.Resources.Support;
            this.btnTroGiup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTroGiup.Location = new System.Drawing.Point(-52, -14);
            this.btnTroGiup.Name = "btnTroGiup";
            this.btnTroGiup.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnTroGiup.Size = new System.Drawing.Size(319, 87);
            this.btnTroGiup.TabIndex = 8;
            this.btnTroGiup.Text = "                       Trợ giúp";
            this.btnTroGiup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTroGiup.UseVisualStyleBackColor = false;
            this.btnTroGiup.Click += new System.EventHandler(this.btnTroGiup_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnInfor);
            this.panel3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 195);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 58);
            this.panel3.TabIndex = 9;
            // 
            // btnInfor
            // 
            this.btnInfor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnInfor.ForeColor = System.Drawing.Color.White;
            this.btnInfor.Image = global::QuanLyThuVienApp.Properties.Resources.istockphoto_1369278773_612x612_removebg_preview;
            this.btnInfor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfor.Location = new System.Drawing.Point(-52, -14);
            this.btnInfor.Name = "btnInfor";
            this.btnInfor.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnInfor.Size = new System.Drawing.Size(319, 87);
            this.btnInfor.TabIndex = 8;
            this.btnInfor.Text = "                       Thông tin nhà phát triển";
            this.btnInfor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfor.UseVisualStyleBackColor = false;
            this.btnInfor.Click += new System.EventHandler(this.btnInfor_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnDangXuat);
            this.panel4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 259);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(233, 58);
            this.panel4.TabIndex = 9;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnDangXuat.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Image = global::QuanLyThuVienApp.Properties.Resources.log_out_removebg_preview;
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(-52, -14);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Padding = new System.Windows.Forms.Padding(60, 0, 0, 0);
            this.btnDangXuat.Size = new System.Drawing.Size(319, 87);
            this.btnDangXuat.TabIndex = 8;
            this.btnDangXuat.Text = "                       Đăng xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.UseVisualStyleBackColor = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click_1);
            // 
            // menuTransition
            // 
            this.menuTransition.Interval = 10;
            this.menuTransition.Tick += new System.EventHandler(this.menuTransition_Tick);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // frmMainAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 830);
            this.Controls.Add(this.sidebar);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.metroPanel1);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmMainAdmin";
            this.Padding = new System.Windows.Forms.Padding(8, 30, 8, 8);
            this.Resizable = false;
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.Load += new System.EventHandler(this.frmMainAdmin_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.sidebar.ResumeLayout(false);
            this.menuContainer.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslbTimer;
        private System.Windows.Forms.ToolStripLabel tslbThongTin;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox btnHam;
        private System.Windows.Forms.FlowLayoutPanel sidebar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCaNhan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnInfor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnTroGiup;
        private System.Windows.Forms.FlowLayoutPanel menuContainer;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button menu;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button btnInfoNhanVien;
        private System.Windows.Forms.Timer menuTransition;
        private System.Windows.Forms.Timer sidebarTransition;
    }
}