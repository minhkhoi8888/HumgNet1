using BTL_nhom2_demo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom2_demo
{
    public partial class HoaDonBan : Form
    {
        QLBH_02Entities db = new QLBH_02Entities();

        public HoaDonBan()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

       
             
        public void LoadComboMaNhanVien()
        {
            var rs = from c in db.tb_Nhanvien
                     select c;
            cbMaNhanVien.DataSource = rs.ToList();
            cbMaNhanVien.DisplayMember = "ten_nv";
            cbMaNhanVien.ValueMember = "ma_nv";
            cbMaHang.SelectedIndex = -1;
        }

        public void LoadComboKhachHang()
        {
            var rs = from c in db.tb_Khachhang select c;
            cbMaKH.DataSource = rs.ToList();
            cbMaKH.DisplayMember = "ten_kh";
            cbMaKH.ValueMember = "ma_kh";
            cbMaKH.SelectedIndex = -1;
        }

        public void LoadComboHangHoa()
        {
            var rs = from c in db.tb_Hanghoa select c;
            cbMaHang.DataSource = rs.ToList();
            cbMaHang.DisplayMember = "ten_hang";
            cbMaHang.ValueMember = "ma_hang";
            cbMaHang.SelectedIndex = -1;
        }

        private void HoaDonBan_Load(object sender, EventArgs e)
        {
            txbMaHoaDon.ReadOnly = true;
            txbTenNhanVien.ReadOnly = true;
            txbThanhTien.ReadOnly = true;
            txbTongThanhTien.ReadOnly = true;
            txbDiaChi.ReadOnly = true;
            txbDienThoai.ReadOnly = true;   

            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            //btnInHoaDon.Enabled = false;
            txbDiaChi.ReadOnly = true;
            LoadComboMaNhanVien();
            LoadComboKhachHang();
            LoadComboHangHoa();
            if (txbMaHoaDon.Text != "")
            {
                LoadFormChiTietHoaDon();
                btnDelete.Enabled = true;
                
            }

            // Cần có mã hóa đơn mới load đc nếu như muốn xem chi tiết hóa đơn
            //LoadDataGridViewChiTietHoaDon();
        }

        // Hiển thị dữ liệu cho chi tiết hóa đơn
        public void LoadDataGridViewChiTietHoaDon()
        {
            int maHoaDonBan = Convert.ToInt32(txbMaHoaDon.Text);
            var result = from a in db.tb_CTHDB                       
                         join b in db.tb_Hanghoa on a.ma_hang equals b.ma_hang
                         where a.ma_hdb == maHoaDonBan 
                         select new { a.ma_hang, b.ten_hang, a.so_luong, b.don_gia_ban, a.giam_gia, a.thanh_tien };
            dataGridView1.DataSource = result.ToList();
            dataGridView1.Columns[0].HeaderText = "Mã sản phẩm";
            dataGridView1.Columns[1].HeaderText = "Tên sản phẩm";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Đơn giá";
            dataGridView1.Columns[4].HeaderText = "Khuyến mãi (%)";
            dataGridView1.Columns[5].HeaderText = "Thành tiền";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].Width = 90;
            dataGridView1.Columns[4].Width = 90;
            dataGridView1.Columns[5].Width = 90;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        // Thông tin form hóa đơn
        public void LoadFormChiTietHoaDon()
        {
            //int maHoaDonBan = Convert.ToInt32(txbMaHoaDon.Text);
            
            int maHoaDonBan = Int32.Parse(txbMaHoaDon.Text);
            var rs = (from c in db.tb_HDB
                     where c.ma_hdb == maHoaDonBan
                     select c);

            foreach (var item in rs)
            {
                //dateTimePicker1.Text = item.ngay_ban.ToString();
                dateTimePicker1.Value = item.ngay_ban.Value;
                cbMaNhanVien.Text = item.ma_nv.ToString();
                cbMaKH.Text = item.ma_kh.ToString();
                txbTongThanhTien.Text = item.thanh_tien.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Random random = new Random(6);
            int newMaHoaDon = random.Next(2488399);
            
            
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;

            ResetValues();

            // Check xem newMaHoaDon có trùng với mã hóa đơn cũ không
            var rs = from c in db.tb_HDB
                     select c;
            foreach(var item in rs)
            {
                while (item.ma_hdb == newMaHoaDon)
                {
                    newMaHoaDon++;
                }
            }
            //string mhd = ;
            txbMaHoaDon.Text = Convert.ToString(newMaHoaDon);

            LoadDataGridViewChiTietHoaDon();
        }

        // Trả về gtri mặc định ban đầu của các input
        public void ResetValues()
        {
            txbMaHoaDon.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
            cbMaNhanVien.Text = "";
            cbMaKH.Text = "";
            txbTongThanhTien.Text = "0";
            cbMaHang.Text = "";
            txbSoLuong.Text = "";
            txbKhuyenMai.Text = "0";
            txbThanhTien.Text = "0";
        }


    }
}
