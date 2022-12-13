using BTL_nhom2_demo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.SqlServer;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom2_demo
{
    public partial class DanhSachNhanVien : Form
    {

        QLBH_02Entities db = new QLBH_02Entities();

        public DanhSachNhanVien()
        {
            InitializeComponent();
            LoadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DanhSachNhanVien_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            var result = from c in db.tb_Nhanvien
                         select new { c.ma_nv, c.ten_nv, c.gioi_tinh, c.ngay_sinh, c.dien_thoai, c.tb_Calam.ten_ca, c.tb_Congviec.ten_cv };

            dataGridView1.DataSource = result.ToList();
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên";
            dataGridView1.Columns[2].HeaderText = "Giới tính";
            dataGridView1.Columns[3].HeaderText = "Ngày sinh";
            dataGridView1.Columns[4].HeaderText = "Điện thoại";
            dataGridView1.Columns[5].HeaderText = "Ca làm việc";
            dataGridView1.Columns[6].HeaderText = "Chức vụ";

            LoadCaLam();
            LoadCongViec();
            ClearForm();
        }

        public void LoadCaLam()
        {
            var rs = from c in db.tb_Calam
                     select c;
            cbCaLam.DataSource = rs.ToList();
            cbCaLam.DisplayMember = "ten_ca";
            cbCaLam.ValueMember = "ma_ca";
            cbCaLam.SelectedIndex = -1;
        }

        public void LoadCongViec()
        {
            var rs = from c in db.tb_Congviec
                     select c;
            cbCongViec.DataSource = rs.ToList();
            cbCongViec.DisplayMember = "ten_cv";
            cbCongViec.ValueMember = "ma_cv";
            cbCongViec.SelectedIndex = -1;
        
        }

        public void CheckEmptyInfo()
        {
            if (String.IsNullOrEmpty(txbTen.Text))
            {
                MessageBox.Show("Vui lòng điền tên nhân viên.", "Notification", MessageBoxButtons.OK);
                txbTen.Focus();
            }

            if (String.IsNullOrEmpty(txbGioiTinh.Text))
            {
                MessageBox.Show("Vui lòng điền giới tính nhân viên.", "Notification", MessageBoxButtons.OK);
                txbGioiTinh.Focus();
            }

            if (String.IsNullOrEmpty(txbDienThoai.Text))
            {
                MessageBox.Show("Vui lòng điền SĐT nhân viên.", "Notification", MessageBoxButtons.OK);
                txbDienThoai.Focus();
            }

            if (String.IsNullOrEmpty(txbDiaChi.Text))
            {
                MessageBox.Show("Vui lòng điền Địa chỉ.", "Notification", MessageBoxButtons.OK);
                txbDiaChi.Focus();
            }

            if (dateTimePicker1.Value == null)
            {
                MessageBox.Show("Vui lòng điền DOB.", "Notification", MessageBoxButtons.OK);
                dateTimePicker1.Focus();
            }

        }

        public void ClearForm()
        {
            txbTen.Clear();
            txbDiaChi.Clear();
            txbDienThoai.Clear();
            txbGioiTinh.Clear();
            dateTimePicker1.Refresh();
            LoadCaLam();
            LoadCongViec();
        }

        public void Them()
        {
            CheckEmptyInfo();
            tb_Nhanvien nhanVien = new tb_Nhanvien()
            {
                ten_nv = txbTen.Text,
                gioi_tinh = txbGioiTinh.Text,
                ngay_sinh = dateTimePicker1.Value,
                //ngay_sinh = DateTime.Parse(dateTimePicker1.Text),
                dien_thoai = txbDienThoai.Text,
                dia_chi = txbDiaChi.Text,
                ma_ca = Convert.ToInt32(cbCaLam.SelectedValue),
                ma_cv = Convert.ToInt32(cbCongViec.SelectedValue)
            };

            db.tb_Nhanvien.Add(nhanVien);
            db.SaveChanges();
            LoadData();
            ClearForm();

        }

        public void Sua()
        {

        }
    }
}
