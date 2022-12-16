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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void hóaĐơnMuaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_hoaDonNhap frm_hdn = new frm_hoaDonNhap();
            frm_hdn.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachKhachHang ds_KH = new DanhSachKhachHang();
            ds_KH.ShowDialog();
        }

        private void caLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            caLam ca_lam_viec = new caLam();
            ca_lam_viec.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if(result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void chấtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_chatLieu chat_lieu = new frm_chatLieu();
            chat_lieu.ShowDialog();
        }
    }
}
