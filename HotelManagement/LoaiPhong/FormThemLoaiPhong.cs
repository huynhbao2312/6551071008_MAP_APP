using HotelManagement.Models;

namespace HotelManagement.LoaiPhong
{
    public partial class FormThemLoaiPhong : Form
    {
        public FormThemLoaiPhong()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLPH = txtMaLPH.Text.Trim().ToUpper();
            string tenLPH = txtTenLPH.Text.Trim();

            if (string.IsNullOrEmpty(maLPH))
            {
                MessageBox.Show("Vui lòng nhập mã loại phòng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLPH.Focus();
                return;
            }

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
                if (db.LoaiPhong.Any(l => l.MaLPH == maLPH))
                {
                    MessageBox.Show("Mã loại phòng đã tồn tại. Vui lòng nhập mã khác.", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLPH.Focus();
                    return;
                }

                var moi = new Models.LoaiPhong
                {
                    MaLPH = maLPH,
                    TenLPH = tenLPH,
                    SoGiuong = (int)nudSoGiuong.Value,
                    SoNguoiToiDa = (int)nudSoNguoiToiDa.Value,
                    GiaNgay = giaNgay,
                    GiaGio = giaGio
                };

                db.LoaiPhong.Add(moi);
                db.SaveChanges();

                MessageBox.Show("Thêm loại phòng thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm loại phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}