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
            txtStudentId.Clear();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "" || txtStudentId.Text == "")
                {
                    MessageBox.Show("Please Enter all fields");
                }
                else
                {
                    SqlConnection con = new SqlConnection(Conn);
                    con.Open();
                    cmd = new SqlCommand("insert into loginForm values('" + txtUsername.Text + "', '" + txtPassword.Text + "', 'No', '" + txtStudentId.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Created");
                    con.Close();
                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtStudentId.Clear();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtStudentId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void NewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
