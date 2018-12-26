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

namespace SqlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

            //
            // The program accesses the connection string.
            // ... It uses it on a connection.
            //
            string conString = "Data Source=130.185.73.100; Initial Catalog=NGO-MIS;User ID=sa;Password=adldoost@2015";
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
                    "select * from const_CodeYegan;",
                    connection))
                {
                    //
                    // Instance methods can be used on the SqlCommand.
                    // ... These read data.
                    //
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                String s = reader.GetValue(i).ToString();
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            // The program accesses the connection string.
            // ... It uses it on a connection.
            //
            string conString = "Data Source=130.185.73.100; Initial Catalog=NGO-MIS;User ID=sa;Password=adldoost@2015";
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
                    "insert into const_CodeYegan(Code, Name) values('" + txtName.Text + "', '" + txtLastName.Text + "');",
                    connection))
                {
                    //
                    // Instance methods can be used on the SqlCommand.
                    // ... These read data.
                    //
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.WriteLine(reader.GetValue(i));
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }

        }
    }
}
