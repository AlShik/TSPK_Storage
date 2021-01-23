using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace База_ТСПК
{
    public partial class AddPartsofTSPK : Form
    {
        public AddPartsofTSPK()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = false;
            }
            else
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = false;
                button3.Enabled = true;
            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection dbConn1;
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase); // dbConn1 = new SqlConnection ("Data Source=WIN-TVNE764OSJI;Initial Catalog=TSPK;Persist Security Info=True;User ID=sa;Password=allstars;");


            var cmd = new SqlCommand("INSERT INTO dbo.Komplektnost (НомерТСПКвБазе, СоставнаяЧасть, НомерСоставнойЧасти ) VALUES ( @NomervBD, @SostavnayaChast, @NomerSostavnoiChasti)", dbConn1);
            cmd.Connection = dbConn1;
            cmd.Parameters.AddWithValue("@NomervBD", GlobalValue.ID);
            cmd.Parameters.AddWithValue("@SostavnayaChast", textBox1.Text);
            cmd.Parameters.AddWithValue("@NomerSostavnoiChasti", textBox2.Text);


            try
            {
                dbConn1.Open();
                cmd.ExecuteNonQuery();

                MessageBox.Show("Составная часть ТСПК Добавлена в Базу, для добавления \nследующей составной части нажмите \"ОК\" и воспользуйтесь \nпредыдущим меню еще раз. ");
                Logs.Write("Добавление комплектности ТСПК№" + GlobalValue.ID + " составная часть=" + textBox1.Text +"№составной части"+ textBox2.Text);
                dbConn1.Close();
                textBox1.Clear();
                textBox2.Clear();

            }
            catch
            {
                MessageBox.Show("Ошибка, проверьте правильность ввода");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ТСПК и комплектность успешно добавлены");
            this.Close();
            Owner.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ТСПК и комплектность успешно добавлены");
            this.Close();
            Owner.Close();
        }
                
        }
    }

