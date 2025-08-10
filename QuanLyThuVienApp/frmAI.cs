using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienApp
{
    public partial class frmAI : Form
    {
        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string schemaDescription = @"
                Cơ sở dữ liệu quản lý thư viện gồm các bảng sau:
                1. **NguoiDung**
                    - ID (PK), TenDangNhap, MatKhau, QuyenHan ('admin' | 'user'), BiKhoa (BIT)
                2. **NhanVien**
                    - MaNV (PK), HoTen, NgaySinh, SDT, DiaChi, Email, NgayDangKi, MaOTP, ThoiGianNhanOTP, TrangThaiXacThuc (BIT), NguoiDungID (FK → NguoiDung.ID)
                3. **DanhMucTaiLieu**
                    - MaDanhMuc (PK), TenDanhMuc, ViTri, SoLuongTL, MoTa
                4. **NhaXuatBan**
                    - MaNXB (PK), TenNXB, SoLuongTL, MoTa
                5. **TacGia**
                    - MaTG (PK), TenTG, SoLuongTL, MoTa
                6. **TaiLieu**
                    - MaTaiLieu (PK), TenTaiLieu, MaDanhMuc (FK → DanhMucTaiLieu.MaDanhMuc), MaTG (FK → TacGia.MaTG), MaNXB (FK → NhaXuatBan.MaNXB),
                      TaiBan, MoTa, SoLuong, SoTaiLieuMuon
                7. **DocGia**
                    - MaDocGia (PK), MaSo, HoTen, Email, LoaiDG, BiKhoa (BIT)
                8. **PhieuMuon**
                    - MaPhieu (PK), MaDG (FK → DocGia.MaDocGia), MaNV (FK → NhanVien.MaNV), NgayMuon, HanTra, DaTra (BIT), NgayTra, NgayTao, DaGuiMail, TongSLMuon
                9. **ChiTietPhieuMuon**
                    - MaChiTiet (PK), MaPM (FK → PhieuMuon.MaPhieu), MaTL (FK → TaiLieu.MaTaiLieu), SoLuong, SoLuongBD
                    - Ràng buộc duy nhất: (MaPM, MaTL)
                Ghi chú:
                - PK: Primary Key
                - FK: Foreign Key
                - BIT: giá trị 0 hoặc 1 (đúng/sai)
                - Người dùng có thể là nhân viên, được liên kết qua NguoiDungID.
                - Mỗi phiếu mượn có thể chứa nhiều tài liệu, lưu tại bảng ChiTietPhieuMuon.
                ";
        public frmAI()
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

        // Thay đổi phần trong frmAL:

        private List<(string role, string content)> conversationHistory = new List<(string role, string content)>();

        private async Task ProcessQuestion()
        {
            string userInput = textBoxInput.Text.Trim();
            if (string.IsNullOrEmpty(userInput)) return;

            AddChatMessage("Bạn", userInput);
            textBoxInput.Clear();
            conversationHistory.Add(("user", userInput));

            var (isNeedSQL, aiResponse) = await GenerateSQLFromAI(userInput);

            if (aiResponse.StartsWith("LỖI"))
            {
                AddChatMessage("Trợ lý", aiResponse);
                conversationHistory.Add(("assistant", aiResponse));
                return;
            }

            if (isNeedSQL)
            {
                string result = await ExecuteSQLAsync(aiResponse);
                string naturalReply = await FormatSQLResultToNaturalReplyAsync(userInput, result);
                AddChatMessage("Trợ lý", naturalReply);
                conversationHistory.Add(("assistant", naturalReply));
            }
            else
            {
                AddChatMessage("Trợ lý", aiResponse);
                conversationHistory.Add(("assistant", aiResponse));
            }

            // Nếu AI không biết hoặc không chắc chắn
            if (aiResponse.IndexOf("Tôi không biết", StringComparison.OrdinalIgnoreCase) >= 0 ||
                aiResponse.IndexOf("không rõ", StringComparison.OrdinalIgnoreCase) >= 0 ||
                aiResponse.IndexOf("chưa có dữ liệu", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                string fallback = "Xin lỗi, tôi chưa có dữ liệu về nội dung này. Bạn có thể hỏi tôi về sách, tác giả hoặc phiếu mượn.";
                AddChatMessage("Trợ lý", fallback);
                conversationHistory.Add(("assistant", fallback));
            }

            // Giới hạn chỉ lưu 10 đoạn hội thoại gần nhất (5 cặp hỏi-đáp)
            if (conversationHistory.Count > 10)
                conversationHistory = conversationHistory.Skip(conversationHistory.Count - 10).ToList();
        }



        private async Task<(bool isNeedSQL, string content)> GenerateSQLFromAI(string userInput)
        {
            string groqApiKey = "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";
            string groqEndpoint = "https://api.groq.com/openai/v1/chat/completions";

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", groqApiKey);

                // === BƯỚC 1: Prompt phụ - Xác định có cần SQL không ===
                var classificationPrompt = new
                {
                    model = "llama3-70b-8192",
                    messages = new[]
                    {
                new {
                    role = "system",
                    content = "Bạn là bộ lọc phân loại. Nếu câu hỏi người dùng yêu cầu truy vấn dữ liệu từ cơ sở dữ liệu, hãy trả lời duy nhất bằng một trong hai chuỗi: 'CẦN SQL' hoặc 'KHÔNG CẦN SQL'. Không được trả lời gì khác."
                },
                new { role = "user", content = userInput }
            }
                };

                var json1 = JsonConvert.SerializeObject(classificationPrompt);
                var content1 = new StringContent(json1, Encoding.UTF8, "application/json");

                try
                {
                    var response1 = await httpClient.PostAsync(groqEndpoint, content1);
                    var responseContent1 = await response1.Content.ReadAsStringAsync();

                    if (!response1.IsSuccessStatusCode)
                    {
                        return (false, $"LỖI: Không phân loại được câu hỏi - HTTP {(int)response1.StatusCode}:{responseContent1}");
                    }

                    dynamic result1 = JsonConvert.DeserializeObject(responseContent1);
                    string answer = result1.choices[0].message.content.ToString().Trim().ToUpper();

                    if (answer.Contains("KHÔNG CẦN SQL"))
                    {
                        string reply = await GenerateNaturalReply(userInput);
                        return (false, reply);
                    }
                }
                catch (Exception ex)
                {
                    return (false, $"LỖI: Phân loại thất bại: {ex.Message}");
                }

                // === BƯỚC 2: Prompt chính - Sinh SQL ===
                var sqlPrompt = new
                {
                    model = "llama3-70b-8192",
                    messages = new[]
                    {
                        new {
                                role = "system",
                                content = $@"
                                Bạn là AI chuyên tạo câu lệnh SQL cho CSDL quản lý thư viện.
                                - Nhiệm vụ của bạn là dựa trên câu hỏi của người dùng, tạo ra câu lệnh SQL chính xác nhất để truy vấn dữ liệu từ cơ sở dữ liệu thư viện.
                                Yêu cầu bắt buộc:
                                - Luôn giả định mọi câu hỏi của người dùng là về thư viện, ngay cả khi họ không nói rõ (ví dụ: 'có bao nhiêu quyển sách' hiểu là 'có bao nhiêu quyển sách trong thư viện').
                                - Chỉ sử dụng các bảng và cột có trong sơ đồ cơ sở dữ liệu sau.
                                - KHÔNG truy xuất về thông tin của admin ,nhân viên thư viện và đọc giả.
                                - Nếu khách hàng hỏi thì cứ trả lời rằng thông tin cá nhân của thư viện không được tiết lộ.  
                                - Hãy đọc hiểu câu hỏi của người dùng và tìm kiếm keyword phù hợp với SQL để sinh ra lệnh SQL chính xác nhất.
                                - Trả về DUY NHẤT một câu lệnh SQL hợp lệ, không kèm giải thích, không kèm chú thích, không có văn bản thừa.
                                - Luôn ưu tiên chính xác tuyệt đối, không suy đoán.

                                Sơ đồ cơ sở dữ liệu:
                                {schemaDescription}"
                            },
                            new { role = "user", content = userInput }
                        }
                };


                var json2 = JsonConvert.SerializeObject(sqlPrompt);
                var content2 = new StringContent(json2, Encoding.UTF8, "application/json");

                try
                {
                    var response2 = await httpClient.PostAsync(groqEndpoint, content2);
                    var responseContent2 = await response2.Content.ReadAsStringAsync();

                    if (!response2.IsSuccessStatusCode)
                    {
                        return (false, $"LỖI: Không thể tạo SQL từ AI - HTTP {(int)response2.StatusCode}:{responseContent2}");
                    }

                    dynamic result2 = JsonConvert.DeserializeObject(responseContent2);
                    string sql = result2.choices[0].message.content.ToString().Trim();
                    return (true, sql);
                }
                catch (Exception ex)
                {
                    return (false, $"LỖI: Không thể tạo SQL từ AI: {ex.Message}");
                }
            }
        }
        private async Task<string> FormatSQLResultToNaturalReplyAsync(string userQuestion, string sqlResult)
        {
            if (string.IsNullOrWhiteSpace(sqlResult))
                return "Không có dữ liệu phù hợp để trả lời.";

            DateTime now = DateTime.Now;
            string currentDate = now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            string currentTime = now.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
            string currentDayOfWeek = now.DayOfWeek == DayOfWeek.Saturday ? "Thứ Bảy"
                : now.DayOfWeek == DayOfWeek.Sunday ? "Chủ Nhật"
                : $"Thứ {(int)now.DayOfWeek + 1}";

            // Nếu kết quả SQL có ngày hạn trả, kiểm tra trễ hạn
            string overdueInfo = "";
            try
            {
                // Tìm tất cả các ngày trong chuỗi SQL Result
                var dateMatches = Regex.Matches(sqlResult, @"\b\d{1,2}/\d{1,2}/\d{4}\b|\b\d{4}-\d{1,2}-\d{1,2}\b");
                foreach (Match match in dateMatches)
                {
                    if (DateTime.TryParse(match.Value, out DateTime dueDate))
                    {
                        int daysDiff = (now.Date - dueDate.Date).Days;
                        if (daysDiff > 0)
                            overdueInfo += $"\n- Hạn {dueDate:dd/MM/yyyy}: ĐÃ trễ {daysDiff} ngày.";
                        else if (daysDiff == 0)
                            overdueInfo += $"\n- Hạn {dueDate:dd/MM/yyyy}: Hôm nay là hạn trả.";
                        else
                            overdueInfo += $"\n- Hạn {dueDate:dd/MM/yyyy}: Còn {-daysDiff} ngày nữa mới đến hạn.";
                    }
                }
            }
            catch
            {
                // Không cần xử lý nếu lỗi parse ngày
            }
            string groqApiKey = "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";
            string groqEndpoint = "https://api.groq.com/openai/v1/chat/completions";
            var payload = new
            {
                model = "llama3-70b-8192",
                messages = new object[]
                {
            new
            {
                role = "system",
                content =
                    "Bạn là trợ lý AI của thư viện Đại học Sư Phạm TP.HCM (HCMUE). " +
                    "Nhiệm vụ của bạn là dựa vào **dữ liệu truy vấn từ cơ sở dữ liệu**, " +
                    "trả lời lại người dùng bằng **tiếng Việt** một cách tự nhiên, ngắn gọn, rõ ràng.\n\n" +
                    "- KHÔNG hiển thị bảng dữ liệu thô.\n" +
                    "- KHÔNG được tự tạo thêm thông tin không có.\n" +
                    "- Chỉ sử dụng dữ liệu truy vấn từ SQL để trả lời.\n" +
                    "- Nếu dữ liệu truy vấn không có thông tin cần thiết, hãy trả lời rõ ràng: 'Xin lỗi, tôi chưa có dữ liệu về nội dung này.'\n" +
                    "- Nếu truy vấn về thông tin cá nhân của admin, nhân viên, đọc giả thì hã thông báo: 'Thông tin cá nhân không thể tiết lộ'.\n" +
                    "- TRẢ LỜI chính xác dựa trên kết quả SQL.\n" +
                    "- Viết như một người thật đang trò chuyện.\n" +
                    "- Nếu kết quả là danh sách (ví dụ tên tác giả), hãy liệt kê ngắn gọn (không cần số thứ tự).\n" +
                    "- Nếu kết quả là số lượng, hãy thêm đơn vị (cuốn sách, tác giả, người dùng...).\n" +
                    "- KHÔNG dùng icon, emoji, không nhấn mạnh in đậm.\n" +
                    "- Tránh lặp lại câu hỏi."
            },
            new
            {
                role = "user",
                content = "Câu hỏi: " + userQuestion + "\nDữ liệu truy vấn từ SQL: " + sqlResult
            }
                }
            };

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", groqApiKey);

                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync(groqEndpoint, content);
                    var result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                        return sqlResult;

                    dynamic jsonResult = JsonConvert.DeserializeObject(result);
                    string reply = jsonResult.choices[0].message.content.ToString().Trim();
                    return reply;
                }
                catch
                {
                    return sqlResult;
                }
            }
        }



        private async Task<string> GenerateNaturalReply(string userInput)
        {
            string groqApiKey = "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";
            string groqEndpoint = "https://api.groq.com/openai/v1/chat/completions";


            var prompt = new
            {
                model = "llama3-70b-8192",
                messages = new[]
                {
            new {
                role = "system",
                content = "Bạn là trợ lý AI của thư viện Đại học Sư Phạm TP.HCM (HCMUE)." +
                "- Trả lời tự nhiên, thân thiện, ngắn gọn, BẮT BUỘC bằng **tiếng Việt**." +
                " - Ưu tiên hỗ trợ các câu hỏi về thư viện, sách, mượn trả, tác giả, sự kiện, cơ sở vật chất, hoặc các thông tin có trong cơ sở dữ liệu." +
                "-Nếu thông tin không có trong cơ sở dữ liệu, hãy thông báo rõ ràng:'Xin lỗi, tôi chưa có dữ liệu về nội dung này.', sau đó đưa ra gợi ý tìm kiếm khác và **trích dẫn nguồn nếu có**." +
                "- Tuyệt đối KHÔNG tự suy đoán thông tin không có thật trong CSDL." +                
                "- Nếu phát hiện người dùng sử dụng ngôn ngữ không phù hợp hoặc hỏi các thông tin khác ngoài trường học và thư viện thì hãy nhắc nhở lịch sự."
            },
            new { role = "user", content = userInput }
        }
            };

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", groqApiKey);

                var json = JsonConvert.SerializeObject(prompt);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PostAsync(groqEndpoint, content);
                    var result = await response.Content.ReadAsStringAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        return $"❌ Lỗi tạo phản hồi tự nhiên: {result}";
                    }

                    dynamic jsonResult = JsonConvert.DeserializeObject(result);
                    string reply = jsonResult.choices[0].message.content.ToString().Trim();
                    return reply;
                }
                catch (Exception ex)
                {
                    return $"❌ Lỗi phản hồi AI: {ex.Message}";
                }
            }
        }

        private async Task<string> ExecuteSQLAsync(string sql)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Server=.;Database=DB_QLTV;Trusted_Connection=True;"))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows) return "Không có kết quả.";

                        List<string> rows = new List<string>();
                        int rowCount = 0;

                        while (await reader.ReadAsync())
                        {
                            // Lấy giá trị của tất cả các cột trong dòng hiện tại
                            List<string> columns = new List<string>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                columns.Add(reader[i].ToString());
                            }

                            // Gộp các cột lại thành 1 dòng, ngăn cách bởi ", "
                            rows.Add(string.Join(", ", columns));
                            rowCount++;

                            if (rowCount >= 20) break; // giới hạn tránh quá nhiều dòng
                        }

                        return string.Join(" | ", rows); // ngăn cách các dòng bằng |
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Lỗi SQL: {ex.Message}";
            }
        }


        private void AddChatMessage(string sender, string message)
        {
            Color senderColor = sender == "Bạn" ? Color.DarkBlue : Color.DarkGreen;
            Font senderFont = new Font("Times New Roman", 18, FontStyle.Bold);
            Font messageFont = new Font("Times New Roman", 18, FontStyle.Regular);

            // Thêm tên người gửi
            richTextBoxChat.SelectionStart = richTextBoxChat.TextLength;
            richTextBoxChat.SelectionFont = senderFont;
            richTextBoxChat.SelectionColor = senderColor;
            richTextBoxChat.AppendText($"{sender}:\n");

            // Thêm nội dung
            richTextBoxChat.SelectionFont = messageFont;
            richTextBoxChat.SelectionColor = Color.Black;
            richTextBoxChat.AppendText($"{message}\n");

            richTextBoxChat.ScrollToCaret();
        }

        private void richTextBoxChat_TextChanged(object sender, EventArgs e)
        {
            // Tự động cuộn xuống cuối khi có thay đổi
            richTextBoxChat.SelectionStart = richTextBoxChat.Text.Length;
            richTextBoxChat.ScrollToCaret();
        }
        private void buttonClearChat_Click(object sender, EventArgs e)
        {
            richTextBoxChat.Clear();
            AddChatMessage("Trợ lý", "Xin chào! Tôi là trợ lý AI của thư viện HCMUE. Bạn cần tìm sách hay hỗ trợ gì không?");
            textBoxInput.Focus();
        }
    }
}
