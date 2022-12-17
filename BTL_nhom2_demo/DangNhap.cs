using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// using entites
using BTL_nhom2_demo.DTO;

namespace BTL_nhom2_demo
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        // entity
        QLBH_02Entities1 db = new QLBH_02Entities1();


        public Boolean getID(string nameU, string pass)
        {
            var select = from s in db.tb_User select s;
            foreach (var data in select)
            {
                if (data.usename == nameU)
                {
                    return false;
                }
            }
            return true;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (getID(textBox1.Text, textBox2.Text) == true)
            {
                Main home = new Main();
                home.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect! Please try again...", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                Close();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
