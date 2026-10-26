namespace HotelManagement.LoaiPhong
{
    partial class FormChiTietLoaiPhong
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
            dataGridViewCTTN = new DataGridView();
            lblTieuDe = new Label();
            btnDong = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCTTN).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewCTTN
            // 
            dataGridViewCTTN.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCTTN.Location = new Point(23, 70);
            dataGridViewCTTN.Name = "dataGridViewCTTN";
            dataGridViewCTTN.RowHeadersWidth = 51;
            dataGridViewCTTN.RowTemplate.Height = 29;
            dataGridViewCTTN.Size = new Size(534, 320);
            dataGridViewCTTN.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.DarkSlateGray;
            lblTieuDe.Location = new Point(23, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(335, 32);
            lblTieuDe.TabIndex = 1;
            lblTieuDe.Text = "Chi tiết tiện nghi loại phòng";
            // 
            // btnDong
            // 
            btnDong.BackColor = SystemColors.GradientActiveCaption;
            btnDong.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDong.Location = new Point(437, 405);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(120, 42);
            btnDong.TabIndex = 2;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // FormChiTietLoaiPhong
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 465);
            Controls.Add(btnDong);
            Controls.Add(lblTieuDe);
            Controls.Add(dataGridViewCTTN);
            Name = "FormChiTietLoaiPhong";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết tiện nghi";
            ((System.ComponentModel.ISupportInitialize)dataGridViewCTTN).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewCTTN;
        private Label lblTieuDe;
        private Button btnDong;
    }
}