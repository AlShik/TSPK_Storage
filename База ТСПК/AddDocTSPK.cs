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
using System.Data.Common;


namespace База_ТСПК
{
    public partial class AddDocTSPK : Form
    {
        public AddDocTSPK()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection dbConn1;
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd1 = new SqlCommand("INSERT INTO dbo.Documents (НомерТСПКвБазе, Документ, НомерДокумента, ДатаДокумента, Отправитель, Получатель, ПУ_Отправитель, ПУ_Получатель) VALUES (@NomervBD, @Document, @NomerDocumenta, @DataDocumenta, @Otpravitel, @Poluchatel, @PUOtpravitel, @PUPoluchatel )", dbConn1);
            cmd1.Parameters.AddWithValue("@NomervBD", comboBox3.Text);
            cmd1.Parameters.AddWithValue("@Document", comboBox15.Text);
            cmd1.Parameters.AddWithValue("@NomerDocumenta", textBox8.Text);
            cmd1.Parameters.AddWithValue("@DataDocumenta", dateTimePicker4.Value);
            cmd1.Parameters.AddWithValue("@Otpravitel", textBox2.Text);
            cmd1.Parameters.AddWithValue("@Poluchatel", comboBox2.Text);
            cmd1.Parameters.AddWithValue("@PUOtpravitel", textBox3.Text);
            cmd1.Parameters.AddWithValue("@PUPoluchatel", comboBox1.Text);

            var cmd2 = new SqlCommand("UPDATE dbo.TSPK SET  Подразделение = @Podrazdelenie, ПУ = @PU, ПунктПропуска = @PunktPropuska where НомерТСПКвБазе = @NomervBD", dbConn1);
            cmd2.Parameters.AddWithValue("@Podrazdelenie", comboBox2.Text);
            cmd2.Parameters.AddWithValue("@PU", comboBox1.Text);
            cmd2.Parameters.AddWithValue("@PunktPropuska",comboBox6.Text);
            cmd2.Parameters.AddWithValue("@NomervBD", comboBox3.Text);

            try
            {
                dbConn1.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                MessageBox.Show("ТСПК Перемещено успешно! \nДокумент добавлен успешно!");
                Logs.Write("Перемещение ТСПК №" + comboBox3.Text + "; Пользователь:" + GlobalValue.Login + " из " + textBox3.Text + " " + textBox2.Text + " В " + comboBox1.Text + " " +  comboBox2.Text);
                dbConn1.Close();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка, проверьте правильность ввода!!! \nПеремещать ТСПК возможно только под учетной записью Администратора ");
                Logs.Write ("Ошибка перемещения ТСПК №" + comboBox3.Text + "; Пользователь:" + GlobalValue.Login);
            }
        }

        private void AddDocTSPK_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "moveTSPK_ID.TSPK". При необходимости она может быть перемещена или удалена.
            this.tSPKTableAdapter.Fill(this.moveTSPK_ID.TSPK);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet1.Vocabulary_Podrazdelenie". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PodrazdelenieTableAdapter1.Fill(this.tSPKDataSet1.Vocabulary_Podrazdelenie);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_Podrazdelenie". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PodrazdelenieTableAdapter.Fill(this.tSPKDataSet.Vocabulary_Podrazdelenie);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "addDocInAddTSPK.Vocabulary_PU". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PUTableAdapter.Fill(this.addDocInAddTSPK.Vocabulary_PU);

        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbConn1 = new SqlConnection();
                dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                var cmd2 = new SqlCommand("select ПУ from dbo.TSPK where НомерТСПКвБазе = '" + comboBox3.Text + "' ", dbConn1);
                var cmd3 = new SqlCommand("select Подразделение from dbo.TSPK where НомерТСПКвБазе = '" + comboBox3.Text + "' ", dbConn1);
                var cmd4 = new SqlCommand("select ПунктПропуска from dbo.TSPK where НомерТСПКвБазе = '" + comboBox3.Text + "' ", dbConn1);
                var cmd5 = new SqlCommand("select НаименованиеИзделия from dbo.TSPK where НомерТСПКвБазе = '" + comboBox3.Text + "' ", dbConn1);
                var cmd6 = new SqlCommand("select ЗаводскойНомер from dbo.TSPK where НомерТСПКвБазе = '" + comboBox3.Text + "' ", dbConn1);
                var cmd7 = new SqlCommand("select Фото from dbo.TSPK where НомерТСПКвБазе ='" + comboBox3.Text + "' ", dbConn1);
                dbConn1.Open();
                

                
                textBox3.Text = cmd2.ExecuteScalar().ToString();
                textBox2.Text = cmd3.ExecuteScalar().ToString();
                textBox4.Text = cmd4.ExecuteScalar().ToString();
                textBox1.Text = cmd5.ExecuteScalar().ToString();
                textBox5.Text = cmd6.ExecuteScalar().ToString();
                try
                {  SqlDataReader ImageReader = cmd7.ExecuteReader();
                if (ImageReader.HasRows)
                {
                    MemoryStream Stream = new MemoryStream();
                    foreach (DbDataRecord record in ImageReader)
                        Stream.Write((byte[])record["Фото"], 0, ((byte[])record["Фото"]).Length);
                    Image image = Image.FromStream(Stream);

                    pictureBox1.Image = Image.FromStream(Stream);
                    Stream.Dispose();
                    image.Dispose();
                    groupBox5.Visible = false;
                }
                else
                {
                    
                    
                    groupBox5.Visible = true;
                     
                }
                }
                catch
                {
                    groupBox5.Visible = true;
                
                }
                
                dbConn1.Close();
            }
           catch
            { MessageBox.Show("Ошибка: возможно введенный номер не существует");
              
            }
        }

       
    }
}
