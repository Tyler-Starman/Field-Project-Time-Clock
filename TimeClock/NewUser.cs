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
        SqlCommand cis;
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
                if (txtUsername.Text == "" || txtPassword.Text == "" || txtStudentId.Text == "" || txtUserID.Text == "")
                {
                    MessageBox.Show("Please Enter all fields");
                }
                else
                {
                    SqlConnection con = new SqlConnection(Conn);
                    con.Open();
                    SqlCommand checkIfExists = new SqlCommand("SELECT COUNT(*) FROM loginForm WHERE UserID = '" + txtUserID.Text + "'", con);
                    int UserExist = (int)checkIfExists.ExecuteScalar();

                    if (UserExist > 0)
                    {
                        MessageBox.Show("User ID Already Exsits");
                    }

                    else
                    {
                        cmd = new SqlCommand("insert into loginForm values('" + txtUsername.Text + "', '" + txtPassword.Text + "', 'No', '" + txtStudentId.Text + "', '" + txtUserID.Text + "')", con);
                        //cis = new SqlCommand("IF NOT EXISTS (select * from loginForm where UserID =  '" + txtUserID.Text + " ') BEGIN insert into loginForm values('" + txtUsername.Text + "', '" + txtPassword.Text + "', 'No', '" + txtStudentId.Text + "', '" + txtUserID.Text + "')END; ", con);
                        cmd.ExecuteNonQuery();
                        //cis.ExecuteNonQuery();
                        MessageBox.Show("Student Created");
                        con.Close();
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtStudentId.Clear();
                    }
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
