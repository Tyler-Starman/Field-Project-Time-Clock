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
    public partial class SearchTimes : Form
    {
        public SearchTimes()
        {
            InitializeComponent();
        }

        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvSearch.DataSource = GetStudentList();
        }

        private DataTable GetStudentList()
        {
            DataTable inStudents = new DataTable();
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT lf.Name, cp.ClockTime, cp.ClockType FROM loginForm lf INNER JOIN ClockPunches cp ON lf.id = cp.id where lf.Name = '" + txtSearch.Text + " '", con);
            SqlDataReader reader = cmd.ExecuteReader();
            inStudents.Load(reader);
            con.Close();
            return inStudents;
        }
    }
}
