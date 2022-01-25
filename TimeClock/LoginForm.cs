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
    public partial class FormLogin : Form
    {

        public static List<Account> accList = new List<Account>();
        public FormLogin()
        {
            InitializeComponent();
        }

        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");
        public static String id;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Username and Password");
                }
                else
                {
                    SqlConnection con = new SqlConnection(Conn);
                    SqlCommand cmd = new SqlCommand("Select * from loginForm where UserID=@Username and Password=@UserPassword", con);
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@UserPassword", txtPassword.Text);

                    con.Open();
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    con.Close();

                    //test code
                    //MessageBox.Show("id retrieved is: " + id);

                    //check for valid username and password based on amount of rows returned
                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1)
                    {
                        con.Open();
                        SqlCommand getId = new SqlCommand("Select ID from loginForm where UserID=@Username and Password=@UserPassword", con);
                        getId.Parameters.AddWithValue("@Username", txtUsername.Text);
                        getId.Parameters.AddWithValue("@UserPassword", txtPassword.Text);
                        id = getId.ExecuteScalar().ToString();
                        con.Close();
                        MessageBox.Show("Successful Login");
                        //check for Admin login ADMIN MUST BE ID OF 1 IN SQL TABLE
                        if (txtUsername.Text == "Admin")
                        {
                            txtUsername.Clear();
                            txtPassword.Clear();
                            new Admin().ShowDialog();
                        }
                        //check for student login
                        else
                        {
                            txtUsername.Clear();
                            txtPassword.Clear();
                            new Student().ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username and Password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            new NewUser().ShowDialog();
        }
    }
}
