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
    public partial class CompareForm : Form
    {
        public CompareForm()
        {
            InitializeComponent();
        }

        private void CompareForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_Podrazdelenie". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PodrazdelenieTableAdapter.Fill(this.tSPKDataSet.Vocabulary_Podrazdelenie);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_PU". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PUTableAdapter.Fill(this.tSPKDataSet.Vocabulary_PU);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            if (comboBox2.Text.ToString() == string.Empty)
            {
                GlobalValue.param = "select * from dbo.TSPK where ПУ='" + comboBox1.Text + "'" + " order by НомерТСПКвБазе";

            }
            else
            {
                GlobalValue.param = "select * from dbo.TSPK where ПУ='" + comboBox1.Text + "' and Подразделение='" + comboBox2.Text + "'" + " order by НомерТСПКвБазе";
            }


            SqlConnection dbConn;
            dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            dbConn.Open();
            SqlCommand command = new SqlCommand(GlobalValue.param);
            command.Connection = dbConn;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            dbConn.Close();
            dataGridView1.AutoGenerateColumns = true;
            bindingSource1.DataSource = dataset.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            SaveFileDialog1.Filter = "mdf files (*.mdf)|*.mdf";
            SaveFileDialog1.FilterIndex = 2;
            SaveFileDialog1.FileName = "TSPKTemp";
            SaveFileDialog1.RestoreDirectory = true;
            if (SaveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filemdf = SaveFileDialog1.FileName;
                if (GlobalValue.param == "select * from dbo.TSPK where ПУ='" + comboBox1.Text + "'" + " order by НомерТСПКвБазе")

                { GlobalValue.param1 = "select * into TSPKTemp..TSPKTemp" + " from TSPK..TSPK where ПУ='" + comboBox1.Text + "'"; }
                if (GlobalValue.param == "select * from dbo.TSPK where ПУ='" + comboBox1.Text + "' and Подразделение='" + comboBox2.Text + "'" + " order by НомерТСПКвБазе")
                { GlobalValue.param1 = "select * into TSPKTemp..TSPKTemp" + " from TSPK..TSPK where ПУ='" + comboBox1.Text + "' and Подразделение='" + comboBox2.Text + "'"; }
                try
                {
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                    SqlCommand Command1 = new SqlCommand("use master create database TSPKTemp on PRIMARY (NAME =TSPKTemp, FILENAME='" + filemdf + "',SIZE=100mb,FILEGROWTH=10%)", dbConn);
                    dbConn.Open();
                    Command1.ExecuteNonQuery();
                    dbConn.Close();
                    Logs.Write("Создание файла сверки" + comboBox1.Text + "-" + comboBox2.Text);
                }

                catch
                {
                    MessageBox.Show("Ошибка создания временной базы", "TSPK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                try
                {
                    SqlConnection dbConn;
                    dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                    SqlCommand Command1 = new SqlCommand(GlobalValue.param1 + "exec sp_detach_db @dbname = TSPKTemp", dbConn);
                    Command1.CommandTimeout = 3000;
                    dbConn.Open();
                    Command1.ExecuteNonQuery();
                    dbConn.Close();
                    MessageBox.Show("Данные выгружены успешно", "TSPKTemp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка загрузки базы во временную базу", "TSPK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFILE = new OpenFileDialog();
            OpenFILE.Filter = "mdf files (*.mdf)|*.mdf";
            if (OpenFILE.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = OpenFILE.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection dbConn;
            dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            SqlCommand Command1 = new SqlCommand("use master create database TSPKTemp on " + " (filename = N'" + textBox1.Text + "') " + "for attach", dbConn);

            dbConn.Open();
            Command1.ExecuteNonQuery();

            SqlCommand command2 = new SqlCommand("select * from TSPKTemp..TSPKTemp order by НомерТСПКвБазе");
            SqlDataAdapter adapter = new SqlDataAdapter(command2);
            command2.Connection = dbConn;
            DataSet dataset1 = new DataSet();
            adapter.Fill(dataset1);

            dataGridView2.AutoGenerateColumns = true;
            bindingSource2.DataSource = dataset1.Tables[0];
            dataGridView2.DataSource = bindingSource2;
            dbConn.Close();
            Logs.Write("Присоединение к базе файла сверки" + textBox1.Text);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string command1;
            SqlConnection dbConn;
            dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            if (comboBox2.Text != string.Empty)
            {
                command1 = "select min (Tablename) as 'Нахождение', ПУ,Подразделение,ПунктПропуска,ВидСообщения,НаименованиеИзделия,Забаланс,ДатаВыпуска,НаименованиеИзготовителя,ДокументОПриемке,ДатаПоставки,ДатаВводаВЭксплуатацию,ЗаводскойНомер,ИнвентарныйНомер,СрокСлужбы,ГарантийныйСрок,НаходитсяВЭксплуатации,НедоработкаПереработка,Категория,ПриказОЗакреплении,НомерФормуляра,ТребуетсяРемонт,ПодвидТСПК,ВидТСПК,ПодвидПодвидаТСПК,ДатаКонцаГарантииЗавода,НомерТСПКвБазе from ( select 'Управление' as Tablename, ПУ,Подразделение,ПунктПропуска,ВидСообщения,НаименованиеИзделия,Забаланс,ДатаВыпуска,НаименованиеИзготовителя,ДокументОПриемке,ДатаПоставки,ДатаВводаВЭксплуатацию,ЗаводскойНомер,ИнвентарныйНомер,СрокСлужбы,ГарантийныйСрок,НаходитсяВЭксплуатации,НедоработкаПереработка,Категория,ПриказОЗакреплении,НомерФормуляра,ТребуетсяРемонт,ПодвидТСПК,ВидТСПК,ПодвидПодвидаТСПК,ДатаКонцаГарантииЗавода,НомерТСПКвБазе from TSPK..TSPK where ПУ ='" + comboBox1.Text + "' and Подразделение='" + comboBox2.Text + "' union all select 'Подразделение' as Tablename, ПУ,Подразделение,ПунктПропуска,ВидСообщения,НаименованиеИзделия,Забаланс,ДатаВыпуска,НаименованиеИзготовителя,ДокументОПриемке,ДатаПоставки,ДатаВводаВЭксплуатацию,ЗаводскойНомер,ИнвентарныйНомер,СрокСлужбы,ГарантийныйСрок,НаходитсяВЭксплуатации,НедоработкаПереработка,Категория,ПриказОЗакреплении,НомерФормуляра,ТребуетсяРемонт,ПодвидТСПК,ВидТСПК,ПодвидПодвидаТСПК,ДатаКонцаГарантииЗавода,НомерТСПКвБазе from TSPKTemp..TSPKTemp ) tmp group by  ПУ,Подразделение,ПунктПропуска,ВидСообщения,НаименованиеИзделия,Забаланс,ДатаВыпуска,НаименованиеИзготовителя,ДокументОПриемке,ДатаПоставки,ДатаВводаВЭксплуатацию,ЗаводскойНомер,ИнвентарныйНомер,СрокСлужбы,ГарантийныйСрок,НаходитсяВЭксплуатации,НедоработкаПереработка,Категория,ПриказОЗакреплении,НомерФормуляра,ТребуетсяРемонт,ПодвидТСПК,ВидТСПК,ПодвидПодвидаТСПК,ДатаКонцаГарантииЗавода,НомерТСПКвБазе having count (*) = 1 order by НомерТСПКвБазе";
            }
            else { command1 = "select min (Tablename) as 'Нахождение', ПУ,Подразделение,ПунктПропуска,ВидСообщения,НаименованиеИзделия,Забаланс,ДатаВыпуска,НаименованиеИзготовителя,ДокументОПриемке,ДатаПоставки,ДатаВводаВЭксплуатацию,ЗаводскойНомер,ИнвентарныйНомер,СрокСлужбы,ГарантийныйСрок,НаходитсяВЭксплуатации,НедоработкаПереработка,Категория,ПриказОЗакреплении,НомерФормуляра,ТребуетсяРемонт,ПодвидТСПК,ВидТСПК,ПодвидПодвидаТСПК,ДатаКонцаГарантииЗавода,НомерТСПКвБазе from ( select 'Управление' as Tablename, ПУ,Подразделение,ПунктПропуска,ВидСообщения,НаименованиеИзделия,Забаланс,ДатаВыпуска,НаименованиеИзготовителя,ДокументОПриемке,ДатаПоставки,ДатаВводаВЭксплуатацию,ЗаводскойНомер,ИнвентарныйНомер,СрокСлужбы,ГарантийныйСрок,НаходитсяВЭксплуатации,НедоработкаПереработка,Категория,ПриказОЗакреплении,НомерФормуляра,ТребуетсяРемонт,ПодвидТСПК,ВидТСПК,ПодвидПодвидаТСПК,ДатаКонцаГарантииЗавода,НомерТСПКвБазе from TSPK..TSPK where ПУ ='" + comboBox1.Text + "' union all select 'Подразделение' as Tablename, ПУ,Подразделение,ПунктПропуска,ВидСообщения,НаименованиеИзделия,Забаланс,ДатаВыпуска,НаименованиеИзготовителя,ДокументОПриемке,ДатаПоставки,ДатаВводаВЭксплуатацию,ЗаводскойНомер,ИнвентарныйНомер,СрокСлужбы,ГарантийныйСрок,НаходитсяВЭксплуатации,НедоработкаПереработка,Категория,ПриказОЗакреплении,НомерФормуляра,ТребуетсяРемонт,ПодвидТСПК,ВидТСПК,ПодвидПодвидаТСПК,ДатаКонцаГарантииЗавода,НомерТСПКвБазе from TSPKTemp..TSPKTemp ) tmp group by  ПУ,Подразделение,ПунктПропуска,ВидСообщения,НаименованиеИзделия,Забаланс,ДатаВыпуска,НаименованиеИзготовителя,ДокументОПриемке,ДатаПоставки,ДатаВводаВЭксплуатацию,ЗаводскойНомер,ИнвентарныйНомер,СрокСлужбы,ГарантийныйСрок,НаходитсяВЭксплуатации,НедоработкаПереработка,Категория,ПриказОЗакреплении,НомерФормуляра,ТребуетсяРемонт,ПодвидТСПК,ВидТСПК,ПодвидПодвидаТСПК,ДатаКонцаГарантииЗавода,НомерТСПКвБазе having count (*) = 1 order by НомерТСПКвБазе"; }

            SqlCommand command3 = new SqlCommand(command1, dbConn);
            SqlDataAdapter adapter3 = new SqlDataAdapter(command3);
            command3.Connection = dbConn;
            DataSet dataset3 = new DataSet();
            adapter3.Fill(dataset3);
            dataGridView3.AutoGenerateColumns = true;
            bindingSource3.DataSource = dataset3.Tables[0];
            dataGridView3.DataSource = bindingSource3;
            dbConn.Close();

            
            int j;
            for (j = 0; j < dataGridView3.RowCount; j++)
            {

                {
                    if (dataGridView3[0, j].Value.ToString() == "Управление")
                    {
                        dataGridView3[0, j].Style.BackColor = System.Drawing.Color.LightGray;

                    }
                    else
                    {
                        dataGridView3[0, j].Style.BackColor = System.Drawing.Color.AntiqueWhite;

                    }

                }
            }



        }









        private void CompareForm_FormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection dbConn;
                dbConn = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
                SqlCommand command1 = new SqlCommand("use master exec sp_detach_db @dbname = TSPKTemp");

                command1.Connection = dbConn;

                dbConn.Open();
                command1.ExecuteNonQuery();
                dbConn.Close();
                MessageBox.Show("Файл .mdf успешно отсоединен. Сверка завершена.", "TSPKTemp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Файл .mdf не присоединялся", "TSPKTemp", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int i, j;
            Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
            System.Diagnostics.Process ExelProc = System.Diagnostics.Process.GetProcessesByName("EXCEL").Last();
            exApp.Workbooks.Open(Environment.CurrentDirectory + "\\2.xlsx");
            Microsoft.Office.Interop.Excel.Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)exApp.ActiveSheet;
            for (i = 0; i < dataGridView3.ColumnCount; i++)
            {
                for (j = 0; j < dataGridView3.RowCount; j++)
                {


                    workSheet.Cells[j + 2, i + 2] = dataGridView3[i, j].Value.ToString();
                    workSheet.Cells[j + 2, i + 2].Interior.Color = dataGridView3[i, j].Style.BackColor;


                }
            }
            try
            {
                workSheet.SaveAs(Environment.CurrentDirectory + "Расхождения при сверке " + comboBox1.Text + "-" + comboBox2.Text + DateTime.Now.ToString("ddMMyyyy") + ".xlsx", Type.Missing);
                Logs.Write("Выгрузка в эксель расхождений" + "Расхождения при сверке " + comboBox1.Text + "-" + comboBox2.Text + DateTime.Now.ToString("ddMMyyyy") + ".xlsx");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            exApp.Visible = true;
        }

        private void CompareForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView3.RowCount == 1) { for (int j1 = 1; j1 < dataGridView3.ColumnCount; j1++) { dataGridView3[j1, 0].Style.BackColor = System.Drawing.Color.LightPink; } }
            if (dataGridView3.RowCount % 2 != 1)
            {
                for (int i = 0; i < dataGridView3.RowCount; i = i + 2)
                {

                    for (int j = 1; j < dataGridView3.ColumnCount; j++)
                    {
                        if (dataGridView3[j, i].Value.ToString() != dataGridView3[j, i + 1].Value.ToString())
                        {
                            dataGridView3[j, i].Style.BackColor = System.Drawing.Color.LightPink;
                            dataGridView3[j, i + 1].Style.BackColor = System.Drawing.Color.LightPink;
                        }
                        else
                        {
                            dataGridView3[j, i].Style.BackColor = System.Drawing.Color.LightGreen;
                            dataGridView3[j, i + 1].Style.BackColor = System.Drawing.Color.LightGreen;
                        }
                    }
                }
            }
            else {for (int i = 0; i < dataGridView3.RowCount-1; i = i + 2)
                {

                    for (int j = 1; j < dataGridView3.ColumnCount; j++)
                    {
                        if (dataGridView3[j, i].Value.ToString() != dataGridView3[j, i + 1].Value.ToString() )
                        {
                            dataGridView3[j, i].Style.BackColor = System.Drawing.Color.LightPink;
                            dataGridView3[j, i + 1].Style.BackColor = System.Drawing.Color.LightPink;
                        }
                        else
                        {
                            dataGridView3[j, i].Style.BackColor = System.Drawing.Color.LightGreen;
                            dataGridView3[j, i + 1].Style.BackColor = System.Drawing.Color.LightGreen;
                        }
                    }
                }
            }
        }
    }
}