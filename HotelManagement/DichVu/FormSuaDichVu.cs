using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace HotelManagement.DichVu
{
    public partial class FormSuaDichVu : Form
    {
        private static readonly string[] LoaiMacDinh = { "Thức uống", "Đồ ăn", "Dịch vụ" };

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaDichVu { get; set; }

        public FormSuaDichVu()
        {
            InitializeComponent();
            Text = "Cập nhật thông tin dịch vụ";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnCapNhat;
            CancelButton = btnThoat;

            txtTenDV.MaxLength = 20;
            txtDonGia.MaxLength = 12;
            txtSoLuongConLai.MaxLength = 6;
            txtSoLuongConLai.PlaceholderText = "Để trống = không giới hạn";
            cbLoaiDV.DropDownStyle = ComboBoxStyle.DropDownList;
            Load += FormSuaDichVu_Load;
        }

        private void FormSuaDichVu_Load(object? sender, EventArgs e)
        {
            string? ma = MaDichVu;
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Chưa xác định được dịch vụ cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapNhat.Enabled = false;
                return;
            }

            Text = "Cập nhật dịch vụ " + ma;
            try
            {
                using var db = new HotelManagementContext();
                var dsLoai = new List<string>(LoaiMacDinh);
                var loaiTrongCsdl = db.DichVu
                    .AsNoTracking()
                    .Select(d => d.LoaiDV)
                    .Distinct()
                    .ToList();

                foreach (var loai in loaiTrongCsdl)
                {
                    string ten = (loai ?? "").Trim();
                    if (ten.Length > 0 && !dsLoai.Contains(ten, StringComparer.OrdinalIgnoreCase))
                        dsLoai.Add(ten);
                }

                cbLoaiDV.Items.Clear();
                cbLoaiDV.Items.AddRange(dsLoai.ToArray());

                var thongTin = db.DichVu
                    .AsNoTracking()
                    .Where(d => d.MaDV == ma && d.DaXoa != true)
                    .Select(d => new { d.TenDV, d.DonGia, d.SLConLai, d.LoaiDV })
                    .FirstOrDefault();

                if (thongTin == null)
                {
                    MessageBox.Show("Không tìm thấy dịch vụ " + ma + ".", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnCapNhat.Enabled = false;
                    return;
                }

                txtTenDV.Text = thongTin.TenDV;
                txtDonGia.Text = thongTin.DonGia.ToString("0");
                txtSoLuongConLai.Text = (thongTin.SLConLai == null || thongTin.SLConLai < 0)
                    ? ""
                    : thongTin.SLConLai.Value.ToString();
                cbLoaiDV.SelectedIndex = cbLoaiDV.FindStringExact((thongTin.LoaiDV ?? "").Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin dịch vụ: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCapNhat.Enabled = false;
            }
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoLuongConLai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string? ma = MaDichVu;
            if (string.IsNullOrEmpty(ma)) return;

            string tenDV = txtTenDV.Text.Trim();
            string donGiaText = txtDonGia.Text.Trim();
            string soLuongText = txtSoLuongConLai.Text.Trim();
            string loaiDV = cbLoaiDV.SelectedItem?.ToString()?.Trim() ?? "";

            if (tenDV.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập tên dịch vụ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDV.Focus();
                return;
            }
            if (loaiDV.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn loại dịch vụ.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbLoaiDV.Focus();
                return;
            }
            if (!decimal.TryParse(donGiaText, out decimal donGia) || donGia <= 0)
            {
                MessageBox.Show("Đơn giá không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Focus();
                return;
            }

            int? soLuongConLai = null;
            if (soLuongText.Length > 0)
            {
                if (!int.TryParse(soLuongText, out int sl) || sl < 0)
                {
                    MessageBox.Show("Số lượng còn lại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuongConLai.Focus();
                    return;
                }
                soLuongConLai = sl;
            }

            try
            {
                using var db = new HotelManagementContext();
                var dichVu = db.DichVu.FirstOrDefault(d => d.MaDV == ma && d.DaXoa != true);
                if (dichVu == null)
                {
                    MessageBox.Show("Không tìm thấy dịch vụ cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dichVu.TenDV = tenDV;
                dichVu.DonGia = donGia;
                dichVu.SLConLai = soLuongConLai;
                dichVu.LoaiDV = loaiDV;

                int rows = db.SaveChanges();
                if (rows > 0)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Thông tin không thay đổi nên không có gì để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}