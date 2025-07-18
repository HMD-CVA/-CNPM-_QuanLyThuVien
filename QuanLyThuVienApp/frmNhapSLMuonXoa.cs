using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmNhapSLMuonXoa : Form
    {
        public int SoLuong { get; private set; }
        public frmNhapSLMuonXoa(int maxSoLuong, bool ok)
        {
            InitializeComponent();
            string loai = "mượn";
            if (!ok)
            {
                loai = "xoá";
            }
            labNhap.Text = $"Nhập số lượng tài liệu cần {loai} (tối đa {maxSoLuong}):";
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = maxSoLuong;
        }
        public frmNhapSLMuonXoa()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SoLuong = (int)numericUpDown1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
