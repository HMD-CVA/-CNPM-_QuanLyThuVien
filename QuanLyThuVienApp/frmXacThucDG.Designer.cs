namespace QuanLyThuVienApp
{
    partial class frmXacThucDG
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnXacThuc = new System.Windows.Forms.Button();
            this.btnGuiLai = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMaXacThuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.TextBox();
            this.progressBar1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(84, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "XÁC THỰC TÀI KHOẢN";
            // 
            // btnXacThuc
            // 
            this.btnXacThuc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnXacThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacThuc.Image = global::QuanLyThuVienApp.Properties.Resources.pngtree_tick_vector_icon_png_image_696437_removebg_preview;
            this.btnXacThuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXacThuc.Location = new System.Drawing.Point(6, 122);
            this.btnXacThuc.Margin = new System.Windows.Forms.Padding(2);
            this.btnXacThuc.Name = "btnXacThuc";
            this.btnXacThuc.Size = new System.Drawing.Size(110, 25);
            this.btnXacThuc.TabIndex = 1;
            this.btnXacThuc.Text = "Xác thực";
            this.btnXacThuc.UseVisualStyleBackColor = false;
            this.btnXacThuc.Click += new System.EventHandler(this.btnXacThuc_Click);
            // 
            // btnGuiLai
            // 
            this.btnGuiLai.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnGuiLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiLai.Image = global::QuanLyThuVienApp.Properties.Resources.abc;
            this.btnGuiLai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuiLai.Location = new System.Drawing.Point(116, 122);
            this.btnGuiLai.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuiLai.Name = "btnGuiLai";
            this.btnGuiLai.Size = new System.Drawing.Size(110, 25);
            this.btnGuiLai.TabIndex = 2;
            this.btnGuiLai.Text = "Gửi lại";
            this.btnGuiLai.UseVisualStyleBackColor = false;
            this.btnGuiLai.Click += new System.EventHandler(this.btnGuiLai_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Image = global::QuanLyThuVienApp.Properties.Resources._1;
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(226, 122);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(110, 25);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(17, 155);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(312, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "*Lưu ý cần kết nối với Internet để nhận mã OTP*";
            // 
            // txtMaXacThuc
            // 
            this.txtMaXacThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaXacThuc.Location = new System.Drawing.Point(172, 73);
            this.txtMaXacThuc.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaXacThuc.Name = "txtMaXacThuc";
            this.txtMaXacThuc.Size = new System.Drawing.Size(88, 23);
            this.txtMaXacThuc.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(85, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Mã xác thực";
            // 
            // lblTimer
            // 
            this.lblTimer.Location = new System.Drawing.Point(281, 180);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(53, 20);
            this.lblTimer.TabIndex = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.Silver;
            this.progressBar1.Location = new System.Drawing.Point(265, 73);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(5);
            this.progressBar1.Maximum = 100;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(23, 23);
            this.progressBar1.TabIndex = 11;
            this.progressBar1.UseSelectable = true;
            // 
            // frmXacThucDG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 208);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaXacThuc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnGuiLai);
            this.Controls.Add(this.btnXacThuc);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmXacThucDG";
            this.Padding = new System.Windows.Forms.Padding(15, 60, 15, 16);
            this.Resizable = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmXacNhanOTP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXacThuc;
        private System.Windows.Forms.Button btnGuiLai;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMaXacThuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lblTimer;
        private MetroFramework.Controls.MetroProgressSpinner progressBar1;
    }
}