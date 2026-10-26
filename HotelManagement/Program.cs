using HotelManagement.DangNhap;

namespace HotelManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Hiện form đăng nhập trước; đăng nhập thành công mới mở form chính
            using (var formDangNhap = new FormDangNhap())
            {
                if (formDangNhap.ShowDialog() != DialogResult.OK)
                    return;
            }

            Application.Run(new FormMain());
        }
    }
}