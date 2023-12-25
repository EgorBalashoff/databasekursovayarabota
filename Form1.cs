using System;
using System.Management;
using System.Windows.Forms;
using System.Collections.Generic;
using FirebirdSql.Data.FirebirdClient;
using System.Security.Cryptography;
using System.Text;

namespace otdelkadrov
{
    public partial class Form1 : Form
    {

        private FbConnection connection; // Соединение с базой данных IBExpert
       
        
        

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string ConnectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";
            connection = new FbConnection(ConnectionString);
            
        }

       

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 form4 = new Form2();
            form4.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
