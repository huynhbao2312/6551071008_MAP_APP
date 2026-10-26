namespace HotelManagement.LoaiPhong
{
    partial class FormSuaLoaiPhong
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaLPH = new TextBox();
            txtTenLPH = new TextBox();
            nudSoGiuong = new NumericUpDown();
            nudSoNguoiToiDa = new NumericUpDown();
            txtGiaNgay = new TextBox();
            txtGiaGio = new TextBox();
            btnLuu = new Button();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)nudSoGiuong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoiToiDa).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(40, 30);
            label1.Name = "label1";
            label1.Size = new Size(132, 25);
            label1.TabIndex = 0;
            label1.Text = "Mã loại phòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(40, 80);
            label2.Name = "label2";
            label2.Size = new Size(134, 25);
            label2.TabIndex = 1;
            label2.Text = "Tên loại phòng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.Location = new Point(40, 130);
            label3.Name = "label3";
            label3.Size = new Size(95, 25);
            label3.TabIndex = 2;
            label3.Text = "Số giường";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(40, 180);
            label4.Name = "label4";
            label4.Size = new Size(141, 25);
            label4.TabIndex = 3;
            label4.Text = "Số người tối đa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F);
            label5.Location = new Point(40, 230);
            label5.Name = "label5";
            label5.Size = new Size(86, 25);
            label5.TabIndex = 4;
            label5.Text = "Giá ngày";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.Location = new Point(40, 280);
            label6.Name = "label6";
            label6.Size = new Size(72, 25);
            label6.TabIndex = 5;
            label6.Text = "Giá giờ";
            // 
            // txtMaLPH
            // 
            txtMaLPH.Font = new Font("Segoe UI", 11F);
            txtMaLPH.Location = new Point(200, 27);
            txtMaLPH.Name = "txtMaLPH";
            txtMaLPH.ReadOnly = true;
            txtMaLPH.Size = new Size(240, 32);
            txtMaLPH.TabIndex = 6;
            // 
            // txtTenLPH
            // 
            txtTenLPH.Font = new Font("Segoe UI", 11F);
            txtTenLPH.Location = new Point(200, 77);
            txtTenLPH.Name = "txtTenLPH";
            txtTenLPH.Size = new Size(240, 32);
            txtTenLPH.TabIndex = 7;
            // 
            // nudSoGiuong
            // 
            nudSoGiuong.Font = new Font("Segoe UI", 11F);
            nudSoGiuong.Location = new Point(200, 128);
            nudSoGiuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoGiuong.Name = "nudSoGiuong";
            nudSoGiuong.Size = new Size(240, 32);
            nudSoGiuong.TabIndex = 8;
            nudSoGiuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudSoNguoiToiDa
            // 
            nudSoNguoiToiDa.Font = new Font("Segoe UI", 11F);
            nudSoNguoiToiDa.Location = new Point(200, 178);
            nudSoNguoiToiDa.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoNguoiToiDa.Name = "nudSoNguoiToiDa";
            nudSoNguoiToiDa.Size = new Size(240, 32);
            nudSoNguoiToiDa.TabIndex = 9;
            nudSoNguoiToiDa.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtGiaNgay
            // 
            txtGiaNgay.Font = new Font("Segoe UI", 11F);
            txtGiaNgay.Location = new Point(200, 227);
            txtGiaNgay.Name = "txtGiaNgay";
            txtGiaNgay.Size = new Size(240, 32);
            txtGiaNgay.TabIndex = 10;
            // 
            // txtGiaGio
            // 
            txtGiaGio.Font = new Font("Segoe UI", 11F);
            txtGiaGio.Location = new Point(200, 277);
            txtGiaGio.Name = "txtGiaGio";
            txtGiaGio.Size = new Size(240, 32);
            txtGiaGio.TabIndex = 11;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Moccasin;
            btnLuu.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLuu.Location = new Point(110, 350);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(130, 48);
            btnLuu.TabIndex = 12;
            btnLuu.Text = "Cập nhật";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = SystemColors.GradientActiveCaption;
            btnHuy.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnHuy.Location = new Point(280, 350);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(130, 48);
            btnHuy.TabIndex = 13;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // FormSuaLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 430);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(txtGiaGio);
            Controls.Add(txtGiaNgay);
            Controls.Add(nudSoNguoiToiDa);
            Controls.Add(nudSoGiuong);
            Controls.Add(txtTenLPH);
            Controls.Add(txtMaLPH);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormSuaLoaiPhong";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cập nhật loại phòng";
            ((System.ComponentModel.ISupportInitialize)nudSoGiuong).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudSoNguoiToiDa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtMaLPH;
        private TextBox txtTenLPH;
        private NumericUpDown nudSoGiuong;
        private NumericUpDown nudSoNguoiToiDa;
        private TextBox txtGiaNgay;
        private TextBox txtGiaGio;
        private Button btnLuu;
        private Button btnHuy;
    }
}