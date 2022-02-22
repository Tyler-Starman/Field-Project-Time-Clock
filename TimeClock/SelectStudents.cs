using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
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
            //Print Preview Stuff
            printDocument.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
            this.printDocument.DefaultPageSettings.Landscape = true;

            using (SqlConnection con = new SqlConnection(Conn))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter("SELECT Name, ID FROM loginForm", con))
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
        //Print Preview Stuff
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private PrintDocument printDocument = new PrintDocument();
        private string documentContents;
        private string stringToPrint;

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
                            WHERE name = '"+names[i]+ "' and (select termStart from termInfo) <= ClockIn and ClockIn <= (select termEnd from termInfo);";
                comm.CommandText = sql;

                SqlDataReader sqlReader = comm.ExecuteReader();

                if (i < 1){
                    using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
                    {
                        writer.WriteLine("Name".PadRight(20) + "\t" + "Clock In Time".PadRight(30) + "\t" + "Clock Out Times".PadRight(30) + "\t" + "Total Time(Min)".PadRight(20) + "\t" + "Total Time(Sec)");
                        while (sqlReader.Read())
                        {
                            writer.WriteLine(sqlReader["Name"].ToString().PadRight(20) + sqlReader["ClockIn"].ToString().PadRight(30) + "\t" + sqlReader["ClockOut"].ToString().PadRight(30) + "\t" + sqlReader["TotalTimeDay"].ToString().PadRight(16) + "\t\t\t" + sqlReader["TotalTimeSeconds"].ToString().PadLeft(5));
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        while (sqlReader.Read())
                        {
                            sw.WriteLine(sqlReader["Name"].ToString().PadRight(20) + sqlReader["ClockIn"].ToString().PadRight(30) + "\t" + sqlReader["ClockOut"].ToString().PadRight(30) + "\t" + sqlReader["TotalTimeDay"].ToString().PadRight(16) + "\t\t\t" + sqlReader["TotalTimeSeconds"].ToString().PadLeft(5));
                        }
                    }
                }
                sqlReader.Close();
            }
            comm.Connection.Close();

            //Print Preview Stuff
            String fName = "ClockedTimeSelected.dat";
            ReadDocument(fName);
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
            //Print Preview Stuff
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
                            WHERE name = '"+names[i]+ "' and (select termStart from termInfo) <= ClockIn and ClockIn <= (select termEnd from termInfo)" +
                            "Group by lf.Name, lf.ID;";
                comm.CommandText = sql;

                SqlDataReader sqlReader = comm.ExecuteReader();

                if (i < 1)
                {
                    using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
                    {
                        writer.WriteLine("ID".PadRight(20) + "\t" + "Name".PadRight(26) + "\t" + "Total Days".PadRight(20));
                        while (sqlReader.Read())
                        {
                            writer.WriteLine(sqlReader["ID"].ToString().PadRight(20) + "\t" + sqlReader["Name"].ToString().PadRight(20) + "\t" + sqlReader["TotalDays"].ToString().PadLeft(7) + "\t\t" + sqlReader["TotalHours"]);
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(fileName))
                    {
                        while (sqlReader.Read())
                        {
                            sw.WriteLine(sqlReader["ID"].ToString().PadRight(20) + "\t" + sqlReader["Name"].ToString().PadRight(20) + "\t" + sqlReader["TotalDays"].ToString().PadLeft(7) + "\t\t" + sqlReader["TotalHours"]);
                        }
                    }
                }
                sqlReader.Close();
            }
            comm.Connection.Close();

            //Print Preview Stuff
            String fName = "TotalTimesSelected.dat";
            ReadDocument(fName);
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
            //Print Preview Stuff

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

        //Print Preview Stuff
        private void ReadDocument(String filename)
        {
            string docName = "" + filename + "";
            string docPath = AppDomain.CurrentDomain.BaseDirectory;
            printDocument.DocumentName = docName;
            using (FileStream stream = new FileStream(docPath + docName, FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }

        void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            //Changing Font
            Font Normal = new Font("Courier New", 9, FontStyle.Regular);

            // Sets the value of charactersOnPage to the number of characters
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, Normal,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, Normal, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }
    }
}
