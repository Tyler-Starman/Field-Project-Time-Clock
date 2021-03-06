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
    public partial class ClockedOut : Form
    {
        public ClockedOut()
        {
            InitializeComponent();
        }
        string Conn = ("Data Source=localhost\\SQLEXPRESS; Initial Catalog=TimeClock; Integrated Security=true;");
        private void ClockedOut_Load(object sender, EventArgs e)
        {
            dgvClockedOut.DataSource = GetStudentList();
        }

        private DataTable GetStudentList()
        {
            DataTable inStudents = new DataTable();
            SqlConnection con = new SqlConnection(Conn);
            con.Open();
            SqlCommand cmd = new SqlCommand("select Name, ClockStatus from loginForm where ClockStatus = 'No'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            inStudents.Load(reader);
            con.Close();

            return inStudents;
        }
    }
}
