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
using Microsoft.Office.Interop.Excel;


namespace База_ТСПК
{
    public partial class CreateSpravka : Form
    {
        public CreateSpravka()
        {
            InitializeComponent();
            GlobalValue.ExelROW = 7;
            GlobalValue.number = 1;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void CreateSpravka_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet1.Vocabulary_PunktPropuska_". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PunktPropuska_TableAdapter.Fill(this.tSPKDataSet1.Vocabulary_PunktPropuska_);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "moveTSPK_ID.TSPK". При необходимости она может быть перемещена или удалена.
            this.tSPKTableAdapter.Fill(this.moveTSPK_ID.TSPK);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "podrazdel.Vocabulary_Podrazdelenie". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PodrazdelenieTableAdapter.Fill(this.podrazdel.Vocabulary_Podrazdelenie);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "addDocInAddTSPK.Vocabulary_PU". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PUTableAdapter.Fill(this.addDocInAddTSPK.Vocabulary_PU);

        }

        private void comboBox5_TextChanged(object sender, EventArgs e)
        {
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd2 = new SqlCommand("select НаименованиеИзделия from dbo.TSPK where Подразделение = '" + comboBox5.Text + "' " + "and ПУ = '" + comboBox1.Text + "'" , dbConn1);
            dbConn1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            DataSet dataset = new DataSet();
           // adapter.TableMappings.Add("1","2");
            adapter.SelectCommand = cmd2;
            adapter.Fill(dataset);
            comboBox2.DataSource = dataset.Tables[0];
            comboBox2.DisplayMember = "НаименованиеИзделия";
         //   comboBox2.ValueMember = "1"; 
            dbConn1.Close();
            
            

        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd2 = new SqlCommand("select ЗаводскойНомер from dbo.TSPK where НаименованиеИзделия = '" + comboBox2.Text + "' ", dbConn1);
            dbConn1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            DataSet dataset = new DataSet();
            // adapter.TableMappings.Add("1","2");
            adapter.SelectCommand = cmd2;
            adapter.Fill(dataset);
            comboBox7.DataSource = dataset.Tables[0];
            comboBox7.DisplayMember = "ЗаводскойНомер";
            //   comboBox2.ValueMember = "1"; 
            dbConn1.Close();
        }

        

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            //comboBox2.Text = string.Empty;
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox2.Text = string.Empty;
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd2 = new SqlCommand("select НаименованиеИзделия from dbo.TSPK where Подразделение = '" + comboBox5.Text + "' " + "and ПУ = '" + comboBox1.Text + "'", dbConn1);
            dbConn1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            DataSet dataset = new DataSet();
            // adapter.TableMappings.Add("1","2");
            adapter.SelectCommand = cmd2;
            adapter.Fill(dataset);
            comboBox2.DataSource = dataset.Tables[0];
            comboBox2.DisplayMember = "НаименованиеИзделия";
            //   comboBox2.ValueMember = "1"; 
            dbConn1.Close();
        }

