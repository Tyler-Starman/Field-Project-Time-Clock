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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }
        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");
        SqlCommand cmd;
        SqlCommand clk;
        SqlCommand ctotTime;

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTermYear_Click(object sender, EventArgs e)
        {
            new TermYear().Show();
        }

        private void btnClockOutAll_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            //NEEDS CHANGED TO MAKE ROW ONLY FOR THOSE WHO ARE CLOCKED IN
            
            //WORK IN PROGRESS
            //this is almost working. ids is getting a list of the ids of those logged in correctly!!
            SqlCommand getId = new SqlCommand("select ID from loginForm where ClockStatus = 'YES'", con);
            getId.CommandType = CommandType.Text;
            SqlDataReader reader = getId.ExecuteReader();
            List<int> ids = new List<int>();
            while (reader.Read())
            {
                ids.Add(reader.GetInt32(0));
            }
            reader.Close();
            foreach(var personId in ids)
            {
             
                cmd = new SqlCommand("UPDATE ClockPunches set ClockOut = '" + DateTime.Now + " ' WHERE ID = '" + personId + "'and ClockOut is null", con);
                ctotTime = new SqlCommand("update ClockPunches set TotalTimeDay = datediff(minute, ClockIn, ClockOut) where TotalTimeDay is null;", con);
                cmd.ExecuteNonQuery();
                ctotTime.ExecuteNonQuery();
            }
            //END WORK IN PROGRESS
            clk = new SqlCommand("UPDATE loginForm SET ClockStatus = 'NO'", con);
            clk.ExecuteNonQuery();
            MessageBox.Show("Everyone is now clocked out.");
            con.Close();
        }

        private void btnClockedIn_Click(object sender, EventArgs e)
        {
            new ClockedIn().ShowDialog();
        }

        private void btnClockedOut_Click(object sender, EventArgs e)
        {
            new ClockedOut().ShowDialog();
        }

        private void btnClockedTimes_Click(object sender, EventArgs e)
        {
            new SearchTimes().ShowDialog();
        }

        //on load do something like this
        /*con.Open();
        SqlCommand getStatus = new SqlCommand("select ClockStatus from loginForm where ID = '" + FormLogin.id + "'", con);
        clockStatus = getStatus.ExecuteScalar().ToString();
        con.Close();

        //SqlCommand getId = new SqlCommand("select ID from loginForm where ClockStatus = 'YES'", con);
        //string[] ids = getId

        but get an array of IDs where status is 'YES'
        then use that array in an sql command when clock out all is pressed

        something like this:
        foreach object in IDarray{
            cmd = new SqlCommand("insert into ClockPunches values('" + object + "', '" + DateTime.Now + "', 'OUT')", con);
            cmd.ExecuteNonQuery();
        */
    }
}
