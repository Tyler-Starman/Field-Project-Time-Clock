using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TimeClock
{
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");
        SqlCommand cmd;
        private void btnReturn_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please Eneter Username and Password");
                }
                else
                {
                    SqlConnection con = new SqlConnection(Conn);
                    con.Open();
                    cmd = new SqlCommand("insert into loginForm values('" + txtUsername.Text + "', '" + txtPassword.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Created");
                    con.Close();
                    txtUsername.Clear();
                    txtPassword.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
