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

namespace BTL_nhom2_demo
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"server=LAPTOP-AOQAELMH\LIAZZ; database=QLBH_02; integrated security=true");

        private string getID(string username, string password)
        {
            string id = "";
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tb_User where Username = '" + username + "' and Password = '" + password + "'", conn);
                SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                myAdapter.Fill(dt);
                if(dt != null)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        id = dr["Username"].ToString();
                    }
                }
            }catch
            {
                MessageBox.Show("Error qerry or connect database fail...", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }finally
            {
                conn.Close();
            }

            return id;
        }

        public static string ID_User = "";
        private void button2_Click(object sender, EventArgs e)
        {
            ID_User = getID(textBox1.Text, textBox2.Text);
            if(ID_User != "")
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

    }
}
