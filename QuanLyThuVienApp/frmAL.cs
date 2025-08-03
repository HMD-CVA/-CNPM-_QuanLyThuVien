using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmAL : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string schemaDescription = @"
        Các bảng có trong cơ sở dữ liệu:
        1. NguoiDung(ID, TenDangNhap, MatKhau, QuyenHan, BiKhoa)
        2. NhanVien(MaNV, HoTen, NgaySinh, SDT, DiaChi, Email, NgayDangKi, MaOTP, ThoiGianNhanOTP, TrangThaiXacThuc, NguoiDungID)
        3. DanhMucTaiLieu(MaDanhMuc, TenDanhMuc, ViTri, SoLuongTL, MoTa)
        4. NhaXuatBan(MaNXB, TenNXB, SoLuongTL, MoTa)
        5. TacGia(MaTG, TenTG, SoLuongTL, MoTa)
        6. TaiLieu(MaTaiLieu, TenTaiLieu, MaDanhMuc, MaTG, MaNXB, TaiBan, MoTa, SoLuong, SoTaiLieuMuon)
        7. DocGia(MaDocGia, HoTen, SDT, Email, BiKhoa)
        8. PhieuMuon(MaPhieu, MaDG, MaNV, NgayMuon, HanTra, DaTra, NgayTra, NgayTao)
        9. ChiTietPhieuMuon(MaChiTiet, MaPM, MaTL, SoLuong)
        Các mối quan hệ:
        - NhanVien.NguoiDungID → NguoiDung.ID
        - TaiLieu.MaDanhMuc → DanhMucTaiLieu.MaDanhMuc
        - TaiLieu.MaTG → TacGia.MaTG
        - TaiLieu.MaNXB → NhaXuatBan.MaNXB
        - PhieuMuon.MaDG → DocGia.MaDocGia
        - PhieuMuon.MaNV → NhanVien.MaNV
        - ChiTietPhieuMuon.MaPM → PhieuMuon.MaPhieu
        - ChiTietPhieuMuon.MaTL → TaiLieu.MaTaiLieu
    ";

        public frmAL()
        {
            InitializeComponent();
            richTextBoxChat.AppendText("Trợ lý: Xin chào! Tôi là trợ lý AI của thư viện HCMUE. Bạn cần tìm sách hay hỗ trợ gì không?\n\n");
            buttonSend.Click += async (s, e) => await ProcessQuestion();
            textBoxInput.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    await ProcessQuestion();
                }
            };
            this.ActiveControl = textBoxInput; // Tự động focus vào textbox khi mở form
        }

        private async Task ProcessQuestion()
        {
            string userInput = textBoxInput.Text.Trim();
            if (string.IsNullOrEmpty(userInput)) return;

            // Chat người dùng màu Xanh
            richTextBoxChat.SelectionColor = System.Drawing.Color.Blue;
            richTextBoxChat.AppendText($"Bạn: {userInput}\n");
            textBoxInput.Clear();

            string aiResponse = await GenerateSQLFromAI(userInput);

            // Nếu AI không biết hoặc không chắc chắn
            if (aiResponse.IndexOf("Tôi không biết", StringComparison.OrdinalIgnoreCase) >= 0 ||
                aiResponse.IndexOf("không rõ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                aiResponse.IndexOf("chưa có dữ liệu", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                aiResponse = "Xin lỗi, tôi chưa có dữ liệu về nội dung này. Bạn có thể hỏi tôi về sách, tác giả hoặc phiếu mượn.";
            }

            // Trợ lý trả lời màu Đen
            richTextBoxChat.SelectionColor = System.Drawing.Color.Black;

            if (aiResponse.StartsWith("LỖI"))
            {
                richTextBoxChat.AppendText($"Trợ lý: {aiResponse}\n\n");
                return;
            }

            if (aiResponse.TrimStart().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase)
                || aiResponse.IndexOf("FROM", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                string result = ExecuteSQL(aiResponse);
                richTextBoxChat.AppendText($"Trợ lý: {result}\n\n");
            }
            else
            {
                richTextBoxChat.AppendText($"Trợ lý: {aiResponse}\n\n");
            }
        }

        private async Task<string> GenerateSQLFromAI(string userInput)
        {
            string groqApiKey = "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";
            string groqEndpoint = "https://api.groq.com/openai/v1/chat/completions";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", groqApiKey);

                var requestBody = new
                {
                    model = "llama3-70b-8192",
                    messages = new[]
                    {
                        new { role = "system", content = @"
                        Bạn là trợ lý AI của thư viện Đại học Sư Phạm TP.HCM (HCMUE), có thể:
                        - Trả lời tự nhiên, thân thiện, ngắn gọn bằng tiếng Việt.
                        - Trả lời các câu hỏi về trường, thư viện, tác giả, sách, quy trình mượn trả, v.v.
                        - Nếu câu hỏi yêu cầu truy vấn dữ liệu (ví dụ: số lượng sách, sách của Nam Cao...), hãy tạo câu lệnh SQL tương thích với SQL Server, **trả về kết quả thôi, không cần hiển thị câu SQL**.
                        - Không cần giải thích chi tiết về logic SQL, chỉ trả lời kết quả cho người dùng.

                        Dưới đây là mô tả sơ lược về cơ sở dữ liệu để hỗ trợ bạn:
                        " + schemaDescription },
                        new { role = "user", content = userInput }
                    }
                };

                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync(groqEndpoint, content);
                    var responseContent = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return $"LỖI: Không thể tạo SQL từ AI - HTTP {(int)response.StatusCode}:\n{responseContent}";
                    }

                    dynamic result = JsonConvert.DeserializeObject(responseContent);
                    string sql = result.choices[0].message.content.ToString().Trim();
                    return sql;
                }
                catch (Exception ex)
                {
                    return $"LỖI: Không thể tạo SQL từ AI: {ex.Message}";
                }
            }
        }

        private string ExecuteSQL(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Server=.\SQLEXPRESS;Database=DB_QLTV;Trusted_Connection=True;"))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows) return "Không tìm thấy kết quả phù hợp.";

                    StringBuilder sb = new StringBuilder();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            sb.Append($"{reader.GetName(i)}: {reader[i]}");
                            if (i < reader.FieldCount - 1) sb.Append(" | ");
                        }
                        sb.AppendLine();
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return $"LỖI SQL: {ex.Message}";
            }
        }
    }
}
