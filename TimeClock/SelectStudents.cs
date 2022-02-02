using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeClock
{
    public partial class SelectStudents : Form
    {
        public SelectStudents()
        {
            InitializeComponent();
            using (SqlConnection con = new SqlConnection(Conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Name FROM loginForm", con))
                {
                    //Fill the DataTable with records from Table.
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    //Loop through the DataTable.
                    foreach (DataRow row in dt.Rows)
                    {
                        //Add Item to ListView.
                        ListViewItem item = new ListViewItem(row["Name"].ToString());
                        lvStudentNames.Items.Add(item);

                    }

                    lvStudentNames.View = View.List;
                }
            }
        }

        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");

        private void lbStudentNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in lvStudentNames.SelectedItems)
            {
                lvStudentNames.Items.Remove(selectedItem);
                lvSelectedStudents.Items.Add(selectedItem);
            }
        }

        private void btnMoveBack_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem selectedItem in lvSelectedStudents.SelectedItems)
            {
                lvSelectedStudents.Items.Remove(selectedItem);
                lvStudentNames.Items.Add(selectedItem);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            var names2 = new List<string>();
            foreach (ListViewItem Item in lvSelectedStudents.Items)
            {
                names2.Add(Item.Text.ToString());
            }
            var names = names2.ToArray();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\ClockedTimeSelected.dat";
            SqlCommand comm = new SqlCommand();
            comm.Connection = new SqlConnection(Conn);
            comm.Connection.Open();
            for (int i = 0; i < lvSelectedStudents.Items.Count; i++)
            {
                String sql = @"SELECT DISTINCT lf.Name, cp.ClockIn, cp.ClockOut, cp.TotalTimeDay, cp.TotalTimeSeconds
                            FROM loginForm lf
                            INNER JOIN ClockPunches cp
                            ON lf.id = cp.id
                            WHERE name = '"+names[i]+"';";
                comm.CommandText = sql;

                SqlDataReader sqlReader = comm.ExecuteReader();

                if (i < 1){
                    using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
                    {
                        writer.WriteLine("Name".PadRight(20) + "\t" + "Clock In Time        " + "\t" + "Clock Out Times        " + "\t" + "Total Time(Min)       " + "\t" + "Total Time(Sec)"); while (sqlReader.Read())
                        {
                            writer.WriteLine(sqlReader["Name"].ToString().PadRight(20) + " \t" + sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"] + "\t" + sqlReader["TotalTimeDay"] + "\t\t\t" + sqlReader["TotalTimeSeconds"]);
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        while (sqlReader.Read())
                        {
                            sw.WriteLine(sqlReader["Name"].ToString().PadRight(20) + " \t" + sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"] + "\t" + sqlReader["TotalTimeDay"] + "\t\t\t" + sqlReader["TotalTimeSeconds"]);
                        }
                    }
                }
                sqlReader.Close();
            }
            comm.Connection.Close();
            MessageBox.Show("Successfully Printed Out Times");
        }

        private void btnPrintTotals_Click(object sender, EventArgs e)
        {
            var names2 = new List<string>();
            foreach (ListViewItem Item in lvSelectedStudents.Items)
            {
                names2.Add(Item.Text.ToString());
            }
            var names = names2.ToArray();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"\TotalTimesSelected.dat";
            SqlCommand comm = new SqlCommand();
            comm.Connection = new SqlConnection(Conn);
            comm.Connection.Open();
            for (int i = 0; i < lvSelectedStudents.Items.Count; i++)
            {
                String sql = @"select lf.ID, lf.Name, count(distinct convert(date,ClockIn)) AS TotalDays, sum(CAST(TotalTimeDay AS DECIMAL(6,2))/60) AS TotalHours
                            from ClockPunches cp INNER JOIN loginForm lf
                            ON lf.id = cp.id
                            WHERE name = '"+names[i]+"'Group by lf.Name, lf.ID;";
                comm.CommandText = sql;

                SqlDataReader sqlReader = comm.ExecuteReader();

                if (i < 1)
                {
                    using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
                    {
                        writer.WriteLine("ID" + "\t" + "Name".PadRight(20) + "\t" + "Total Days" + "\t" + "Total Hours");
                        while (sqlReader.Read())
                        {
                            writer.WriteLine(sqlReader["ID"] + "\t" + sqlReader["Name"].ToString().PadRight(20) + "\t" + sqlReader["TotalDays"] + "\t\t" + sqlReader["TotalHours"]);
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        while (sqlReader.Read())
                        {
                            sw.WriteLine(sqlReader["ID"] + "\t" + sqlReader["Name"].ToString().PadRight(20) + "\t" + sqlReader["TotalDays"] + "\t\t" + sqlReader["TotalHours"]);
                        }
                    }
                }
                sqlReader.Close();
            }
            comm.Connection.Close();
            MessageBox.Show("Successfully Printed Out Total Times");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            //warning message that will only continue delete if 'yes' is selected
            DialogResult delConfirm = MessageBox.Show("Are you sure you wish to proceed?", "Deleting students is permanent!", MessageBoxButtons.YesNo);
            if (delConfirm == DialogResult.Yes)
            {
                //initialize commands and connection
                SqlConnection con = new SqlConnection(Conn);
                con.Open();
                SqlCommand cmd0, cmd1, cmd2;
                //Make a list of selected students and use this lise to query the database for
                //their IDs.
                List<string> stuDelList = lvSelectedStudents.Items.Cast<ListViewItem>()
                                 .Select(item => item.Text)
                                 .ToList();
                string[] stuDelArray = stuDelList.ToArray();
                string stuDelString = "('" + string.Join("', '", stuDelArray) + "')";
                cmd0 = new SqlCommand("SELECT ID FROM loginForm WHERE Name IN " + stuDelString, con);
                //use data reader to get ids of selected students
                //and place them into list
                List<int> stuDelIds = new List<int>();
                SqlDataReader reader = cmd0.ExecuteReader(CommandBehavior.Default);
                while (reader.Read())
                {
                    stuDelIds.Add((int)reader["ID"]);
                }
                reader.Close();
                //make a string of IDs that's usable in the sql statement
                string stuDelIdString = "('" + string.Join("', '", stuDelIds) + "')";
                //delete from clockpunches table using IDs from list
                cmd1 = new SqlCommand("DELETE FROM ClockPunches WHERE ID IN " + stuDelIdString, con);
                //delete from loginForm table using IDs from list
                cmd2 = new SqlCommand("DELETE FROM loginForm WHERE ID IN " + stuDelIdString, con);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                con.Close();
                //confirmation of deletion
                MessageBox.Show("Students deleted successfully");
            }
            else
            {
                //cancelation message
                MessageBox.Show("Deletion Canceled");
            }
        }
    }
}
