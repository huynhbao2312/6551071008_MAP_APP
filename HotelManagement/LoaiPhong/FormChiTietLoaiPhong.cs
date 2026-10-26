using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.LoaiPhong
{
    public partial class FormChiTietLoaiPhong : Form
    {
        private string? _maLPH;

        public FormChiTietLoaiPhong()
        {
            InitializeComponent();
        }

        public FormChiTietLoaiPhong(string maLPH, string tenLPH) : this()
        {
            _maLPH = maLPH;
            lblTieuDe.Text = $"Tiện nghi loại phòng: {tenLPH} ({maLPH})";
            LoadDanhSachTienNghi();
        }

        private void LoadDanhSachTienNghi()
        {
            try
            {
                using var db = new HotelManagementContext();
                var dsTienNghi = db.CTTN
                    .AsNoTracking()
                    .Where(ct => ct.MaLPH == _maLPH && ct.DaXoa != true)
                    .Select(ct => new
                    {
                        MaTN = ct.MaTN,
                        TenTN = ct.MaTNNavigation.TenTN,
                        SL = ct.SL
                    })
                    .ToList();

                dataGridViewCTTN.ReadOnly = true;
                dataGridViewCTTN.AllowUserToAddRows = false;
                dataGridViewCTTN.AllowUserToDeleteRows = false;
                dataGridViewCTTN.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewCTTN.DataSource = dsTienNghi;

                if (dataGridViewCTTN.Columns.Contains("MaTN"))
                    dataGridViewCTTN.Columns["MaTN"].HeaderText = "Mã tiện nghi";
                if (dataGridViewCTTN.Columns.Contains("TenTN"))
                    dataGridViewCTTN.Columns["TenTN"].HeaderText = "Tên tiện nghi";
                if (dataGridViewCTTN.Columns.Contains("SL"))
                    dataGridViewCTTN.Columns["SL"].HeaderText = "Số lượng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải tiện nghi loại phòng: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}