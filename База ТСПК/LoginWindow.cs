using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace База_ТСПК
{
    public partial class LoginWindow : Form
    { 
        public LoginWindow(string Login, string DataSourse, string Password)
        {
            InitializeComponent();
           
            textBox1.Text = DataSourse;
            textBox2.Text = Login;
            textBox3.Text = Password;
            FileStream a1 = new FileStream("setup.txt", FileMode.OpenOrCreate);
            StreamReader SR = new StreamReader(a1);
            textBox1.Text =  SR.ReadLine();
            SR.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalValue.DataBaseSourse = textBox1.Text;
            GlobalValue.Login = textBox2.Text;
            GlobalValue.Password = textBox3.Text;

            GlobalValue.ConnectionStringToDatabase = "Data Source=" + GlobalValue.DataBaseSourse + ";Initial Catalog=TSPK;Persist Security Info=True;User ID=" + GlobalValue.Login + ";Password=" + GlobalValue.Password + ";";
      try
            {   
                SqlConnection dbConn;
                dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                dbConn.Open();
                dbConn.Close();
                MessageBox.Show("Соединение установлено");
                
                MainForm StartPage = new MainForm();
                StartPage.Owner = this; 
                StartPage.Show();
                this.Hide();
                Logs.Write("Вход пользователя:" +  GlobalValue.Login);
                FileStream a1 = new FileStream("setup.txt", FileMode.OpenOrCreate);
                StreamWriter SW = new StreamWriter(a1);
                SW.WriteLine(GlobalValue.DataBaseSourse);
                SW.Close();
          
            }
          catch
            { 
                MessageBox.Show("Неправильные введенные параметры");
                
            }
        }

        private void LoginWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            
            Logs.Write("Выход пользователя:" + GlobalValue.Login);
        }
        
         
    }
}
