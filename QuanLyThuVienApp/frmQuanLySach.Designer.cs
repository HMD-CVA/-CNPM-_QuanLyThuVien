﻿namespace QuanLyThuVienApp
{
    partial class frmQuanLySach
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.btnTimKiem = new FontAwesome.Sharp.IconButton();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lbMaSach = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cbTacGia = new System.Windows.Forms.ComboBox();
            this.cbNXB = new System.Windows.Forms.ComboBox();
            this.cbTheLoai = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThemTG = new FontAwesome.Sharp.IconButton();
            this.btnThemNXB = new FontAwesome.Sharp.IconButton();
            this.btnThemTheLoai = new FontAwesome.Sharp.IconButton();
            this.lbDangMuon = new System.Windows.Forms.Label();
            this.txtDangMuon = new System.Windows.Forms.TextBox();
            this.radioThem = new System.Windows.Forms.RadioButton();
            this.radioSuaXoa = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTaiBan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.MaTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTaiLieuMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSach);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 196);
            this.panel1.TabIndex = 0;
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.AllowUserToResizeRows = false;
            this.dgvSach.BackgroundColor = System.Drawing.Color.White;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTaiLieu,
            this.TenTaiLieu,
            this.TenDanhMuc,
            this.TenTG,
            this.TenNXB,
            this.TaiBan,
            this.SoLuong,
            this.SoTaiLieuMuon});
            this.dgvSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSach.Location = new System.Drawing.Point(0, 0);
            this.dgvSach.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSach.MultiSelect = false;
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.RowHeadersVisible = false;
            this.dgvSach.RowHeadersWidth = 51;
            this.dgvSach.RowTemplate.Height = 24;
            this.dgvSach.Size = new System.Drawing.Size(915, 196);
            this.dgvSach.TabIndex = 1;
            this.dgvSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellClick);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btnLamMoi.IconColor = System.Drawing.Color.Black;
            this.btnLamMoi.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnLamMoi.IconSize = 19;
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(60, 239);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(87, 25);
            this.btnLamMoi.TabIndex = 11;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnTimKiem.IconColor = System.Drawing.Color.Black;
            this.btnTimKiem.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnTimKiem.IconSize = 19;
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(154, 239);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(87, 25);
            this.btnTimKiem.TabIndex = 12;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Items.AddRange(new object[] {
            "Mã sách",
            "Tên sách",
            "Tác giả",
            "Nhà xuất bản",
            "Thể loại"});
            this.cbTimKiem.Location = new System.Drawing.Point(148, 164);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(99, 25);
            this.cbTimKiem.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Tìm kiếm theo";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(52, 201);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(196, 23);
            this.txtTimKiem.TabIndex = 8;
            // 
            // lbMaSach
            // 
            this.lbMaSach.AutoSize = true;
            this.lbMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaSach.Location = new System.Drawing.Point(348, 13);
            this.lbMaSach.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMaSach.Name = "lbMaSach";
            this.lbMaSach.Size = new System.Drawing.Size(61, 17);
            this.lbMaSach.TabIndex = 13;
            this.lbMaSach.Text = "Mã sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(348, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tên sách";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tác giả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Nhà xuất bản";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 94);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Danh mục";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.Location = new System.Drawing.Point(351, 84);
            this.lbSoLuong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(64, 17);
            this.lbSoLuong.TabIndex = 13;
            this.lbSoLuong.Text = "Số lượng";
            // 
            // txtMaSach
            // 
            this.txtMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSach.Location = new System.Drawing.Point(444, 13);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(184, 23);
            this.txtMaSach.TabIndex = 14;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSach.Location = new System.Drawing.Point(444, 48);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(184, 23);
            this.txtTenSach.TabIndex = 14;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoLuong.Location = new System.Drawing.Point(411, 84);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(45, 23);
            this.txtSoLuong.TabIndex = 14;
            // 
            // cbTacGia
            // 
            this.cbTacGia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTacGia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTacGia.FormattingEnabled = true;
            this.cbTacGia.Location = new System.Drawing.Point(118, 13);
            this.cbTacGia.Margin = new System.Windows.Forms.Padding(2);
            this.cbTacGia.Name = "cbTacGia";
            this.cbTacGia.Size = new System.Drawing.Size(184, 25);
            this.cbTacGia.TabIndex = 15;
            // 
            // cbNXB
            // 
            this.cbNXB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbNXB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbNXB.FormattingEnabled = true;
            this.cbNXB.Items.AddRange(new object[] {
            "    "});
            this.cbNXB.Location = new System.Drawing.Point(118, 54);
            this.cbNXB.Margin = new System.Windows.Forms.Padding(2);
            this.cbNXB.Name = "cbNXB";
            this.cbNXB.Size = new System.Drawing.Size(184, 25);
            this.cbNXB.TabIndex = 15;
            // 
            // cbTheLoai
            // 
            this.cbTheLoai.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbTheLoai.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTheLoai.FormattingEnabled = true;
            this.cbTheLoai.Items.AddRange(new object[] {
            "   "});
            this.cbTheLoai.Location = new System.Drawing.Point(118, 94);
            this.cbTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.cbTheLoai.Name = "cbTheLoai";
            this.cbTheLoai.Size = new System.Drawing.Size(184, 25);
            this.cbTheLoai.TabIndex = 15;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(572, 223);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(95, 25);
            this.btnThem.TabIndex = 16;
            this.btnThem.Text = "Thêm sách";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Location = new System.Drawing.Point(509, 223);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(95, 25);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa sách";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(630, 223);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(95, 25);
            this.btnXoa.TabIndex = 16;
            this.btnXoa.Text = "Xóa sách";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThemTG
            // 
            this.btnThemTG.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThemTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTG.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnThemTG.IconColor = System.Drawing.Color.Black;
            this.btnThemTG.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemTG.IconSize = 15;
            this.btnThemTG.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemTG.Location = new System.Drawing.Point(306, 13);
            this.btnThemTG.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemTG.Name = "btnThemTG";
            this.btnThemTG.Size = new System.Drawing.Size(21, 21);
            this.btnThemTG.TabIndex = 17;
            this.btnThemTG.UseVisualStyleBackColor = false;
            this.btnThemTG.Click += new System.EventHandler(this.btnThemTG_Click);
            // 
            // btnThemNXB
            // 
            this.btnThemNXB.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThemNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNXB.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnThemNXB.IconColor = System.Drawing.Color.Black;
            this.btnThemNXB.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemNXB.IconSize = 15;
            this.btnThemNXB.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemNXB.Location = new System.Drawing.Point(306, 54);
            this.btnThemNXB.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemNXB.Name = "btnThemNXB";
            this.btnThemNXB.Size = new System.Drawing.Size(21, 21);
            this.btnThemNXB.TabIndex = 17;
            this.btnThemNXB.UseVisualStyleBackColor = false;
            this.btnThemNXB.Click += new System.EventHandler(this.btnThemNXB_Click);
            // 
            // btnThemTheLoai
            // 
            this.btnThemTheLoai.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThemTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemTheLoai.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnThemTheLoai.IconColor = System.Drawing.Color.Black;
            this.btnThemTheLoai.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnThemTheLoai.IconSize = 15;
            this.btnThemTheLoai.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnThemTheLoai.Location = new System.Drawing.Point(306, 94);
            this.btnThemTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.btnThemTheLoai.Name = "btnThemTheLoai";
            this.btnThemTheLoai.Size = new System.Drawing.Size(21, 21);
            this.btnThemTheLoai.TabIndex = 17;
            this.btnThemTheLoai.UseVisualStyleBackColor = false;
            this.btnThemTheLoai.Click += new System.EventHandler(this.btnThemTheLoai_Click);
            // 
            // lbDangMuon
            // 
            this.lbDangMuon.AutoSize = true;
            this.lbDangMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDangMuon.Location = new System.Drawing.Point(348, 124);
            this.lbDangMuon.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDangMuon.Name = "lbDangMuon";
            this.lbDangMuon.Size = new System.Drawing.Size(81, 17);
            this.lbDangMuon.TabIndex = 13;
            this.lbDangMuon.Text = "Đang mượn";
            // 
            // txtDangMuon
            // 
            this.txtDangMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDangMuon.Location = new System.Drawing.Point(444, 120);
            this.txtDangMuon.Margin = new System.Windows.Forms.Padding(2);
            this.txtDangMuon.Name = "txtDangMuon";
            this.txtDangMuon.ReadOnly = true;
            this.txtDangMuon.Size = new System.Drawing.Size(184, 23);
            this.txtDangMuon.TabIndex = 14;
            // 
            // radioThem
            // 
            this.radioThem.AutoSize = true;
            this.radioThem.Location = new System.Drawing.Point(136, 17);
            this.radioThem.Margin = new System.Windows.Forms.Padding(2);
            this.radioThem.Name = "radioThem";
            this.radioThem.Size = new System.Drawing.Size(96, 21);
            this.radioThem.TabIndex = 18;
            this.radioThem.Text = "Thêm sách";
            this.radioThem.UseVisualStyleBackColor = true;
            this.radioThem.CheckedChanged += new System.EventHandler(this.radioThem_CheckedChanged);
            // 
            // radioSuaXoa
            // 
            this.radioSuaXoa.AutoSize = true;
            this.radioSuaXoa.Location = new System.Drawing.Point(10, 17);
            this.radioSuaXoa.Margin = new System.Windows.Forms.Padding(2);
            this.radioSuaXoa.Name = "radioSuaXoa";
            this.radioSuaXoa.Size = new System.Drawing.Size(122, 21);
            this.radioSuaXoa.TabIndex = 19;
            this.radioSuaXoa.Text = "Sửa / Xóa sách";
            this.radioSuaXoa.UseVisualStyleBackColor = true;
            this.radioSuaXoa.CheckedChanged += new System.EventHandler(this.radioSuaXoa_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioThem);
            this.groupBox1.Controls.Add(this.radioSuaXoa);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(506, 171);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(235, 45);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // txtTaiBan
            // 
            this.txtTaiBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaiBan.Location = new System.Drawing.Point(536, 84);
            this.txtTaiBan.Margin = new System.Windows.Forms.Padding(2);
            this.txtTaiBan.Name = "txtTaiBan";
            this.txtTaiBan.Size = new System.Drawing.Size(45, 23);
            this.txtTaiBan.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(476, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 23;
            this.label7.Text = "Tái bản";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Location = new System.Drawing.Point(664, 25);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(236, 118);
            this.txtMoTa.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(661, 7);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 25;
            this.label8.Text = "Mô Tả";
            // 
            // MaTaiLieu
            // 
            this.MaTaiLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaTaiLieu.DataPropertyName = "MaTaiLieu";
            this.MaTaiLieu.HeaderText = "Mã Tài Liệu";
            this.MaTaiLieu.MinimumWidth = 6;
            this.MaTaiLieu.Name = "MaTaiLieu";
            this.MaTaiLieu.ReadOnly = true;
            this.MaTaiLieu.Width = 107;
            // 
            // TenTaiLieu
            // 
            this.TenTaiLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenTaiLieu.DataPropertyName = "TenTaiLieu";
            this.TenTaiLieu.HeaderText = "Tên Tài Liệu";
            this.TenTaiLieu.MinimumWidth = 6;
            this.TenTaiLieu.Name = "TenTaiLieu";
            this.TenTaiLieu.ReadOnly = true;
            // 
            // TenDanhMuc
            // 
            this.TenDanhMuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.TenDanhMuc.HeaderText = "Danh Mục";
            this.TenDanhMuc.MinimumWidth = 6;
            this.TenDanhMuc.Name = "TenDanhMuc";
            this.TenDanhMuc.ReadOnly = true;
            this.TenDanhMuc.Width = 97;
            // 
            // TenTG
            // 
            this.TenTG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TenTG.DataPropertyName = "TenTG";
            this.TenTG.HeaderText = "Tác giả";
            this.TenTG.MinimumWidth = 6;
            this.TenTG.Name = "TenTG";
            this.TenTG.ReadOnly = true;
            this.TenTG.Width = 80;
            // 
            // TenNXB
            // 
            this.TenNXB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TenNXB.DataPropertyName = "TenNXB";
            this.TenNXB.HeaderText = "Nhà xuất bản";
            this.TenNXB.MinimumWidth = 6;
            this.TenNXB.Name = "TenNXB";
            this.TenNXB.ReadOnly = true;
            this.TenNXB.Width = 117;
            // 
            // TaiBan
            // 
            this.TaiBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TaiBan.DataPropertyName = "TaiBan";
            this.TaiBan.HeaderText = "Tái Bản";
            this.TaiBan.MinimumWidth = 6;
            this.TaiBan.Name = "TaiBan";
            this.TaiBan.ReadOnly = true;
            this.TaiBan.Width = 82;
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 89;
            // 
            // SoTaiLieuMuon
            // 
            this.SoTaiLieuMuon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SoTaiLieuMuon.DataPropertyName = "SoTaiLieuMuon";
            this.SoTaiLieuMuon.HeaderText = "Đang mượn";
            this.SoTaiLieuMuon.MinimumWidth = 6;
            this.SoTaiLieuMuon.Name = "SoTaiLieuMuon";
            this.SoTaiLieuMuon.ReadOnly = true;
            this.SoTaiLieuMuon.Width = 106;
            // 
            // frmQuanLySach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 475);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTaiBan);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThemTheLoai);
            this.Controls.Add(this.btnThemNXB);
            this.Controls.Add(this.btnThemTG);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cbTheLoai);
            this.Controls.Add(this.cbNXB);
            this.Controls.Add(this.cbTacGia);
            this.Controls.Add(this.txtDangMuon);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.txtMaSach);
            this.Controls.Add(this.lbDangMuon);
            this.Controls.Add(this.lbSoLuong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMaSach);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cbTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmQuanLySach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLySach";
            this.Load += new System.EventHandler(this.frmQuanLySach_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSach;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private FontAwesome.Sharp.IconButton btnTimKiem;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lbMaSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cbTacGia;
        private System.Windows.Forms.ComboBox cbNXB;
        private System.Windows.Forms.ComboBox cbTheLoai;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private FontAwesome.Sharp.IconButton btnThemTG;
        private FontAwesome.Sharp.IconButton btnThemNXB;
        private FontAwesome.Sharp.IconButton btnThemTheLoai;
        private System.Windows.Forms.Label lbDangMuon;
        private System.Windows.Forms.TextBox txtDangMuon;
        private System.Windows.Forms.RadioButton radioThem;
        private System.Windows.Forms.RadioButton radioSuaXoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTaiBan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTaiLieuMuon;
    }
}