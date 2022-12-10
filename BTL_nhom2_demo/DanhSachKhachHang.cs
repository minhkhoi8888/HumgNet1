using BTL_nhom2_demo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BTL_nhom2_demo
{
    public partial class DanhSachKhachHang : Form
    {
        QLBH_01Entities db = new QLBH_01Entities();

        public DanhSachKhachHang()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            var result = from c in db.tb_Khachhang
                         select new { c.ma_kh, c.ten_kh, c.dia_chi, SĐT = c.dien_thoai };
            dataGridView1.DataSource = result.ToList();
            dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[1].HeaderText = "Tên";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Số điện thoại";
            //var rs2 = from c in db.BANGCAPs
            //          select c;
            //comboBox1.DataSource = rs2.ToList();
            //comboBox1.DisplayMember = "TenBangCap";
            //comboBox1.ValueMember = "MaBangCap";

        }

        public void ClearForm()
        {
            txbTen.Clear();
            txbDiaChi.Clear();
            txbDienThoai.Clear();
        }

        public void Them()
        {
            tb_Khachhang khachhang = new tb_Khachhang()
            {
                ten_kh = txbTen.Text,
                dia_chi = txbDiaChi.Text,
                dien_thoai = txbDienThoai.Text
            };
            db.tb_Khachhang.Add(khachhang);
            db.SaveChanges();
            LoadData();
            ClearForm();
        }   

        public void Sua()
        {
            int maKH = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ma_kh"].Value.ToString());
            tb_Khachhang curKhachHang = db.tb_Khachhang.Where(khacHang => khacHang.ma_kh == maKH).SingleOrDefault();
            if (String.IsNullOrEmpty(txbTen.Text) || String.IsNullOrEmpty(txbDiaChi.Text) || String.IsNullOrEmpty(txbDienThoai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Notification", MessageBoxButtons.OK);
            } 
            else
            {
                curKhachHang.ten_kh = txbTen.Text;
                curKhachHang.dia_chi = txbDiaChi.Text;
                var rs = from c in db.tb_Khachhang 
                         where c.dien_thoai == txbDienThoai.Text
                         select c.dien_thoai;
                
                if (rs.Equals())
                {
                    MessageBox.Show("Số điện thoại này đã tồn tại. Vui lòng sử dụng số khác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txbDienThoai.Focus();
                    return;
                }
                curKhachHang.dien_thoai = txbDienThoai.Text;
                db.SaveChanges();
                MessageBox.Show("Cập nhật thành công", "Notification", MessageBoxButtons.OK);
                LoadData();
                ClearForm();
            }
            
        }

        public void Xoa()
        {
            int maKH = Convert.ToInt32(dataGridView1.SelectedCells[0].OwningRow.Cells["ma_kh"].Value.ToString());
            tb_Khachhang curKhachHang = db.tb_Khachhang.Where(khacHang => khacHang.ma_kh == maKH).SingleOrDefault();

            DialogResult res = MessageBox.Show("Bạn có muốn xóa khách hàng khỏi danh sách?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                db.tb_Khachhang.Remove(curKhachHang);
                db.SaveChanges();
                MessageBox.Show("Xóa thành công", "Notification", MessageBoxButtons.OK);
                LoadData();
            }
        }

        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txbTen.Text = row.Cells[1].Value.ToString();
            txbDienThoai.Text = row.Cells[3].Value.ToString();
            txbDiaChi.Text = row.Cells[2].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Them();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Sua();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Xoa();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có muốn thoát khỏi chương trình?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
