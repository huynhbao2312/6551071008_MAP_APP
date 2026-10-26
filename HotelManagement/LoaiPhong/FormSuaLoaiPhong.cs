using HotelManagement.Models;

namespace HotelManagement.LoaiPhong
{
    public partial class FormSuaLoaiPhong : Form
    {
        private string? _maLPH;

        public FormSuaLoaiPhong()
        {
            InitializeComponent();
        }

        public FormSuaLoaiPhong(string maLPH) : this()
        {
            _maLPH = maLPH;
            LoadThongTinLoaiPhong();
        }

        private void LoadThongTinLoaiPhong()
        {
            try
            {
                using var db = new HotelManagementContext();
                var lp = db.LoaiPhong.FirstOrDefault(l => l.MaLPH == _maLPH);
                if (lp == null)
                {
                    MessageBox.Show("Không tìm thấy loại phòng!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                txtMaLPH.Text = lp.MaLPH;
                txtTenLPH.Text = lp.TenLPH;
                nudSoGiuong.Value = lp.SoGiuong;
                nudSoNguoiToiDa.Value = lp.SoNguoiToiDa;
                txtGiaNgay.Text = lp.GiaNgay.ToString("0.##");
                txtGiaGio.Text = lp.GiaGio.ToString("0.##");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin loại phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string tenLPH = txtTenLPH.Text.Trim();
            if (string.IsNullOrEmpty(tenLPH))
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLPH.Focus();
                return;
            }

            if (!decimal.TryParse(txtGiaNgay.Text.Trim(), out decimal giaNgay) || giaNgay < 0)
            {
                MessageBox.Show("Giá ngày không hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaNgay.Focus();
                return;
            }

            if (!decimal.TryParse(txtGiaGio.Text.Trim(), out decimal giaGio) || giaGio < 0)
            {
                MessageBox.Show("Giá giờ không hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGiaGio.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();
                var lp = db.LoaiPhong.FirstOrDefault(l => l.MaLPH == _maLPH);
                if (lp == null)
                {
                    MessageBox.Show("Loại phòng không tồn tại.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                lp.TenLPH = tenLPH;
                lp.SoGiuong = (int)nudSoGiuong.Value;
                lp.SoNguoiToiDa = (int)nudSoNguoiToiDa.Value;
                lp.GiaNgay = giaNgay;
                lp.GiaGio = giaGio;

                db.SaveChanges();
                MessageBox.Show("Cập nhật loại phòng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu loại phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}