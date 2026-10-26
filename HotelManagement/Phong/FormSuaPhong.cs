using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Phong
{
    public partial class FormSuaPhong : Form
    {
        private string? maPhong;

        public FormSuaPhong()
        {
            InitializeComponent();
            Text = "Cập nhật thông tin phòng";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnCapNhat;
            CancelButton = btnThoat;
            txtGhiChu.MaxLength = 100;
            cbTrangThaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTinhTrangDonDep.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public FormSuaPhong(string maPhong) : this()
        {
            this.maPhong = maPhong;
            Text = $"Cập nhật phòng {maPhong}";
            label5.Text = $"Cập nhật thông tin phòng {maPhong}";
            LoadLoaiPhong();
            LoadThongTinPhong();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Chưa xác định được phòng cần cập nhật.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string trangThai = cbTrangThaiPhong.Text;
            string donDep = cbTinhTrangDonDep.Text;
            string? maLPH = cbLoaiPhong.SelectedValue?.ToString();
            string ghiChu = txtGhiChu.Text.Trim();

            if (string.IsNullOrEmpty(maLPH))
            {
                MessageBox.Show("Vui lòng chọn loại phòng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLoaiPhong.Focus();
                return;
            }

            if (trangThai.Length == 0 || donDep.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn trạng thái phòng và tình trạng dọn dẹp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new HotelManagementContext();
                var phong = db.Phong.FirstOrDefault(p => p.MaPH == maPhong && p.DaXoa != true);
                if (phong == null)
                {
                    MessageBox.Show("Không tìm thấy phòng cần cập nhật (có thể đã bị xóa).", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                phong.TTPH = trangThai;
                phong.TTDD = donDep;
                phong.MaLPH = maLPH;
                phong.GhiChu = ghiChu.Length == 0 ? null : ghiChu;

                int rows = db.SaveChanges();
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Thông tin không thay đổi nên không có gì để cập nhật.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phòng: " + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadLoaiPhong()
        {
            try
            {
                using var db = new HotelManagementContext();
                var dsLoaiPhong = db.LoaiPhong
                    .AsNoTracking()
                    .OrderBy(l => l.MaLPH)
                    .Select(l => new { l.MaLPH, l.TenLPH })
                    .ToList();

                cbLoaiPhong.DisplayMember = "TenLPH";
                cbLoaiPhong.ValueMember = "MaLPH";
                cbLoaiPhong.DataSource = dsLoaiPhong;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách loại phòng: " + ex.Message);
            }
        }

        private void LoadThongTinPhong()
        {
            try
            {
                using var db = new HotelManagementContext();
                var thongTin = db.Phong
                    .AsNoTracking()
                    .Where(p => p.MaPH == maPhong && p.DaXoa != true)
                    .Select(p => new { p.TTPH, p.TTDD, p.MaLPH, p.GhiChu })
                    .FirstOrDefault();

                if (thongTin == null)
                {
                    MessageBox.Show("Không tìm thấy phòng " + maPhong + ".", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCapNhat.Enabled = false;
                    return;
                }

                cbTrangThaiPhong.SelectedIndex = cbTrangThaiPhong.FindStringExact(thongTin.TTPH);
                cbTinhTrangDonDep.SelectedIndex = cbTinhTrangDonDep.FindStringExact(thongTin.TTDD);
                cbLoaiPhong.SelectedValue = thongTin.MaLPH;
                txtGhiChu.Text = thongTin.GhiChu ?? "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin phòng: " + ex.Message);
                btnCapNhat.Enabled = false;
            }
        }
    }
}