        private void comboBox7_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox7.Text = string.Empty;
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd2 = new SqlCommand("select ЗаводскойНомер from dbo.TSPK where НаименованиеИзделия = '" + comboBox2.Text + "' ", dbConn1);
            dbConn1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            DataSet dataset = new DataSet();
            // adapter.TableMappings.Add("1","2");
            adapter.SelectCommand = cmd2;
            adapter.Fill(dataset);
            comboBox7.DataSource = dataset.Tables[0];
            comboBox7.DisplayMember = "ЗаводскойНомер";
            //   comboBox2.ValueMember = "1"; 
            dbConn1.Close();
        }

        private void comboBox2_TextChanged_1(object sender, EventArgs e)
        {
            comboBox7.Text = string.Empty;
        }

        private void comboBox4_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox4.Text = string.Empty;
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd2 = new SqlCommand("select РасходныйМатериал from dbo.RashodMat where НаименованиеТСПК = '" + comboBox2.Text + "' ", dbConn1);
            dbConn1.Open();
            SqlDataAdapter adapter1 = new SqlDataAdapter(cmd2);
            DataSet dataset1 = new DataSet();
            // adapter.TableMappings.Add("1","2");
            adapter1.SelectCommand = cmd2;
            adapter1.Fill(dataset1);
            comboBox4.DataSource = dataset1.Tables[0];
            comboBox4.DisplayMember = "РасходныйМатериал";
            //   comboBox2.ValueMember = "1"; 
            dbConn1.Close();
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd3 = new SqlCommand("select ОстатокРасходМат from dbo.Ostatok where РасходныйМатериал = '" + comboBox4.Text + "' ", dbConn1);
            dbConn1.Open();
            object a = new object();
            a = cmd3.ExecuteScalar();
            label19.Text = Convert.ToString(a);

            dbConn1.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {   try
           {
            if (Convert.ToInt16(textBox1.Text) > Convert.ToInt16(label19.Text))
            {
                MessageBox.Show("Указанное количество расходованных материалов на обслуживание превышает количество запасов");
                textBox1.Text = string.Empty;}
            }
            catch 
                {textBox1.Text = string.Empty;}
                    
            }

        private void button2_Click(object sender, EventArgs e)
        {   
            Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
              System.Diagnostics.Process ExelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL").Last();
            exApp.Workbooks.Open(Environment.CurrentDirectory + "\\1.xlsx");
          
            Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
            workSheet.Cells[2, 1] =  "СПРАВКА № " + numericUpDown2.Value.ToString();
            workSheet.Cells[3, 1] = "с " + dateTimePicker1.Value.ToString("dd MMMMMMMMMMM yyyy") + " года" + " по " + dateTimePicker1.Value.ToString("dd MMMMMMMMMMM yyyy") + " года " +  "в " +  comboBox5.Text + "\n произведён ремонт указанных ниже ТСПК";
            GlobalValue.ExelROW = 7;
            GlobalValue.number = 1;
        /*    workSheet.Cells[GlobalValue.ExelROW, 1] = GlobalValue.number.ToString(); 
            workSheet.Cells[GlobalValue.ExelROW, 2] = comboBox2.Text;
            workSheet.Cells[GlobalValue.ExelROW, 3] = comboBox7.Text;
            workSheet.Cells[GlobalValue.ExelROW, 4] = richTextBox1.Text;
            workSheet.Cells[GlobalValue.ExelROW, 5] = comboBox3.Text + ",\n" + richTextBox2.Text;
            workSheet.Cells[GlobalValue.ExelROW, 6] = comboBox4.Text;
            workSheet.Cells[GlobalValue.ExelROW, 7] = textBox2.Text; ;
            workSheet.Cells[GlobalValue.ExelROW, 8] = textBox1.Text;
            workSheet.Cells[GlobalValue.ExelROW, 9] = richTextBox3.Text;
            workSheet.Cells[GlobalValue.ExelROW, 10] = richTextBox4.Text;
           */
            
            

            try
            {   
               // File.Delete(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");
                workSheet.SaveAs(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx", Type.Missing);
                label24.Text = "0";

                
                exApp.Application.Quit();
                ExelProc.Kill();
                
                //MessageBox.Show("Добавлено успешно, добавить еще обслуженное ТСПК?","Добавлено!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (MessageBox.Show("Справка успешно создана.  \n Хотите добавить ТСПК в данную справку \n При нажатии \"Нет\" будет сформирована  пустая справка", "Успешно!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    
                    Microsoft.Office.Interop.Excel.Application exApp1 = new Microsoft.Office.Interop.Excel.Application();

                    exApp.Workbooks.Open(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");

                    exApp.Visible = true;
                }
                else
                { }
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка, возможно файл уже открыт", "!!!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
                    
                        }
             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GlobalValue.number >= 11)
            { MessageBox.Show("Добавлено предельно допустимое число обслуженных ТСПК. Для завершения нажмите <Сформировать Справку>", "Предельно допустимое число обслуженных ТСПК", MessageBoxButtons.OK,MessageBoxIcon.Warning); }
            else
            {

                if (MessageBox.Show("Добавить обслуженное ТСПК согласно заполненным полям??", "Добавить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                   // File.Delete(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");
                    Microsoft.Office.Interop.Excel.Application exApp2 = new Microsoft.Office.Interop.Excel.Application();
                    System.Diagnostics.Process ExelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL").Last();
                    exApp2.Workbooks.Open(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                    Worksheet workSheet1 = (Worksheet)exApp2.ActiveSheet;

                    string hi = Convert.ToString(workSheet1.Cells[7, 1]);
                    
                    workSheet1.Cells[GlobalValue.ExelROW, 1] = Convert.ToString(GlobalValue.number);
                    workSheet1.Cells[GlobalValue.ExelROW, 2] = comboBox2.Text;
                    workSheet1.Cells[GlobalValue.ExelROW, 3] = comboBox7.Text;
                    workSheet1.Cells[GlobalValue.ExelROW, 4] = richTextBox1.Text;
                    workSheet1.Cells[GlobalValue.ExelROW, 5] = comboBox3.Text + ",\n" + richTextBox2.Text;
                    workSheet1.Cells[GlobalValue.ExelROW, 6] = comboBox4.Text;
                    workSheet1.Cells[GlobalValue.ExelROW, 7] = textBox2.Text; ;
                    workSheet1.Cells[GlobalValue.ExelROW, 8] = textBox1.Text;
                    workSheet1.Cells[GlobalValue.ExelROW, 9] = richTextBox3.Text;
                    workSheet1.Cells[GlobalValue.ExelROW, 10] = richTextBox4.Text; 
                    GlobalValue.ExelROW++;
                    GlobalValue.number++;
                    
                    exApp2.DisplayAlerts = false;
                    workSheet1.SaveAs(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx", Type.Missing);
                   // exApp2.Workbooks.Application.SaveWorkspace();
                 //   workSheet1.SaveAs(Environment.CurrentDirectory + "Справка о ремонте от" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx", Type.Missing);
                 //   File.Delete(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");



                    SqlConnection dbConn1 = new SqlConnection();
                    dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                    var cmd2 = new SqlCommand("update  dbo.Ostatok set ОстатокРасходМат = (@mat) where РасходныйМатериал = '" + comboBox4.Text + "' ", dbConn1);
                   string OST;
                   if (string.Empty == label19.Text)
                       OST = Convert.ToString(textBox1.Text);
                   else
                   {
                       int ost2;
                       ost2 = Convert.ToInt16(label19.Text) - Convert.ToInt16(textBox1.Text);
                       OST = Convert.ToString(ost2);
                   }
                    cmd2.Parameters.AddWithValue("@mat", OST);
                    dbConn1.Open();
                    cmd2.ExecuteNonQuery();
                    dbConn1.Close();

                    exApp2.Application.Quit();
                    ExelProc.Kill();
                    label24.Text = (GlobalValue.number-1).ToString();
                    MessageBox.Show("Добавлено Успешно! Для добавления следующего обслуженного ТСПК воcпользуйтесь формой еще раз.","Добавлено",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    comboBox2.Text = string.Empty;
                    comboBox7.Text = string.Empty;
                    richTextBox1.Text = string.Empty;
                    richTextBox2.Text = string.Empty;
                    comboBox3.Text = string.Empty;
                    comboBox4.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox1.Text = string.Empty;

                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {          // File.Delete(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");
                    Microsoft.Office.Interop.Excel.Application exApp2 = new Microsoft.Office.Interop.Excel.Application();
                    System.Diagnostics.Process ExelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL").Last();
                    exApp2.Workbooks.Open(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");
                    Worksheet workSheet1 = (Worksheet)exApp2.ActiveSheet;
                    /* 
                                 // увеличив  exelrow написать последние строчки 
                     * Заместитель начальника кпп по ТСПК - начальник группы АСПК кпп "Суджа" отдела (погк) в г. Судже и тд.
                   разобраться с форматированием и потом чтобы конец справки писался не статично как ниже,
                     * а записывался в ячейки которые инкрементировались
             
             
             
                     */



                    workSheet1.Cells[17, 1] = richTextBox5.Text;
                    workSheet1.Cells[18, 1] = textBox3.Text;
                    workSheet1.Cells[18, 10] = textBox4.Text;
                    workSheet1.Cells[19, 1] = dateTimePicker1.Value.ToString("dd MMMMMMMMMMM yyyy")+ " г.";
                    
                   // workSheet1.SaveAs(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx", Type.Missing);
                   // if (DialogResult == DialogResult.No)
                   // { return; }
                    exApp2.DisplayAlerts = false;
                    exApp2.SaveWorkspace();
                    exApp2.Application.Quit();
            
                   // exApp2.Application.Quit();
                    ExelProc.Kill();
                   // File.Delete(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");
                    Microsoft.Office.Interop.Excel.Application exApp1 = new Microsoft.Office.Interop.Excel.Application();

                    exApp1.Workbooks.Open(Environment.CurrentDirectory + "Справка о ремонте" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");

                    exApp1.Visible = true;
                    Logs.Write("Формирование справки" + "Пользователь: " + GlobalValue.Login);
            // увеличив  exelrow написать последние строчки Заместитель начальника кпп по ТСПК - начальник группы АСПК кпп "Суджа" отдела (погк) в г. Судже и тд.
        }
        
    }
}
