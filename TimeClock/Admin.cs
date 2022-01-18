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

        private void btnPrintTimes_Click(object sender, EventArgs e)
        {
            //Get File Path Working So File Is At Root of Folder
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\ClockedTime.dat";
            //MessageBox.Show(fileName);
            SqlCommand comm = new SqlCommand();
            comm.Connection = new SqlConnection(Conn);
            //String sql = @"select ClockIn, ClockOut from clockPunches";
            String sql = @"SELECT lf.Name, cp.ClockIn, cp.ClockOut, cp.TotalTimeDay
                            FROM loginForm lf
                            INNER JOIN ClockPunches cp
                            ON lf.id = cp.id;";

            comm.CommandText = sql;
            comm.Connection.Open();

            SqlDataReader sqlReader = comm.ExecuteReader();

            // Change the Encoding to what you need here (UTF8, Unicode, etc)

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("Name" + "\t" + "Clock In Time        " + "\t" + "Clock Out Times        " + "\t" + "Total Time");
                while (sqlReader.Read())
                {
                    //writer.WriteLine(sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"]);
                    writer.WriteLine(sqlReader["Name"] + "\t" + sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"] + "\t" + sqlReader["TotalTimeDay"]);
                }
            }

            sqlReader.Close();
            comm.Connection.Close();
        }

        private void btnPrintTotals_Click(object sender, EventArgs e)
        {
            //Get File Path Working So File Is At Root of Folder
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\TotalTimes.dat";
            //MessageBox.Show(fileName);
            SqlCommand comm = new SqlCommand();
            comm.Connection = new SqlConnection(Conn);
            //String sql = @"select ClockIn, ClockOut from clockPunches";
            String sql = @"select lf.ID, lf.Name, count(distinct convert(date,ClockIn)) AS TotalDays, sum(CAST(TotalTimeDay AS DECIMAL(6,2))/60) AS TotalHours
                            from ClockPunches cp INNER JOIN loginForm lf
                            ON lf.id = cp.id
                            Group by lf.Name, lf.ID;";

            comm.CommandText = sql;
            comm.Connection.Open();

            SqlDataReader sqlReader = comm.ExecuteReader();

            // Change the Encoding to what you need here (UTF8, Unicode, etc)

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("ID" + "\t" + "Name       " + "\t" + "Total Days" + "\t" + "Total Hours");
                while (sqlReader.Read())
                {
                    //writer.WriteLine(sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"]);
                    writer.WriteLine(sqlReader["ID"] + "\t" + sqlReader["Name"] +  "       \t" + sqlReader["TotalDays"] + "\t\t" + sqlReader["TotalHours"]);
                }
            }

            sqlReader.Close();
            comm.Connection.Close();
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
