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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");
        SqlCommand cmd;
        SqlCommand clk;
        SqlCommand ctotTime;
        String clockStatus;

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            cmd = new SqlCommand("insert into ClockPunches (ID, ClockIn) values('" + FormLogin.id + "', '" + DateTime.Now + "')", con);
            clk = new SqlCommand("UPDATE loginForm SET ClockStatus = 'YES' WHERE ID = '" + FormLogin.id + "'", con);
            cmd.ExecuteNonQuery();
            clk.ExecuteNonQuery();
            MessageBox.Show("You are now clocked in");
            con.Close();

            btnClockIn.Enabled = false;
            btnClockOut.Enabled = true;
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            cmd = new SqlCommand("UPDATE ClockPunches set ClockOut = '"+ DateTime.Now+ " '  WHERE ID = '" + FormLogin.id + "'and ClockOut is null", con);

            ctotTime = new SqlCommand("update ClockPunches set TotalTimeDay = datediff(minute, ClockIn, ClockOut)  WHERE ID = '" + FormLogin.id + "'and TotalTimeDay is null", con);

            clk = new SqlCommand("UPDATE loginForm SET ClockStatus = 'NO' WHERE ID = '" + FormLogin.id + "'", con);
     
            cmd.ExecuteNonQuery();
            ctotTime.ExecuteNonQuery();
            clk.ExecuteNonQuery();
            MessageBox.Show("You are now clocked out.");
            con.Close();

            btnClockIn.Enabled = true;
            btnClockOut.Enabled = false;
        }

        private void Student_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand getStatus = new SqlCommand("select ClockStatus from loginForm where ID = '" + FormLogin.id + "'", con);
            clockStatus = getStatus.ExecuteScalar().ToString();
            con.Close();

            if (clockStatus == "YES")
            {
                btnClockIn.Enabled = false;
                btnClockOut.Enabled = true;
            }
            else
            {
                btnClockIn.Enabled = true;
                btnClockOut.Enabled = false;
            }
        }
    }
}
