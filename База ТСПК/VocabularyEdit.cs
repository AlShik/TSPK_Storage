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
    public partial class VocabularyEdit : Form
    {
        public VocabularyEdit()
        {
            InitializeComponent();
        }

        private void VocabularyEdit_Load(object sender, EventArgs e)
        {
            try
            // TODO: данная строка кода позволяет загрузить данные в таблицу "rashodMat._RashodMat". При необходимости она может быть перемещена или удалена.
            {
                this.rashodMatTableAdapter.Fill(this.rashodMat._RashodMat);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet1.NameTSPK". При необходимости она может быть перемещена или удалена.
                this.nameTSPKTableAdapter.Fill(this.tSPKDataSet1.NameTSPK);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_Podrazdelenie". При необходимости она может быть перемещена или удалена.
                this.vocabulary_PodrazdelenieTableAdapter.Fill(this.tSPKDataSet.Vocabulary_Podrazdelenie);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_PunktPropuska_". При необходимости она может быть перемещена или удалена.
                this.vocabulary_PunktPropuska_TableAdapter.Fill(this.tSPKDataSet.Vocabulary_PunktPropuska_);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_PU". При необходимости она может быть перемещена или удалена.

                this.vocabulary_PUTableAdapter.Fill(this.tSPKDataSet.Vocabulary_PU);
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
                this.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Vocabulary_PU ([ПУ]) VALUES (@namePU)", dbconn);
                cmd.Parameters.AddWithValue("@namePU", textBox1.Text);
                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();
              //  MessageBox.Show("Добавлено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
            this.vocabulary_PUTableAdapter.Fill(this.tSPKDataSet.Vocabulary_PU);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Vocabulary_PU WHERE  ПУ ='"+ dataGridView1.CurrentCell.Value.ToString() + "'" , dbconn);
                
                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();
                MessageBox.Show("Удалено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
            this.vocabulary_PUTableAdapter.Fill(this.tSPKDataSet.Vocabulary_PU);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Vocabulary_PunktPropuska  WHERE  PunktPropuska ='" + dataGridView2.CurrentCell.Value.ToString() + "'", dbconn);

                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();
                MessageBox.Show("Удалено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
            this.vocabulary_PunktPropuska_TableAdapter.Fill(this.tSPKDataSet.Vocabulary_PunktPropuska_);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Vocabulary_PunktPropuska (PunktPropuska) VALUES (@nameP)", dbconn);
                cmd.Parameters.AddWithValue("@nameP", textBox2.Text);
                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();
               // MessageBox.Show("Добавлено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
            this.vocabulary_PunktPropuska_TableAdapter.Fill(this.tSPKDataSet.Vocabulary_PunktPropuska_);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Vocabulary_Podrazdelenie  WHERE  Podrazdelenie ='" + dataGridView3.CurrentCell.Value.ToString() + "'", dbconn);

                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();
                MessageBox.Show("Удалено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
            this.vocabulary_PodrazdelenieTableAdapter.Fill(this.tSPKDataSet.Vocabulary_Podrazdelenie);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.Vocabulary_Podrazdelenie (Podrazdelenie) VALUES (@nameP)", dbconn);
                cmd.Parameters.AddWithValue("@nameP", textBox3.Text);
                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();
                // MessageBox.Show("Добавлено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            } this.vocabulary_PodrazdelenieTableAdapter.Fill(this.tSPKDataSet.Vocabulary_Podrazdelenie);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("DELETE FROM dbo.NameTSPK  WHERE  Name ='" + dataGridView4.CurrentCell.Value.ToString() + "'", dbconn);

                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();
                MessageBox.Show("Удалено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
            this.nameTSPKTableAdapter.Fill(this.tSPKDataSet1.NameTSPK);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.NameTSPK (Name) VALUES (@nameP)", dbconn);
                cmd.Parameters.AddWithValue("@nameP", textBox4.Text);
                dbconn.Open();
                cmd.ExecuteNonQuery();
                dbconn.Close();
                // MessageBox.Show("Добавлено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            } this.nameTSPKTableAdapter.Fill(this.tSPKDataSet1.NameTSPK);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand cmd = new SqlCommand("INSERT INTO dbo.RashodMat ([НаименованиеТСПК], [РасходныйМатериал]) VALUES (@name, @mat)", dbconn);
                SqlCommand cmd1 = new SqlCommand("INSERT INTO  dbo.Ostatok (РасходныйМатериал) VALUES (@mat)", dbconn);
                cmd.Parameters.AddWithValue("@name", comboBox1.Text);
                cmd.Parameters.AddWithValue("@mat", textBox5.Text);
                cmd1.Parameters.AddWithValue("@mat", textBox5.Text);
                dbconn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                dbconn.Close();
                  MessageBox.Show("Добавлено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
            
            this.rashodMatTableAdapter.Fill(this.rashodMat._RashodMat);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                string strr = "DELETE FROM dbo.RashodMat WHERE  НаименованиеТСПК ='" + dataGridView5[0, dataGridView5.CurrentRow.Index].Value.ToString() + "' and РасходныйМатериал = '" + dataGridView5[1, dataGridView5.CurrentRow.Index].Value.ToString() + "'";
                string strr1 = "DELETE FROM dbo.Ostatok WHERE  РасходныйМатериал ='" + dataGridView5[1, dataGridView5.CurrentRow.Index].Value.ToString() + "'";
                SqlCommand cmd = new SqlCommand(strr,dbconn);
                SqlCommand cmd1 = new SqlCommand(strr1, dbconn);
                dbconn.Open();
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                dbconn.Close();
                MessageBox.Show("Удалено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
            
            this.rashodMatTableAdapter.Fill(this.rashodMat._RashodMat);
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd2 = new SqlCommand("select Name from dbo.NameTSPK", dbConn1);
            dbConn1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            DataSet dataset = new DataSet();
            // adapter.TableMappings.Add("1","2");
            adapter.SelectCommand = cmd2;
            adapter.Fill(dataset);
            comboBox1.DataSource = dataset.Tables[0];
            comboBox1.DisplayMember = "Name";
            //   comboBox2.ValueMember = "1"; 
            dbConn1.Close();
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox2.Text = string.Empty;
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd2 = new SqlCommand("select РасходныйМатериал from dbo.Ostatok", dbConn1);
            dbConn1.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd2);
            DataSet dataset1 = new DataSet();
            // adapter.TableMappings.Add("1","2");
            adapter1.SelectCommand = cmd2;
            adapter1.Fill(dataset1);
            comboBox2.DataSource = dataset1.Tables[0];
            comboBox2.DisplayMember = "РасходныйМатериал";
            //   comboBox2.ValueMember = "1"; 
            dbConn1.Close();
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd3 = new SqlCommand("select ОстатокРасходМат from dbo.Ostatok where РасходныйМатериал = '" + comboBox2.Text + "' ", dbConn1);
            dbConn1.Open();
            object a = new object();
            a = cmd3.ExecuteScalar();
            textBox6.Text = Convert.ToString(a);

            dbConn1.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try 
            {SqlConnection dbconn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);

            SqlCommand cmd1 = new SqlCommand("update  dbo.Ostatok set ОстатокРасходМат = (@mat) where РасходныйМатериал = '" + comboBox2.Text + "' ", dbconn);
                                             
                cmd1.Parameters.AddWithValue("@mat", numericUpDown1.Value.ToString());
                dbconn.Open();
                
                cmd1.ExecuteNonQuery();
                dbconn.Close();
                  MessageBox.Show("Добавлено Успешно!");
            }
            catch
            {
                MessageBox.Show("Редактирование возможно только под учетной записью Администратора");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
