using System.Globalization;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.ThongKe
{
    public partial class FormThongKe : Form
    {
        private readonly CultureInfo viVN = new CultureInfo("vi-VN");

        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            // Thiết lập mặc định lọc từ đầu tháng hiện tại đến hôm nay
            DateTime now = DateTime.Today;
            dtpTuNgay.Value = new DateTime(now.Year, now.Month, 1);
            dtpDenNgay.Value = now;

            NapDuLieuThongKe();
        }

        private void btnXemThongKe_Click(object sender, EventArgs e)
        {
            if (dtpTuNgay.Value.Date > dtpDenNgay.Value.Date)
            {
                MessageBox.Show("Từ ngày không thể lớn hơn đến ngày!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NapDuLieuThongKe();
        }

        private void NapDuLieuThongKe()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1); // Lấy hết ngày

            try
            {
                using var db = new HotelManagementContext();

                // 1. Thống kê theo Chi tiết phiếu thuê (CTDP) trong khoảng thời gian đã chọn
                var danhSachCTDP = db.CTDP
                    .AsNoTracking()
                    .Where(c => c.DaXoa != true && c.CheckIn >= tuNgay && c.CheckIn < denNgay)
                    .Select(c => new
                    {
                        c.MaCTDP,
                        c.MaPH,
                        TenLPH = c.MaPHNavigation.MaLPHNavigation.TenLPH,
                        ThanhTien = c.ThanhTien ?? 0m
                    })
                    .ToList();

                // 2. Thống kê theo Dịch vụ (CTDV) đã dùng trong các chi tiết thuê trên
                var danhSachCTDV = db.CTDV
                    .AsNoTracking()
                    .Where(v => v.DaXoa != true && db.CTDP.Any(c => c.MaCTDP == v.MaCTDP && c.DaXoa != true && c.CheckIn >= tuNgay && c.CheckIn < denNgay))
                    .Select(v => new
                    {
                        v.MaDV,
                        TenDV = v.MaDVNavigation.TenDV,
                        SL = v.SL,
                        ThanhTien = v.ThanhTien ?? (v.SL * v.MaDVNavigation.DonGia)
                    })
                    .ToList();

                // --- A. CÁC THẺ TỔNG QUAN (KPIs) ---
                decimal tongTienPhong = danhSachCTDP.Sum(c => c.ThanhTien);
                decimal tongTienDichVu = danhSachCTDV.Sum(v => v.ThanhTien);
                int tongSoPhongDat = danhSachCTDP.Count;

                lbTienPhong.Text = tongTienPhong.ToString("N0", viVN) + " VND";
                lbTienDichVu.Text = tongTienDichVu.ToString("N0", viVN) + " VND";
                lbSoPhongDat.Text = tongSoPhongDat.ToString();

                // --- B. CÁC THẺ XẾP HẠNG TOP ---
                // Top loại phòng doanh thu cao nhất
                var topLoaiPhongDoanhThu = danhSachCTDP
                    .GroupBy(c => c.TenLPH)
                    .Select(g => new { TenLPH = g.Key, DoanhThu = g.Sum(x => x.ThanhTien) })
                    .OrderByDescending(x => x.DoanhThu)
                    .FirstOrDefault();

                lbTopLoaiPhongDoanhThu.Text = topLoaiPhongDoanhThu != null
                    ? $"{topLoaiPhongDoanhThu.TenLPH} ({topLoaiPhongDoanhThu.DoanhThu.ToString("N0", viVN)} VND)"
                    : "Chưa có";

                // Top loại phòng được đặt nhiều nhất
                var topLoaiPhongDatNhieu = danhSachCTDP
                    .GroupBy(c => c.TenLPH)
                    .Select(g => new { TenLPH = g.Key, SoLuot = g.Count() })
                    .OrderByDescending(x => x.SoLuot)
                    .FirstOrDefault();

                lbTopLoaiPhongDatNhieu.Text = topLoaiPhongDatNhieu != null
                    ? $"{topLoaiPhongDatNhieu.TenLPH} ({topLoaiPhongDatNhieu.SoLuot} lượt)"
                    : "Chưa có";

                // Top dịch vụ doanh thu cao nhất
                var topDichVu = danhSachCTDV
                    .GroupBy(v => v.TenDV)
                    .Select(g => new { TenDV = g.Key, DoanhThu = g.Sum(x => x.ThanhTien) })
                    .OrderByDescending(x => x.DoanhThu)
                    .FirstOrDefault();

                lbTopDichVu.Text = topDichVu != null
                    ? $"{topDichVu.TenDV} ({topDichVu.DoanhThu.ToString("N0", viVN)} VND)"
                    : "Chưa có";

                // --- C. VẼ CÁC BIỂU ĐỒ (CHARTS) ---
                // 1. Biểu đồ cột Doanh thu theo loại phòng
                chartDoanhThuPhong.Series[0].Points.Clear();
                var nhomDoanhThuLoaiPhong = danhSachCTDP
                    .GroupBy(c => c.TenLPH)
                    .Select(g => new { TenLPH = g.Key, DoanhThu = g.Sum(x => x.ThanhTien) })
                    .ToList();

                foreach (var item in nhomDoanhThuLoaiPhong)
                {
                    chartDoanhThuPhong.Series[0].Points.AddXY(item.TenLPH, item.DoanhThu);
                }

                // 2. Biểu đồ tròn Các dịch vụ được sử dụng
                chartDichVu.Series[0].Points.Clear();
                var nhomDichVu = danhSachCTDV
                    .GroupBy(v => v.TenDV)
                    .Select(g => new { TenDV = g.Key, TongSL = g.Sum(x => x.SL) })
                    .ToList();

                foreach (var item in nhomDichVu)
                {
                    int ptIndex = chartDichVu.Series[0].Points.AddXY(item.TenDV, item.TongSL);
                    chartDichVu.Series[0].Points[ptIndex].LegendText = item.TenDV;
                }

                // 3. Biểu đồ cột Số phòng được đặt theo từng loại
                chartSoPhongDat.Series[0].Points.Clear();
                var nhomSoLuongLoaiPhong = danhSachCTDP
                    .GroupBy(c => c.TenLPH)
                    .Select(g => new { TenLPH = g.Key, SoLuong = g.Count() })
                    .ToList();

                foreach (var item in nhomSoLuongLoaiPhong)
                {
                    chartSoPhongDat.Series[0].Points.AddXY(item.TenLPH, item.SoLuong);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}