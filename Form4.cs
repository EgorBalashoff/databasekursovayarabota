using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otdelkadrov
{
    public partial class Form4 : Form
    {
        string ConnectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пользователь зарегистрирован!");

        }


        private void SaveUserCredentials(string login, string hashedPassword, string flashcard)
        {
            using (FbConnection connection = new FbConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Создать команду для выполнения SQL-запроса
                    FbCommand command = new FbCommand("INSERT INTO ID (LOGIN, PASSWORD, flashcard) VALUES (@LOGIN, @PASSWORD)", connection);
                    command.Parameters.AddWithValue("@Login", login);

                    // Выполнить команду
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении логина и пароля: {ex.Message}");
                }
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}