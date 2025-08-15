namespace QuanLyThuVienApp
{
    partial class frmQuanLyDocGia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBanDoc = new System.Windows.Forms.DataGridView();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnKhoa = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbSinhVien = new System.Windows.Forms.RadioButton();
            this.rbGiangVien = new System.Windows.Forms.RadioButton();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaSo = new System.Windows.Forms.TextBox();
            this.labMS = new System.Windows.Forms.Label();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoVaTen = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.btnTimKiem = new FontAwesome.Sharp.IconButton();
            this.btnBiKhoa = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.txtNgayDK = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNgayHetHan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MaDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BiKhoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanDoc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvBanDoc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 220);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1219, 504);
            this.panel1.TabIndex = 21;
            // 
            // dgvBanDoc
            // 
            this.dgvBanDoc.AllowUserToAddRows = false;
            this.dgvBanDoc.AllowUserToDeleteRows = false;
            this.dgvBanDoc.AllowUserToResizeRows = false;
            this.dgvBanDoc.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBanDoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBanDoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBanDoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDocGia,
            this.MaSo,
            this.Loai,
            this.HoTen,
            this.Email,
            this.BiKhoa,
            this.SoLuong,
            this.NgayDk,
            this.NgayHH});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBanDoc.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBanDoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBanDoc.Location = new System.Drawing.Point(0, 0);
            this.dgvBanDoc.Margin = new System.Windows.Forms.Padding(2);
            this.dgvBanDoc.MultiSelect = false;
            this.dgvBanDoc.Name = "dgvBanDoc";
            this.dgvBanDoc.ReadOnly = true;
            this.dgvBanDoc.RowHeadersVisible = false;
            this.dgvBanDoc.RowHeadersWidth = 51;
            this.dgvBanDoc.RowTemplate.Height = 24;
            this.dgvBanDoc.Size = new System.Drawing.Size(1219, 504);
            this.dgvBanDoc.TabIndex = 1;
            this.dgvBanDoc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBanDoc_CellClick);
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Items.AddRange(new object[] {
            "Mã độc giả",
            "Tên độc giả",
            "Email"});
            this.cbTimKiem.Location = new System.Drawing.Point(152, 54);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(210, 25);
            this.cbTimKiem.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 23;
            this.label1.Text = "Tìm kiếm theo";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(33, 105);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(329, 23);
            this.txtTimKiem.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNgayHetHan);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnGiaHan);
            this.groupBox1.Controls.Add(this.txtNgayDK);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnKhoa);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtTrangThai);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMaSo);
            this.groupBox1.Controls.Add(this.labMS);
            this.groupBox1.Controls.Add(this.txtMaDG);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtHoVaTen);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(7, 1);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(810, 214);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin độc giả";
            // 
            // btnKhoa
            // 
            this.btnKhoa.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhoa.Location = new System.Drawing.Point(468, 91);
            this.btnKhoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnKhoa.Name = "btnKhoa";
            this.btnKhoa.Size = new System.Drawing.Size(147, 27);
            this.btnKhoa.TabIndex = 28;
            this.btnKhoa.Text = "Mở khoá";
            this.btnKhoa.UseVisualStyleBackColor = false;
            this.btnKhoa.Click += new System.EventHandler(this.btnBiKhoa_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbSinhVien);
            this.groupBox2.Controls.Add(this.rbGiangVien);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(646, 20);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(147, 70);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loại độc giả";
            // 
            // rbSinhVien
            // 
            this.rbSinhVien.AutoSize = true;
            this.rbSinhVien.Location = new System.Drawing.Point(6, 23);
            this.rbSinhVien.Name = "rbSinhVien";
            this.rbSinhVien.Size = new System.Drawing.Size(84, 21);
            this.rbSinhVien.TabIndex = 1;
            this.rbSinhVien.TabStop = true;
            this.rbSinhVien.Text = "Sinh viên";
            this.rbSinhVien.UseVisualStyleBackColor = true;
            this.rbSinhVien.CheckedChanged += new System.EventHandler(this.rbSinhVien_CheckedChanged);
            // 
            // rbGiangVien
            // 
            this.rbGiangVien.AutoSize = true;
            this.rbGiangVien.Location = new System.Drawing.Point(6, 46);
            this.rbGiangVien.Name = "rbGiangVien";
            this.rbGiangVien.Size = new System.Drawing.Size(94, 21);
            this.rbGiangVien.TabIndex = 0;
            this.rbGiangVien.TabStop = true;
            this.rbGiangVien.Text = "Giảng viên";
            this.rbGiangVien.UseVisualStyleBackColor = true;
            this.rbGiangVien.CheckedChanged += new System.EventHandler(this.rbGiangVien_CheckedChanged);
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTrangThai.Location = new System.Drawing.Point(468, 57);
            this.txtTrangThai.Margin = new System.Windows.Forms.Padding(2);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(147, 24);
            this.txtTrangThai.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(465, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Trạng thái";
            // 
            // txtMaSo
            // 
            this.txtMaSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSo.Location = new System.Drawing.Point(196, 56);
            this.txtMaSo.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaSo.Name = "txtMaSo";
            this.txtMaSo.ReadOnly = true;
            this.txtMaSo.Size = new System.Drawing.Size(237, 23);
            this.txtMaSo.TabIndex = 15;
            // 
            // labMS
            // 
            this.labMS.AutoSize = true;
            this.labMS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labMS.Location = new System.Drawing.Point(193, 37);
            this.labMS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labMS.Name = "labMS";
            this.labMS.Size = new System.Drawing.Size(50, 17);
            this.labMS.TabIndex = 13;
            this.labMS.Text = "Mã số ";
            // 
            // txtMaDG
            // 
            this.txtMaDG.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaDG.Location = new System.Drawing.Point(25, 55);
            this.txtMaDG.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.ReadOnly = true;
            this.txtMaDG.Size = new System.Drawing.Size(149, 24);
            this.txtMaDG.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 35);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Mã độc giả";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 96);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Họ tên";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(22, 154);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 3;
            this.label10.Text = "Email";
            // 
            // txtHoVaTen
            // 
            this.txtHoVaTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoVaTen.Location = new System.Drawing.Point(25, 115);
            this.txtHoVaTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoVaTen.Name = "txtHoVaTen";
            this.txtHoVaTen.ReadOnly = true;
            this.txtHoVaTen.Size = new System.Drawing.Size(408, 23);
            this.txtHoVaTen.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(25, 173);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(408, 23);
            this.txtEmail.TabIndex = 5;
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
            this.btnLamMoi.Location = new System.Drawing.Point(33, 158);
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
            this.btnTimKiem.Location = new System.Drawing.Point(277, 158);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(85, 25);
            this.btnTimKiem.TabIndex = 26;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnBiKhoa
            // 
            this.btnBiKhoa.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBiKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBiKhoa.Location = new System.Drawing.Point(466, 47);
            this.btnBiKhoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnBiKhoa.Name = "btnBiKhoa";
            this.btnBiKhoa.Size = new System.Drawing.Size(135, 24);
            this.btnBiKhoa.TabIndex = 27;
            this.btnBiKhoa.Text = "Mở khoá";
            this.btnBiKhoa.UseVisualStyleBackColor = false;
            this.btnBiKhoa.Click += new System.EventHandler(this.btnBiKhoa_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbTimKiem);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnLamMoi);
            this.groupBox3.Controls.Add(this.txtTimKiem);
            this.groupBox3.Controls.Add(this.btnTimKiem);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(822, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(385, 214);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGiaHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiaHan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiaHan.Location = new System.Drawing.Point(474, 178);
            this.btnGiaHan.Margin = new System.Windows.Forms.Padding(2);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(319, 27);
            this.btnGiaHan.TabIndex = 31;
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = false;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // txtNgayDK
            // 
            this.txtNgayDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayDK.Location = new System.Drawing.Point(474, 150);
            this.txtNgayDK.Margin = new System.Windows.Forms.Padding(2);
            this.txtNgayDK.Name = "txtNgayDK";
            this.txtNgayDK.ReadOnly = true;
            this.txtNgayDK.Size = new System.Drawing.Size(147, 24);
            this.txtNgayDK.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(471, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 29;
            this.label2.Text = "Ngày đăng ký";
            // 
            // txtNgayHetHan
            // 
            this.txtNgayHetHan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNgayHetHan.Location = new System.Drawing.Point(646, 150);
            this.txtNgayHetHan.Margin = new System.Windows.Forms.Padding(2);
            this.txtNgayHetHan.Name = "txtNgayHetHan";
            this.txtNgayHetHan.ReadOnly = true;
            this.txtNgayHetHan.Size = new System.Drawing.Size(147, 24);
            this.txtNgayHetHan.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(643, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 18);
            this.label4.TabIndex = 32;
            this.label4.Text = "Ngày hết hạn";
            // 
            // MaDocGia
            // 
            this.MaDocGia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.MaDocGia.DataPropertyName = "MaDocGia";
            this.MaDocGia.HeaderText = "Mã";
            this.MaDocGia.MinimumWidth = 6;
            this.MaDocGia.Name = "MaDocGia";
            this.MaDocGia.ReadOnly = true;
            this.MaDocGia.Width = 51;
            // 
            // MaSo
            // 
            this.MaSo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MaSo.DataPropertyName = "MaSo";
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            this.MaSo.DefaultCellStyle = dataGridViewCellStyle8;
            this.MaSo.HeaderText = "Mã số SV/GV";
            this.MaSo.MinimumWidth = 6;
            this.MaSo.Name = "MaSo";
            this.MaSo.ReadOnly = true;
            this.MaSo.Width = 113;
            // 
            // Loai
            // 
            this.Loai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại độc giả";
            this.Loai.Name = "Loai";
            this.Loai.ReadOnly = true;
            this.Loai.Visible = false;
            this.Loai.Width = 106;
            // 
            // HoTen
            // 
            this.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 71;
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
            // BiKhoa
            // 
            this.BiKhoa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BiKhoa.DataPropertyName = "BiKhoa";
            this.BiKhoa.HeaderText = "Trạng thái";
            this.BiKhoa.MinimumWidth = 6;
            this.BiKhoa.Name = "BiKhoa";
            this.BiKhoa.ReadOnly = true;
            this.BiKhoa.Width = 92;
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "SL Phiếu";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 85;
            // 
            // NgayDk
            // 
            this.NgayDk.DataPropertyName = "NgayDk";
            this.NgayDk.HeaderText = "Ngày ĐK";
            this.NgayDk.Name = "NgayDk";
            this.NgayDk.ReadOnly = true;
            this.NgayDk.Visible = false;
            // 
            // NgayHH
            // 
            this.NgayHH.DataPropertyName = "NgayHH";
            this.NgayHH.HeaderText = "NgayHetHan";
            this.NgayHH.Name = "NgayHH";
            this.NgayHH.ReadOnly = true;
            this.NgayHH.Visible = false;
            // 
            // frmQuanLyDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1219, 724);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmQuanLyDocGia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmQuanLyBanDoc";
            this.Load += new System.EventHandler(this.frmQuanLyBanDoc_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBanDoc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvBanDoc;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private FontAwesome.Sharp.IconButton btnTimKiem;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaSo;
        private System.Windows.Forms.Label labMS;
        private System.Windows.Forms.TextBox txtMaDG;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHoVaTen;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnBiKhoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbSinhVien;
        private System.Windows.Forms.RadioButton rbGiangVien;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnKhoa;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.TextBox txtNgayDK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNgayHetHan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn BiKhoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDk;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHH;
    }
}