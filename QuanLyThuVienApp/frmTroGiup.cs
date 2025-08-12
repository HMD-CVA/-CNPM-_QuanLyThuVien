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
    public partial class frmTroGiup : Form
    {
        public frmTroGiup()
        {
            InitializeComponent();
        }
     
        private void frmTroGiup_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;

            richTextBox1.Text = "-> Nhấn vào Đăng ký mượn tài liệu\n\n" +
                   "-> Bên phải cuốn tài liệu bạn muốn mượn, chọn Đăng ký để thêm vào danh tài liệu\n\n" +
                   "-> Trên Danh tài liệu đăng ký mượn, nhập Email do trường cấp và nhấn vào Đăng ký để gửi yêu cầu\n\n" +
                   "-> Vui lòng đến gặp thủ thư để xác nhận phiếu mượn trong vòng 15 phút, sau 15 phút không đến xác nhận thì chúng tôi sẽ hủy phiếu đăng ký";
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Red;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            richTextBox1.Text = "-> Nếu bạn quá hạn mượn tài liệu, bạn sẽ chịu mức phạt tương ứng với số ngày quá hạn\n\n" +
                "-> Mỗi tài liệu quá hạn sẽ được tính là: số tài liệu * 1000 VNĐ\n\n" +
                "-> 7 ngày đầu tiên quá hạn được tính là: 2000 VNĐ/ngày\n\n" +
                "-> Từ ngày 8 đến ngày 14 được tính là: 5000 VNĐ/ngày\n\n" +
                "-> Từ ngày 15 đến ngày 30 được tính là: 10000 VNĐ/ngày\n\n" +
                "-> Nếu thư viện thấy có dấu hiệu vi phạm nghiêm trọng, chúng tôi sẽ tiến hành khóa tài khoản của bạn và ghi nhận vào hồ sơ";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Red;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            richTextBox1.Text =  "-> Nếu muốn gia hạn thời gian mượn tài liệu, vui lòng đến gặp thủ thư để được hỗ trợ";
        }

        private void label4_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Red;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Black;
            richTextBox1.Text = "-> Bạn hãy vào mục \"Thông tin tài liệu\"\nSau đó nhập thông tin như tên tài liệu, chọn danh mục, nhà xuất bản, tác giả của tài liệu đó\n" +
                "-> Hệ thống của thư viện sẽ giúp bạn tìm kiếm ngay!";
        }

        private void label5_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Red;
            label6.ForeColor = Color.Black;
            richTextBox1.Text =
                "-> Bạn chọn mục \"Lịch sử phiếu mượn\"\n\n" +
                "-> Nhập thông tin cá nhân của bạn\n\n" +
                "-> Hệ thống sẽ tìm và hiển thị thông tin về những phiếu mượn của bạn cùng với tình trạng cụ thể\n\n";
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label6.ForeColor = Color.Red;
            richTextBox1.Text = "-> Bạn chọn mục \"Chatbox AI\"\n\n" +
                "-> AI của thư viện sẽ giúp bạn trả lời những thắc mắc khác\n\n" +
                "-> Lưu ý: Hệ thống AI chỉ trả lời những câu hỏi đơn giản về tài liệu và thư viện!\n\n";
        }
    }
}
