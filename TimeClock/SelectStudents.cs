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
    public partial class SelectStudents : Form
    {
        public SelectStudents()
        {
            InitializeComponent();
            //SqlConnection con = new SqlConnection(Conn);
            //con.Open();
            //DataSet ds = new DataSet();
            //SqlDataAdapter adapter = new SqlDataAdapter(
            //"SELECT name from loginform", con);
            //adapter.Fill(ds);
            //this.lvStudentNames.DataSource = ds.Tables[0];
            //this.lvStudentNames.DisplayMember = "name";
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
            foreach(ListViewItem selectedItem in lvStudentNames.SelectedItems)
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

        private void lvStudentNames_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
