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
    public partial class ReloginUserAdd : Form
    {
        public ReloginUserAdd(string Login, string DataSourse, string Password)
        {
            InitializeComponent();
            textBox1.Text = DataSourse;
            textBox2.Text = Login;
            textBox3.Text = Password;
        }

        private void ReloginUserAdd_Load(object sender, EventArgs e)
        {

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
                Logs.Write("Вход пользователя:" + GlobalValue.Login);

            }
            catch
            {
                MessageBox.Show("Неправильные введенные параметры");

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                button1.Enabled = false;
                textBox1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
            }

            else 
            {
                button1.Enabled = true;
                textBox1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbConn1;
                dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                var cmd = new SqlCommand("use TSPK create login " + textBox2.Text + " with password = '" + textBox3.Text + "' create user " + textBox2.Text + " for login " + textBox2.Text + " grant select on dbo.TSPK to " + textBox2.Text + " grant select on dbo.Documents to " + textBox2.Text + " grant select on dbo.Komplektnost to " + textBox2.Text + " grant select on dbo.NameTSPK to " + textBox2.Text + " grant select on dbo.RepairDocuments to " + textBox2.Text + " grant select on dbo.Vocabulary_Podrazdelenie to " + textBox2.Text + " grant select on dbo.Vocabulary_PU to " + textBox2.Text + " grant select on dbo.Vocabulary_PunktPropuska  to " + textBox2.Text + " grant update on dbo.TSPK to " + textBox2.Text + " grant select on dbo.RashodMat  to " + textBox2.Text + " grant select on dbo.Ostatok  to " + textBox2.Text + "", dbConn1);
               // cmd.Parameters.AddWithValue("@Username", textBox2.Text);
               // cmd.Parameters.AddWithValue("@password", textBox3.Text.);
                dbConn1.Open();
                cmd.ExecuteNonQuery();
                dbConn1.Close();
                MessageBox.Show("Новый пользователь успешно создан");
                Logs.Write("Добавление Пользователя с правами рядового пользователя:" + textBox2.Text);
            }
            catch 
            { MessageBox.Show("Новый пользователь не создан, возможно пользователь c таким именем уже существует \n P.S. Добавление пользователей возможно только под учетной записью Администратора приложения");
            }

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Создать пользователя для просмотра базы данных ТСПК без права добавления ТСПК",button2);

        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Создать администратора с правами добавления ТСПК, редактирования справочников, документов,комплектности и тд.",button3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                SqlConnection dbConn1;
                dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                var cmd = new SqlCommand("use TSPK create login " + textBox2.Text + " with password = '" + textBox3.Text + "' create user " + textBox2.Text + " for login " + textBox2.Text + " EXEC sys.sp_addsrvrolemember @loginame = N'" + textBox2.Text + "', @rolename = N'sysadmin'" , dbConn1);
                                        //  use TSPK create login noo                   with password =      'allstars'         create user        noo            for login       noo             EXEC sys.sp_addsrvrolemember @loginame = N'noo', @rolename = N'sysadmin'
                dbConn1.Open();
                cmd.ExecuteNonQuery();
                dbConn1.Close();
                MessageBox.Show("Новый Админ успешно создан");
                Logs.Write("Добавление Пользователя с правами администратора:" + textBox2.Text);
            }
            catch
            {
                MessageBox.Show("Новый пользователь не создан, возможно пользователь c таким именем уже существует \n P.S. Добавление пользователей возможно только под учетной записью приложения");
            }
        }
    }
}
