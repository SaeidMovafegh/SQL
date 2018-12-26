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

namespace SqlTest
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string conString = "data source=NIRA-LAB; initial catalog = shamsipour_db2; integrated security = True; MultipleActiveResultSets = True;";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
                //
                // SqlCommand should be created inside using.
                // ... It receives the SQL statement.
                // ... It receives the connection object.
                // ... The SQL text works with a specific database.
                //
                using (SqlCommand command = new SqlCommand(
                    "select * from person;",
                    connection))
                {
                    //
                    // Instance methods can be used on the SqlCommand.
                    // ... These read data.
                    //
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //MessageBox.Show("Data inserted");
                        //txtFirstName.Text = "";
                        //txtLastName.Text = "";
                        //txtNid.Text = "";
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                txtResult.Text += reader.GetValue(i);
                                txtResult.Text += ",";
                            }
                            txtResult.Text += "\n";
                        }
                    }
                }
            }
        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
