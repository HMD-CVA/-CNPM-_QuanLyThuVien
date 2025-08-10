namespace QuanLyThuVienApp
{
    partial class frmMuonTaiLieu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            this.dgvTaiLieu = new System.Windows.Forms.DataGridView();
            this.MaTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTaiLieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenTG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenNXB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoSan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTaiLieuMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTLMuon = new System.Windows.Forms.DataGridView();
            this.MaSach2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDangKy = new FontAwesome.Sharp.IconButton();
            this.btnXoaHet = new FontAwesome.Sharp.IconButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.grbDocGia = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.txtEmail = new MetroFramework.Controls.MetroTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTTDG = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSTenTL = new System.Windows.Forms.TextBox();
            this.cbbSTG = new System.Windows.Forms.ComboBox();
            this.cbbSNXB = new System.Windows.Forms.ComboBox();
            this.cbbSDM = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSMaTL = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.btnTimKiem = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiLieu)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTLMuon)).BeginInit();
            this.grbDocGia.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTaiLieu
            // 
            this.dgvTaiLieu.AllowUserToAddRows = false;
            this.dgvTaiLieu.AllowUserToDeleteRows = false;
            this.dgvTaiLieu.AllowUserToResizeRows = false;
            this.dgvTaiLieu.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaiLieu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaiLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiLieu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTaiLieu,
            this.TenTaiLieu,
            this.TenDanhMuc,
            this.TenTG,
            this.TenNXB,
            this.TaiBan,
            this.CoSan,
            this.SoLuong,
            this.SoTaiLieuMuon,
            this.MoTa});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTaiLieu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTaiLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTaiLieu.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvTaiLieu.Location = new System.Drawing.Point(0, 0);
            this.dgvTaiLieu.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTaiLieu.MultiSelect = false;
            this.dgvTaiLieu.Name = "dgvTaiLieu";
            this.dgvTaiLieu.ReadOnly = true;
            this.dgvTaiLieu.RowHeadersVisible = false;
            this.dgvTaiLieu.RowHeadersWidth = 51;
            this.dgvTaiLieu.RowTemplate.Height = 24;

            this.dgvTaiLieu.Size = new System.Drawing.Size(909, 205);
            this.dgvTaiLieu.TabIndex = 0;
            this.dgvTaiLieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellClick);
            // 
            // MaTaiLieu
            // 
            this.MaTaiLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MaTaiLieu.DataPropertyName = "MaTaiLieu";
            this.MaTaiLieu.HeaderText = "Mã";
            this.MaTaiLieu.MinimumWidth = 6;
            this.MaTaiLieu.Name = "MaTaiLieu";
            this.MaTaiLieu.ReadOnly = true;
            this.MaTaiLieu.Width = 51;
            // 
            // TenTaiLieu
            // 
            this.TenTaiLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenTaiLieu.DataPropertyName = "TenTaiLieu";
            this.TenTaiLieu.HeaderText = "Tên tài liệu";
            this.TenTaiLieu.MinimumWidth = 6;
            this.TenTaiLieu.Name = "TenTaiLieu";
            this.TenTaiLieu.ReadOnly = true;
            // 
            // TenDanhMuc
            // 
            this.TenDanhMuc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenDanhMuc.DataPropertyName = "TenDanhMuc";
            this.TenDanhMuc.HeaderText = "Danh mục";
            this.TenDanhMuc.MinimumWidth = 6;
            this.TenDanhMuc.Name = "TenDanhMuc";
            this.TenDanhMuc.ReadOnly = true;
            this.TenDanhMuc.Width = 85;
            // 
            // TenTG
            // 
            this.TenTG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenTG.DataPropertyName = "TenTG";
            this.TenTG.HeaderText = "Tác giả";
            this.TenTG.MinimumWidth = 6;
            this.TenTG.Name = "TenTG";
            this.TenTG.ReadOnly = true;
            this.TenTG.Width = 72;
            // 
            // TenNXB
            // 
            this.TenNXB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenNXB.DataPropertyName = "TenNXB";
            this.TenNXB.HeaderText = "Nhà xuất bản";
            this.TenNXB.MinimumWidth = 6;
            this.TenNXB.Name = "TenNXB";
            this.TenNXB.ReadOnly = true;
            this.TenNXB.Width = 101;
            // 
            // TaiBan
            // 
            this.TaiBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TaiBan.DataPropertyName = "TaiBan";
            this.TaiBan.HeaderText = "Tái bản";
            this.TaiBan.Name = "TaiBan";
            this.TaiBan.ReadOnly = true;
            this.TaiBan.Width = 72;
            // 
            // CoSan
            // 
            this.CoSan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.CoSan.DataPropertyName = "CoSan";
            this.CoSan.HeaderText = "Có sẵn";
            this.CoSan.MinimumWidth = 6;
            this.CoSan.Name = "CoSan";
            this.CoSan.ReadOnly = true;
            this.CoSan.Width = 69;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Visible = false;
            // 
            // SoTaiLieuMuon
            // 
            this.SoTaiLieuMuon.DataPropertyName = "SoTaiLieuMuon";
            this.SoTaiLieuMuon.HeaderText = "Số tài liệu mượn";
            this.SoTaiLieuMuon.Name = "SoTaiLieuMuon";
            this.SoTaiLieuMuon.ReadOnly = true;
            this.SoTaiLieuMuon.Visible = false;
            // 
            // MoTa
            // 
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô tả";
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            this.MoTa.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTaiLieu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;

            this.panel1.Location = new System.Drawing.Point(0, 238);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 205);
            this.panel1.TabIndex = 8;
            // 
            // dgvTLMuon
            // 
            this.dgvTLMuon.AllowUserToAddRows = false;
            this.dgvTLMuon.AllowUserToDeleteRows = false;
            this.dgvTLMuon.AllowUserToResizeColumns = false;
            this.dgvTLMuon.AllowUserToResizeRows = false;
            this.dgvTLMuon.BackgroundColor = System.Drawing.Color.White;

            this.dgvTLMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTLMuon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSach2,
            this.TenSach2,
            this.SoLuong2});

            this.dgvTLMuon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTLMuon.Location = new System.Drawing.Point(5, 22);
            this.dgvTLMuon.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTLMuon.MultiSelect = false;
            this.dgvTLMuon.Name = "dgvTLMuon";
            this.dgvTLMuon.ReadOnly = true;
            this.dgvTLMuon.RowHeadersVisible = false;
            this.dgvTLMuon.RowHeadersWidth = 51;
            this.dgvTLMuon.RowTemplate.Height = 24;

            this.dgvTLMuon.Size = new System.Drawing.Size(538, 176);
            this.dgvTLMuon.TabIndex = 9;
            this.dgvTLMuon.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSachMuon_CellClick);
            // 
            // MaSach2
            // 
            this.MaSach2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaSach2.DataPropertyName = "MaSach2";
            this.MaSach2.HeaderText = "Mã sách";
            this.MaSach2.MinimumWidth = 6;
            this.MaSach2.Name = "MaSach2";
            this.MaSach2.ReadOnly = true;
            this.MaSach2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.MaSach2.Width = 71;
            // 
            // TenSach2
            // 
            this.TenSach2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenSach2.DataPropertyName = "TenSach2";
            this.TenSach2.HeaderText = "Tên sách";
            this.TenSach2.MinimumWidth = 6;
            this.TenSach2.Name = "TenSach2";
            this.TenSach2.ReadOnly = true;
            this.TenSach2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SoLuong2
            // 
            this.SoLuong2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SoLuong2.DataPropertyName = "SoLuong2";
            this.SoLuong2.HeaderText = "Số lượng";
            this.SoLuong2.MinimumWidth = 6;
            this.SoLuong2.Name = "SoLuong2";
            this.SoLuong2.ReadOnly = true;
            this.SoLuong2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SoLuong2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;

            this.SoLuong2.Width = 73;
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangKy.IconChar = FontAwesome.Sharp.IconChar.PaperPlane;
            this.btnDangKy.IconColor = System.Drawing.Color.Black;
            this.btnDangKy.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnDangKy.IconSize = 19;
            this.btnDangKy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnDangKy.Location = new System.Drawing.Point(590, 209);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(115, 25);
            this.btnDangKy.TabIndex = 16;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnXoaHet
            // 
            this.btnXoaHet.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXoaHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaHet.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnXoaHet.IconColor = System.Drawing.Color.Black;
            this.btnXoaHet.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnXoaHet.IconSize = 19;
            this.btnXoaHet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnXoaHet.Location = new System.Drawing.Point(366, 209);
            this.btnXoaHet.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoaHet.Name = "btnXoaHet";
            this.btnXoaHet.Size = new System.Drawing.Size(115, 25);
            this.btnXoaHet.TabIndex = 16;
            this.btnXoaHet.Text = "Xóa hết";
            this.btnXoaHet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaHet.UseVisualStyleBackColor = false;
            this.btnXoaHet.Click += new System.EventHandler(this.btnXoaHet_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // grbDocGia
            // 
            this.grbDocGia.Controls.Add(this.progressBar1);
            this.grbDocGia.Controls.Add(this.txtEmail);
            this.grbDocGia.Controls.Add(this.label4);
            this.grbDocGia.Controls.Add(this.btnTTDG);
            this.grbDocGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDocGia.Location = new System.Drawing.Point(0, 0);
            this.grbDocGia.Name = "grbDocGia";

            this.grbDocGia.Size = new System.Drawing.Size(348, 79);
            this.grbDocGia.TabIndex = 20;
            this.grbDocGia.TabStop = false;
            this.grbDocGia.Text = "Thông tin độc giả";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(316, 21);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(23, 23);
            this.progressBar1.TabIndex = 47;
            this.progressBar1.UseSelectable = true;
            // 
            // txtEmail
            // 
            // 
            // 
            // 
            this.txtEmail.CustomButton.Image = null;
            this.txtEmail.CustomButton.Location = new System.Drawing.Point(228, 1);
            this.txtEmail.CustomButton.Name = "";
            this.txtEmail.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtEmail.CustomButton.TabIndex = 1;
            this.txtEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtEmail.CustomButton.UseSelectable = true;
            this.txtEmail.CustomButton.Visible = false;
            this.txtEmail.Lines = new string[0];
            this.txtEmail.Location = new System.Drawing.Point(60, 21);
            this.txtEmail.MaxLength = 32767;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.PromptText = "Nhập vào email để xác thực";
            this.txtEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.ShortcutsEnabled = true;
            this.txtEmail.Size = new System.Drawing.Size(250, 23);
            this.txtEmail.TabIndex = 22;
            this.txtEmail.UseSelectable = true;
            this.txtEmail.WaterMark = "Nhập vào email để xác thực";
            this.txtEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 18);
            this.label4.TabIndex = 2;
            this.label4.Text = "Email";
            // 
            // btnTTDG
            // 
            this.btnTTDG.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTTDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTTDG.IconChar = FontAwesome.Sharp.IconChar.IdCard;
            this.btnTTDG.IconColor = System.Drawing.Color.Black;
            this.btnTTDG.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnTTDG.IconSize = 19;
            this.btnTTDG.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTTDG.Location = new System.Drawing.Point(126, 48);
            this.btnTTDG.Margin = new System.Windows.Forms.Padding(2);
            this.btnTTDG.Name = "btnTTDG";
            this.btnTTDG.Size = new System.Drawing.Size(97, 25);
            this.btnTTDG.TabIndex = 46;
            this.btnTTDG.Text = "Thông tin";
            this.btnTTDG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTTDG.UseVisualStyleBackColor = false;
            this.btnTTDG.Click += new System.EventHandler(this.btnTTDG_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnClose.IconColor = System.Drawing.Color.Black;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnClose.IconSize = 19;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.btnClose.Location = new System.Drawing.Point(832, 209);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 25);
            this.btnClose.TabIndex = 48;
            this.btnClose.Text = "Thoát";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSTenTL);
            this.groupBox2.Controls.Add(this.cbbSTG);
            this.groupBox2.Controls.Add(this.cbbSNXB);
            this.groupBox2.Controls.Add(this.cbbSDM);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtSMaTL);
            this.groupBox2.Controls.Add(this.btnLamMoi);
            this.groupBox2.Controls.Add(this.btnTimKiem);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(7, 82);
            this.groupBox2.Name = "groupBox2";

            this.groupBox2.Size = new System.Drawing.Size(348, 155);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm kiếm";
            // 
            // txtSTenTL
            // 
            this.txtSTenTL.Location = new System.Drawing.Point(8, 75);
            this.txtSTenTL.Name = "txtSTenTL";
            this.txtSTenTL.Size = new System.Drawing.Size(161, 24);
            this.txtSTenTL.TabIndex = 22;
            // 
            // cbbSTG
            // 
            this.cbbSTG.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbSTG.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbSTG.FormattingEnabled = true;
            this.cbbSTG.Location = new System.Drawing.Point(183, 124);
            this.cbbSTG.Name = "cbbSTG";
            this.cbbSTG.Size = new System.Drawing.Size(147, 26);
            this.cbbSTG.TabIndex = 21;
            // 
            // cbbSNXB
            // 
            this.cbbSNXB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbSNXB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbSNXB.FormattingEnabled = true;
            this.cbbSNXB.Location = new System.Drawing.Point(183, 75);
            this.cbbSNXB.Name = "cbbSNXB";
            this.cbbSNXB.Size = new System.Drawing.Size(147, 26);
            this.cbbSNXB.TabIndex = 20;
            // 
            // cbbSDM
            // 
            this.cbbSDM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbbSDM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbbSDM.FormattingEnabled = true;
            this.cbbSDM.Location = new System.Drawing.Point(8, 122);
            this.cbbSDM.Name = "cbbSDM";
            this.cbbSDM.Size = new System.Drawing.Size(158, 26);
            this.cbbSDM.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên tài liệu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 24);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Mã tài liệu";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(180, 104);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Tác giả";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(180, 55);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Nhà xuất bản";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(5, 102);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Danh mục";
            // 
            // txtSMaTL
            // 
            this.txtSMaTL.BackColor = System.Drawing.Color.White;
            this.txtSMaTL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSMaTL.Location = new System.Drawing.Point(79, 21);
            this.txtSMaTL.Margin = new System.Windows.Forms.Padding(2);
            this.txtSMaTL.Name = "txtSMaTL";
            this.txtSMaTL.Size = new System.Drawing.Size(90, 23);
            this.txtSMaTL.TabIndex = 15;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btnLamMoi.IconColor = System.Drawing.Color.Black;
            this.btnLamMoi.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnLamMoi.IconSize = 19;
            this.btnLamMoi.Location = new System.Drawing.Point(261, 21);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(67, 23);
            this.btnLamMoi.TabIndex = 7;
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
            this.btnTimKiem.Location = new System.Drawing.Point(183, 21);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(76, 23);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvTLMuon);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(361, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(548, 203);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách đăng ký mượn";
            // 
            // frmMuonTaiLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;

            this.ClientSize = new System.Drawing.Size(909, 443);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grbDocGia);
            this.Controls.Add(this.btnXoaHet);
            this.Controls.Add(this.btnDangKy);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMuonTaiLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMuonSach";
            this.Load += new System.EventHandler(this.frmMuonSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiLieu)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTLMuon)).EndInit();
            this.grbDocGia.ResumeLayout(false);
            this.grbDocGia.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTaiLieu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTLMuon;
        private FontAwesome.Sharp.IconButton btnDangKy;
        private FontAwesome.Sharp.IconButton btnXoaHet;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.GroupBox grbDocGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSach2;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong2;
        private MetroFramework.Controls.MetroTextBox txtEmail;
        private FontAwesome.Sharp.IconButton btnTTDG;
        private FontAwesome.Sharp.IconButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTaiLieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenTG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenNXB;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoSan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTaiLieuMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSTenTL;
        private System.Windows.Forms.ComboBox cbbSTG;
        private System.Windows.Forms.ComboBox cbbSNXB;
        private System.Windows.Forms.ComboBox cbbSDM;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSMaTL;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private FontAwesome.Sharp.IconButton btnTimKiem;
        private MetroFramework.Controls.MetroProgressSpinner progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}