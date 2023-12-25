using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using otdelkadrov.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace otdelkadrov
{
    public partial class Form2 : Form
    {
        private int selectedRowIndex = -1; // Переменная для хранения индекса выбранной строки в DataGridView

        public Form2()
        {
            InitializeComponent();
            button2.Click += button2_Click_1;
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox21_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            Employee employee = new Employee();

            // Личные данные
            employee.Surname = textBox6.Text;
            employee.Name = textBox7.Text;
            employee.FatherName = textBox8.Text;
            employee.BirthDay = textBox9.Text;
            employee.PhoneNumber = textBox16.Text;
            employee.BankCardNumber = textBox17.Text;

            // Паспортные данные
            employee.PassSerial = textBox1.Text;
            employee.PassNumber = textBox2.Text;
            employee.DepartmentNumber = textBox3.Text;
            employee.IssueDate = textBox4.Text;
            employee.IssuedBy = textBox5.Text;

            // Зарегистрирован
            employee.Country = textBox14.Text;
            employee.State = textBox13.Text;
            employee.City = textBox12.Text;
            employee.Street = textBox11.Text;
            employee.House = textBox10.Text;
            employee.Flat = textBox15.Text;

            // Трудовая деятельность
            employee.EmploymentDate = textBox19.Text;
            employee.Rate = textBox18.Text;

            employee.Photo = textBox23.Text;

            try
            {
                DataBase dataBase = new DataBase();
                dataBase.AddNewEmpoloyee(employee);

                MessageBox.Show("Данные успешно сохранены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка. Тип исключения: {ex.Message}");
                throw;
            }
        }

  

        private void button3_Click(object sender, EventArgs e)
        {
      
            LoadDataFromDatabase();
        }


        private void textBox22_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox22_TextChanged_1(object sender, EventArgs e)
        {

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Заполняем TextBox значениями из выбранной строки
                textBox6.Text = selectedRow.Cells["FAMILIYA"].Value.ToString();
                textBox7.Text = selectedRow.Cells["IMYA"].Value.ToString();
                textBox8.Text = selectedRow.Cells["OTCHESTVO"].Value.ToString();
                textBox9.Text = selectedRow.Cells["DATAROZHDENIYA"].Value.ToString();
                textBox16.Text = selectedRow.Cells["NOMERTELEPHONA"].Value.ToString();
                textBox17.Text = selectedRow.Cells["NOMERBANKOVSKOYKARTI"].Value.ToString();
                textBox1.Text = selectedRow.Cells["SERIYA"].Value.ToString();
                textBox2.Text = selectedRow.Cells["NOMER"].Value.ToString();
                textBox3.Text = selectedRow.Cells["NOMERPODRAZDELENIYA"].Value.ToString();
                textBox14.Text = selectedRow.Cells["STRANA"].Value.ToString();
                textBox13.Text = selectedRow.Cells["OBLAST"].Value.ToString();
                textBox12.Text = selectedRow.Cells["GOROD"].Value.ToString();
                textBox11.Text = selectedRow.Cells["ULICA"].Value.ToString();
                textBox10.Text = selectedRow.Cells["DOM"].Value.ToString();
                textBox15.Text = selectedRow.Cells["KVARTIRA"].Value.ToString();
                textBox4.Text = selectedRow.Cells["KOGDAVIDAN"].Value.ToString();
                textBox5.Text = selectedRow.Cells["KEMVIDAN"].Value.ToString();
                textBox19.Text = selectedRow.Cells["DATAPRIEMANARABOTU"].Value.ToString();
                textBox18.Text = selectedRow.Cells["ZARPLATA"].Value.ToString();
                textBox23.Text = selectedRow.Cells["PHOTO"].Value.ToString();
            }
        }
        private void LoadDataFromDatabase(string searchLastName = "")
        {
            string connectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";
            string query = "SELECT " +
                "SOTRUDNIKI.PHOTO, SOTRUDNIKI.ID_SOTRUDNIKA, SOTRUDNIKI.FAMILIYA, SOTRUDNIKI.IMYA, SOTRUDNIKI.OTCHESTVO, " +
                "SOTRUDNIKI.DATAROZHDENIYA, SOTRUDNIKI.NOMERTELEPHONA, SOTRUDNIKI.NOMERBANKOVSKOYKARTI, " +
                "PASPORT.SERIYA AS SERIYA, PASPORT.NOMER AS NOMER, PASPORT.KEMVIDAN AS KEMVIDAN, " +
                "PASPORT.KOGDAVIDAN AS KOGDAVIDAN, PASPORT.NOMERPODRAZDELENIYA AS NOMERPODRAZDELENIYA, " +
                "PROPISKA.STRANA AS STRANA, PROPISKA.OBLAST AS OBLAST, PROPISKA.GOROD AS GOROD, PROPISKA.ULICA AS ULICA, PROPISKA.DOM AS DOM, PROPISKA.KVARTIRA AS KVARTIRA, DOLJNOST.NAZVANIEDOLJNOSTI AS NAZVANIEDOLJNOSTI, TRUDOVAYADEYATELNOST.DATAPRIEMANARABOTU as DATAPRIEMANARABOTU, TRUDOVAYADEYATELNOST.ZARPLATA as ZARPLATA " +
                "FROM SOTRUDNIKI " +
                "INNER JOIN PASPORT ON SOTRUDNIKI.ID_PASPORTA = PASPORT.ID_PASPORTA " +
                "INNER JOIN PROPISKA ON SOTRUDNIKI.ID_PROPISKI = PROPISKA.ID_PROPISKI " + 
                "INNER JOIN TRUDOVAYADEYATELNOST ON SOTRUDNIKI.ID_TRUDOVOYDEYATELNOSTI = TRUDOVAYADEYATELNOST.ID_TRUDOVOYDEYATELNOSTI " + 
                "INNER JOIN DOLJNOST ON TRUDOVAYADEYATELNOST.ID_DOLJNOSTI = DOLJNOST.ID_DOLJNOSTI " + 
                "INNER JOIN OTDEL ON TRUDOVAYADEYATELNOST.ID_OTDELA = OTDEL.ID_OTDELA " +
                 $"WHERE SOTRUDNIKI.FAMILIYA LIKE '%{searchLastName}%'"; ;

            using (FbConnection connection = new FbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (FbCommand command = new FbCommand(query, connection))
                    {

                        using (FbDataAdapter adapter = new FbDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;

                            // Изменение названий столбцов
                            dataGridView1.Columns["PHOTO"].Visible = false;
                            dataGridView1.Columns["ID_SOTRUDNIKA"].Visible = false;
                            dataGridView1.Columns["FAMILIYA"].HeaderText = "Фамилия";
                            dataGridView1.Columns["IMYA"].HeaderText = "Имя";
                            dataGridView1.Columns["OTCHESTVO"].HeaderText = "Отчество";
                            dataGridView1.Columns["DATAROZHDENIYA"].HeaderText = "Дата рождения";
                            dataGridView1.Columns["NOMERTELEPHONA"].HeaderText = "Номер телефона";
                            dataGridView1.Columns["NOMERBANKOVSKOYKARTI"].HeaderText = "Номер банковской карты";
                            dataGridView1.Columns["SERIYA"].HeaderText = "Серия паспорта";
                            dataGridView1.Columns["NOMER"].HeaderText = "Номер паспорта";
                            dataGridView1.Columns["KEMVIDAN"].HeaderText = "Кем выдан";
                            dataGridView1.Columns["KOGDAVIDAN"].HeaderText = "Когда выдан";
                            dataGridView1.Columns["NOMERPODRAZDELENIYA"].HeaderText = "Номер подразделения";
                            dataGridView1.Columns["STRANA"].HeaderText = "Страна";
                            dataGridView1.Columns["OBLAST"].HeaderText = "Область";
                            dataGridView1.Columns["GOROD"].HeaderText = "Город";
                            dataGridView1.Columns["ULICA"].HeaderText = "Улица";
                            dataGridView1.Columns["DOM"].HeaderText = "Дом";
                            dataGridView1.Columns["KVARTIRA"].HeaderText = "Квартира";
                            dataGridView1.Columns["NAZVANIEDOLJNOSTI"].HeaderText = "Должность";
                            dataGridView1.Columns["DATAPRIEMANARABOTU"].HeaderText = "Дата приема на работу";
                            dataGridView1.Columns["ZARPLATA"].HeaderText = "Зарплата";

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных из базы данных: {ex.Message}");
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Получаем значение ячейки с путем к изображению
                string imagePath = dataGridView1.Rows[e.RowIndex].Cells["PHOTO"].Value.ToString();

                // Загружаем изображение в pictureBox1
                if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                {
                    // Устанавливаем свойство SizeMode, чтобы фото полностью умещалось в PictureBox
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

                    pictureBox1.Image = Image.FromFile(imagePath);
                }
                else
                {
                    // Если путь к изображению недействителен, можно сбросить pictureBox1
                    pictureBox1.Image = null;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";
            string query = "SELECT FAMILIYA, IMYA, OTCHESTVO, DATAROZHDENIYA, NOMERTELEPHONA, NOMERBANKOVSKOYKARTI FROM SOTRUDNIKI";

            using (FbConnection connection = new FbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (FbCommand command = new FbCommand(query, connection))
                    {
                        using (FbDataAdapter adapter = new FbDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;

                            // Изменение названий столбцов
                            dataGridView1.Columns["ID_SOTRUDNIKA"].HeaderText = "ID";
                            dataGridView1.Columns["FAMILIYA"].HeaderText = "Фамилия";
                            dataGridView1.Columns["IMYA"].HeaderText = "Имя";
                            dataGridView1.Columns["OTCHESTVO"].HeaderText = "Отчество";
                            dataGridView1.Columns["DATAROZHDENIYA"].HeaderText = "Дата рождения";
                            dataGridView1.Columns["NOMERTELEPHONA"].HeaderText = "Номер телефона";
                            dataGridView1.Columns["NOMERBANKOVSKOYKARTI"].HeaderText = "Номер банковской карты";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных из базы данных: {ex.Message}");
                }
            }
        }
        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Обработчик кнопки
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем ID первой выбранной строки (если есть несколько)
                int selectedRecordID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_SOTRUDNIKA"].Value);

                // Удаляем запись из базы данных
                DeleteRecordFromDatabase(selectedRecordID);

                // Удаляем выбранные строки из DataGridView
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }

                MessageBox.Show("Запись успешно удалена.");
            }
        }

        private void DeleteRecordFromDatabase(int recordID)
        {
            string connectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";
            string query = "DELETE FROM SOTRUDNIKI WHERE ID_SOTRUDNIKA = @recordID";

            using (FbConnection connection = new FbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (FbCommand command = new FbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@recordID", recordID);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении записи из базы данных: {ex.Message}");
                }
            }
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged_1(object sender, EventArgs e)
        {

        }
       
        private void textBox22_TextChanged_2(object sender, EventArgs e)
        {
            LoadDataFromDatabase(textBox22.Text);
        }

        private void UpdateRecordInDatabase(int recordID)
        {
            string connectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";

            try
            {
                string query = "UPDATE SOTRUDNIKI SET " +
                    "FAMILIYA = @Surname, IMYA = @Name, OTCHESTVO = @FatherName, " +
                    "DATAROZHDENIYA = @BirthDay, NOMERTELEPHONA = @PhoneNumber, " +
                    "NOMERBANKOVSKOYKARTI = @BankCardNumber, " +
                    "ID_PASPORTA = (SELECT FIRST 1 ID_PASPORTA FROM PASPORT WHERE SERIYA = @PassSerial AND NOMER = @PassNumber), " +
                    "ID_PROPISKI = (SELECT FIRST 1 ID_PROPISKI FROM PROPISKA WHERE STRANA = @Country AND OBLAST = @State AND GOROD = @City AND ULICA = @Street AND DOM = @House AND KVARTIRA = @Flat), " +
                    "ID_TRUDOVOYDEYATELNOSTI = (SELECT FIRST 1 ID_TRUDOVOYDEYATELNOSTI FROM TRUDOVAYADEYATELNOST WHERE DATAPRIEMANARABOTU = @EmploymentDate AND ZARPLATA = @Rate) " +
                    "WHERE ID_SOTRUDNIKA = @RecordID";

                using (FbConnection connection = new FbConnection(connectionString))
                {
                    connection.Open();
                    using (FbCommand command = new FbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Surname", textBox6.Text);
                        command.Parameters.AddWithValue("@Name", textBox7.Text);
                        command.Parameters.AddWithValue("@FatherName", textBox8.Text);
                        command.Parameters.AddWithValue("@BirthDay", textBox9.Text);
                        command.Parameters.AddWithValue("@PhoneNumber", textBox16.Text);
                        command.Parameters.AddWithValue("@BankCardNumber", textBox17.Text);
                        command.Parameters.AddWithValue("@PassSerial", textBox1.Text);
                        command.Parameters.AddWithValue("@PassNumber", textBox2.Text);
                        command.Parameters.AddWithValue("@DepartmentNumber", textBox3.Text);
                        command.Parameters.AddWithValue("@IssueDate", textBox4.Text);
                        command.Parameters.AddWithValue("@IssuedBy", textBox5.Text);
                        command.Parameters.AddWithValue("@Country", textBox14.Text);
                        command.Parameters.AddWithValue("@State", textBox13.Text);
                        command.Parameters.AddWithValue("@City", textBox12.Text);
                        command.Parameters.AddWithValue("@Street", textBox11.Text);
                        command.Parameters.AddWithValue("@House", textBox10.Text);
                        command.Parameters.AddWithValue("@Flat", textBox15.Text);
                        command.Parameters.AddWithValue("@EmploymentDate", textBox19.Text);
                        command.Parameters.AddWithValue("@Rate", textBox18.Text);
                        command.Parameters.AddWithValue("@Photo", textBox23.Text);
                        command.Parameters.AddWithValue("@RecordID", recordID);

                        command.ExecuteNonQuery();
                    }
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при изменении записи: " + ex.Message);
            }
        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            // Обработчик кнопки
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Получаем ID первой выбранной строки (если есть несколько)
                int selectedRecordID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID_SOTRUDNIKA"].Value);

                // Вызываем метод для обновления записи в базе данных
                UpdateRecordInDatabase(selectedRecordID);

                MessageBox.Show("Запись успешно изменена.");

            }
        }
        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}