using BTL_nhom2_demo.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_nhom2_demo
{
    public partial class caLam : Form
    {
        QLBH_FinalEntities db = new QLBH_FinalEntities();
        public caLam()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            var result = from c in db.tb_Calam
                         select c;
            data_GV_caLam.DataSource = result.ToList();
            data_GV_caLam.Columns[0].HeaderText = "Ma ca";
            data_GV_caLam.Columns[1].HeaderText = "Ten ca";
        }

        public void Binding()
        {
            txt_maCa.DataBindings.Add(new Binding("text", data_GV_caLam.DataSource, "ma_ca", true, DataSourceUpdateMode.Never));
            txt_tenCa.DataBindings.Add(new Binding("text", data_GV_caLam.DataSource, "ten_ca", true, DataSourceUpdateMode.Never));
        }

        public void Add()
        {
            tb_Calam calam = new tb_Calam()
            {
                ma_ca = Int32.Parse(txt_maCa.Text),
                ten_ca = txt_tenCa.Text
            };
            db.tb_Calam.Add(calam);
            db.SaveChanges();
            LoadData();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int ma_ca = Convert.ToInt32(txt_maCa.Text);
            tb_Calam ca_lam = db.tb_Calam.Where(p => p.ma_ca == ma_ca).SingleOrDefault();
            db.tb_Calam.Remove(ca_lam);
            db.SaveChanges();
            LoadData();
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            int ma_ca = Convert.ToInt32(txt_maCa.Text);
            tb_Calam ca_lam = db.tb_Calam.Where(p => p.ma_ca == ma_ca).SingleOrDefault();

            ca_lam.ten_ca = txt_tenCa.Text;
            db.SaveChanges();
            MessageBox.Show("Update succesful...", "Notification", MessageBoxButtons.OK);
            LoadData();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void caLam_Load(object sender, EventArgs e)
        {

        }
    }
}
