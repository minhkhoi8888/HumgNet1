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
    public partial class frm_hoaDonNhap : Form
    {
        QLBH_FinalEntities db = new QLBH_FinalEntities();
        public frm_hoaDonNhap()
        {
            InitializeComponent();
            LoadData();
        }


        private void frm_hoaDonNhap_Load(object sender, EventArgs e)
        {

        }
        public void LoadData()
        {
            /*var result = from c in db.tb_HDN 
                         select new {c.ma_hdn, c.ma_nv, c.ngay_nhap, c.ma_ncc, c.thanh_tien};
            dataGV_hdn.DataSource = result.ToList();
            dataGV_hdn.Columns[0].HeaderText = "Mã hóa đơn nhập";
            dataGV_hdn.Columns[1].HeaderText = "Mã nhân viên";
            dataGV_hdn.Columns[2].HeaderText = "Ngày nhập";
            dataGV_hdn.Columns[3].HeaderText = "Mã nhà cung cấp";
            dataGV_hdn.Columns[4].HeaderText = "Thành tiền";*/
        }

        public void Create()
        {
            /*
            tb_HDN hdn = new tb_HDN()
            {
                ma_hdn = Int32.Parse(txt_maHDN.Text),
                ma_nv = Int32.Parse(txt_maNV.Text),
                ngay_nhap = dateTimePicker1.Value,
                ma_ncc = Int32.Parse(txt_maNCC.Text),
                thanh_tien = Int32.Parse(txt_thanhTien.Text)
            };
            db.tb_HDN.Add(hdn);
            db.SaveChanges();
            LoadData();*/

        }

        public void Update()
        {
            /*int ma_hdn = Convert.ToInt32(dataGV_hdn.SelectedCells[0].OwningRow.Cells["ma_hdn"].Value.ToString());
            tb_HDN hdn = db.tb_HDN.Where(p => p.ma_hdn == ma_hdn).SingleOrDefault();
            hdn.ma_nv = Int32.Parse(txt_maNV.Text);
            hdn.ngay_nhap = dateTimePicker1.Value;
            hdn.ma_ncc = Int32.Parse(txt_maNCC.Text);
            hdn.thanh_tien= Int32.Parse(txt_thanhTien.Text);
            db.SaveChanges();
            LoadData();*/
        }

        public void Delete()
        {
           /* int ma_hdn = Convert.ToInt32(txt_maHDN.Text);
            tb_HDN hdn = db.tb_HDN.Where(p => p.ma_hdn == ma_hdn).SingleOrDefault();
            db.tb_HDN.Remove(hdn);
            db.SaveChanges();
            LoadData();*/
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Create();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void dataGV_hdn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
