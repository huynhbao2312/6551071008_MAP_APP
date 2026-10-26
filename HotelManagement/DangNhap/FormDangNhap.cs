using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DangNhap
{
    public partial class FormDangNhap : Form
    {
        // Thông tin phiên đăng nhập - các form khác đọc trực tiếp
        public static string MaNV_DangNhap = string.Empty;
        public static string TenNV_DangNhap = string.Empty;
        public static int CapDoQuyen_DangNhap; // 1: Nhân viên, 2: Quản lý, 3: Admin

        public FormDangNhap()
        {
            InitializeComponent();
            ActiveControl = txtTenDangNhap;
        }

        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (tenDangNhap.Length == 0 || matKhau.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnDangNhap.Enabled = false;

            try
            {
                bool hopLe = await KiemTraDangNhapAsync(tenDangNhap, matKhau);
                if (hopLe)
                {
                    DialogResult = DialogResult.OK; // Program.cs sẽ mở form chính
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Đăng nhập thất bại",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMatKhau.Clear();
                    txtMatKhau.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDangNhap.Enabled = true;
            }
        }

        private async Task<bool> KiemTraDangNhapAsync(string tenDangNhap, string matKhau)
        {
            await using var db = new HotelManagementContext();

            var tk = await db.TaiKhoan
                .AsNoTracking()
                .Where(t => t.TenTK == tenDangNhap && t.DaXoa != true)
                .Select(t => new
                {
                    t.Password,
                    t.MaNV,
                    t.CapDoQuyen,
                    TenNv = t.MaNVNavigation.TenNV,
                    NhanVienDaXoa = t.MaNVNavigation.DaXoa
                })
                .FirstOrDefaultAsync();

            if (tk == null || tk.NhanVienDaXoa == true)
                return false;

            if (!string.Equals(tk.Password, matKhau, StringComparison.Ordinal))
                return false;

            MaNV_DangNhap = tk.MaNV;
            TenNV_DangNhap = tk.TenNv;
            CapDoQuyen_DangNhap = tk.CapDoQuyen;
            Tag = tk.TenNv;

            return true;
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnDangNhap.PerformClick();
            }
        }
    }
}