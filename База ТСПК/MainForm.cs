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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            SqlConnection dbConn1;
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd6 = new SqlCommand("select count (*) from dbo.TSPK", dbConn1);
             dbConn1.Open();
            if (cmd6.ExecuteScalar().ToString() != "0")

            {var cmd = new SqlCommand("use TSPK select  НомерТСПКвБазе  from dbo.TSPK   order by НомерТСПКвБазе desc", dbConn1);
                string str = cmd.ExecuteScalar().ToString();
                //   if (str != "-")
                {
                    int y = Convert.ToInt16(str);
                    for (int i = 0; i <= y; i++)
                    {
                        var cmd2 = new SqlCommand("select ДатаВводаВЭксплуатацию from dbo.TSPK where НомерТСПКвБазе =" + i + "", dbConn1);

                        string exec = Convert.ToString(cmd2.ExecuteScalar());



                        if (exec == "-")
                        {
                            var cmd4 = new SqlCommand("update dbo.TSPK set НаходитсяВЭксплуатации = '-' where НомерТСПКвБазе =" + i + "", dbConn1);
                            cmd4.ExecuteNonQuery();
                        }
                        else
                        {
                            DateTime DT = new DateTime();
                            DT = Convert.ToDateTime(cmd2.ExecuteScalar());

                            DateTime DT1 = new DateTime();
                            DT1 = DateTime.Now;
                            TimeSpan DT3 = DT1.Subtract(DT);

                            int DT5 = DT3.Days / 365; //года
                            int DT6 = (DT3.Days - DT5 * 365) / 30;//месяцы
                            string stri = DT5.ToString() + " лет " + DT6.ToString() + " месяцев ";
                            var cmd3 = new SqlCommand("update dbo.TSPK set НаходитсяВЭксплуатации = '" + stri + "' where НомерТСПКвБазе =" + i + "", dbConn1);
                            cmd3.ExecuteNonQuery();
                        }
                    

                        
                    }
                }
            }dbConn1.Close();
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_PunktPropuska_". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PunktPropuska_TableAdapter.Fill(this.tSPKDataSet.Vocabulary_PunktPropuska_);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_Podrazdelenie". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PodrazdelenieTableAdapter.Fill(this.tSPKDataSet.Vocabulary_Podrazdelenie);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet.Vocabulary_PU". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PUTableAdapter.Fill(this.tSPKDataSet.Vocabulary_PU);
            
           
            
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
            
            Application.Exit();
        }

        private void button12_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Учетные записи", button12);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ReloginUserAdd ConnectionSettingsPage = new ReloginUserAdd(GlobalValue.Login, GlobalValue.DataBaseSourse, GlobalValue.Password);
            ConnectionSettingsPage.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            VocabularyEdit VocabularyEditPage = new VocabularyEdit();
            VocabularyEditPage.Owner = this;
            VocabularyEditPage.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            AddNewTSPK Add = new AddNewTSPK();
            Add.Owner = this;
            Add.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            GlobalValue.Podrazdelenie = comboBox2.Text;
            GlobalValue.PU = comboBox1.Text;
            GlobalValue.PunktPropuska = comboBox3.Text;
            int varswitch = 4;
            if (GlobalValue.Podrazdelenie == string.Empty)
                 {  varswitch = 3; }
            if (GlobalValue.PunktPropuska == string.Empty)
                 {   varswitch = 2; }
            if ((GlobalValue.Podrazdelenie == string.Empty) && (GlobalValue.PunktPropuska == string.Empty))
                 {  varswitch = 1; }
            if ((GlobalValue.Podrazdelenie == string.Empty) && (GlobalValue.PunktPropuska == string.Empty) && (GlobalValue.PU == string.Empty))
                 { varswitch = 0; }
            if ((GlobalValue.PU == string.Empty) && (GlobalValue.PunktPropuska == string.Empty))
                 { varswitch = 5; }
            switch (varswitch)
            {
                    case 0:
                    {
                        MessageBox.Show("Ничего не выбрано");

                        break;
                    }
                    case 1:
                    {
                        MainWindow mw = new MainWindow("SELECT * FROM dbo.TSPK WHERE ПУ = '" + GlobalValue.PU + "'");
                        mw.ShowDialog();

                        break;
                    }
                    case 2:
                    { 
                        MainWindow mw = new MainWindow("SELECT * FROM dbo.TSPK WHERE ПУ = '" + GlobalValue.PU + "' and Подразделение = '" + GlobalValue.Podrazdelenie +"'");
                        mw.ShowDialog();
                        break;
                    }
                    case 3:
                    {
                        MessageBox.Show("Выберите подразделение");
                        break; 
                    }
                    case 4:
                    {
                        MainWindow mw = new MainWindow("SELECT * FROM dbo.TSPK WHERE ПУ = '" + GlobalValue.PU + "' and Подразделение = '" + GlobalValue.Podrazdelenie + "' and ПунктПропуска = '" + GlobalValue.PunktPropuska + "'");
                        mw.ShowDialog();
                        break;
                    }
                    case 5:
                    {
                        MessageBox.Show("Выберите ПУ");

                        break;
                    }
            }
            
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AddDocTSPK AddDoc = new AddDocTSPK();
            AddDoc.Owner = this;
            AddDoc.ShowDialog();
        }

        private void button9_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Перемещение ТСПК между подразделениями",button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            CreateSpravka AddSP = new CreateSpravka();
            AddSP.Owner = this;
            AddSP.ShowDialog();

        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Сверка с подразделениями", button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CompareForm CompareForm = new CompareForm();
            CompareForm.Owner = this;
            CompareForm.ShowDialog();
        }

       

       

        
    }
}
