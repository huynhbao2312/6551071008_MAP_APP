namespace HotelManagement.LoaiPhong
{
    partial class FormDanhSachLoaiPhong
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            txtTimKiem = new TextBox();
            pictureBox1 = new PictureBox();
            btnThemMoiLoaiPhong = new Button();
            dtgDanhSachLoaiPhong = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachLoaiPhong).BeginInit();
            SuspendLayout();
            // 
            // txtTimKiem
            // 
            txtTimKiem.Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTimKiem.Location = new Point(70, 16);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo mã hoặc tên...";
            txtTimKiem.Size = new Size(240, 32);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Address;
            pictureBox1.Location = new Point(25, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(39, 37);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // btnThemMoiLoaiPhong
            // 
            btnThemMoiLoaiPhong.BackColor = Color.MediumSpringGreen;
            btnThemMoiLoaiPhong.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThemMoiLoaiPhong.Location = new Point(810, 12);
            btnThemMoiLoaiPhong.Name = "btnThemMoiLoaiPhong";
            btnThemMoiLoaiPhong.Size = new Size(215, 37);
            btnThemMoiLoaiPhong.TabIndex = 3;
            btnThemMoiLoaiPhong.Text = "Thêm mới loại phòng";
            btnThemMoiLoaiPhong.UseVisualStyleBackColor = false;
            btnThemMoiLoaiPhong.Click += btnThemMoiLoaiPhong_Click;
            // 
            // dtgDanhSachLoaiPhong
            // 
            dtgDanhSachLoaiPhong.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtgDanhSachLoaiPhong.Location = new Point(25, 68);
            dtgDanhSachLoaiPhong.Name = "dtgDanhSachLoaiPhong";
            dtgDanhSachLoaiPhong.RowHeadersWidth = 51;
            dtgDanhSachLoaiPhong.RowTemplate.Height = 35;
            dtgDanhSachLoaiPhong.Size = new Size(1000, 600);
            dtgDanhSachLoaiPhong.TabIndex = 2;
            dtgDanhSachLoaiPhong.CellClick += dtgDanhSachLoaiPhong_CellClick;
            // 
            // FormDanhSachLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 690);
            Controls.Add(dtgDanhSachLoaiPhong);
            Controls.Add(btnThemMoiLoaiPhong);
            Controls.Add(pictureBox1);
            Controls.Add(txtTimKiem);
            Name = "FormDanhSachLoaiPhong";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách loại phòng";
            Load += FormDanhSachLoaiPhong_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtgDanhSachLoaiPhong).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTimKiem;
        private PictureBox pictureBox1;
        private Button btnThemMoiLoaiPhong;
        private DataGridView dtgDanhSachLoaiPhong;
    }
}