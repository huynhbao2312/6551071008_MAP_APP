using HotelManagement.DangNhap;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace HotelManagement.SoDoPhong
{
    public partial class FormDatPhong : Form
    {
        private readonly Image _iconThem = Properties.Resources.Add;
        private readonly Image _iconHuy = Properties.Resources.delete;
        private bool _dangKhoiTao;

        public FormDatPhong()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            CancelButton = button2;

            txtHoVaTen.MaxLength = 50;
            txtCCCD.MaxLength = 12;
            txtSoDienThoai.MaxLength = 10;
            txtQuocTich.MaxLength = 30;
            cbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioDen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGioDi.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDangGioDen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDangGioDi.DropDownStyle = ComboBoxStyle.DropDownList;

            txtSoDienThoai.KeyPress += txtSoDienThoai_KeyPress;
            txtCCCD.TextChanged += txtCCCD_TextChanged;
            dtpNgayBD.ValueChanged += dtpNgayBD_ValueChanged;
            dtpNgayKT.ValueChanged += ThayDoiThoiGian;
            cbGioDen.SelectedIndexChanged += ThayDoiThoiGian;
            cbDangGioDen.SelectedIndexChanged += ThayDoiThoiGian;
            cbGioDi.SelectedIndexChanged += ThayDoiThoiGian;
            cbDangGioDi.SelectedIndexChanged += ThayDoiThoiGian;
            button2.Click += button2_Click;
        }

        private void FormDatPhong_Load(object sender, EventArgs e)
        {
            _dangKhoiTao = true;
            dtpNgayBD.MinDate = DateTime.Today;
            CapNhatNgayKetThucToiThieu();

            cbGioDen.SelectedIndex = cbGioDen.FindStringExact("02:00");
            cbDangGioDen.SelectedIndex = cbDangGioDen.FindStringExact("PM");
            cbGioDi.SelectedIndex = cbGioDi.FindStringExact("12:00");
            cbDangGioDi.SelectedIndex = cbDangGioDi.FindStringExact("PM");

            KhoiTaoGridPhongTrong();
            KhoiTaoGridPhongDaChon();
            _dangKhoiTao = false;
            LoadDanhSachPhongTrong();
        }

        private void KhoiTaoGridPhongTrong()
        {
            if (dtgDanhSachPhongTrong.Columns.Count > 0)
                return;

            dtgDanhSachPhongTrong.ReadOnly = true;
            dtgDanhSachPhongTrong.AllowUserToAddRows = false;
            dtgDanhSachPhongTrong.AllowUserToDeleteRows = false;
            dtgDanhSachPhongTrong.AllowUserToResizeRows = false;
            dtgDanhSachPhongTrong.MultiSelect = false;
            dtgDanhSachPhongTrong.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDanhSachPhongTrong.RowHeadersVisible = false;
            dtgDanhSachPhongTrong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgDanhSachPhongTrong.RowTemplate.Height = 32;

            dtgDanhSachPhongTrong.Columns.Add("MaPH", "Mã phòng");
            dtgDanhSachPhongTrong.Columns.Add("TenLPH", "Loại phòng");
            dtgDanhSachPhongTrong.Columns.Add("SoNguoiToiDa", "Số người tối đa");
            dtgDanhSachPhongTrong.Columns["SoNguoiToiDa"]!.Visible = false;
            dtgDanhSachPhongTrong.Columns.Add(TaoCotAnh("Them", "Thêm", _iconThem, 50));
        }

        private void KhoiTaoGridPhongDaChon()
        {
            if (dtgDanhSachPhongDaChon.Columns.Count > 0)
                return;

            dtgDanhSachPhongDaChon.ReadOnly = true;
            dtgDanhSachPhongDaChon.AllowUserToAddRows = false;
            dtgDanhSachPhongDaChon.AllowUserToDeleteRows = false;
            dtgDanhSachPhongDaChon.AllowUserToResizeRows = false;
            dtgDanhSachPhongDaChon.MultiSelect = false;
            dtgDanhSachPhongDaChon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgDanhSachPhongDaChon.RowHeadersVisible = false;
            dtgDanhSachPhongDaChon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgDanhSachPhongDaChon.RowTemplate.Height = 32;
            dtgDanhSachPhongDaChon.AutoGenerateColumns = false;

            dtgDanhSachPhongDaChon.Columns.Add("MaPhong", "Mã phòng");
            dtgDanhSachPhongDaChon.Columns.Add("SoNguoiToiDa", "Số người tối đa");
            dtgDanhSachPhongDaChon.Columns.Add("NgayBatDau", "Ngày bắt đầu");
            dtgDanhSachPhongDaChon.Columns.Add("NgayKetThuc", "Ngày kết thúc");
            dtgDanhSachPhongDaChon.Columns["NgayBatDau"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgDanhSachPhongDaChon.Columns["NgayKetThuc"]!.DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgDanhSachPhongDaChon.Columns.Add(TaoCotAnh("Huy", "Hủy", _iconHuy, 45));
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

        private void CapNhatNgayKetThucToiThieu()
        {
            DateTime toiThieu = dtpNgayBD.Value.Date.AddDays(1);
            if (dtpNgayKT.Value.Date < toiThieu)
                dtpNgayKT.Value = toiThieu;
            dtpNgayKT.MinDate = toiThieu;
        }

        private void dtpNgayBD_ValueChanged(object? sender, EventArgs e)
        {
            if (_dangKhoiTao) return;
            CapNhatNgayKetThucToiThieu();
            LoadDanhSachPhongTrong();
        }

        private void ThayDoiThoiGian(object? sender, EventArgs e)
        {
            if (_dangKhoiTao) return;
            LoadDanhSachPhongTrong();
        }

        private void LoadDanhSachPhongTrong()
        {
            if (_dangKhoiTao) return;
            try
            {
                DateTime checkIn = LayThoiGian(dtpNgayBD, cbGioDen, cbDangGioDen) ?? dtpNgayBD.Value.Date;
                DateTime checkOut = LayThoiGian(dtpNgayKT, cbGioDi, cbDangGioDi) ?? dtpNgayKT.Value.Date;

                using var db = new HotelManagementContext();
                var dsPhongTrong = db.Phong
                    .AsNoTracking()
                    .Where(p => p.DaXoa != true
                        && p.TTPH == "Bình thường"
                        && !p.CTDP.Any(c => c.DaXoa != true
                            && c.CheckIn < checkOut
                            && c.CheckOut > checkIn))
                    .OrderBy(p => p.MaPH)
                    .Select(p => new
                    {
                        p.MaPH,
                        TenLph = p.MaLPHNavigation.TenLPH,
                        SoNguoiToiDa = p.MaLPHNavigation.SoNguoiToiDa
                    })
                    .ToList();

                dtgDanhSachPhongTrong.Rows.Clear();
                foreach (var p in dsPhongTrong)
                {
                    dtgDanhSachPhongTrong.Rows.Add(p.MaPH, p.TenLph, p.SoNguoiToiDa, _iconThem);
                }
                dtgDanhSachPhongTrong.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng trống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgDanhSachPhongTrong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dtgDanhSachPhongTrong.Columns[e.ColumnIndex].Name != "Them") return;

            var dong = dtgDanhSachPhongTrong.Rows[e.RowIndex];
            string? maPhong = dong.Cells["MaPH"].Value?.ToString();
            if (string.IsNullOrEmpty(maPhong)) return;

            foreach (DataGridViewRow daChon in dtgDanhSachPhongDaChon.Rows)
            {
                if (string.Equals(daChon.Cells["MaPhong"].Value?.ToString(), maPhong, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show($"Phòng {maPhong} đã có trong danh sách phòng đã chọn.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            DateTime? checkIn = LayThoiGian(dtpNgayBD, cbGioDen, cbDangGioDen);
            DateTime? checkOut = LayThoiGian(dtpNgayKT, cbGioDi, cbDangGioDi);

            if (checkIn == null || checkOut == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ giờ đến và giờ đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (checkOut.Value.Date <= checkIn.Value.Date)
            {
                MessageBox.Show("Ngày trả phòng phải sau ngày nhận phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soNguoiToiDa = Convert.ToInt32(dong.Cells["SoNguoiToiDa"].Value);
            dtgDanhSachPhongDaChon.Rows.Add(maPhong, soNguoiToiDa, checkIn.Value, checkOut.Value, _iconHuy);
        }

        private DateTime? LayThoiGian(DateTimePicker dtp, ComboBox cbGio, ComboBox cbAMPM)
        {
            string? gio = cbGio.SelectedItem?.ToString();
            string? ampm = cbAMPM.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(gio) || string.IsNullOrEmpty(ampm))
                return null;

            string[] phan = gio.Split(':');
            if (phan.Length != 2 || !int.TryParse(phan[0], out int hour) || !int.TryParse(phan[1], out int minute))
                return null;

            if (ampm == "PM" && hour < 12) hour += 12;
            if (ampm == "AM" && hour == 12) hour = 0;

            return dtp.Value.Date.AddHours(hour).AddMinutes(minute);
        }

        private void dtgDanhSachPhongDaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dtgDanhSachPhongDaChon.Columns[e.ColumnIndex].Name == "Huy")
            {
                dtgDanhSachPhongDaChon.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void txtSoDienThoai_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void txtCCCD_TextChanged(object? sender, EventArgs e)
        {
            if (txtHoVaTen.Enabled) return;
            txtHoVaTen.Clear();
            txtSoDienThoai.Clear();
            txtQuocTich.Clear();
            cbGioiTinh.SelectedIndex = -1;
            DatChoPhepNhapThongTinKhach(true);
        }

        private void DatChoPhepNhapThongTinKhach(bool choPhep)
        {
            txtHoVaTen.Enabled = choPhep;
            txtSoDienThoai.Enabled = choPhep;
            txtQuocTich.Enabled = choPhep;
            cbGioiTinh.Enabled = choPhep;
        }

        private void button2_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool KiemTraVaDienThongTinKH(string cccd)
        {
            if (cccd.Length == 0) return false;
            try
            {
                using var db = new HotelManagementContext();
                var khachHang = db.KhachHang
                    .AsNoTracking()
                    .Where(k => k.CCCD_Passport == cccd && k.DaXoa != true)
                    .Select(k => new { k.TenKH, k.SDT, k.QuocTich, k.GioiTinh })
                    .FirstOrDefault();

                if (khachHang == null) return false;

                txtHoVaTen.Text = khachHang.TenKH;
                txtSoDienThoai.Text = khachHang.SDT;
                txtQuocTich.Text = khachHang.QuocTich;
                cbGioiTinh.SelectedIndex = cbGioiTinh.FindStringExact(khachHang.GioiTinh ?? "");
                DatChoPhepNhapThongTinKhach(false);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kiểm tra thông tin khách hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static string TaoMaTiepTheo(IEnumerable<string> cacMa, string tienTo, int soChuSo, int doDaiToiDa)
        {
            int lonNhat = 0;
            foreach (string ma in cacMa)
            {
                if (ma.Length > tienTo.Length
                    && ma.StartsWith(tienTo, StringComparison.OrdinalIgnoreCase)
                    && int.TryParse(ma.Substring(tienTo.Length), out int so)
                    && so > lonNhat)
                {
                    lonNhat = so;
                }
            }
            string maMoi = tienTo + (lonNhat + 1).ToString("D" + soChuSo);
            if (maMoi.Length > doDaiToiDa)
                throw new InvalidOperationException($"Đã hết mã có tiền tố {tienTo} (tối đa {doDaiToiDa} ký tự).");
            return maMoi;
        }

        private bool LuuPhieuThue()
        {
            string maNV = FormDangNhap.MaNV_DangNhap;
            if (string.IsNullOrWhiteSpace(maNV))
            {
                MessageBox.Show("Chưa xác định được nhân viên đang đăng nhập. Vui lòng đăng nhập lại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            string tenKH = txtHoVaTen.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            string quocTich = txtQuocTich.Text.Trim();
            string gioiTinh = cbGioiTinh.SelectedItem?.ToString() ?? "";

            var cacPhongChon = new List<(string MaPH, int SoNguoi, DateTime CheckIn, DateTime CheckOut)>();
            foreach (DataGridViewRow row in dtgDanhSachPhongDaChon.Rows)
            {
                if (row.IsNewRow) continue;
                cacPhongChon.Add((
                    row.Cells["MaPhong"].Value?.ToString() ?? "",
                    Convert.ToInt32(row.Cells["SoNguoiToiDa"].Value),
                    Convert.ToDateTime(row.Cells["NgayBatDau"].Value),
                    Convert.ToDateTime(row.Cells["NgayKetThuc"].Value)));
            }

            try
            {
                using var db = new HotelManagementContext();
                using var giaoDich = db.Database.BeginTransaction(IsolationLevel.Serializable);

                var khachHang = db.KhachHang.FirstOrDefault(k => k.CCCD_Passport == cccd);
                string maKH;
                if (khachHang == null)
                {
                    maKH = TaoMaTiepTheo(db.KhachHang.Select(k => k.MaKH).ToList(), "KH", 3, 5);
                    db.KhachHang.Add(new Models.KhachHang
                    {
                        MaKH = maKH,
                        TenKH = tenKH,
                        SDT = sdt,
                        CCCD_Passport = cccd,
                        QuocTich = quocTich,
                        GioiTinh = gioiTinh,
                        DaXoa = false
                    });
                }
                else
                {
                    maKH = khachHang.MaKH;
                    if (khachHang.DaXoa == true)
                    {
                        khachHang.TenKH = tenKH;
                        khachHang.SDT = sdt;
                        khachHang.QuocTich = quocTich;
                        khachHang.GioiTinh = gioiTinh;
                        khachHang.DaXoa = false;
                    }
                }

                string maPT = TaoMaTiepTheo(db.PhieuThue.Select(p => p.MaPT).ToList(), "PT", 3, 5);
                db.PhieuThue.Add(new Models.PhieuThue
                {
                    MaPT = maPT,
                    NgPT = DateTime.Now,
                    MaKH = maKH,
                    MaNV = maNV,
                    DaXoa = false
                });
                db.SaveChanges();

                var cacMaCtdp = db.CTDP.Select(c => c.MaCTDP).ToList();
                var cacPhongCapNhat = new List<Models.Phong>();

                foreach (var phongChon in cacPhongChon)
                {
                    string maPH = phongChon.MaPH;
                    DateTime checkIn = phongChon.CheckIn;
                    DateTime checkOut = phongChon.CheckOut;

                    var phong = db.Phong
                        .Include(p => p.MaLPHNavigation)
                        .FirstOrDefault(p => p.MaPH == maPH && p.DaXoa != true);

                    if (phong == null)
                    {
                        MessageBox.Show($"Không tìm thấy phòng {maPH}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    if (phong.TTPH != "Bình thường")
                    {
                        MessageBox.Show($"Phòng {maPH} hiện ở trạng thái \"{phong.TTPH}\" nên không thể đặt.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    bool biTrung = db.CTDP.Any(c => c.MaPH == maPH
                        && c.DaXoa != true
                        && c.CheckIn < checkOut
                        && c.CheckOut > checkIn);

                    if (biTrung)
                    {
                        MessageBox.Show($"Phòng {maPH} đã có người đặt trong khoảng thời gian này.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    decimal donGia = phong.MaLPHNavigation.GiaNgay;
                    int soNgay = Math.Max(1, (checkOut.Date - checkIn.Date).Days);
                    string maCTDP = TaoMaTiepTheo(cacMaCtdp, "CTDP", 3, 7);
                    cacMaCtdp.Add(maCTDP);

                    db.CTDP.Add(new Models.CTDP
                    {
                        MaCTDP = maCTDP,
                        SoNguoi = phongChon.SoNguoi,
                        MaPT = maPT,
                        MaPH = maPH,
                        CheckIn = checkIn,
                        CheckOut = checkOut,
                        TrangThai = "Đã đặt",
                        DonGia = donGia,
                        ThanhTien = donGia * soNgay,
                        DaXoa = false,
                        TheoGio = false
                    });
                    db.SaveChanges();

                    if (!cacPhongCapNhat.Contains(phong))
                        cacPhongCapNhat.Add(phong);
                }

                foreach (var phong in cacPhongCapNhat)
                {
                    phong.TTPH = "Đã đặt";
                }
                db.SaveChanges();
                giaoDich.Commit();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi lưu phiếu thuê: " + (ex.InnerException?.Message ?? ex.Message), "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            bool khachHangTonTai = KiemTraVaDienThongTinKH(txtCCCD.Text.Trim());
            if (khachHangTonTai)
            {
                DialogResult result = MessageBox.Show(
                    "Khách hàng đã tồn tại trong hệ thống. Thông tin sẽ được tự động điền và không thể sửa.\nBạn có muốn tiếp tục đặt phòng không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No) return;
            }

            if (txtHoVaTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập họ và tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Focus();
                return;
            }
            if (txtCCCD.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập số CCCD/Passport!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }
            string sdt = txtSoDienThoai.Text.Trim();
            if (sdt.Length == 0 || !sdt.All(char.IsDigit))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ (chỉ gồm chữ số)!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoDienThoai.Focus();
                return;
            }
            if (txtQuocTich.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập quốc tịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuocTich.Focus();
                return;
            }
            if (cbGioiTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbGioiTinh.Focus();
                return;
            }
            if (dtgDanhSachPhongDaChon.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ít nhất 1 phòng để đặt!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool thanhCong = LuuPhieuThue();
            if (thanhCong)
            {
                MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}