namespace HotelManagement.ThongKe
{
    partial class FormThongKe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FastReport.DataVisualization.Charting.ChartArea chartArea1 = new FastReport.DataVisualization.Charting.ChartArea();
            FastReport.DataVisualization.Charting.Legend legend1 = new FastReport.DataVisualization.Charting.Legend();
            FastReport.DataVisualization.Charting.Series series1 = new FastReport.DataVisualization.Charting.Series();
            FastReport.DataVisualization.Charting.Title title1 = new FastReport.DataVisualization.Charting.Title();
            FastReport.DataVisualization.Charting.ChartArea chartArea2 = new FastReport.DataVisualization.Charting.ChartArea();
            FastReport.DataVisualization.Charting.Legend legend2 = new FastReport.DataVisualization.Charting.Legend();
            FastReport.DataVisualization.Charting.Series series2 = new FastReport.DataVisualization.Charting.Series();
            FastReport.DataVisualization.Charting.Title title2 = new FastReport.DataVisualization.Charting.Title();
            FastReport.DataVisualization.Charting.ChartArea chartArea3 = new FastReport.DataVisualization.Charting.ChartArea();
            FastReport.DataVisualization.Charting.Legend legend3 = new FastReport.DataVisualization.Charting.Legend();
            FastReport.DataVisualization.Charting.Series series3 = new FastReport.DataVisualization.Charting.Series();
            FastReport.DataVisualization.Charting.Title title3 = new FastReport.DataVisualization.Charting.Title();
            panelTop = new Panel();
            btnXemThongKe = new Button();
            dtpDenNgay = new DateTimePicker();
            labelDenNgay = new Label();
            dtpTuNgay = new DateTimePicker();
            labelTuNgay = new Label();
            panelCard1 = new Panel();
            lbTienPhong = new Label();
            labelTieuDeCard1 = new Label();
            pictureBoxCard1 = new PictureBox();
            panelCard2 = new Panel();
            lbTienDichVu = new Label();
            labelTieuDeCard2 = new Label();
            pictureBoxCard2 = new PictureBox();
            panelCard3 = new Panel();
            lbSoPhongDat = new Label();
            labelTieuDeCard3 = new Label();
            pictureBoxCard3 = new PictureBox();
            panelRank1 = new Panel();
            lbTopLoaiPhongDoanhThu = new Label();
            labelTieuDeRank1 = new Label();
            pictureBoxRank1 = new PictureBox();
            panelRank2 = new Panel();
            lbTopLoaiPhongDatNhieu = new Label();
            labelTieuDeRank2 = new Label();
            pictureBoxRank2 = new PictureBox();
            panelRank3 = new Panel();
            lbTopDichVu = new Label();
            labelTieuDeRank3 = new Label();
            pictureBoxRank3 = new PictureBox();
            chartDoanhThuPhong = new FastReport.DataVisualization.Charting.Chart();
            chartDichVu = new FastReport.DataVisualization.Charting.Chart();
            chartSoPhongDat = new FastReport.DataVisualization.Charting.Chart();
            panelTop.SuspendLayout();
            panelCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard1).BeginInit();
            panelCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard2).BeginInit();
            panelCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard3).BeginInit();
            panelRank1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRank1).BeginInit();
            panelRank2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRank2).BeginInit();
            panelRank3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRank3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThuPhong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartDichVu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartSoPhongDat).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.AliceBlue;
            panelTop.Controls.Add(btnXemThongKe);
            panelTop.Controls.Add(dtpDenNgay);
            panelTop.Controls.Add(labelDenNgay);
            panelTop.Controls.Add(dtpTuNgay);
            panelTop.Controls.Add(labelTuNgay);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1160, 50);
            panelTop.TabIndex = 0;
            // 
            // btnXemThongKe
            // 
            btnXemThongKe.BackColor = SystemColors.GradientActiveCaption;
            btnXemThongKe.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            btnXemThongKe.Location = new Point(950, 8);
            btnXemThongKe.Name = "btnXemThongKe";
            btnXemThongKe.Size = new Size(180, 35);
            btnXemThongKe.TabIndex = 4;
            btnXemThongKe.Text = "Xem thống kê";
            btnXemThongKe.UseVisualStyleBackColor = false;
            btnXemThongKe.Click += btnXemThongKe_Click;
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.Font = new Font("Segoe UI", 10.8F);
            dtpDenNgay.Format = DateTimePickerFormat.Short;
            dtpDenNgay.Location = new Point(620, 10);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Size = new Size(250, 31);
            dtpDenNgay.TabIndex = 3;
            // 
            // labelDenNgay
            // 
            labelDenNgay.AutoSize = true;
            labelDenNgay.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            labelDenNgay.Location = new Point(510, 14);
            labelDenNgay.Name = "labelDenNgay";
            labelDenNgay.Size = new Size(96, 25);
            labelDenNgay.TabIndex = 2;
            labelDenNgay.Text = "Đến ngày:";
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.Font = new Font("Segoe UI", 10.8F);
            dtpTuNgay.Format = DateTimePickerFormat.Short;
            dtpTuNgay.Location = new Point(130, 10);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Size = new Size(250, 31);
            dtpTuNgay.TabIndex = 1;
            // 
            // labelTuNgay
            // 
            labelTuNgay.AutoSize = true;
            labelTuNgay.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            labelTuNgay.Location = new Point(30, 14);
            labelTuNgay.Name = "labelTuNgay";
            labelTuNgay.Size = new Size(84, 25);
            labelTuNgay.TabIndex = 0;
            labelTuNgay.Text = "Từ ngày:";
            // 
            // panelCard1
            // 
            panelCard1.BackColor = Color.Salmon;
            panelCard1.Controls.Add(lbTienPhong);
            panelCard1.Controls.Add(labelTieuDeCard1);
            panelCard1.Controls.Add(pictureBoxCard1);
            panelCard1.Location = new Point(15, 60);
            panelCard1.Name = "panelCard1";
            panelCard1.Size = new Size(360, 95);
            panelCard1.TabIndex = 1;
            // 
            // lbTienPhong
            // 
            lbTienPhong.AutoSize = true;
            lbTienPhong.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbTienPhong.ForeColor = Color.White;
            lbTienPhong.Location = new Point(90, 48);
            lbTienPhong.Name = "lbTienPhong";
            lbTienPhong.Size = new Size(88, 35);
            lbTienPhong.TabIndex = 2;
            lbTienPhong.Text = "0 VND";
            // 
            // labelTieuDeCard1
            // 
            labelTieuDeCard1.AutoSize = true;
            labelTieuDeCard1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            labelTieuDeCard1.ForeColor = Color.White;
            labelTieuDeCard1.Location = new Point(90, 12);
            labelTieuDeCard1.Name = "labelTieuDeCard1";
            labelTieuDeCard1.Size = new Size(198, 25);
            labelTieuDeCard1.TabIndex = 1;
            labelTieuDeCard1.Text = "Doanh thu thuê phòng";
            // 
            // pictureBoxCard1
            // 
            pictureBoxCard1.Image = Properties.Resources.details;
            pictureBoxCard1.Location = new Point(15, 18);
            pictureBoxCard1.Name = "pictureBoxCard1";
            pictureBoxCard1.Size = new Size(60, 60);
            pictureBoxCard1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCard1.TabIndex = 0;
            pictureBoxCard1.TabStop = false;
            // 
            // panelCard2
            // 
            panelCard2.BackColor = Color.DarkKhaki;
            panelCard2.Controls.Add(lbTienDichVu);
            panelCard2.Controls.Add(labelTieuDeCard2);
            panelCard2.Controls.Add(pictureBoxCard2);
            panelCard2.Location = new Point(400, 60);
            panelCard2.Name = "panelCard2";
            panelCard2.Size = new Size(360, 95);
            panelCard2.TabIndex = 2;
            // 
            // lbTienDichVu
            // 
            lbTienDichVu.AutoSize = true;
            lbTienDichVu.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lbTienDichVu.ForeColor = Color.White;
            lbTienDichVu.Location = new Point(90, 48);
            lbTienDichVu.Name = "lbTienDichVu";
            lbTienDichVu.Size = new Size(88, 35);
            lbTienDichVu.TabIndex = 2;
            lbTienDichVu.Text = "0 VND";
            // 
            // labelTieuDeCard2
            // 
            labelTieuDeCard2.AutoSize = true;
            labelTieuDeCard2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            labelTieuDeCard2.ForeColor = Color.White;
            labelTieuDeCard2.Location = new Point(90, 12);
            labelTieuDeCard2.Name = "labelTieuDeCard2";
            labelTieuDeCard2.Size = new Size(166, 25);
            labelTieuDeCard2.TabIndex = 1;
            labelTieuDeCard2.Text = "Doanh thu dịch vụ";
            // 
            // pictureBoxCard2
            // 
            pictureBoxCard2.Image = Properties.Resources.DichVu;
            pictureBoxCard2.Location = new Point(15, 18);
            pictureBoxCard2.Name = "pictureBoxCard2";
            pictureBoxCard2.Size = new Size(60, 60);
            pictureBoxCard2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCard2.TabIndex = 0;
            pictureBoxCard2.TabStop = false;
            // 
            // panelCard3
            // 
            panelCard3.BackColor = Color.DarkSeaGreen;
            panelCard3.Controls.Add(lbSoPhongDat);
            panelCard3.Controls.Add(labelTieuDeCard3);
            panelCard3.Controls.Add(pictureBoxCard3);
            panelCard3.Location = new Point(785, 60);
            panelCard3.Name = "panelCard3";
            panelCard3.Size = new Size(360, 95);
            panelCard3.TabIndex = 3;
            // 
            // lbSoPhongDat
            // 
            lbSoPhongDat.AutoSize = true;
            lbSoPhongDat.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lbSoPhongDat.ForeColor = Color.White;
            lbSoPhongDat.Location = new Point(90, 46);
            lbSoPhongDat.Name = "lbSoPhongDat";
            lbSoPhongDat.Size = new Size(32, 37);
            lbSoPhongDat.TabIndex = 2;
            lbSoPhongDat.Text = "0";
            // 
            // labelTieuDeCard3
            // 
            labelTieuDeCard3.AutoSize = true;
            labelTieuDeCard3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold);
            labelTieuDeCard3.ForeColor = Color.White;
            labelTieuDeCard3.Location = new Point(90, 12);
            labelTieuDeCard3.Name = "labelTieuDeCard3";
            labelTieuDeCard3.Size = new Size(122, 25);
            labelTieuDeCard3.TabIndex = 1;
            labelTieuDeCard3.Text = "Số phòng đặt";
            // 
            // pictureBoxCard3
            // 
            pictureBoxCard3.Image = Properties.Resources.Phong;
            pictureBoxCard3.Location = new Point(15, 18);
            pictureBoxCard3.Name = "pictureBoxCard3";
            pictureBoxCard3.Size = new Size(60, 60);
            pictureBoxCard3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxCard3.TabIndex = 0;
            pictureBoxCard3.TabStop = false;
            // 
            // panelRank1
            // 
            panelRank1.BackColor = Color.FromArgb(235, 225, 245);
            panelRank1.Controls.Add(lbTopLoaiPhongDoanhThu);
            panelRank1.Controls.Add(labelTieuDeRank1);
            panelRank1.Controls.Add(pictureBoxRank1);
            panelRank1.Location = new Point(15, 170);
            panelRank1.Name = "panelRank1";
            panelRank1.Size = new Size(410, 85);
            panelRank1.TabIndex = 4;
            // 
            // lbTopLoaiPhongDoanhThu
            // 
            lbTopLoaiPhongDoanhThu.AutoSize = true;
            lbTopLoaiPhongDoanhThu.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lbTopLoaiPhongDoanhThu.ForeColor = Color.DarkSlateBlue;
            lbTopLoaiPhongDoanhThu.Location = new Point(80, 45);
            lbTopLoaiPhongDoanhThu.Name = "lbTopLoaiPhongDoanhThu";
            lbTopLoaiPhongDoanhThu.Size = new Size(106, 28);
            lbTopLoaiPhongDoanhThu.TabIndex = 2;
            lbTopLoaiPhongDoanhThu.Text = "Chưa có";
            // 
            // labelTieuDeRank1
            // 
            labelTieuDeRank1.AutoSize = true;
            labelTieuDeRank1.Font = new Font("Segoe UI Semibold", 10.5F);
            labelTieuDeRank1.ForeColor = Color.FromArgb(70, 70, 90);
            labelTieuDeRank1.Location = new Point(80, 12);
            labelTieuDeRank1.Name = "labelTieuDeRank1";
            labelTieuDeRank1.Size = new Size(248, 25);
            labelTieuDeRank1.TabIndex = 1;
            labelTieuDeRank1.Text = "Loại phòng doanh thu cao nhất";
            // 
            // pictureBoxRank1
            // 
            pictureBoxRank1.Image = Properties.Resources.details;
            pictureBoxRank1.Location = new Point(15, 16);
            pictureBoxRank1.Name = "pictureBoxRank1";
            pictureBoxRank1.Size = new Size(50, 50);
            pictureBoxRank1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRank1.TabIndex = 0;
            pictureBoxRank1.TabStop = false;
            // 
            // panelRank2
            // 
            panelRank2.BackColor = Color.FromArgb(235, 225, 245);
            panelRank2.Controls.Add(lbTopLoaiPhongDatNhieu);
            panelRank2.Controls.Add(labelTieuDeRank2);
            panelRank2.Controls.Add(pictureBoxRank2);
            panelRank2.Location = new Point(15, 270);
            panelRank2.Name = "panelRank2";
            panelRank2.Size = new Size(410, 85);
            panelRank2.TabIndex = 5;
            // 
            // lbTopLoaiPhongDatNhieu
            // 
            lbTopLoaiPhongDatNhieu.AutoSize = true;
            lbTopLoaiPhongDatNhieu.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lbTopLoaiPhongDatNhieu.ForeColor = Color.DarkSlateBlue;
            lbTopLoaiPhongDatNhieu.Location = new Point(80, 45);
            lbTopLoaiPhongDatNhieu.Name = "lbTopLoaiPhongDatNhieu";
            lbTopLoaiPhongDatNhieu.Size = new Size(106, 28);
            lbTopLoaiPhongDatNhieu.TabIndex = 2;
            lbTopLoaiPhongDatNhieu.Text = "Chưa có";
            // 
            // labelTieuDeRank2
            // 
            labelTieuDeRank2.AutoSize = true;
            labelTieuDeRank2.Font = new Font("Segoe UI Semibold", 10.5F);
            labelTieuDeRank2.ForeColor = Color.FromArgb(70, 70, 90);
            labelTieuDeRank2.Location = new Point(80, 12);
            labelTieuDeRank2.Name = "labelTieuDeRank2";
            labelTieuDeRank2.Size = new Size(251, 25);
            labelTieuDeRank2.TabIndex = 1;
            labelTieuDeRank2.Text = "Loại phòng được đặt nhiều nhất";
            // 
            // pictureBoxRank2
            // 
            pictureBoxRank2.Image = Properties.Resources.details;
            pictureBoxRank2.Location = new Point(15, 16);
            pictureBoxRank2.Name = "pictureBoxRank2";
            pictureBoxRank2.Size = new Size(50, 50);
            pictureBoxRank2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRank2.TabIndex = 0;
            pictureBoxRank2.TabStop = false;
            // 
            // panelRank3
            // 
            panelRank3.BackColor = Color.FromArgb(235, 225, 245);
            panelRank3.Controls.Add(lbTopDichVu);
            panelRank3.Controls.Add(labelTieuDeRank3);
            panelRank3.Controls.Add(pictureBoxRank3);
            panelRank3.Location = new Point(15, 370);
            panelRank3.Name = "panelRank3";
            panelRank3.Size = new Size(410, 85);
            panelRank3.TabIndex = 6;
            // 
            // lbTopDichVu
            // 
            lbTopDichVu.AutoSize = true;
            lbTopDichVu.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            lbTopDichVu.ForeColor = Color.DarkSlateBlue;
            lbTopDichVu.Location = new Point(80, 45);
            lbTopDichVu.Name = "lbTopDichVu";
            lbTopDichVu.Size = new Size(106, 28);
            lbTopDichVu.TabIndex = 2;
            lbTopDichVu.Text = "Chưa có";
            // 
            // labelTieuDeRank3
            // 
            labelTieuDeRank3.AutoSize = true;
            labelTieuDeRank3.Font = new Font("Segoe UI Semibold", 10.5F);
            labelTieuDeRank3.ForeColor = Color.FromArgb(70, 70, 90);
            labelTieuDeRank3.Location = new Point(80, 12);
            labelTieuDeRank3.Name = "labelTieuDeRank3";
            labelTieuDeRank3.Size = new Size(207, 25);
            labelTieuDeRank3.TabIndex = 1;
            labelTieuDeRank3.Text = "Dịch vụ doanh thu cao nhất";
            // 
            // pictureBoxRank3
            // 
            pictureBoxRank3.Image = Properties.Resources.details;
            pictureBoxRank3.Location = new Point(15, 16);
            pictureBoxRank3.Name = "pictureBoxRank3";
            pictureBoxRank3.Size = new Size(50, 50);
            pictureBoxRank3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxRank3.TabIndex = 0;
            pictureBoxRank3.TabStop = false;
            // 
            // chartDoanhThuPhong
            // 
            chartArea1.Name = "ChartArea1";
            chartDoanhThuPhong.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chartDoanhThuPhong.Legends.Add(legend1);
            chartDoanhThuPhong.Location = new Point(445, 170);
            chartDoanhThuPhong.Name = "chartDoanhThuPhong";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Doanh thu theo loại phòng";
            chartDoanhThuPhong.Series.Add(series1);
            chartDoanhThuPhong.Size = new Size(700, 285);
            chartDoanhThuPhong.TabIndex = 7;
            title1.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Doanh thu thuê phòng";
            chartDoanhThuPhong.Titles.Add(title1);
            // 
            // chartDichVu
            // 
            chartArea2.Name = "ChartArea1";
            chartDichVu.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartDichVu.Legends.Add(legend2);
            chartDichVu.Location = new Point(15, 470);
            chartDichVu.Name = "chartDichVu";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = FastReport.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "DichVu";
            chartDichVu.Series.Add(series2);
            chartDichVu.Size = new Size(410, 275);
            chartDichVu.TabIndex = 8;
            title2.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            title2.Name = "Title1";
            title2.Text = "Các dịch vụ được sử dụng";
            chartDichVu.Titles.Add(title2);
            // 
            // chartSoPhongDat
            // 
            chartArea3.Name = "ChartArea1";
            chartSoPhongDat.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartSoPhongDat.Legends.Add(legend3);
            chartSoPhongDat.Location = new Point(445, 470);
            chartSoPhongDat.Name = "chartSoPhongDat";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Số lượng đặt";
            chartSoPhongDat.Series.Add(series3);
            chartSoPhongDat.Size = new Size(700, 275);
            chartSoPhongDat.TabIndex = 9;
            title3.Font = new Font("Segoe UI Semibold", 11.5F, FontStyle.Bold);
            title3.Name = "Title1";
            title3.Text = "Số phòng được đặt";
            chartSoPhongDat.Titles.Add(title3);
            // 
            // FormThongKe
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1160, 760);
            Controls.Add(chartSoPhongDat);
            Controls.Add(chartDichVu);
            Controls.Add(chartDoanhThuPhong);
            Controls.Add(panelRank3);
            Controls.Add(panelRank2);
            Controls.Add(panelRank1);
            Controls.Add(panelCard3);
            Controls.Add(panelCard2);
            Controls.Add(panelCard1);
            Controls.Add(panelTop);
            Name = "FormThongKe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Báo cáo thống kê";
            Load += FormThongKe_Load;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelCard1.ResumeLayout(false);
            panelCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard1).EndInit();
            panelCard2.ResumeLayout(false);
            panelCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard2).EndInit();
            panelCard3.ResumeLayout(false);
            panelCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCard3).EndInit();
            panelRank1.ResumeLayout(false);
            panelRank1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRank1).EndInit();
            panelRank2.ResumeLayout(false);
            panelRank2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRank2).EndInit();
            panelRank3.ResumeLayout(false);
            panelRank3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRank3).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThuPhong).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartDichVu).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartSoPhongDat).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label labelTuNgay;
        private DateTimePicker dtpTuNgay;
        private Label labelDenNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnXemThongKe;
        private Panel panelCard1;
        private PictureBox pictureBoxCard1;
        private Label labelTieuDeCard1;
        private Label lbTienPhong;
        private Panel panelCard2;
        private Label lbTienDichVu;
        private Label labelTieuDeCard2;
        private PictureBox pictureBoxCard2;
        private Panel panelCard3;
        private Label lbSoPhongDat;
        private Label labelTieuDeCard3;
        private PictureBox pictureBoxCard3;
        private Panel panelRank1;
        private Label lbTopLoaiPhongDoanhThu;
        private Label labelTieuDeRank1;
        private PictureBox pictureBoxRank1;
        private Panel panelRank2;
        private Label lbTopLoaiPhongDatNhieu;
        private Label labelTieuDeRank2;
        private PictureBox pictureBoxRank2;
        private Panel panelRank3;
        private Label lbTopDichVu;
        private Label labelTieuDeRank3;
        private PictureBox pictureBoxRank3;
        private FastReport.DataVisualization.Charting.Chart chartDoanhThuPhong;
        private FastReport.DataVisualization.Charting.Chart chartDichVu;
        private FastReport.DataVisualization.Charting.Chart chartSoPhongDat;
    }
}