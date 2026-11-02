using HotelManagement.Models;

namespace HotelManagement.TienNghi
{
    public partial class FormSuaTienNghi : Form
    {
        private string maTN = string.Empty;

        public FormSuaTienNghi()
        {
            InitializeComponent();
        }

        public FormSuaTienNghi(string maTN) : this()
        {
            this.maTN = maTN;
        }

        private void FormSuaTienNghi_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maTN))
            {
                MessageBox.Show("Không xác định được tiện nghi cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();
                var tienNghi = db.TienNghi
                    .Where(t => t.MaTN == maTN && t.DaXoa != true)
                    .Select(t => new { t.TenTN })
                    .FirstOrDefault();

                if (tienNghi == null)
                {
                    MessageBox.Show("Không tìm thấy tiện nghi cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtTenTN.Text = tienNghi.TenTN;
                txtTenTN.Focus();
                txtTenTN.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load tiện nghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string tenTN = txtTenTN.Text.Trim();
            if (string.IsNullOrEmpty(tenTN))
            {
                MessageBox.Show("Vui lòng nhập tên tiện nghi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTN.Focus();
                return;
            }
            if (tenTN.Length > 50)
            {
                MessageBox.Show("Tên tiện nghi tối đa 50 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTN.Focus();
                return;
            }

            try
            {
                using var db = new HotelManagementContext();
                var tienNghi = db.TienNghi.FirstOrDefault(t => t.MaTN == maTN && t.DaXoa != true);
                if (tienNghi == null)
                {
                    MessageBox.Show("Không tìm thấy tiện nghi cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (db.TienNghi.Any(t => t.MaTN != maTN && t.DaXoa != true && t.TenTN == tenTN))
                {
                    MessageBox.Show("Tên tiện nghi đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenTN.Focus();
                    return;
                }

                tienNghi.TenTN = tenTN;
                int kq = db.SaveChanges();
                if (kq > 0)
                {
                    MessageBox.Show("Cập nhật tiện nghi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Không có thay đổi nào để cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật tiện nghi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}