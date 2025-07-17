namespace QuanLyThuVienApp
{
    partial class frmQuanLyNhanVien
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.btnTimKiem = new FontAwesome.Sharp.IconButton();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTDN = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.btnGuiMa = new System.Windows.Forms.Button();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSuaTen = new System.Windows.Forms.TextBox();
            this.btnSuaEmail = new System.Windows.Forms.Button();
            this.btnSuaTen = new System.Windows.Forms.Button();
            this.btnResetMK = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtSuaEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MaNV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDangKi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvNhanVien);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 231);
            this.panel1.TabIndex = 21;
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.AllowUserToAddRows = false;
            this.dgvNhanVien.AllowUserToDeleteRows = false;
            this.dgvNhanVien.AllowUserToResizeRows = false;
            this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvNhanVien.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNV,
            this.TenDangNhap,
            this.HoTen,
            this.Email,
            this.NgayDangKi,
            this.TrangThai});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvNhanVien.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNhanVien.Location = new System.Drawing.Point(0, 0);
            this.dgvNhanVien.Margin = new System.Windows.Forms.Padding(2);
            this.dgvNhanVien.MultiSelect = false;
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.ReadOnly = true;
            this.dgvNhanVien.RowHeadersVisible = false;
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(915, 231);
            this.dgvNhanVien.TabIndex = 1;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBanDoc_CellClick);
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
            this.btnLamMoi.Location = new System.Drawing.Point(711, 210);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(85, 25);
            this.btnLamMoi.TabIndex = 25;
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
            this.btnTimKiem.Location = new System.Drawing.Point(803, 210);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 25);
            this.btnTimKiem.TabIndex = 26;
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
            "Mã bạn đọc",
            "Tên bạn đọc",
            "Email"});
            this.cbTimKiem.Location = new System.Drawing.Point(790, 133);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(114, 25);
            this.cbTimKiem.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(693, 137);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tìm kiếm theo";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(696, 169);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(208, 23);
            this.txtTimKiem.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTDN);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.btnDangKy);
            this.groupBox1.Controls.Add(this.btnGuiMa);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Controls.Add(this.txtTen);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 24);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(314, 216);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tạo tài khoản mới";
            // 
            // txtTDN
            // 
            this.txtTDN.Location = new System.Drawing.Point(130, 37);
            this.txtTDN.Margin = new System.Windows.Forms.Padding(2);
            this.txtTDN.Name = "txtTDN";
            this.txtTDN.Size = new System.Drawing.Size(180, 23);
            this.txtTDN.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 37);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 6;
            this.label8.Text = "Tên đăng nhập";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowRotateBackward;
            this.btnBack.IconColor = System.Drawing.Color.Black;
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.IconSize = 19;
            this.btnBack.Location = new System.Drawing.Point(268, 127);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(23, 22);
            this.btnBack.TabIndex = 5;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDangKy
            // 
            this.btnDangKy.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDangKy.Location = new System.Drawing.Point(211, 177);
            this.btnDangKy.Margin = new System.Windows.Forms.Padding(2);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(80, 25);
            this.btnDangKy.TabIndex = 4;
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = false;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // btnGuiMa
            // 
            this.btnGuiMa.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuiMa.Location = new System.Drawing.Point(244, 81);
            this.btnGuiMa.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuiMa.Name = "btnGuiMa";
            this.btnGuiMa.Size = new System.Drawing.Size(66, 25);
            this.btnGuiMa.TabIndex = 4;
            this.btnGuiMa.Text = "Gửi mã";
            this.btnGuiMa.UseVisualStyleBackColor = false;
            this.btnGuiMa.Click += new System.EventHandler(this.btnGuiMa_Click);
            // 
            // txtMa
            // 
            this.txtMa.Location = new System.Drawing.Point(113, 177);
            this.txtMa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(89, 23);
            this.txtMa.TabIndex = 3;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(72, 126);
            this.txtTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(180, 23);
            this.txtTen.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(60, 83);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(180, 23);
            this.txtEmail.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 179);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã xác nhận";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Họ Tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Email";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSuaTen);
            this.groupBox2.Controls.Add(this.btnSuaEmail);
            this.groupBox2.Controls.Add(this.btnSuaTen);
            this.groupBox2.Controls.Add(this.btnResetMK);
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Controls.Add(this.txtSuaEmail);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(348, 24);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(322, 216);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin bạn đọc";
            // 
            // txtSuaTen
            // 
            this.txtSuaTen.Location = new System.Drawing.Point(103, 93);
            this.txtSuaTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtSuaTen.Name = "txtSuaTen";
            this.txtSuaTen.Size = new System.Drawing.Size(201, 23);
            this.txtSuaTen.TabIndex = 5;
            // 
            // btnSuaEmail
            // 
            this.btnSuaEmail.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSuaEmail.Location = new System.Drawing.Point(37, 136);
            this.btnSuaEmail.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuaEmail.Name = "btnSuaEmail";
            this.btnSuaEmail.Size = new System.Drawing.Size(122, 25);
            this.btnSuaEmail.TabIndex = 4;
            this.btnSuaEmail.Text = "Cập nhật email";
            this.btnSuaEmail.UseVisualStyleBackColor = false;
            this.btnSuaEmail.Click += new System.EventHandler(this.btnSuaEmail_Click);
            // 
            // btnSuaTen
            // 
            this.btnSuaTen.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSuaTen.Location = new System.Drawing.Point(172, 136);
            this.btnSuaTen.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuaTen.Name = "btnSuaTen";
            this.btnSuaTen.Size = new System.Drawing.Size(122, 25);
            this.btnSuaTen.TabIndex = 4;
            this.btnSuaTen.Text = "Sửa tên";
            this.btnSuaTen.UseVisualStyleBackColor = false;
            this.btnSuaTen.Click += new System.EventHandler(this.btnSuaTen_Click);
            // 
            // btnResetMK
            // 
            this.btnResetMK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnResetMK.Location = new System.Drawing.Point(106, 171);
            this.btnResetMK.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetMK.Name = "btnResetMK";
            this.btnResetMK.Size = new System.Drawing.Size(122, 25);
            this.btnResetMK.TabIndex = 4;
            this.btnResetMK.Text = "Reset mật khẩu";
            this.btnResetMK.UseVisualStyleBackColor = false;
            this.btnResetMK.Click += new System.EventHandler(this.btnResetMK_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(103, 25);
            this.txtID.Margin = new System.Windows.Forms.Padding(2);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(201, 23);
            this.txtID.TabIndex = 4;
            // 
            // txtSuaEmail
            // 
            this.txtSuaEmail.Location = new System.Drawing.Point(103, 60);
            this.txtSuaEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtSuaEmail.Name = "txtSuaEmail";
            this.txtSuaEmail.Size = new System.Drawing.Size(201, 23);
            this.txtSuaEmail.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 93);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tên bạn đọc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 60);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Email";
            // 
            // MaNV
            // 
            this.MaNV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MaNV.DataPropertyName = "MaNV";
            this.MaNV.HeaderText = "Mã";
            this.MaNV.MinimumWidth = 6;
            this.MaNV.Name = "MaNV";
            this.MaNV.ReadOnly = true;
            this.MaNV.Width = 51;
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TenDangNhap.DataPropertyName = "TenDangNhap";
            this.TenDangNhap.HeaderText = "Tên đăng nhập";
            this.TenDangNhap.Name = "TenDangNhap";
            this.TenDangNhap.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // NgayDangKi
            // 
            this.NgayDangKi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.NgayDangKi.DataPropertyName = "NgayDangKi";
            dataGridViewCellStyle2.Format = "dd/MM/yyyy";
            this.NgayDangKi.DefaultCellStyle = dataGridViewCellStyle2;
            this.NgayDangKi.HeaderText = "Ngày đăng ký";
            this.NgayDangKi.MinimumWidth = 6;
            this.NgayDangKi.Name = "NgayDangKi";
            this.NgayDangKi.ReadOnly = true;
            this.NgayDangKi.Width = 116;
            // 
            // TrangThai
            // 
            this.TrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            this.TrangThai.ReadOnly = true;
            this.TrangThai.Width = 92;
            // 
            // frmQuanLyNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 475);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cbTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmQuanLyNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLyBanDoc";
            this.Load += new System.EventHandler(this.frmQuanLyBanDoc_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private FontAwesome.Sharp.IconButton btnTimKiem;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Button btnGuiMa;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnBack;
        private System.Windows.Forms.TextBox txtSuaTen;
        private System.Windows.Forms.Button btnResetMK;
        private System.Windows.Forms.TextBox txtSuaEmail;
        private System.Windows.Forms.Button btnSuaTen;
        private System.Windows.Forms.Button btnSuaEmail;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTDN;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDangNhap;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDangKi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}