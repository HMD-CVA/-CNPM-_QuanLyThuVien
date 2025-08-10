namespace QuanLyThuVienApp
{
    partial class frmQuanLyPhieuMuonTreHan
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvChiTietPM = new System.Windows.Forms.DataGridView();
            this.MaChiTiet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.lbTienPhat1 = new System.Windows.Forms.Label();
            this.lbTienPhat2 = new System.Windows.Forms.Label();
            this.btnHoaDonPhat = new System.Windows.Forms.Button();
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.MaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenDG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThoat = new FontAwesome.Sharp.IconButton();
            this.btnTimKiem = new FontAwesome.Sharp.IconButton();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(692, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 30;
            this.label1.Text = "Tìm kiếm theo";
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Items.AddRange(new object[] {
            "Mã phiếu",
            "Mã bạn đọc",
            "Tên bạn đọc"});
            this.cbTimKiem.Location = new System.Drawing.Point(793, 71);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(108, 25);
            this.cbTimKiem.TabIndex = 31;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(695, 113);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(206, 23);
            this.txtTimKiem.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvChiTietPM);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 196);
            this.panel1.TabIndex = 28;
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
            this.MaTaiLieu,
            this.TenTaiLieu,
            this.TenDanhMuc,
            this.TenTG,
            this.TenNXB,
            this.dataGridViewTextBoxColumn1});
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
            this.dgvChiTietPM.Size = new System.Drawing.Size(915, 196);
            this.dgvChiTietPM.TabIndex = 2;
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SoLuong";
            this.dataGridViewTextBoxColumn1.HeaderText = "Số lượng";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 85;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(227, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 38;
            this.label2.Text = "Chi tiết phiếu";
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGiaHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiaHan.Location = new System.Drawing.Point(220, 222);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(106, 25);
            this.btnGiaHan.TabIndex = 41;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = false;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTraSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraSach.Location = new System.Drawing.Point(330, 222);
            this.btnTraSach.Margin = new System.Windows.Forms.Padding(2);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(106, 25);
            this.btnTraSach.TabIndex = 41;
            this.btnTraSach.Text = "Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = false;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // lbTienPhat1
            // 
            this.lbTienPhat1.AutoSize = true;
            this.lbTienPhat1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienPhat1.ForeColor = System.Drawing.Color.Red;
            this.lbTienPhat1.Location = new System.Drawing.Point(217, 255);
            this.lbTienPhat1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTienPhat1.Name = "lbTienPhat1";
            this.lbTienPhat1.Size = new System.Drawing.Size(76, 17);
            this.lbTienPhat1.TabIndex = 42;
            this.lbTienPhat1.Text = "Tiền phạt: ";
            // 
            // lbTienPhat2
            // 
            this.lbTienPhat2.AutoSize = true;
            this.lbTienPhat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTienPhat2.ForeColor = System.Drawing.Color.Red;
            this.lbTienPhat2.Location = new System.Drawing.Point(287, 255);
            this.lbTienPhat2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTienPhat2.Name = "lbTienPhat2";
            this.lbTienPhat2.Size = new System.Drawing.Size(49, 17);
            this.lbTienPhat2.TabIndex = 42;
            this.lbTienPhat2.Text = "0 VNĐ";
            // 
            // btnHoaDonPhat
            // 
            this.btnHoaDonPhat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHoaDonPhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDonPhat.Location = new System.Drawing.Point(110, 222);
            this.btnHoaDonPhat.Margin = new System.Windows.Forms.Padding(2);
            this.btnHoaDonPhat.Name = "btnHoaDonPhat";
            this.btnHoaDonPhat.Size = new System.Drawing.Size(106, 25);
            this.btnHoaDonPhat.TabIndex = 41;
            this.btnHoaDonPhat.Text = "Hóa đơn phạt";
            this.btnHoaDonPhat.UseVisualStyleBackColor = false;
            this.btnHoaDonPhat.Click += new System.EventHandler(this.btnHoaDonPhat_Click);
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
            this.dgvPhieuMuon.Location = new System.Drawing.Point(11, 28);
            this.dgvPhieuMuon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPhieuMuon.MultiSelect = false;
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.ReadOnly = true;
            this.dgvPhieuMuon.RowHeadersVisible = false;
            this.dgvPhieuMuon.RowHeadersWidth = 51;
            this.dgvPhieuMuon.RowTemplate.Height = 24;
            this.dgvPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(654, 190);
            this.dgvPhieuMuon.TabIndex = 43;
            this.dgvPhieuMuon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuMuon_CellClick);
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
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btnThoat.IconColor = System.Drawing.Color.Black;
            this.btnThoat.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnThoat.IconSize = 19;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnThoat.Location = new System.Drawing.Point(579, 222);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 25);
            this.btnThoat.TabIndex = 44;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
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
            this.btnTimKiem.Location = new System.Drawing.Point(803, 150);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(86, 25);
            this.btnTimKiem.TabIndex = 33;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
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
            this.btnLamMoi.Location = new System.Drawing.Point(705, 150);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(86, 25);
            this.btnLamMoi.TabIndex = 32;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // frmQuanLyPhieuMuonTreHan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 475);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dgvPhieuMuon);
            this.Controls.Add(this.lbTienPhat2);
            this.Controls.Add(this.lbTienPhat1);
            this.Controls.Add(this.btnTraSach);
            this.Controls.Add(this.btnHoaDonPhat);
            this.Controls.Add(this.btnGiaHan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.cbTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmQuanLyPhieuMuonTreHan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLyPhieuMuon";
            this.Load += new System.EventHandler(this.frmQuanLyPhieuMuon_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnTimKiem;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.Label lbTienPhat1;
        private System.Windows.Forms.Label lbTienPhat2;
        private System.Windows.Forms.Button btnHoaDonPhat;
        private System.Windows.Forms.DataGridView dgvChiTietPM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dgvPhieuMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenDG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTra;
        private FontAwesome.Sharp.IconButton btnThoat;
    }
}