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
using WindowsFormsApp1;

namespace DriversApp
{
    public partial class Form2 : Form
    {
 
        SqlConnection sqlConnection;
        public Form2()
        {
            InitializeComponent();
        }
        private async void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Drivers;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Amogus]", sqlConnection);

            List<string[]> data = new List<string[]>();

            try
            {
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
            dataGridView1.Columns.Add("column", "ID");
            dataGridView1.Columns.Add("column", "Имя");
            dataGridView1.Columns.Add("column", "Отчество");
            dataGridView1.Columns.Add("column", "Паспорт");
            dataGridView1.Columns.Add("column", "Индекс");
            dataGridView1.Columns.Add("column", "Адрес");
            dataGridView1.Columns.Add("column", "Город");
            dataGridView1.Columns.Add("column", "Компания");
            dataGridView1.Columns.Add("column", "Должность");
            dataGridView1.Columns.Add("column", "Телефон");
            dataGridView1.Columns.Add("column", "Почта");
            dataGridView1.Columns.Add("column", "Фото");

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewPerson frm = new NewPerson();
            frm.Show(this);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Drivers;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [Amogus]", sqlConnection);

            List<string[]> data = new List<string[]>();

            try
            {
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

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [Amogus] WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox1.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
                MessageBox.Show("ID не введён");
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show(this);
        }
    }
}
