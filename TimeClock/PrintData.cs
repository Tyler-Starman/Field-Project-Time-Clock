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

namespace TimeClock
{
    public partial class PrintData : Form
    {
        public PrintData()
        {
            InitializeComponent();
        }
        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrintTimes_Click(object sender, EventArgs e)
        {
            //Get File Path Working So File Is At Root of Folder
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\ClockedTime.dat";
            //MessageBox.Show(fileName);
            SqlCommand comm = new SqlCommand();
            comm.Connection = new SqlConnection(Conn);
            //String sql = @"select ClockIn, ClockOut from clockPunches";
            String sql = @"SELECT lf.Name, cp.ClockIn, cp.ClockOut, cp.TotalTimeDay, cp.TotalTimeSeconds
                            FROM loginForm lf
                            INNER JOIN ClockPunches cp
                            ON lf.id = cp.id;";

            comm.CommandText = sql;
            comm.Connection.Open();

            SqlDataReader sqlReader = comm.ExecuteReader();

            // Change the Encoding to what you need here (UTF8, Unicode, etc)

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("Name".PadRight(20) + "\t" + "Clock In Time        " + "\t" + "Clock Out Times        " + "\t" + "Total Time(Min)       " + "\t" + "Total Time(Sec)");
                while (sqlReader.Read())
                {
                    //writer.WriteLine(sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"]);
                    writer.WriteLine(sqlReader["Name"].ToString().PadRight(20) + " \t" + sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"] + "\t" + sqlReader["TotalTimeDay"] + "\t\t\t" + sqlReader["TotalTimeSeconds"]);
                }
            }

            sqlReader.Close();
            comm.Connection.Close();
            MessageBox.Show("Successfully Printed Out Times");
        }

        private void btnPrintTotals_Click(object sender, EventArgs e)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\TotalTimes.dat";
            SqlCommand comm = new SqlCommand();
            comm.Connection = new SqlConnection(Conn);
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
                writer.WriteLine("ID" + "\t" + "Name".PadRight(20) + "\t" + "Total Days" + "\t" + "Total Hours");
                while (sqlReader.Read())
                {
                    //writer.WriteLine(sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"]);
                    writer.WriteLine(sqlReader["ID"] + "\t" + sqlReader["Name"].ToString().PadRight(20) + "\t" + sqlReader["TotalDays"] + "\t\t" + sqlReader["TotalHours"]);
                }
            }

            sqlReader.Close();
            comm.Connection.Close();
            MessageBox.Show("Successfully Printed Out Totals");
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            new SelectStudents().ShowDialog();
        }
    }
}
