using System.ComponentModel;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.PhieuThue
{
    public partial class FormThemDichVuPhongDaDung : Form
    {
        private sealed class MucDichVu
        {
            public string MaDV { get; set; } = "";
            public string TenDV { get; set; } = "";
            public decimal DonGia { get; set; }
            public int? SLConLai { get; set; }
        }

        private List<MucDichVu> _danhSachDichVu = new List<MucDichVu>();
        private bool _dangNapDuLieu;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaChiTietDatPhong { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? MaPhong { get; set; }

        public FormThemDichVuPhongDaDung()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            AcceptButton = btnThemDV;
            CancelButton = btnThoat;

            cbTenDV.DropDownStyle = ComboBoxStyle.DropDownList;
            txtSoLuong.MaxLength = 6;
            txtSoLuong.KeyPress += txtSoLuong_KeyPress;
        }

        private void FormThemDichVuPhongDaDung_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MaChiTietDatPhong) || string.IsNullOrEmpty(MaPhong))
            {
                MessageBox.Show("Chưa xác định được chi tiết phiếu thuê cần thêm dịch vụ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnThemDV.Enabled = false;
                return;
            }

            lbSoCTPhieu.Text = "Mã CTDP: " + MaChiTietDatPhong;
            lbSoPhong.Text = "Số phòng: " + MaPhong;
            lbThanhTien.Text = "Thành tiền: 0";

            try
            {
                _dangNapDuLieu = true;
                using var db = new HotelManagementContext();
                _danhSachDichVu = db.DichVu
                    .AsNoTracking()
                    .Where(d => d.DaXoa != true)
                    .OrderBy(d => d.TenDV)
                    .Select(d => new MucDichVu
                    {
                        MaDV = d.MaDV,
                        TenDV = d.TenDV,
                        DonGia = d.DonGia,
                        SLConLai = d.SLConLai
                    })
                    .ToList();

                cbTenDV.DisplayMember = "TenDV";
                cbTenDV.ValueMember = "MaDV";
                cbTenDV.DataSource = _danhSachDichVu;
                cbTenDV.SelectedIndex = -1;
                _dangNapDuLieu = false;
                txtMaDV.Text = "";
                txtDonGia.Text = "";
            }
            catch (Exception ex)
            {
                _dangNapDuLieu = false;
                MessageBox.Show("Lỗi tải danh sách dịch vụ: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnThemDV.Enabled = false;
            }
        }

        private MucDichVu? LayDichVuDangChon()
        {
            return cbTenDV.SelectedItem as MucDichVu;
        }

        private void cbTenDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_dangNapDuLieu)
                return;

            var dv = LayDichVuDangChon();
            if (dv == null)
            {
                txtMaDV.Text = "";
                txtDonGia.Text = "";
            }
            else
            {
                txtMaDV.Text = dv.MaDV;
                txtDonGia.Text = dv.DonGia.ToString("N0");
            }
            TinhThanhTien();
        }

        private void txtSoLuong_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTien();
        }

        private void TinhThanhTien()
        {
            var dv = LayDichVuDangChon();
            if (dv != null && int.TryParse(txtSoLuong.Text, out int soLuong) && soLuong > 0)
            {
                decimal thanhTien = soLuong * dv.DonGia;
                lbThanhTien.Text = "Thành tiền: " + thanhTien.ToString("N0") + " VND";
            }
            else
            {
                lbThanhTien.Text = "Thành tiền: 0 VND";
            }
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            string? maCTDP = MaChiTietDatPhong;
            if (string.IsNullOrEmpty(maCTDP))
            {
                MessageBox.Show("Chưa xác định được chi tiết phiếu thuê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dichVuChon = LayDichVuDangChon();
            if (dichVuChon == null)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTenDV.Focus();
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
                return;
            }

            string maDV = dichVuChon.MaDV;
            try
            {
                using var db = new HotelManagementContext();
                var chiTietPhong = db.CTDP
                    .AsNoTracking()
                    .Where(c => c.MaCTDP == maCTDP && c.DaXoa != true)
                    .Select(c => new { c.TrangThai })
                    .FirstOrDefault();

                if (chiTietPhong == null)
                {
                    MessageBox.Show("Không tìm thấy chi tiết phiếu thuê " + maCTDP + ".", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (chiTietPhong.TrangThai != "Đang thuê")
                {
                    MessageBox.Show("Chỉ có thể thêm dịch vụ cho phòng đang thuê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dichVu = db.DichVu.FirstOrDefault(d => d.MaDV == maDV && d.DaXoa != true);
                if (dichVu == null)
                {
                    MessageBox.Show("Dịch vụ không còn tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool gioiHanSoLuong = dichVu.SLConLai.HasValue && dichVu.SLConLai.Value >= 0;
                if (gioiHanSoLuong && soLuong > dichVu.SLConLai!.Value)
                {
                    MessageBox.Show($"Dịch vụ \"{dichVu.TenDV}\" chỉ còn {dichVu.SLConLai.Value} phần.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSoLuong.Focus();
                    return;
                }

                var daCo = db.CTDV.FirstOrDefault(v => v.MaCTDP == maCTDP && v.MaDV == maDV);
                if (daCo == null)
                {
                    db.CTDV.Add(new CTDV
                    {
                        MaCTDP = maCTDP,
                        MaDV = maDV,
                        SL = soLuong,
                        ThanhTien = soLuong * dichVu.DonGia,
                        DaXoa = false
                    });
                }
                else if (daCo.DaXoa == true)
                {
                    daCo.SL = soLuong;
                    daCo.ThanhTien = soLuong * dichVu.DonGia;
                    daCo.DaXoa = false;
                }
                else
                {
                    daCo.SL += soLuong;
                    daCo.ThanhTien = daCo.SL * dichVu.DonGia;
                }

                if (gioiHanSoLuong)
                {
                    dichVu.SLConLai = dichVu.SLConLai!.Value - soLuong;
                }

                db.SaveChanges();
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Thêm thất bại: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}