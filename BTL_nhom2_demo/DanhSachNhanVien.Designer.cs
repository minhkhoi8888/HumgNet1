namespace BTL_nhom2_demo
{
    partial class DanhSachNhanVien
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbCongViec = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbCaLam = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbGioiTinh = new System.Windows.Forms.ComboBox();
            this.txbDiaChi = new System.Windows.Forms.TextBox();
            this.txbDienThoai = new System.Windows.Forms.TextBox();
            this.txbTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(555, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH NHÂN VIÊN";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbCongViec);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbCaLam);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbGioiTinh);
            this.groupBox1.Controls.Add(this.txbDiaChi);
            this.groupBox1.Controls.Add(this.txbDienThoai);
            this.groupBox1.Controls.Add(this.txbTen);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(64, 136);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1210, 425);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin chi tiết";
            // 
            // cbCongViec
            // 
            this.cbCongViec.FormattingEnabled = true;
            this.cbCongViec.Location = new System.Drawing.Point(779, 208);
            this.cbCongViec.Name = "cbCongViec";
            this.cbCongViec.Size = new System.Drawing.Size(351, 32);
            this.cbCongViec.TabIndex = 13;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(659, 208);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 24);
            this.label9.TabIndex = 14;
            this.label9.Text = "Công việc";
            // 
            // cbCaLam
            // 
            this.cbCaLam.FormattingEnabled = true;
            this.cbCaLam.Location = new System.Drawing.Point(779, 126);
            this.cbCaLam.Name = "cbCaLam";
            this.cbCaLam.Size = new System.Drawing.Size(351, 32);
            this.cbCaLam.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(659, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 24);
            this.label8.TabIndex = 12;
            this.label8.Text = "Ca làm";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(779, 57);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(345, 29);
            this.dateTimePicker1.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(659, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 24);
            this.label7.TabIndex = 10;
            this.label7.Text = "Ngày sinh";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "Địa chỉ";
            // 
            // cbGioiTinh
            // 
            this.cbGioiTinh.FormattingEnabled = true;
            this.cbGioiTinh.Location = new System.Drawing.Point(197, 126);
            this.cbGioiTinh.Name = "cbGioiTinh";
            this.cbGioiTinh.Size = new System.Drawing.Size(351, 32);
            this.cbGioiTinh.TabIndex = 8;
            this.cbGioiTinh.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txbDiaChi
            // 
            this.txbDiaChi.Location = new System.Drawing.Point(197, 286);
            this.txbDiaChi.Multiline = true;
            this.txbDiaChi.Name = "txbDiaChi";
            this.txbDiaChi.Size = new System.Drawing.Size(351, 47);
            this.txbDiaChi.TabIndex = 7;
            // 
            // txbDienThoai
            // 
            this.txbDienThoai.Location = new System.Drawing.Point(197, 208);
            this.txbDienThoai.Multiline = true;
            this.txbDienThoai.Name = "txbDienThoai";
            this.txbDienThoai.Size = new System.Drawing.Size(351, 47);
            this.txbDienThoai.TabIndex = 6;
            // 
            // txbTen
            // 
            this.txbTen.Location = new System.Drawing.Point(197, 46);
            this.txbTen.Multiline = true;
            this.txbTen.Name = "txbTen";
            this.txbTen.Size = new System.Drawing.Size(351, 47);
            this.txbTen.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 24);
            this.label5.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Điện thoại";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giới tính";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(64, 677);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1210, 404);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách nhân viên";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 72;
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1201, 373);
            this.dataGridView1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(64, 591);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 61);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm ";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(261, 591);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(123, 61);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(469, 591);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(123, 61);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(680, 591);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 61);
            this.btnExit.TabIndex = 6;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // DanhSachNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1358, 1061);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "DanhSachNhanVien";
            this.Text = "DanhSachNhanVien";
            this.Load += new System.EventHandler(this.DanhSachNhanVien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbGioiTinh;
        private System.Windows.Forms.TextBox txbDiaChi;
        private System.Windows.Forms.TextBox txbDienThoai;
        private System.Windows.Forms.TextBox txbTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbCongViec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbCaLam;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}