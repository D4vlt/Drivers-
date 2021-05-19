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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewPerson2 frm = new NewPerson2();
            frm.Show();
        }

        SqlConnection sqlConnection;

        private async void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=localhost;Initial Catalog=Drivers;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [licence]", sqlConnection);

            List<string[]> data = new List<string[]>();

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    data.Add(new string[24]);

                    for (int i = 0; i < 24; i++)
                    {
                        data[data.Count - 1][i] = sqlReader[i].ToString();
                    }

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
            dataGridView1.Columns.Add("column", "Дата лизенции");
            dataGridView1.Columns.Add("column", "Годен до");
            dataGridView1.Columns.Add("column", "Категория");
            dataGridView1.Columns.Add("column", "Серия лицензии");
            dataGridView1.Columns.Add("column", "Лицензионный номер");
            dataGridView1.Columns.Add("column", "Статус");
            dataGridView1.Columns.Add("column", "VIN");
            dataGridView1.Columns.Add("column", "Монуфактура");
            dataGridView1.Columns.Add("column", "Модель");
            dataGridView1.Columns.Add("column", "Год");
            dataGridView1.Columns.Add("column", "Масса");
            dataGridView1.Columns.Add("column", "Цвет");
            //dataGridView1.Columns.Add("column", "Тип двигателя");
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=Drivers;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [licence]", sqlConnection);

            List<string[]> data = new List<string[]>();

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    data.Add(new string[12]);

                    for (int i = 0; i < 24; i++)
                    {
                        data[data.Count - 1][i] = sqlReader[i].ToString();
                    }

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
                SqlCommand command = new SqlCommand("DELETE FROM [licence] WHERE [id]=@id", sqlConnection);

                command.Parameters.AddWithValue("id", textBox1.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
                MessageBox.Show("ID не введён");
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show(this);
        }

        private void PicSave_Click(object sender, EventArgs e)
        {
            Image a = Image.FromFile(@"C:\Users\ToPzSpAyWin10\Desktop\vsDB\vsDB\DriversApp\Resources\driver_license_template.jpg"); //получаем исходное изображение из файла 
            Graphics part2 = Graphics.FromImage(a); //получаем его часть
            part2.DrawString("ЛАДНО \nТЕКСТ\n\nА в чём мем?\n\nПотом обьясню\n\nок",
            new System.Drawing.Font("Arial", 24, FontStyle.Bold),
            new SolidBrush(Color.Black), new RectangleF(370, 275, 0, 340),
            new StringFormat(StringFormatFlags.NoWrap)); // наносим на эту часть текст с параметрами
            //graphics.DrawImage(Image.FromFile(image1), 0, 0, result.Width, result.Height);
            Image img = Image.FromFile("photo//002-cool-5.png");
            part2.DrawImage(img, 80, 265, img.Width / 3, img.Height / 3);
            a.Save("test2.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);//записываем получающееся изображение в файл 
        }
    }
}
