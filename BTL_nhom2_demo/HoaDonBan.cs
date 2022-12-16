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
            txbDiaChi.ReadOnly = true;

            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = false;
            
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

            // Sử dụng Linq method (src tham khảo: https://www.entityframeworktutorial.net/Querying-with-EDM.aspx) 
            //var rs2 = db.tb_CTHDB
            //    .Where(s => s.ma_hdb == maHoaDonBan)
            //    .Join(db.tb_Hanghoa, b => b.ma_hang, c => c.ma_nuoc, (b, c) => new
            //    {
            //        b.ma_hang, c.ten_hang, b.so_luong, c.don_gia_ban, b.giam_gia, b.thanh_tien
            //    }).ToList();

            dataGridView1.DataSource = result.ToList(); ;
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

        // Tải lên thông tin form chi tiết hóa đơn
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

        // Xử lý "Thêm mới hóa đơn"
        private void btnAdd_Click(object sender, EventArgs e)
        {
                    
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;

            ResetValues();

            // Gen ra random mã hóa đơn
            Random random = new Random();
            int newMaHoaDon = random.Next(2488399);
            
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
            txbMaHoaDon.Text = Convert.ToString(newMaHoaDon);

            LoadDataGridViewChiTietHoaDon();
        }

        // Trả về gtri mặc định ban đầu của các input
        public void ResetValues()
        {
            txbMaHoaDon.Text = "";
            dateTimePicker1.Value = DateTime.Now;
            cbMaNhanVien.Text = "";
            cbMaKH.Text = "";
            txbTongThanhTien.Text = "0";
            cbMaHang.Text = "";
            txbSoLuong.Text = "";
            txbKhuyenMai.Text = "0";
            txbThanhTien.Text = "0";
        }


        // Xử lý "Lưu hóa đơn"
        private void btnSave_Click(object sender, EventArgs e)
        {
            double soLuong, soLuongConlai, tongThanhTienCu, tongThanhTienMoi;           
            int maHoaDonBan = Int32.Parse(txbMaHoaDon.Text);

            //Check xem đã tồn tại hóa đơn chưa. Nếu chưa thì lưu maHD mới vào db.tb_HDB trước
            var rs1 = from c in db.tb_HDB
                      where c.ma_hdb == maHoaDonBan
                      select c.ma_hdb;
            if (!(rs1.Count() > 0))
            {
                if (cbMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaNhanVien.Focus();
                    return;
                }
                if (cbMaKH.Text.Length == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbMaKH.Focus();
                    return;
                }

                tb_HDB newHDB = new tb_HDB()
                {
                    ma_hdb = maHoaDonBan,
                    ngay_ban = dateTimePicker1.Value,
                    ma_nv = Convert.ToInt32(cbMaNhanVien.SelectedValue.ToString()),
                    ma_kh = Convert.ToInt32(cbMaKH.SelectedValue.ToString()),
                    thanh_tien = Convert.ToDouble(txbTongThanhTien.Text),
                };
                db.tb_HDB.Add(newHDB);
                db.SaveChanges();
            }



            //tb_HDB curHoaDonBan = db.tb_HDB.Where(hoaDon => hoaDon.ma_hdb == maHoaDonBan).SingleOrDefault();
            //if (curHoaDonBan == null)
            //{
            //    if (cbMaNhanVien.Text.Length == 0)
            //    {
            //        MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        cbMaNhanVien.Focus();
            //        return;
            //    }
            //    if (cbMaKH.Text.Length == 0)
            //    {
            //        MessageBox.Show("Vui lòng chọn khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        cbMaKH.Focus();
            //        return;
            //    }

            //    curHoaDonBan.ma_hdb = maHoaDonBan;
            //    curHoaDonBan.ngay_ban = dateTimePicker1.Value;
            //    curHoaDonBan.ma_nv = Convert.ToInt32(cbMaNhanVien.SelectedValue.ToString());
            //    curHoaDonBan.ma_kh = Convert.ToInt32(cbMaKH.SelectedValue.ToString());
            //    curHoaDonBan.thanh_tien = Convert.ToDouble(txbTongThanhTien.Text);

            //    db.SaveChanges();
            //}

            // Tiến hành lưu thông tin mặt hàng của hóa đơn
            if (cbMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng chọn mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbMaHang.Focus();
                return;
            }

            if ((txbSoLuong.Text.Trim().Length == 0) || (txbSoLuong.Text == "0"))
            {
                MessageBox.Show("Vui lòng nhập số lượng sản phẩm lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoLuong.Text = "";
                txbSoLuong.Focus();
                return;
            }

            if (txbKhuyenMai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Vui lòng nhập khuyến mãi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbKhuyenMai.Focus();
                return;
            }


            ////tb_CTHDB curCTHDB = db.tb_CTHDB.Where(c => c.ma_hang == Convert.ToInt32(cbMaHang.SelectedValue) && c.ma_hdb == maHoaDonBan).SingleOrDefault();
            ////if (curCTHDB == null)
            ////{

            ////}
            // Ktra xem sản phẩm nhập mới đã có trong ds sp chưa
            int maHangSelected = Convert.ToInt32(cbMaHang.SelectedValue);
            var rs = from c in db.tb_CTHDB
                     where c.ma_hang == maHangSelected  && c.ma_hdb == maHoaDonBan
                     select c.ma_hang;
            if (rs.Count() > 0)
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                cbMaHang.Focus();
                return;
            }
            
            // Ktra số lượng còn lại trong kho
            tb_Hanghoa curSanPham = db.tb_Hanghoa.Where(sp => sp.ma_hang == maHangSelected).SingleOrDefault();
            soLuong = (double)curSanPham.so_luong;
            if (Convert.ToDouble(txbSoLuong.Text) > soLuong )
            {
                MessageBox.Show("Số lượng của sản phẩm này chỉ còn " + soLuong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbSoLuong.Text = "";
                txbSoLuong.Focus();
                return;
            }

            tb_CTHDB tb_CTHDB = new tb_CTHDB()
            {
                ma_hdb = maHoaDonBan,
                ma_hang = Convert.ToInt32(cbMaHang.SelectedValue),
                //ma_hang = Convert.ToInt32(cbMaHang.SelectedValue.ToString()),
                so_luong = Convert.ToDouble(txbSoLuong.Text),
                don_gia = Convert.ToDouble(txbDonGia.Text),
                giam_gia = Convert.ToDouble(txbKhuyenMai.Text),
                thanh_tien = Convert.ToDouble(txbThanhTien.Text),
            };

            db.tb_CTHDB.Add(tb_CTHDB);
            db.SaveChanges();
            
            LoadDataGridViewChiTietHoaDon();

            // Cập nhật số lượng sản phẩm cho bảng tb_Hanghoa
            soLuongConlai = soLuong - Convert.ToDouble(txbSoLuong.Text);
            curSanPham.so_luong = soLuongConlai;
            db.SaveChanges();

            // Cập nhật lại tổng tiền cho hóa đơn bán
            tb_HDB curHoaDonBan = db.tb_HDB.Where(hoaDon => hoaDon.ma_hdb == maHoaDonBan).SingleOrDefault();
            tongThanhTienCu = (double)curHoaDonBan.thanh_tien;  
            tongThanhTienMoi = tongThanhTienCu + Convert.ToDouble(txbThanhTien.Text);
            curHoaDonBan.thanh_tien = tongThanhTienMoi;
            db.SaveChanges();
            ResetValuesHang();
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
        }

        // Reset lại khi mặt hàng thêm mới đã có trên gridview sản phẩm
        private void ResetValuesHang()
        {
            cbMaHang.Text = "";
            txbSoLuong.Text = "";
            txbKhuyenMai.Text = "0";
            txbThanhTien.Text = "0";
        }




        // Xử lý "Xóa hóa đơn"
        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
