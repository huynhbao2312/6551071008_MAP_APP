using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Phong
{
    public partial class FormThemPhong : Form
    {
        public FormThemPhong()
        {
            InitializeComponent();
            Text = "Thêm mới phòng";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnThemMoi;
            CancelButton = btnThoat;
        }

        private void FormThemPhong_Load(object sender, EventArgs e)
        {
            txtMaPhong.MaxLength = 5;
            txtGhiChu.MaxLength = 100;
            cbTrangThaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTinhTrangDonDep.DropDownStyle = ComboBoxStyle.DropDownList;
            cbLoaiPhong.DropDownStyle = ComboBoxStyle.DropDownList;

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

            if (cbTrangThaiPhong.Items.Count > 0) cbTrangThaiPhong.SelectedIndex = 0;
            if (cbTinhTrangDonDep.Items.Count > 0) cbTinhTrangDonDep.SelectedIndex = 0;
            txtMaPhong.Focus();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string maPH = txtMaPhong.Text.Trim().ToUpper();
            string? maLPH = cbLoaiPhong.SelectedValue?.ToString();
            string trangThai = cbTrangThaiPhong.Text;
            string donDep = cbTinhTrangDonDep.Text;
            string ghiChu = txtGhiChu.Text.Trim();

            if (maPH.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập mã phòng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaPhong.Focus();
                return;
            }

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
                var tonTai = db.Phong.FirstOrDefault(p => p.MaPH == maPH);
                if (tonTai != null)
                {
                    if (tonTai.DaXoa != true)
                    {
                        MessageBox.Show("Mã phòng đã tồn tại. Vui lòng nhập mã khác.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMaPhong.Focus();
                        return;
                    }

                    var traLoi = MessageBox.Show(
                        $"Mã phòng {maPH} từng bị xóa trước đây.\nBạn có muốn khôi phục phòng này với thông tin vừa nhập không?",
                        "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (traLoi != DialogResult.Yes)
                        return;

                    tonTai.TTPH = trangThai;
                    tonTai.TTDD = donDep;
                    tonTai.GhiChu = ghiChu.Length == 0 ? null : ghiChu;
                    tonTai.MaLPH = maLPH;
                    tonTai.DaXoa = false;
                }
                else
                {
                    db.Phong.Add(new Models.Phong
                    {
                        MaPH = maPH,
                        TTPH = trangThai,
                        TTDD = donDep,
                        GhiChu = ghiChu.Length == 0 ? null : ghiChu,
                        MaLPH = maLPH,
                        DaXoa = false
                    });
                }

                int result = db.SaveChanges();
                if (result > 0)
                {
                    MessageBox.Show("Thêm phòng thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm phòng.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng: " + (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}