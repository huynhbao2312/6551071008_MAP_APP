using ClosedXML.Excel;
using HotelManagement.ChiTietTienNghi;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.LoaiPhong
{
    public partial class FormDanhSachLoaiPhong : Form
    {
        private readonly Image _iconGiuong = Properties.Resources.Giuong;
        private readonly Image _iconTienNghi = Properties.Resources.details;
        private readonly Image _iconSua = Properties.Resources.edit;
        private readonly Image _iconXoa = Properties.Resources.delete;

        public FormDanhSachLoaiPhong()
        {
            InitializeComponent();
            Load += FormDanhSachLoaiPhong_Load;
        }

        private void FormDanhSachLoaiPhong_Load(object? sender, EventArgs e)
        {
            CauHinhLuoi();
            LoadLoaiPhong();
        }

        private void txtTimKiem_TextChanged(object? sender, EventArgs e)
        {
            LocTheoTuKhoa();
        }

        private void btnThemMoiLoaiPhong_Click(object sender, EventArgs e)
        {
            using (var formThemLoaiPhong = new FormThemLoaiPhong())
            {
                if (formThemLoaiPhong.ShowDialog() == DialogResult.OK)
                {
                    LoadLoaiPhong();
                }
            }
        }

        private void dtgDanhSachLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var dong = dtgDanhSachLoaiPhong.Rows[e.RowIndex];
            string? maLPH = dong.Cells["MaLPH"].Value?.ToString();
            string? tenLPH = dong.Cells["TenLPH"].Value?.ToString();
            if (string.IsNullOrEmpty(maLPH)) return;

            string tenCot = dtgDanhSachLoaiPhong.Columns[e.ColumnIndex].Name;

            if (tenCot == "colTienNghi")
            {
                using (var formTienNghi = new FormDanhSachChiTietTienNghi(maLPH, tenLPH ?? ""))
                {
                    formTienNghi.ShowDialog();
                }
            }
            else if (tenCot == "colSua")
            {
                using (var formSua = new FormSuaLoaiPhong(maLPH))
                {
                    if (formSua.ShowDialog() == DialogResult.OK)
                    {
                        LoadLoaiPhong();
                    }
                }
            }
            else if (tenCot == "colXoa")
            {
                DialogResult hoi = MessageBox.Show(
                    $"Bạn có chắc muốn xóa loại phòng {tenLPH} ({maLPH})?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (hoi == DialogResult.Yes)
                {
                    XoaLoaiPhong(maLPH);
                    LoadLoaiPhong();
                }
            }
        }

        private void CauHinhLuoi()
        {
            if (dtgDanhSachLoaiPhong.Columns.Count > 0) return;

            dtgDanhSachLoaiPhong.ReadOnly = true;
            dtgDanhSachLoaiPhong.AllowUserToAddRows = false;
            dtgDanhSachLoaiPhong.AllowUserToDeleteRows = false;
            dtgDanhSachLoaiPhong.AllowUserToResizeRows = false;
            dtgDanhSachLoaiPhong.MultiSelect = false;
            dtgDanhSachLoaiPhong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDanhSachLoaiPhong.RowHeadersVisible = false;
            dtgDanhSachLoaiPhong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgDanhSachLoaiPhong.RowTemplate.Height = 40;

            dtgDanhSachLoaiPhong.Columns.Add(TaoCotAnh("colIcon", "", _iconGiuong, 50));
            dtgDanhSachLoaiPhong.Columns.Add("MaLPH", "Mã loại");
            dtgDanhSachLoaiPhong.Columns.Add("TenLPH", "Tên loại");
            dtgDanhSachLoaiPhong.Columns.Add("SoGiuong", "Số giường");
            dtgDanhSachLoaiPhong.Columns.Add("SoNguoiToiDa", "Số người tối đa");
            dtgDanhSachLoaiPhong.Columns.Add("GiaNgay", "Giá ngày");
            dtgDanhSachLoaiPhong.Columns.Add("GiaGio", "Giá giờ");

            dtgDanhSachLoaiPhong.Columns["GiaNgay"]!.DefaultCellStyle.Format = "N0";
            dtgDanhSachLoaiPhong.Columns["GiaGio"]!.DefaultCellStyle.Format = "N0";
            dtgDanhSachLoaiPhong.Columns["GiaNgay"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtgDanhSachLoaiPhong.Columns["GiaGio"]!.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtgDanhSachLoaiPhong.Columns.Add(TaoCotAnh("colTienNghi", "Tiện nghi", _iconTienNghi, 60));
            dtgDanhSachLoaiPhong.Columns.Add(TaoCotAnh("colSua", "Sửa", _iconSua, 50));
            dtgDanhSachLoaiPhong.Columns.Add(TaoCotAnh("colXoa", "Xóa", _iconXoa, 50));
        }

        private DataGridViewImageColumn TaoCotAnh(string ten, string tieuDe, Image anh, int doRong)
        {
            return new DataGridViewImageColumn
            {
                Name = ten,
                HeaderText = tieuDe,
                Image = anh,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = doRong,
                Resizable = DataGridViewTriState.False,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };
        }

        private void LoadLoaiPhong()
        {
            try
            {
                using var db = new HotelManagementContext();
                var dsLoaiPhong = db.LoaiPhong
                    .AsNoTracking()
                    .OrderBy(l => l.MaLPH)
                    .Select(l => new
                    {
                        l.MaLPH,
                        l.TenLPH,
                        l.SoGiuong,
                        l.SoNguoiToiDa,
                        l.GiaNgay,
                        l.GiaGio
                    })
                    .ToList();

                dtgDanhSachLoaiPhong.Rows.Clear();
                foreach (var l in dsLoaiPhong)
                {
                    dtgDanhSachLoaiPhong.Rows.Add(
                        _iconGiuong,
                        l.MaLPH,
                        l.TenLPH,
                        l.SoGiuong,
                        l.SoNguoiToiDa,
                        l.GiaNgay,
                        l.GiaGio,
                        _iconTienNghi,
                        _iconSua,
                        _iconXoa
                    );
                }
                LocTheoTuKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải loại phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LocTheoTuKhoa()
        {
            string keyword = txtTimKiem.Text.Trim();
            dtgDanhSachLoaiPhong.CurrentCell = null;
            foreach (DataGridViewRow row in dtgDanhSachLoaiPhong.Rows)
            {
                string ma = row.Cells["MaLPH"].Value?.ToString() ?? "";
                string ten = row.Cells["TenLPH"].Value?.ToString() ?? "";
                row.Visible = keyword.Length == 0
                    || ma.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                    || ten.Contains(keyword, StringComparison.OrdinalIgnoreCase);
            }
        }

        private void XoaLoaiPhong(string maLPH)
        {
            try
            {
                using var db = new HotelManagementContext();
                bool coPhong = db.Phong.Any(p => p.MaLPH == maLPH && p.DaXoa != true);
                if (coPhong)
                {
                    MessageBox.Show("Loại phòng này đang có phòng trực thuộc, không thể xóa!",
                        "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lp = db.LoaiPhong.FirstOrDefault(l => l.MaLPH == maLPH);
                if (lp != null)
                {
                    db.LoaiPhong.Remove(lp);
                    db.SaveChanges();
                    MessageBox.Show("Đã xóa loại phòng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa loại phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}