using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace otdelkadrov
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            textBox2.PasswordChar = '♦';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            
            // Проверка логина
            if (username == "admin")
            {
                // Открыть форму для администратора
                Form1 form1 = new Form1();
                form1.Show();

                
            }
            else if (username == "user")
            {
                // Открыть форму для обычного пользователя
                Form2 Form2 = new Form2();
                Form2.Show();

                
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
