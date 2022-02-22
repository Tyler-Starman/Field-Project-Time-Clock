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
    public partial class PrintData : Form
    {
        public PrintData()
        {
            InitializeComponent();
            //Print Preview Stuff
            printDocument1.PrintPage +=
                new PrintPageEventHandler(printDocument1_PrintPage);
            this.printDocument1.DefaultPageSettings.Landscape = true;
        }
        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");

        //Print Preview Stuff
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private PrintDocument printDocument = new PrintDocument();
        private string documentContents;
        private string stringToPrint;

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
                            ON lf.id = cp.id
                            where (select termStart from termInfo) <= ClockIn and ClockIn <= (select termEnd from termInfo);";

            comm.CommandText = sql;
            comm.Connection.Open();

            SqlDataReader sqlReader = comm.ExecuteReader();

            // Change the Encoding to what you need here (UTF8, Unicode, etc)

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("Name".PadRight(20) + "\t" + "Clock In Time".PadRight(30) + "\t" + "Clock Out Times".PadRight(30) + "\t" + "Total Time(Min)" .PadRight(20)+ "\t" + "Total Time(Sec)");
                while (sqlReader.Read())
                {
                    writer.WriteLine(sqlReader["Name"].ToString().PadRight(20) + sqlReader["ClockIn"].ToString().PadRight(30) + "\t" + sqlReader["ClockOut"].ToString().PadRight(30) + "\t" + sqlReader["TotalTimeDay"].ToString().PadRight(16) + "\t\t\t" + sqlReader["TotalTimeSeconds"].ToString().PadLeft(5));
                }


                //writer.WriteLine("Name".PadRight(25) + "\t" + "Clock In Time".PadRight(35) + "\t" + "Clock Out Times        ".PadRight(30) + "\t" + "Total Time(Min)       ".PadRight(10) + "\t" + "Total Time(Sec)");
                //while (sqlReader.Read())
                //{
                //    //writer.WriteLine(sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"]);
                //    writer.WriteLine(sqlReader["Name"].ToString().PadLeft(20) + "\t" + sqlReader["ClockIn"].ToString().PadRight(30) + "\t" + sqlReader["ClockOut"].ToString().PadRight(30) + "\t" + sqlReader["TotalTimeDay"].ToString().PadRight(10) + "\t\t\t" + sqlReader["TotalTimeSeconds"].ToString().PadLeft(30));
                //}
            }

            sqlReader.Close();
            comm.Connection.Close();

            //Print Preview Stuff
            String fName = "ClockedTime.dat";
            ReadDocument(fName);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            //Print Preview Stuff

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
                            where (select termStart from termInfo) <= ClockIn and ClockIn <= (select termEnd from termInfo)
                            Group by lf.Name, lf.ID;";

            comm.CommandText = sql;
            comm.Connection.Open();

            SqlDataReader sqlReader = comm.ExecuteReader();

            // Change the Encoding to what you need here (UTF8, Unicode, etc)

            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine("ID".PadRight(20) + "\t" + "Name".PadRight(26) + "\t" + "Total Days".PadRight(20));
                while (sqlReader.Read())
                {
                    //writer.WriteLine(sqlReader["ClockIn"] + "\t" + sqlReader["ClockOut"]);
                    writer.WriteLine(sqlReader["ID"].ToString().PadRight(20) + "\t" + sqlReader["Name"].ToString().PadRight(20) + "\t" + sqlReader["TotalDays"].ToString().PadLeft(7) + "\t\t" + sqlReader["TotalHours"]);
                }
            }

            sqlReader.Close();
            comm.Connection.Close();

            //Print Preview Stuff
            String fName = "TotalTimes.dat";
            ReadDocument(fName);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            //Print Preview Stuff

            MessageBox.Show("Successfully Printed Out Totals");
        }

        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            new SelectStudents().ShowDialog();
        }


        //Print Preview Stuff
        private void ReadDocument(String filename)
        {
            string docName = ""+filename+"";
            string docPath = AppDomain.CurrentDomain.BaseDirectory;
            printDocument1.DocumentName = docName;
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
