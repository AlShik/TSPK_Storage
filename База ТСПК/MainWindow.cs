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
    public partial class MainWindow : Form
    {
        string KPP1 = "1";
        public MainWindow(string KPP)
        {
            InitializeComponent();
            KPP1 = KPP;
        } 
        void ReadData(string par)  // метод загрузки из БД в ДатаГрид с отлючением от БД параметр метода строка запроса в sql select * from
        {
            
            SqlConnection dbConn; 
            dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            dbConn.Open();
            SqlCommand command = new SqlCommand(par);
            command.Connection = dbConn;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dbConn.Close();
            dataGridView1.AutoGenerateColumns = true;
            bindingSource1.DataSource = dataset.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }
        void ReadData2(string par) //Загрузка накладных во второй датагридс отлючением от БД параметр метода строка запроса в sql select * from
            { SqlConnection dbConn;
             dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
             dbConn.Open();
             SqlCommand command = new SqlCommand(par);
             command.Connection = dbConn;
             SqlDataAdapter adapter2 = new SqlDataAdapter(command);
             DataSet dataset2 = new DataSet();
             adapter2.Fill(dataset2);
             dbConn.Close();
             dataGridView2.AutoGenerateColumns = true;
             bindingSource2.DataSource = dataset2.Tables[0];
             dataGridView2.DataSource = bindingSource2;
             string Serial = Convert.ToString(dataGridView1[26, dataGridView1.CurrentRow.Index].Value);
             string Zapros = "SELECT  Документ, НомерДокумента, ДатаДокумента, Отправитель, Получатель, ПУ_Отправитель, ПУ_Получатель from dbo.Documents where НомерТСПКвБазе='";
             Zapros = Zapros + Serial + "'";
             
             
             label1.Text = Zapros;    
             SqlConnection dbConn2;
             dbConn2 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
             dbConn2.Open();
             SqlCommand command2 = new SqlCommand ( Zapros );
             command2.Connection = dbConn2;
             SqlDataAdapter adapter3 = new SqlDataAdapter(command2);
             DataSet dataset3 = new DataSet();
             adapter3.Fill(dataset3);
             dbConn2.Close();
             dataGridView2.AutoGenerateColumns = true;
             bindingSource2.DataSource = dataset3.Tables[0];
             dataGridView2.DataSource = bindingSource2;
            }
        void ReadData3(string par) //Загрузка комплектности в 3й датагридс отлючением от БД параметр метода строка запроса в sql select * from
        {
            SqlConnection dbConn;
            dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            dbConn.Open();
            SqlCommand command = new SqlCommand(par);
            command.Connection = dbConn;
            SqlDataAdapter adapter3 = new SqlDataAdapter(command);
            DataSet dataset3 = new DataSet();
            adapter3.Fill(dataset3);
            dbConn.Close();
            dataGridView2.AutoGenerateColumns = true;
            bindingSource3.DataSource = dataset3.Tables[0];
            dataGridView3.DataSource = bindingSource3;
            string Serial = Convert.ToString(dataGridView1[26, dataGridView1.CurrentRow.Index].Value);
            string Zapros = "SELECT СоставнаяЧасть, НомерСоставнойЧасти  from dbo.Komplektnost where НомерТСПКвБазе='";
            Zapros = Zapros + Serial + "'";


            label1.Text = Zapros;
            SqlConnection dbConn2;
            dbConn2 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            dbConn2.Open();
            SqlCommand command3 = new SqlCommand(Zapros);
            command3.Connection = dbConn2;
            SqlDataAdapter adapter4 = new SqlDataAdapter(command3);
            DataSet dataset4 = new DataSet();
            adapter4.Fill(dataset4);
            dbConn2.Close();
            dataGridView3.AutoGenerateColumns = true;
            bindingSource3.DataSource = dataset4.Tables[0];
            dataGridView3.DataSource = bindingSource3;
        }
        void RevealChosen(string strokaSoderzhaniya, string PathOfPicture)// Метод смена картинки по клику на строке тспк (параметры метода наименование и путь к картинке)
        { 

            string stroka = Convert.ToString (dataGridView1.CurrentRow.Index);  
            int NomerStroki = Convert.ToInt32(stroka);

            stroka = Convert.ToString(dataGridView1[4, NomerStroki].Value);
             
             if (stroka == strokaSoderzhaniya)
           
                pictureBox1.ImageLocation = PathOfPicture;  // путь к картинке"D:\\Users\\Public\\Pictures\\Sample Pictures\\Tulips.jpg"
             label9.Text = Convert.ToString(dataGridView1[6, NomerStroki].Value);
             label10.Text = Convert.ToString(dataGridView1[10, NomerStroki].Value);
             label11.Text = Convert.ToString(dataGridView1[14, NomerStroki].Value);
             label13.Text = Convert.ToString(dataGridView1[19, NomerStroki].Value);
             label14.Text = Convert.ToString(dataGridView1[13, NomerStroki].Value);

              DateTime DT = new DateTime () ;     //ниже запись в поле находится в эксплуатации в датагриде  и в не в базе! и в лейбл сегоддата минус ввод в эксплуатацию
             DateTime DT1 = new DateTime();
             DT = DateTime.Today;
             DT1 = Convert.ToDateTime(dataGridView1[10, NomerStroki].Value);
             int DT3;
             DT3 = (Convert.ToInt16(DT.Subtract(DT1).TotalDays)) / 365;
             dataGridView1[15, NomerStroki].Value = Convert.ToString(DT3);

             label12.Text = Convert.ToString(dataGridView1[15, NomerStroki].Value);

             
          
            

        }
        void RevealChosen1()
        {
            SqlConnection dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            SqlCommand cmd = new SqlCommand("select Фото from dbo.TSPK where НомерТСПКвБазе ='"+ dataGridView1[26, dataGridView1.CurrentRow.Index].Value.ToString() + "'", dbConn1);
            dbConn1.Open();
            SqlDataReader ImageReader = cmd.ExecuteReader();

            try
            {
                if (ImageReader.HasRows)
                {
                    MemoryStream Stream = new MemoryStream();
                    foreach (DbDataRecord record in ImageReader)
                        Stream.Write((byte[])record["Фото"], 0, ((byte[])record["Фото"]).Length);
                    Image image = Image.FromStream(Stream);

                    pictureBox1.Image = Image.FromStream(Stream);
                    Stream.Dispose();
                    image.Dispose();
                    
                }
                else
                    MessageBox.Show("Изображение ТСПК отсутствует");
            }
            catch { MessageBox.Show("Изображение ТСПК отсутствует"); }
        }
        
        public void MainFormAirport_Load(object sender, EventArgs e)
        {
            ReadData(KPP1);
            
        }
        
        public void button1_Click(object sender, EventArgs e)
        {
            string StrokaForComplex = KPP1 + " and ВидТСПК = 'Комплекс' ";
            ReadData(StrokaForComplex);
            
            
        }  // кнопка на выбор комплексов

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RevealChosen1();
           // RevealChosen("Корунд", "D:\\Users\\Public\\Pictures\\Sample Pictures\\Tulips.jpg");
           // RevealChosen("Гастроль-П", "D:\\Users\\Администратор\\Desktop\\Новая папка\\Гастроль п.jpg"); 
           // RevealChosen("Регула-3022", "D:\\Users\\Администратор\\Desktop\\Новая папка\\3022.png");
           // RevealChosen("Микроскоп-МСП", "D:\\Users\\Администратор\\Desktop\\Новая папка\\мсп.bmp");
          //  RevealChosen("Шахта-РП", "D:\\Users\\Администратор\\Desktop\\Новая папка\\шахта рп.JPG");
          //  RevealChosen("Ультрамаг-5СЛГ", "D:\\Users\\Администратор\\Desktop\\Новая папка\\5слг 1.JPG");
           // RevealChosen("Ультрамаг-А36", " D:\\Users\\Администратор\\Desktop\\Новая папка\\а36.jpg");
           // RevealChosen("Ультрамаг-С6У", " D:\\Users\\Администратор\\Desktop\\Новая папка\\с6у.JPG");
            ReadData2("SELECT * FROM dbo.Documents");
            ReadData3("SELECT * FROM dbo.Komplektnost");
            label12.Text = Convert.ToString(dataGridView1[15, dataGridView1.CurrentRow.Index].Value);
            
           
            label11.Text = Convert.ToString(dataGridView1[14, dataGridView1.CurrentRow.Index].Value);
            label13.Text = Convert.ToString(dataGridView1[19, dataGridView1.CurrentRow.Index].Value);
            label14.Text = Convert.ToString(dataGridView1[13, dataGridView1.CurrentRow.Index].Value);
           DateTime n =  Convert.ToDateTime(dataGridView1[6, dataGridView1.CurrentRow.Index].Value);
           label9.Text = n.ToString("dd MMMMMM yyyy");
           DateTime n1 = Convert.ToDateTime(dataGridView1[10, dataGridView1.CurrentRow.Index].Value);
           label10.Text = n1.ToString("dd MMMMMM yyyy");

        }

        private void button9_Click(object sender, EventArgs e)  // кнопка на выбор всех тспк
        {

            int varswitch = 4;
            if (GlobalValue.Podrazdelenie == string.Empty)
            { varswitch = 3; }
            
            if (GlobalValue.PunktPropuska == string.Empty)
            { varswitch = 2; }
            if ((GlobalValue.Podrazdelenie == string.Empty) && (GlobalValue.PunktPropuska == string.Empty))
            { varswitch = 1; }
            if ((GlobalValue.Podrazdelenie == string.Empty) && (GlobalValue.PunktPropuska == string.Empty) && (GlobalValue.PU == string.Empty))
            { varswitch = 0; }
            switch (varswitch)
            {
                case 0:
                    {
                        MessageBox.Show("Ничего не выбрано");

                        break;
                    }
                case 1:
                    {

                        ReadData("SELECT * FROM dbo.TSPK WHERE ПУ = '" + GlobalValue.PU + "'");
                        break;
                    }
                case 2:
                    {
                        ReadData("SELECT * FROM dbo.TSPK WHERE Подразделение = '" + GlobalValue.Podrazdelenie + "' and ПУ = '" + GlobalValue.PU + "'");
                        break;
                    }
                case 3:
                    {
                        ReadData("SELECT * FROM dbo.TSPK WHERE ПУ = '" + GlobalValue.PU + "' and ПунктПропуска = '" + GlobalValue.PunktPropuska + "'");
                        break;
                    }
                case 4:
                    {
                        ReadData("SELECT * FROM dbo.TSPK WHERE ПУ = '" + GlobalValue.PU + "' and Подразделение = '" + GlobalValue.Podrazdelenie + "' and ПунктПропуска = '" + GlobalValue.PunktPropuska + "'");
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)    // ниже кнопки на выбор тспк по виду
        {
            string StrokaForComplex = KPP1 + " and ВидТСПК = 'Тех. Средства Паспортного Контроля'";
            ReadData(StrokaForComplex);
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string StrokaForComplex = KPP1 + " and ВидТСПК = 'Тех. Средства Осмотра Досмотра'";
            ReadData(StrokaForComplex);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string StrokaForComplex = KPP1 + " and ВидТСПК = 'Тех. Средства Обнаружения  Оружия'";
            ReadData(StrokaForComplex);
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string StrokaForComplex = KPP1 + " and ВидТСПК = 'Тех. Средства Аудио-Видео-Фотодокументирования'";
            ReadData(StrokaForComplex);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string StrokaForComplex = KPP1 + " and ВидТСПК = 'Копировально-Множительная Техника'";
            ReadData(StrokaForComplex);
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string StrokaForComplex = KPP1 + " and ВидТСПК = 'Средства обеспечения эксплуатации технических средств пограничного контроля и вспомогательное оборудование'";
            ReadData(StrokaForComplex);
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string StrokaForComplex = KPP1 + " and ВидТСПК = 'Специальные Технические средства обучения и учебное оборудование'";
            ReadData(StrokaForComplex);
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int i, j;
            Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
            exApp.Workbooks.Open(Environment.CurrentDirectory + "\\2.xlsx");
            Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
            for (i = 0; i < dataGridView1.ColumnCount; i++)
             {
                 for (j = 0; j < dataGridView1.RowCount; j++)
                 {
                     workSheet.Cells[j+2, i+2] = dataGridView1[i, j].Value.ToString();
                 }
            }
            try
            {
                workSheet.SaveAs(Environment.CurrentDirectory + "Выгрузка" + DateTime.Now.ToString("ddMMyyyy") + ".xlsx", Type.Missing);
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            exApp.Visible = true;
            Logs.Write("Выгрузка тспк подразделения" + GlobalValue.PU + GlobalValue.Podrazdelenie);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }
        







       


        }
    }

