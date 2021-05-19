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

namespace DriversApp
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Drivers;Integrated Security=True"; // \SQLEXPRESS

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Log_in]", sqlConnection);
            
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (true)
                {
                    while (await sqlReader.ReadAsync())
                    {
                        if (User.Text == Convert.ToString(sqlReader["user"]) && Pass.Text == Convert.ToString(sqlReader["pass"]))
                        {
                            Form1.ActiveForm.Visible = false;
                            Form2 frm = new Form2();
                            frm.Show();
                            goto LoopEnd;
                        }
                    }
                        
                    MessageBox.Show("Неверный логин или пароль");
                    break;
                }

            LoopEnd:; 
            }
            catch
            {

            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }


        }

    }
}
