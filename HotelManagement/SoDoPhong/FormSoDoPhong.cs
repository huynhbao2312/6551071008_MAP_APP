using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.SoDoPhong
{
    public partial class FormSoDoPhong : Form
    {
        private bool _dangkhoiTao;

        public FormSoDoPhong()
        {
            InitializeComponent();
        }

        private void FormSoDoPhong_Load(object sender, EventArgs e)
        {
            _dangkhoiTao = true;

            rdbTatCaTrangThaiPhong.Checked = true;
            rdbTatCaLoaiPhong.Checked = true;
            rdbTatCaPhong.Checked = true;

            dtNgayChon.ShowCheckBox = true;
            dtNgayChon.Checked = false;

            toolTip1.SetToolTip(txtSearchMaPhong, "Ví dụ: 101, P20...");

            dataGridViewPhong.ReadOnly = true;
            dataGridViewPhong.AllowUserToAddRows = false;
            dataGridViewPhong.AllowUserToDeleteRows = false;
            dataGridViewPhong.MultiSelect = false;
            dataGridViewPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            _dangkhoiTao = false;
            TaiLaiDanhSach();
        }

        private void LocTheoRadio(object sender)
        {
            if (_dangkhoiTao) return;
            if (sender is RadioButton rdb && !rdb.Checked) return;
            TaiLaiDanhSach();
        }

        private void rdbPhongChuaDon_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongDaDonDep_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbTatCaLoaiPhong_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongVipDoi_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongVipDon_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongThuongDoi_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongThuongDon_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbTatCaTrangThaiPhong_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongDangSuaChua_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongDangThue_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongDaDat_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);
        private void rdbPhongTrong_CheckedChanged(object sender, EventArgs e) => LocTheoRadio(sender);

        private void txtSearchMaPhong_TextChanged(object sender, EventArgs e)
        {
            if (_dangkhoiTao) return;
            TaiLaiDanhSach();
        }

        private void dtNgayChon_ValueChanged(object sender, EventArgs e)
        {
            if (_dangkhoiTao) return;
            TaiLaiDanhSach();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            string? maPhong = MaPhongDangChon();
            MessageBox.Show(
                "Chức năng đặt phòng đang được xây dựng."
                + (maPhong != null ? Environment.NewLine + "Phòng đang chọn: " + maPhong : ""),
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string? TrangThaiPhongDangChon()
        {
            if (rdbPhongTrong.Checked) return "Bình thường";
            if (rdbPhongDaDat.Checked) return "Đã đặt";
            if (rdbPhongDangThue.Checked) return "Đang thuê";
            if (rdbPhongDangSuaChua.Checked) return "Đang sửa chữa";
            return null;
        }

        private string? MaLoaiPhongDangChon()
        {
            if (rdbPhongThuongDon.Checked) return "NOR01";
            if (rdbPhongThuongDoi.Checked) return "NOR02";
            if (rdbPhongVipDon.Checked) return "VIP01";
            if (rdbPhongVipDoi.Checked) return "VIP02";
            return null;
        }

        private string? TinhTrangDonDepDangChon()
        {
            if (rdbPhongDaDonDep.Checked) return "Đã dọn dẹp";
            if (rdbPhongChuaDon.Checked) return "Chưa dọn dẹp";
            return null;
        }

        private string? MaPhongDangChon()
        {
            return dataGridViewPhong.CurrentRow?.Cells["MaPH"].Value?.ToString();
        }

        private void TaiLaiDanhSach()
        {
            try
            {
                string? ttph = TrangThaiPhongDangChon();
                string? malph = MaLoaiPhongDangChon();
                string? ttdd = TinhTrangDonDepDangChon();
                string maPhong = txtSearchMaPhong.Text.Trim();

                using var db = new HotelManagementContext();

                var query = db.Phong.AsNoTracking().Where(p => p.DaXoa != true);

                if (ttph != null) query = query.Where(p => p.TTPH == ttph);
                if (malph != null) query = query.Where(p => p.MaLPH == malph);
                if (ttdd != null) query = query.Where(p => p.TTDD == ttdd);
                if (maPhong.Length > 0) query = query.Where(p => p.MaPH.Contains(maPhong));

                if (dtNgayChon.Checked)
                {
                    DateTime ngayChon = dtNgayChon.Value.Date;
                    query = query.Where(p =>
                        p.TTPH == "Bình thường"
                        && !p.CTDP.Any(c =>
                            c.DaXoa != true
                            && ngayChon >= c.CheckIn.Date
                            && ngayChon < c.CheckOut.Date));
                }

                var dsPhong = query
                    .OrderBy(p => p.MaPH)
                    .Select(p => new
                    {
                        p.MaPH,
                        TenLph = p.MaLPHNavigation.TenLPH,
                        p.TTPH,
                        p.TTDD,
                        p.GhiChu
                    })
                    .ToList();

                dataGridViewPhong.DataSource = dsPhong
                    .Select(p => new
                    {
                        MaPH = p.MaPH,
                        Tang = p.MaPH.Length > 1 ? p.MaPH.Substring(1, 1) : "",
                        TenLPH = p.TenLph,
                        TTPH = p.TTPH,
                        TTDD = p.TTDD,
                        GhiChu = p.GhiChu
                    })
                    .ToList();

                DatTieuDeCot("MaPH", "Mã phòng");
                DatTieuDeCot("Tang", "Tầng");
                DatTieuDeCot("TenLPH", "Loại phòng");
                DatTieuDeCot("TTPH", "Trạng thái phòng");
                DatTieuDeCot("TTDD", "Tình trạng dọn dẹp");
                DatTieuDeCot("GhiChu", "Ghi chú");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message);
            }
        }

        private void DatTieuDeCot(string tenCot, string tieuDe)
        {
            if (dataGridViewPhong.Columns.Contains(tenCot))
            {
                dataGridViewPhong.Columns[tenCot].HeaderText = tieuDe;
            }
        }
    }
}