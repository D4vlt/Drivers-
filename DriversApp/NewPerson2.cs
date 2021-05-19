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
using DriversApp;


namespace DriversApp
{
    public partial class NewPerson2 : Form
    {
        SqlConnection sqlConnection;
        public NewPerson2()
        {
            InitializeComponent();
        }

        private int parsedID;
        private bool IsCustomerNameValid()
        {
            bool chk = true;

            foreach (Control c in Controls)
            {
                foreach (Control d in c.Controls)
                    if (d.GetType() == typeof(TextBox))
                        if (d.Text == "")
                        {
                            MessageBox.Show("Please enter a data.");
                            chk = false;
                        }       
            }
            
            return chk;

        }


        private void ClearForm()
        {
            foreach (Control c in Controls)
            {
                foreach (Control d in c.Controls)
                    if (d.GetType() == typeof(TextBox))
                        d.Text = "";

            }



            txtCustomerID.Clear();
            this.parsedID = 0;
        }


        public async void btnCreateAccount_Click(object sender, EventArgs e)
        {

        

            if (IsCustomerNameValid())
            {
                string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Drivers;Integrated Security=True";

                sqlConnection = new SqlConnection(connectionString);

                await sqlConnection.OpenAsync();

                SqlDataReader sqlReader = null;

                SqlCommand command = new SqlCommand("SET IDENTITY_INSERT licence ON INSERT  INTO [licence] (id, name, middlename, passport, postcode, address, address_life, company, jobname, phone, email, photo, licence_date, expire_date, categories, licence_series, licence_number, Status, VIN, Manufacturer, Model_Year, Weight, Color, Engine_Type, type_of_drive)VALUES((SELECT MAX(id) +1 FROM Amogus), @name, @middlename, @passport, @postcode, @address, @address_life, @company, @jobname, @phone, @email, @photo, @licence_date, @expire_date, @categories, @licence_series, @licence_number, @Status, @VIN, @Manufacturer, @Model_Year, @Weight, @Color, @Engine_Type, @type_of_drive) ", sqlConnection);
                //SqlCommand DBCount = new SqlCommand("SELECT COUNT(*) FROM dbo.Amogus", sqlConnection);
                
                //command.Parameters.AddWithValue("id", (int)DBCount.ExecuteScalar()+1);
                command.Parameters.AddWithValue("name", textBox2.Text);
                command.Parameters.AddWithValue("middlename", textBox3.Text);
                command.Parameters.AddWithValue("passport", textBox4.Text);
                command.Parameters.AddWithValue("postcode", textBox5.Text);
                command.Parameters.AddWithValue("address", textBox6.Text);
                command.Parameters.AddWithValue("city", textBox7.Text);
                command.Parameters.AddWithValue("company", textBox8.Text);
                command.Parameters.AddWithValue("jobname", textBox9.Text);
                command.Parameters.AddWithValue("phone", textBox10.Text);
                command.Parameters.AddWithValue("email", textBox11.Text);
                command.Parameters.AddWithValue("photo", textBox1.Text);

                List<string[]> data = new List<string[]>();

                try
                {
                    MessageBox.Show("Добавлено успешно");

                    sqlReader = await command.ExecuteReaderAsync();

                    while (await sqlReader.ReadAsync())
                    {
                        data.Add(new string[12]);

                        data[data.Count - 1][0] = sqlReader[0].ToString();
                        data[data.Count - 1][1] = sqlReader[1].ToString();
                        data[data.Count - 1][2] = sqlReader[2].ToString();
                        data[data.Count - 1][3] = sqlReader[3].ToString();
                        data[data.Count - 1][4] = sqlReader[4].ToString();
                        data[data.Count - 1][5] = sqlReader[5].ToString();
                        data[data.Count - 1][6] = sqlReader[6].ToString();
                        data[data.Count - 1][7] = sqlReader[7].ToString();
                        data[data.Count - 1][8] = sqlReader[8].ToString();
                        data[data.Count - 1][9] = sqlReader[9].ToString();
                        data[data.Count - 1][10] = sqlReader[10].ToString();
                        data[data.Count - 1][11] = sqlReader[11].ToString();


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }


            }
        }

        private void btnAddAnotherAccount_Click(object sender, EventArgs e)
        {
            this.ClearForm();
        }

    }
}
