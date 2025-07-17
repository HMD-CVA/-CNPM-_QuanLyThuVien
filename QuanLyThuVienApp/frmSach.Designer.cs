namespace QuanLyThuVienApp
{
    partial class frmSach
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.txtNXB = new System.Windows.Forms.TextBox();
            this.txtTheLoai = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbTimKiem = new System.Windows.Forms.ComboBox();
            this.txtConSan = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new FontAwesome.Sharp.IconButton();
            this.btnLamMoi = new FontAwesome.Sharp.IconButton();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
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
            this.MoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSach);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 279);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(915, 196);
            this.panel1.TabIndex = 1;
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.AllowUserToResizeRows = false;
            this.dgvSach.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTaiLieu,
            this.TenTaiLieu,
            this.TenDanhMuc,
            this.TenTG,
            this.TenNXB,
            this.TaiBan,
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
            this.dgvSach.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.dgvSach.TabIndex = 0;
            this.dgvSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 102);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên tài liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(316, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nhà xuất bản";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(316, 102);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Thể loại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(316, 162);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Còn sẵn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tác giả";
            // 
            // txtTenSach
            // 
            this.txtTenSach.BackColor = System.Drawing.Color.White;
            this.txtTenSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSach.Location = new System.Drawing.Point(82, 102);
            this.txtTenSach.Margin = new System.Windows.Forms.Padding(2);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.ReadOnly = true;
            this.txtTenSach.Size = new System.Drawing.Size(230, 23);
            this.txtTenSach.TabIndex = 3;
            // 
            // txtTacGia
            // 
            this.txtTacGia.BackColor = System.Drawing.Color.White;
            this.txtTacGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTacGia.Location = new System.Drawing.Point(82, 162);
            this.txtTacGia.Margin = new System.Windows.Forms.Padding(2);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.ReadOnly = true;
            this.txtTacGia.Size = new System.Drawing.Size(230, 23);
            this.txtTacGia.TabIndex = 3;
            // 
            // txtNXB
            // 
            this.txtNXB.BackColor = System.Drawing.Color.White;
            this.txtNXB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNXB.Location = new System.Drawing.Point(410, 46);
            this.txtNXB.Margin = new System.Windows.Forms.Padding(2);
            this.txtNXB.Name = "txtNXB";
            this.txtNXB.ReadOnly = true;
            this.txtNXB.Size = new System.Drawing.Size(241, 23);
            this.txtNXB.TabIndex = 3;
            // 
            // txtTheLoai
            // 
            this.txtTheLoai.BackColor = System.Drawing.Color.White;
            this.txtTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheLoai.Location = new System.Drawing.Point(410, 102);
            this.txtTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.txtTheLoai.Name = "txtTheLoai";
            this.txtTheLoai.ReadOnly = true;
            this.txtTheLoai.Size = new System.Drawing.Size(241, 23);
            this.txtTheLoai.TabIndex = 3;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(688, 203);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(204, 23);
            this.txtTimKiem.TabIndex = 4;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(685, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tìm kiếm theo";
            // 
            // cbTimKiem
            // 
            this.cbTimKiem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimKiem.FormattingEnabled = true;
            this.cbTimKiem.Items.AddRange(new object[] {
            "Mã tài liệu",
            "Tên tài liệu",
            "Tác giả",
            "Nhà xuất bản",
            "Thể loại"});
            this.cbTimKiem.Location = new System.Drawing.Point(783, 167);
            this.cbTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.cbTimKiem.Name = "cbTimKiem";
            this.cbTimKiem.Size = new System.Drawing.Size(108, 25);
            this.cbTimKiem.TabIndex = 6;
            // 
            // txtConSan
            // 
            this.txtConSan.BackColor = System.Drawing.Color.White;
            this.txtConSan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConSan.Location = new System.Drawing.Point(410, 162);
            this.txtConSan.Margin = new System.Windows.Forms.Padding(2);
            this.txtConSan.Name = "txtConSan";
            this.txtConSan.ReadOnly = true;
            this.txtConSan.Size = new System.Drawing.Size(241, 23);
            this.txtConSan.TabIndex = 3;
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
            this.btnTimKiem.Location = new System.Drawing.Point(795, 241);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(2);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(88, 25);
            this.btnTimKiem.TabIndex = 7;
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
            this.btnLamMoi.Location = new System.Drawing.Point(700, 241);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(88, 25);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 46);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Mã tài liệu";
            // 
            // txtMaSach
            // 
            this.txtMaSach.BackColor = System.Drawing.Color.White;
            this.txtMaSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSach.Location = new System.Drawing.Point(82, 46);
            this.txtMaSach.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(230, 23);
            this.txtMaSach.TabIndex = 3;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Location = new System.Drawing.Point(671, 32);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(2);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(236, 118);
            this.txtMoTa.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(668, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "Mô Tả";
            // 
            // MaTaiLieu
            // 
            this.MaTaiLieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
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
            this.TenDanhMuc.HeaderText = "Danh Mục";
            this.TenDanhMuc.MinimumWidth = 6;
            this.TenDanhMuc.Name = "TenDanhMuc";
            this.TenDanhMuc.ReadOnly = true;
            this.TenDanhMuc.Width = 92;
            // 
            // TenTG
            // 
            this.TenTG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenTG.DataPropertyName = "TenTG";
            this.TenTG.HeaderText = "Tác giả";
            this.TenTG.MinimumWidth = 6;
            this.TenTG.Name = "TenTG";
            this.TenTG.ReadOnly = true;
            this.TenTG.Width = 78;
            // 
            // TenNXB
            // 
            this.TenNXB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TenNXB.DataPropertyName = "TenNXB";
            this.TenNXB.HeaderText = "Nhà xuất bản";
            this.TenNXB.MinimumWidth = 6;
            this.TenNXB.Name = "TenNXB";
            this.TenNXB.ReadOnly = true;
            this.TenNXB.Width = 110;
            // 
            // TaiBan
            // 
            this.TaiBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TaiBan.DataPropertyName = "TaiBan";
            this.TaiBan.HeaderText = "Tái bản";
            this.TaiBan.Name = "TaiBan";
            this.TaiBan.ReadOnly = true;
            this.TaiBan.Width = 78;
            // 
            // SoLuong
            // 
            this.SoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.MinimumWidth = 6;
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            this.SoLuong.Width = 85;
            // 
            // SoTaiLieuMuon
            // 
            this.SoTaiLieuMuon.DataPropertyName = "SoTaiLieuMuon";
            this.SoTaiLieuMuon.HeaderText = "Số Tài Liệu Mượn";
            this.SoTaiLieuMuon.MinimumWidth = 6;
            this.SoTaiLieuMuon.Name = "SoTaiLieuMuon";
            this.SoTaiLieuMuon.ReadOnly = true;
            this.SoTaiLieuMuon.Visible = false;
            this.SoTaiLieuMuon.Width = 125;
            // 
            // MoTa
            // 
            this.MoTa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.MoTa.DataPropertyName = "MoTa";
            this.MoTa.HeaderText = "Mô Tả";
            this.MoTa.MinimumWidth = 6;
            this.MoTa.Name = "MoTa";
            this.MoTa.ReadOnly = true;
            this.MoTa.Visible = false;
            this.MoTa.Width = 125;
            // 
            // frmSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(915, 475);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cbTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.txtConSan);
            this.Controls.Add(this.txtTheLoai);
            this.Controls.Add(this.txtNXB);
            this.Controls.Add(this.txtTacGia);
            this.Controls.Add(this.txtMaSach);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSach";
            this.Load += new System.EventHandler(this.frmSach_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.TextBox txtNXB;
        private System.Windows.Forms.TextBox txtTheLoai;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTimKiem;
        private System.Windows.Forms.TextBox txtConSan;
        private FontAwesome.Sharp.IconButton btnTimKiem;
        private FontAwesome.Sharp.IconButton btnLamMoi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMaSach;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn MoTa;
    }
}