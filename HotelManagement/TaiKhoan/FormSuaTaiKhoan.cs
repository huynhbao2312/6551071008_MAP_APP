using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.TaiKhoan
{
    public partial class FormSuaTaiKhoan : Form
    {
        private string tenTK = string.Empty;

        public FormSuaTaiKhoan()
        {
            InitializeComponent();
        }

        public FormSuaTaiKhoan(string tenTK) : this()
        {
            this.tenTK = tenTK;
        }

        private void FormSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTenTK.MaxLength = 50;
            txtMatKhau.MaxLength = 100;
            txtMaNV.ReadOnly = true;
            cbCapDoQuyen.DropDownStyle = ComboBoxStyle.DropDownList;

            if (string.IsNullOrEmpty(tenTK))
            {
                MessageBox.Show("Không xác định được tài khoản cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            LoadThongTinTaiKhoan();
        }

        private void LoadThongTinTaiKhoan()
        {
            try
            {
                using var db = new HotelManagementContext();
                var taikhoan = db.TaiKhoan
                    .AsNoTracking()
                    .Where(t => t.TenTK == tenTK && t.DaXoa != true)
                    .Select(t => new
                    {
                        t.TenTK,
                        t.Password,
                        t.CapDoQuyen,
                        t.MaNV
                    })
                    .FirstOrDefault();

                if (taikhoan == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                tenTK = taikhoan.TenTK;
                txtTenTK.Text = taikhoan.TenTK;
                txtMatKhau.Text = taikhoan.Password;
                txtMaNV.Text = taikhoan.MaNV;

                string capDo = taikhoan.CapDoQuyen.ToString();
                int viTri = cbCapDoQuyen.FindStringExact(capDo);
                if (viTri < 0)
                {
                    viTri = cbCapDoQuyen.Items.Add(capDo);
                }
                cbCapDoQuyen.SelectedIndex = viTri;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tenTKMoi = txtTenTK.Text.Trim();
            string matKhau = txtMatKhau.Text;

            if (tenTKMoi == "" || matKhau == "" || cbCapDoQuyen.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cbCapDoQuyen.SelectedItem.ToString(), out int quyen))
            {
                MessageBox.Show("Cấp độ quyền không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using var db = new HotelManagementContext();
                if (db.TaiKhoan.Any(t => t.TenTK == tenTKMoi && t.TenTK != tenTK))
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTenTK.Focus();
                    return;
                }

                int kq = db.TaiKhoan
                    .Where(t => t.TenTK == tenTK && t.DaXoa != true)
                    .ExecuteUpdate(s => s
                        .SetProperty(t => t.TenTK, tenTKMoi)
                        .SetProperty(t => t.Password, matKhau)
                        .SetProperty(t => t.CapDoQuyen, quyen));

                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}