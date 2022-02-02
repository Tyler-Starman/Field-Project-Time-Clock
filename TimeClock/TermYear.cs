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
    public partial class TermYear : Form
    {
        public static string term;
        public static string start, end;
        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");
        string termDb;
        public TermYear()
        {
            InitializeComponent();
            
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void TermYear_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand getId = new SqlCommand("Select termYear from termInfo", con);
            
            termDb = getId.ExecuteScalar().ToString();
            con.Close();

            
        }

        private void btnSaveDates_Click(object sender, EventArgs e)
        {
            DateTime startDate, endDate;
            startDate = dtpStartTerm.Value.Date;
            endDate = dtpEndTerm.Value.Date;

            start = startDate.ToString("yyyy/MM/dd");
            end = endDate.ToString("yyyy/MM/dd");

            if (rbtnSpring.Checked)
            {
                term = "Spring";
            } 
            else
            {
                if (rbtnSummer.Checked)
                {
                    term = "Summer";
                }
                else
                {
                    if (rbtnFall.Checked)
                    {
                        term = "Fall";
                    }
                    else
                    {
                        term = "Winter";
                    }
                }
            }
            MessageBox.Show("Data Saved");

            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE termInfo set termStart = '" + start + "', termEnd = '" + end + "', termYear = '" + term + "' WHERE termYear = '" + termDb + "'; ", con);
            cmd.ExecuteNonQuery();
            con.Close(); 

        }
    }
}
