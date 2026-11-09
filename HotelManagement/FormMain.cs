using HotelManagement.DangNhap;

namespace HotelManagement
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            HienThiThongTinNguoiDung();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            this.Hide();
            using (var formLogin = new FormDangNhap())
            {
                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    HienThiThongTinNguoiDung();
                    HienThiTrangChu();
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form formCon = new ThongKe.FormThongKe();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void btnTrangChu_Click(object sender, EventArgs e)
        {
            HienThiTrangChu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form formCon = new TaiKhoan.FormDanhSachTaiKhoan();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain(); // hoặc panelMain.Controls.Clear();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form formCon = new LoaiPhong.FormDanhSachLoaiPhong();
            LoadFormCon(formCon);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form formCon = new NhanVien.FormDanhSachNhanVien();
            LoadFormCon(formCon);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form formCon = new KhachHang.FormDanhSachKhachHang();
            LoadFormCon(formCon);
        }

        private void btnQuanLyPhong_Click(object sender, EventArgs e)
        {
            Form formCon = new Phong.FormDanhSachPhong();
            LoadFormCon(formCon);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form formCon = new TienNghi.FormDanhSachTienNghi();
            LoadFormCon(formCon);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form formCon = new DichVu.FormDanhSachDichVu();
            LoadFormCon(formCon);
        }

        private void btnSoDoPhong_Click(object sender, EventArgs e)
        {
            Form formCon = new SoDoPhong.FormSoDoPhong();
            LoadFormCon(formCon);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form formCon = new PhieuThue.FormDanhSachPhieuThue();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain(); // Nếu project dùng tên khác, thay bằng panelMain.Controls.Clear();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form formCon = new HoaDon.FormDanhSachHoaDon();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            XoaNoiDungPanelMain(); // hoặc panelMain.Controls.Clear();
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            HienThiTrangChu();
        }

        private void HienThiThongTinNguoiDung()
        {
            lblTenNguoiDung.Text = FormDangNhap.TenNV_DangNhap;
            lblTenNguoiDung.Left = (panel2.Width - lblTenNguoiDung.PreferredWidth) / 2;
        }

        private void XoaNoiDungPanelMain()
        {
            foreach (Control c in panelMain.Controls.Cast<Control>().ToList())
            {
                panelMain.Controls.Remove(c);
                c.Dispose();
            }
        }

        public void LoadUserControl(UserControl uc)
        {
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(uc);
            uc.Dock = DockStyle.Fill;
            uc.BringToFront();
        }

        public void LoadFormCon(Form formCon)
        {
            XoaNoiDungPanelMain();
            formCon.TopLevel = false;
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;
            panelMain.Controls.Add(formCon);
            formCon.Show();
        }

        private void HienThiTrangChu()
        {
            if (panelMain.Controls.Count == 1 && panelMain.Controls[0] is FormTrangChu)
                return;

            XoaNoiDungPanelMain();
            LoadUserControl(new FormTrangChu());
        }

        private void HienThiDangPhatTrien(string tenChucNang)
        {
            XoaNoiDungPanelMain();
            panelMain.Controls.Add(new Label
            {
                Dock = DockStyle.Fill,
                Text = tenChucNang + Environment.NewLine + "(chức năng đang được xây dựng)",
                Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Italic),
                ForeColor = Color.DarkCyan,
                TextAlign = ContentAlignment.MiddleCenter
            });
        }
    }
}