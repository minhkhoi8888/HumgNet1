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
    public partial class frm_chatLieu : Form
    {

        QLBH_FinalEntities db = new QLBH_FinalEntities();
        public frm_chatLieu()
        {
            InitializeComponent();
            LoadData();
        }

        private void frm_chatLieu_Load(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            var result = from c in db.tb_Chatlieu select c;
            data_GV_CL.DataSource = result.ToList();
            data_GV_CL.Columns[0].HeaderText = "Ma chat lieu";
            data_GV_CL.Columns[1].HeaderText = "Ten chat lieu";
        }

        public void Binding()
        {
            txt_maCL.DataBindings.Add(new Binding("text", data_GV_CL.DataSource, "ma_chat_lieu", true, DataSourceUpdateMode.Never));
            txt_tenCL.DataBindings.Add(new Binding("text", data_GV_CL.DataSource, "ten_chat_lieu", true, DataSourceUpdateMode.Never));
        }

        public void ADD()
        {
            tb_Chatlieu chat_lieu = new tb_Chatlieu()
            {
                ma_chat_lieu = Int32.Parse(txt_maCL.Text),
                ten_chat_lieu = txt_tenCL.Text
            };

            db.tb_Chatlieu.Add(chat_lieu);
            db.SaveChanges();
            MessageBox.Show("Add data succesful...", "Notification", MessageBoxButtons.OK);
            LoadData();
        }

        public void Update()
        {
            int ma_CL = Convert.ToInt32(txt_maCL.Text);
            tb_Chatlieu chat_lieu = db.tb_Chatlieu.Where(p => p.ma_chat_lieu == ma_CL).SingleOrDefault();
            chat_lieu.ten_chat_lieu = txt_tenCL.Text;
            db.SaveChanges();
            MessageBox.Show("Update data succesful...", "Notification", MessageBoxButtons.OK);
            LoadData();
        }

        public void Del()
        {
            int ma_CL = Convert.ToInt32(txt_maCL.Text);
            tb_Chatlieu chat_lieu = db.tb_Chatlieu.Where(p => p.ma_chat_lieu == ma_CL).SingleOrDefault();

            db.tb_Chatlieu.Remove(chat_lieu);
            db.SaveChanges();
            MessageBox.Show("Delete data succesful...", "Notification", MessageBoxButtons.OK);
            LoadData();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            ADD();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            Del();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
