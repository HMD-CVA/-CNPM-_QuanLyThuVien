namespace QuanLyThuVienApp
{
    partial class frmQuanLyPhieuMuon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTimKiem = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvChiTietPM = new System.Windows.Forms.DataGridView();
            this.MaChiTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaPM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongBD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupPhieuTra = new System.Windows.Forms.GroupBox();
            this.rdbTreHan = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.radioPhieuTra = new System.Windows.Forms.RadioButton();
            this.radioPhieuMuon = new System.Windows.Forms.RadioButton();
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.MaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMuonMoi = new System.Windows.Forms.Button();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnTraTL = new System.Windows.Forms.Button();
            this.btnInPM = new System.Windows.Forms.Button();
            this.btnChoMuon = new System.Windows.Forms.Button();
            this.lab_Huy = new MetroFramework.Controls.MetroLabel();
            this.btnTTDG = new FontAwesome.Sharp.IconButton();
            this.btnHuyPhieu = new FontAwesome.Sharp.IconButton();
            this.btnXLTreHan = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPM)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupPhieuTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            this.SuspendLayout();
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
            this.btnTimKiem.Location = new System.Drawing.Point(1115, 240);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(86, 25);
            this.btnTimKiem.TabIndex = 33;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(992, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tìm kiếm theo";
            // 
            // dgvChiTietPM
            // 
            this.dgvChiTietPM.AllowUserToAddRows = false;
            this.dgvChiTietPM.AllowUserToDeleteRows = false;
            this.dgvChiTietPM.AllowUserToResizeRows = false;
            this.dgvChiTietPM.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChiTietPM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChiTietPM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietPM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChiTiet,
            this.MaPM,
            this.MaTaiLieu,
            this.TenTaiLieu,
            this.TenDanhMuc,
            this.TenTG,
            this.TenNXB,
            this.SoLuongBD,
            this.SoLuong});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChiTietPM.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChiTietPM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChiTietPM.Location = new System.Drawing.Point(0, 0);
            this.dgvChiTietPM.Margin = new System.Windows.Forms.Padding(2);
            this.dgvChiTietPM.MultiSelect = false;
            this.dgvChiTietPM.Name = "dgvChiTietPM";
            this.dgvChiTietPM.ReadOnly = true;
            this.dgvChiTietPM.RowHeadersVisible = false;
            this.dgvChiTietPM.RowHeadersWidth = 51;
            this.dgvChiTietPM.RowTemplate.Height = 24;
            this.dgvChiTietPM.Size = new System.Drawing.Size(1219, 423);
            this.dgvChiTietPM.TabIndex = 1;
            this.dgvChiTietPM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietPM_CellClick);
            this.dgvChiTietPM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvChiTietPM_CellFormatting);
            // 
            // MaChiTiet
            // 
            this.MaChiTiet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MaChiTiet.DataPropertyName = "MaChiTiet";
            this.MaChiTiet.HeaderText = "Mã";
            this.MaChiTiet.Name = "MaChiTiet";
            this.MaChiTiet.ReadOnly = true;
            this.MaChiTiet.Visible = false;
            // 
            // MaPM
            // 
            this.MaPM.DataPropertyName = "MaPM";
            this.MaPM.HeaderText = "Mã phiếu mượn";
            this.MaPM.Name = "MaPM";
            this.MaPM.ReadOnly = true;
            this.MaPM.Visible = false;
            // 
            // MaTaiLieu
            // 
            this.MaTaiLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MaTaiLieu.DataPropertyName = "MaTaiLieu";
            this.MaTaiLieu.HeaderText = "Mã";
            this.MaTaiLieu.Name = "MaTaiLieu";
            this.MaTaiLieu.ReadOnly = true;
            this.MaTaiLieu.Width = 51;
            // 
            // TenTaiLieu
            // 
            this.TenTaiLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenTaiLieu.DataPropertyName = "TenTaiLieu";
            this.TenTaiLieu.HeaderText = "Tên tài liệu";
            this.TenTaiLieu.Name = "TenTaiLieu";
            this.TenTaiLieu.ReadOnly = true;
            // 
            // TenDanhMuc
            // 
            this.TenDanhMuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.TenDanhMuc.HeaderText = "Danh mục";
            this.TenDanhMuc.Name = "TenDanhMuc";
            this.TenDanhMuc.ReadOnly = true;
            this.TenDanhMuc.Width = 92;
            // 
            // TenTG
            // 
            this.TenTG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenTG.DataPropertyName = "TenTG";
            this.TenTG.HeaderText = "Tác giả";
            this.TenTG.Name = "TenTG";
            this.TenTG.ReadOnly = true;
            this.TenTG.Width = 78;
            // 
            // TenNXB
            // 
            this.TenNXB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenNXB.DataPropertyName = "TenNXB";
            this.TenNXB.HeaderText = "NXB";
            this.TenNXB.Name = "TenNXB";
            this.TenNXB.ReadOnly = true;
            this.TenNXB.Width = 59;
            // 
            // SoLuongBD
            // 
            this.SoLuongBD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SoLuongBD.DataPropertyName = "SoLuongBD";
            this.SoLuongBD.HeaderText = "Số lượng";
            this.SoLuongBD.Name = "SoLuongBD";
            this.SoLuongBD.ReadOnly = true;
            this.SoLuongBD.Width = 85;
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Chưa trả";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 81;
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
            this.btnLamMoi.Location = new System.Drawing.Point(995, 240);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(86, 25);
            this.btnLamMoi.TabIndex = 32;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Items.AddRange(new object[] {
            "Mã phiếu",
            "Tên độc giả",
            "Tên nhân viên",
            "Ngày mượn",
            "Ngày trả"});
            this.cbTimKiem.Location = new System.Drawing.Point(1093, 161);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(108, 25);
            this.cbTimKiem.TabIndex = 31;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(995, 203);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(206, 23);
            this.txtTimKiem.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvChiTietPM);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 301);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 423);
            this.panel1.TabIndex = 28;
            // 
            // groupPhieuTra
            // 
            this.groupPhieuTra.Controls.Add(this.rdbTreHan);
            this.groupPhieuTra.Controls.Add(this.rdbAll);
            this.groupPhieuTra.Controls.Add(this.radioPhieuTra);
            this.groupPhieuTra.Controls.Add(this.radioPhieuMuon);
            this.groupPhieuTra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupPhieuTra.Location = new System.Drawing.Point(995, 32);
            this.groupPhieuTra.Margin = new System.Windows.Forms.Padding(2);
            this.groupPhieuTra.Name = "groupPhieuTra";
            this.groupPhieuTra.Padding = new System.Windows.Forms.Padding(2);
            this.groupPhieuTra.Size = new System.Drawing.Size(213, 125);
            this.groupPhieuTra.TabIndex = 35;
            this.groupPhieuTra.TabStop = false;
            this.groupPhieuTra.Text = "Danh sách phiếu";
            // 
            // rdbTreHan
            // 
            this.rdbTreHan.AutoSize = true;
            this.rdbTreHan.Location = new System.Drawing.Point(10, 74);
            this.rdbTreHan.Name = "rdbTreHan";
            this.rdbTreHan.Size = new System.Drawing.Size(76, 21);
            this.rdbTreHan.TabIndex = 36;
            this.rdbTreHan.TabStop = true;
            this.rdbTreHan.Text = "Trễ hạn";
            this.rdbTreHan.UseVisualStyleBackColor = true;
            this.rdbTreHan.CheckedChanged += new System.EventHandler(this.rdbTreHan_CheckedChanged);
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(10, 99);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(144, 21);
            this.rdbAll.TabIndex = 35;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "Tất cả phiếu mượn";
            this.rdbAll.UseVisualStyleBackColor = true;
            this.rdbAll.CheckedChanged += new System.EventHandler(this.rdbAll_CheckedChanged);
            // 
            // radioPhieuTra
            // 
            this.radioPhieuTra.AutoSize = true;
            this.radioPhieuTra.Location = new System.Drawing.Point(10, 48);
            this.radioPhieuTra.Margin = new System.Windows.Forms.Padding(2);
            this.radioPhieuTra.Name = "radioPhieuTra";
            this.radioPhieuTra.Size = new System.Drawing.Size(65, 21);
            this.radioPhieuTra.TabIndex = 34;
            this.radioPhieuTra.TabStop = true;
            this.radioPhieuTra.Text = "Đã trả";
            this.radioPhieuTra.UseVisualStyleBackColor = true;
            this.radioPhieuTra.CheckedChanged += new System.EventHandler(this.radioPhieuTra_CheckedChanged);
            // 
            // radioPhieuMuon
            // 
            this.radioPhieuMuon.AutoSize = true;
            this.radioPhieuMuon.Location = new System.Drawing.Point(10, 23);
            this.radioPhieuMuon.Margin = new System.Windows.Forms.Padding(2);
            this.radioPhieuMuon.Name = "radioPhieuMuon";
            this.radioPhieuMuon.Size = new System.Drawing.Size(99, 21);
            this.radioPhieuMuon.TabIndex = 34;
            this.radioPhieuMuon.TabStop = true;
            this.radioPhieuMuon.Text = "Đang mượn";
            this.radioPhieuMuon.UseVisualStyleBackColor = true;
            this.radioPhieuMuon.CheckedChanged += new System.EventHandler(this.radioPhieuMuon_CheckedChanged);
            // 
            // dgvPhieuMuon
            // 
            this.dgvPhieuMuon.AllowUserToAddRows = false;
            this.dgvPhieuMuon.AllowUserToDeleteRows = false;
            this.dgvPhieuMuon.AllowUserToResizeRows = false;
            this.dgvPhieuMuon.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieuMuon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieu,
            this.HoTenDG,
            this.HoTenNV,
            this.NgayMuon,
            this.HanTra,
            this.DaTra,
            this.NgayTra});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhieuMuon.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPhieuMuon.Location = new System.Drawing.Point(11, 32);
            this.dgvPhieuMuon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPhieuMuon.MultiSelect = false;
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.ReadOnly = true;
            this.dgvPhieuMuon.RowHeadersVisible = false;
            this.dgvPhieuMuon.RowHeadersWidth = 51;
            this.dgvPhieuMuon.RowTemplate.Height = 24;
            this.dgvPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(962, 190);
            this.dgvPhieuMuon.TabIndex = 37;
            this.dgvPhieuMuon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuMuon_CellClick);
            this.dgvPhieuMuon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhieuMuon_CellFormatting);
            // 
            // MaPhieu
            // 
            this.MaPhieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MaPhieu.DataPropertyName = "MaPhieu";
            this.MaPhieu.HeaderText = "Mã";
            this.MaPhieu.MinimumWidth = 6;
            this.MaPhieu.Name = "MaPhieu";
            this.MaPhieu.ReadOnly = true;
            this.MaPhieu.Width = 51;
            // 
            // HoTenDG
            // 
            this.HoTenDG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoTenDG.DataPropertyName = "HoTenDG";
            this.HoTenDG.HeaderText = "Độc giả";
            this.HoTenDG.MinimumWidth = 6;
            this.HoTenDG.Name = "HoTenDG";
            this.HoTenDG.ReadOnly = true;
            // 
            // HoTenNV
            // 
            this.HoTenNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoTenNV.DataPropertyName = "HoTenNV";
            this.HoTenNV.HeaderText = "Nhân viên";
            this.HoTenNV.MinimumWidth = 6;
            this.HoTenNV.Name = "HoTenNV";
            this.HoTenNV.ReadOnly = true;
            // 
            // NgayMuon
            // 
            this.NgayMuon.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NgayMuon.DataPropertyName = "NgayMuon";
            this.NgayMuon.HeaderText = "Ngày mượn";
            this.NgayMuon.MinimumWidth = 6;
            this.NgayMuon.Name = "NgayMuon";
            this.NgayMuon.ReadOnly = true;
            this.NgayMuon.Width = 101;
            // 
            // HanTra
            // 
            this.HanTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.HanTra.DataPropertyName = "HanTra";
            this.HanTra.HeaderText = "Hạn trả";
            this.HanTra.Name = "HanTra";
            this.HanTra.ReadOnly = true;
            this.HanTra.Width = 75;
            // 
            // DaTra
            // 
            this.DaTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DaTra.DataPropertyName = "DaTra";
            this.DaTra.HeaderText = "Trạng thái";
            this.DaTra.MinimumWidth = 6;
            this.DaTra.Name = "DaTra";
            this.DaTra.ReadOnly = true;
            this.DaTra.Width = 92;
            // 
            // NgayTra
            // 
            this.NgayTra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NgayTra.DataPropertyName = "NgayTra";
            this.NgayTra.HeaderText = "Ngày trả";
            this.NgayTra.Name = "NgayTra";
            this.NgayTra.ReadOnly = true;
            this.NgayTra.Width = 83;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(419, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "DANH SÁCH PHIẾU MƯỢN";
            // 
            // btnMuonMoi
            // 
            this.btnMuonMoi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMuonMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuonMoi.Image = global::QuanLyThuVienApp.Properties.Resources._992651_removebg_preview;
            this.btnMuonMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMuonMoi.Location = new System.Drawing.Point(11, 226);
            this.btnMuonMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnMuonMoi.Name = "btnMuonMoi";
            this.btnMuonMoi.Size = new System.Drawing.Size(106, 25);
            this.btnMuonMoi.TabIndex = 40;
            this.btnMuonMoi.Text = "    Mượn mới";
            this.btnMuonMoi.UseVisualStyleBackColor = false;
            this.btnMuonMoi.Click += new System.EventHandler(this.btnMuonMoi_Click);
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGiaHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiaHan.Image = global::QuanLyThuVienApp.Properties.Resources.images__3__removebg_preview;
            this.btnGiaHan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiaHan.Location = new System.Drawing.Point(455, 226);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(106, 25);
            this.btnGiaHan.TabIndex = 41;
            this.btnGiaHan.Text = "   Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = false;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnTraTL
            // 
            this.btnTraTL.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTraTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraTL.Image = global::QuanLyThuVienApp.Properties.Resources.images__5__removebg_preview;
            this.btnTraTL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTraTL.Location = new System.Drawing.Point(143, 226);
            this.btnTraTL.Margin = new System.Windows.Forms.Padding(2);
            this.btnTraTL.Name = "btnTraTL";
            this.btnTraTL.Size = new System.Drawing.Size(154, 25);
            this.btnTraTL.TabIndex = 41;
            this.btnTraTL.Text = "     Trả phiếu mượn";
            this.btnTraTL.UseVisualStyleBackColor = false;
            this.btnTraTL.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // btnInPM
            // 
            this.btnInPM.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnInPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInPM.Image = global::QuanLyThuVienApp.Properties.Resources._3022251_removebg_preview;
            this.btnInPM.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInPM.Location = new System.Drawing.Point(587, 226);
            this.btnInPM.Margin = new System.Windows.Forms.Padding(2);
            this.btnInPM.Name = "btnInPM";
            this.btnInPM.Size = new System.Drawing.Size(106, 25);
            this.btnInPM.TabIndex = 41;
            this.btnInPM.Text = "   In phiếu mượn";
            this.btnInPM.UseVisualStyleBackColor = false;
            this.btnInPM.Click += new System.EventHandler(this.btnINHoaDon_Click);
            // 
            // btnChoMuon
            // 
            this.btnChoMuon.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnChoMuon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoMuon.Image = global::QuanLyThuVienApp.Properties.Resources._6e85433773df189370918acb9dc95e68_t_removebg_preview;
            this.btnChoMuon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChoMuon.Location = new System.Drawing.Point(323, 226);
            this.btnChoMuon.Margin = new System.Windows.Forms.Padding(2);
            this.btnChoMuon.Name = "btnChoMuon";
            this.btnChoMuon.Size = new System.Drawing.Size(106, 25);
            this.btnChoMuon.TabIndex = 43;
            this.btnChoMuon.Text = "   Cho mượn";
            this.btnChoMuon.UseVisualStyleBackColor = false;
            this.btnChoMuon.Click += new System.EventHandler(this.btnChoMuon_Click);
            // 
            // lab_Huy
            // 
            this.lab_Huy.AutoSize = true;
            this.lab_Huy.BackColor = System.Drawing.Color.White;
            this.lab_Huy.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lab_Huy.ForeColor = System.Drawing.Color.Red;
            this.lab_Huy.Location = new System.Drawing.Point(0, 280);
            this.lab_Huy.Name = "lab_Huy";
            this.lab_Huy.Size = new System.Drawing.Size(94, 19);
            this.lab_Huy.TabIndex = 44;
            this.lab_Huy.Text = "metroLabel1";
            // 
            // btnTTDG
            // 
            this.btnTTDG.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTTDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTTDG.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.btnTTDG.IconColor = System.Drawing.Color.Black;
            this.btnTTDG.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnTTDG.IconSize = 19;
            this.btnTTDG.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnTTDG.Location = new System.Drawing.Point(719, 226);
            this.btnTTDG.Margin = new System.Windows.Forms.Padding(2);
            this.btnTTDG.Name = "btnTTDG";
            this.btnTTDG.Size = new System.Drawing.Size(121, 25);
            this.btnTTDG.TabIndex = 45;
            this.btnTTDG.Text = "Thông tin ĐG";
            this.btnTTDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTTDG.UseVisualStyleBackColor = false;
            this.btnTTDG.Click += new System.EventHandler(this.btnTTDG_Click);
            // 
            // btnHuyPhieu
            // 
            this.btnHuyPhieu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHuyPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyPhieu.IconChar = FontAwesome.Sharp.IconChar.Remove;
            this.btnHuyPhieu.IconColor = System.Drawing.Color.Black;
            this.btnHuyPhieu.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnHuyPhieu.IconSize = 19;
            this.btnHuyPhieu.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnHuyPhieu.Location = new System.Drawing.Point(866, 226);
            this.btnHuyPhieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnHuyPhieu.Name = "btnHuyPhieu";
            this.btnHuyPhieu.Size = new System.Drawing.Size(106, 25);
            this.btnHuyPhieu.TabIndex = 46;
            this.btnHuyPhieu.Text = "Huỷ phiếu";
            this.btnHuyPhieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuyPhieu.UseVisualStyleBackColor = false;
            this.btnHuyPhieu.Click += new System.EventHandler(this.btnHuyPhieu_Click);
            // 
            // btnXLTreHan
            // 
            this.btnXLTreHan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXLTreHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXLTreHan.IconChar = FontAwesome.Sharp.IconChar.Ban;
            this.btnXLTreHan.IconColor = System.Drawing.Color.Black;
            this.btnXLTreHan.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnXLTreHan.IconSize = 19;
            this.btnXLTreHan.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnXLTreHan.Location = new System.Drawing.Point(1075, 272);
            this.btnXLTreHan.Margin = new System.Windows.Forms.Padding(2);
            this.btnXLTreHan.Name = "btnXLTreHan";
            this.btnXLTreHan.Size = new System.Drawing.Size(126, 25);
            this.btnXLTreHan.TabIndex = 47;
            this.btnXLTreHan.Text = "Xử lý trễ hạn";
            this.btnXLTreHan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXLTreHan.UseVisualStyleBackColor = false;
            this.btnXLTreHan.Click += new System.EventHandler(this.btnXLTreHan_Click);
            // 
            // frmQuanLyPhieuMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 724);
            this.Controls.Add(this.btnXLTreHan);
            this.Controls.Add(this.btnHuyPhieu);
            this.Controls.Add(this.btnTTDG);
            this.Controls.Add(this.lab_Huy);
            this.Controls.Add(this.btnChoMuon);
            this.Controls.Add(this.btnTraTL);
            this.Controls.Add(this.btnInPM);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.btnMuonMoi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPhieuMuon);
            this.Controls.Add(this.groupPhieuTra);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.cbTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmQuanLyPhieuMuon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmQuanLyPhieuMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPM)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupPhieuTra.ResumeLayout(false);
            this.groupPhieuTra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvChiTietPM;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupPhieuTra;
        private System.Windows.Forms.RadioButton radioPhieuTra;
        private System.Windows.Forms.RadioButton radioPhieuMuon;
        private System.Windows.Forms.DataGridView dgvPhieuMuon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMuonMoi;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnTraTL;
        private System.Windows.Forms.Button btnInPM;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbTreHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTra;
        private System.Windows.Forms.Button btnChoMuon;
        private MetroFramework.Controls.MetroLabel lab_Huy;
        private FontAwesome.Sharp.IconButton btnTTDG;
        private FontAwesome.Sharp.IconButton btnHuyPhieu;
        private FontAwesome.Sharp.IconButton btnXLTreHan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongBD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
    }
}