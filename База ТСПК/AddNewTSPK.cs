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



    public partial class AddNewTSPK : Form
    {



        public AddNewTSPK()
        {
            InitializeComponent();

            SqlConnection dbConn1;
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd = new SqlCommand("select count (*) from dbo.TSPK", dbConn1);
            dbConn1.Open();
            string str = cmd.ExecuteScalar().ToString();
            int y = Convert.ToInt16(str) + 1;
            textBox9.Text = Convert.ToString(y);
            dbConn1.Close();

        }



        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox13.Hide();
            label24.Hide();
            string StrokaPodvida = comboBox11.Text;
            switch (StrokaPodvida)
            {
                case "Комплекс":
                    {
                        comboBox12.Items.Clear();
                        comboBox12.Items.Add("Транспортируемый пост пограничного контроля типа \"Габарит-М\"");
                        comboBox12.Items.Add("Подвижный пост пограничного контроля типа \"Галоп\"");

                        break;
                    }
                case "Тех. Средства Паспортного Контроля":
                    {
                        comboBox12.Items.Clear();
                        comboBox12.Items.Add("ПТК");
                        comboBox12.Items.Add("Тех.Средства Общей проверки документов");
                        comboBox12.Items.Add("Средства простановки оттисков Даташтампов");
                        comboBox12.Items.Add("Тех. средства специальной проверки документов");

                        break;
                    }

                case "Тех. Средства Осмотра Досмотра":
                    {
                        comboBox12.Items.Clear();
                        comboBox12.Items.Add("Досмотровый прибор типа Ниоген");
                        comboBox12.Items.Add("Досмотровый прибор типа Регула 3022");
                        comboBox12.Items.Add("Эндоскоп Досмотровый");
                        comboBox12.Items.Add("Фонарь аккумуляторный с устройством крепления на элементах одежды");
                        comboBox12.Items.Add("Фонарь аккумуляторный с зарядным устройством");
                        comboBox12.Items.Add("Комплект Щупов типа КЩ-3");
                        comboBox12.Items.Add("Комплект специального инструмента (переносной) типа Гастроль-П");
                        comboBox12.Items.Add("Комплект специального инструмента (стационарный) типа Гастроль-С");
                        break;
                    }
                case "Тех. Средства Обнаружения  Оружия":
                    {
                        comboBox12.Items.Clear();
                        comboBox12.Items.Add("Ручной металлоискатель");

                        break;
                    }
                case "Тех. Средства Аудио-Видео-Фотодокументирования":
                    {
                        comboBox12.Items.Clear();
                        comboBox12.Items.Add("АРМ для обработки и хранения Аудио-,Фото-,Видеоинформации");
                        comboBox12.Items.Add("Цифровой фотоаппарат");
                        comboBox12.Items.Add("Цифровая видеокамера");
                        comboBox12.Items.Add("Электронный автоматический переводчик");
                        comboBox12.Items.Add("Диктофон");
                        break;
                    }
                case "Средства обеспечения эксплуатации технических средств пограничного контроля и вспомогательное оборудование":
                    {
                        comboBox12.Items.Clear();
                        comboBox12.Items.Add("Универсальное рабочее место радиомеханика");
                        comboBox12.Items.Add("Пропускные модули и кабины паспортного контроля");
                        comboBox12.Items.Add("Стеллажи для хранения ТСПК и пополняемого состава комплектующих изделий");
                        comboBox12.Items.Add("Средства принудительной остановки автотранспорта");
                        comboBox12.Items.Add("Автоматический шлагбаум");
                        comboBox12.Items.Add("Двухпозиционный светофор");
                        comboBox12.Items.Add("Аппаратура по хранению и выдачи даташтампов типа \"Ключ\"");
                        comboBox12.Items.Add("USB-накопитель / жесткий диск объемом не менее 500 Гб");
                        comboBox12.Items.Add("Зарядное устройство универсальное для АКБ тип АА, ААА и прочих");
                        comboBox12.Items.Add("Устройство для уничтожения Бумаг, Дисков,Дискет");
                        comboBox12.Items.Add("Плоттер формата А1");
                        comboBox12.Items.Add("Брошюратор");
                        comboBox12.Items.Add("Система кондиционирования (кондиционер, сплит-система серверного помещения ПТК и ЦОД)");
                        comboBox12.Items.Add("Холодильник для хранения элементов питания емкостью не менее 120л");
                        comboBox12.Items.Add("Ламинатор формата А4");
                        break;
                    }
                case "Специальные Технические средства обучения и учебное оборудование":
                    {
                        comboBox12.Items.Clear();
                        comboBox12.Items.Add("Компьютерный тренажер \"Визит КТ-1\", \"Визит КТ-2\",\"Яхонт\"");
                        comboBox12.Items.Add("АК ТСО");
                        comboBox12.Items.Add("Мультимедийный проектор с экраном");
                        comboBox12.Items.Add("Устройство отображения информации (Интерактивная доска)");
                        break;
                    }
                case "Копировально-Множительная Техника":
                    {
                        comboBox12.Items.Clear();
                        comboBox12.Items.Add("МФУ");
                        comboBox12.Items.Add("Копировально-множительный аппарат формата А3");
                        comboBox12.Items.Add("Принтер лазерный для цветной печати формата А3");
                        comboBox12.Items.Add("Принтер формата А4");
                        comboBox12.Items.Add("Сканер формата А4");
                        break;
                    }
            }


        } //содержание комбобоксов

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            string StrokaForPodvidPodvida = comboBox12.Text;


            switch (StrokaForPodvidPodvida)
            {
                case "ПТК":
                    {
                        comboBox13.Items.Clear();
                        comboBox13.Text = "Выберите...";
                        comboBox13.Items.Add("АРМ ОПК");
                        comboBox13.Items.Add("АРМ ОПК Мобильный со считывателем паспортов и виз");
                        comboBox13.Items.Add("ПТК в ЦОД");
                        comboBox13.Items.Add("АРМ ОПК, СЦОД облегченной версии ПАК МСПВ \"Каскад-Л\"");
                        comboBox13.Items.Add("АРМ ОПК Мобильный облегченной версии ПАК МСПВ \"Каскад-Л\" ");
                        comboBox13.Items.Add("АРМ Других Типов");
                        comboBox13.Show();
                        label24.Show();
                        break;
                    }

                case "Тех.Средства Общей проверки документов":
                    {
                        comboBox13.Items.Clear();
                        comboBox13.Text = "Выберите...";
                        comboBox13.Items.Add("Портативный осветитель типа \"Шкода\", \"Регула 1010\", \"Ультрамаг А36\"");
                        comboBox13.Items.Add("Прибор для проверки документов типа \"Ультрамаг-5СЛГ\", \"ППД-СМ\", \"Генетика 02.01\", \"Генетика 09.01\", \"Генетика 3\"");
                        comboBox13.Show();
                        label24.Show();
                    }
                    break;

                case "Средства простановки оттисков Даташтампов":
                    {
                        comboBox13.Items.Clear();
                        comboBox13.Text = "Выберите...";
                        comboBox13.Items.Add("Даташтамп типа Тродат \"5430\", GRM");
                        comboBox13.Items.Add("Даташтамп типа Тродат \"4430\" ");
                        comboBox13.Show();
                        label24.Show();
                    }
                    break;
                case "Тех. средства специальной проверки документов":
                    {
                        comboBox13.Items.Clear();
                        comboBox13.Text = "Выберите...";
                        comboBox13.Items.Add("Информационно-поисковая система типа ИПС «Яшма»");
                        comboBox13.Items.Add("Информационно-поисковая система типа «Рубеж-ИПС КТ-1» («Рубеж-ИПС КТ-2») ");
                        comboBox13.Items.Add("Прибор специальной проверки документов типа «Ультрамаг-С6У», «Генетика-02.02», «Генетика-09.02»");
                        comboBox13.Items.Add("Переносной комбинированный ультрафиолетовый и инфракрасный осветитель типа «Корунд»");
                        comboBox13.Items.Add("Атлас паспортов иностранных государств «Яшма-А»");
                        comboBox13.Items.Add("Мобильная мини лаборатория для специальной проверки в нестационарных условиях");
                        comboBox13.Items.Add("Микроскоп типа МБС-10, МСП-1");
                        comboBox13.Show();
                        label24.Show();
                    }
                    break;

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection dbConn1;
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase); // dbConn1 = new SqlConnection ("Data Source=WIN-TVNE764OSJI;Initial Catalog=TSPK;Persist Security Info=True;User ID=sa;Password=allstars;");

            //Add photo of TSPK

            SqlParameter sqlparam = new SqlParameter("@img", SqlDbType.Image);
            string ImageName = textBox10.Text;
            
            try
            {
                Image image = Image.FromFile(ImageName);
                MemoryStream memorystream = new MemoryStream();
                image.Save(memorystream, System.Drawing.Imaging.ImageFormat.Jpeg);
                sqlparam.Value = memorystream.ToArray();
                memorystream.Dispose();
            }
            catch { MessageBox.Show("Выберите Фото"); }

            // 
            

            var cmd = new SqlCommand("INSERT INTO dbo.TSPK (ПУ, Подразделение, ПунктПропуска, ВидСообщения, НаименованиеИзделия ,Забаланс, ДатаВыпуска, НаименованиеИзготовителя, ДокументОПриемке, ДатаПоставки, ДатаВводаВЭксплуатацию, ЗаводскойНомер, ИнвентарныйНомер, СрокСлужбы, ГарантийныйСрок, НаходитсяВЭксплуатации, НедоработкаПереработка, Категория, ПриказОЗакреплении, НомерФормуляра, ТребуетсяРемонт, ВидТСПК, ПодвидТСПК, ПодвидПодвидаТСПК, Фото ) VALUES (@PU, @Podrazdeleniye, @PunktPropuska, @VidSoobsheniya, @NaimenovanieIzdeliya, @Zabalans, @DataVipuska, @NaimenovanieIzgotovitelya, @DocumentOPriemke, @DataPostavki, @DataVvodaVExplotaciy, @ZavodskoiNomer, @InventarniiNomer, @SrokSluzhbi, @GarantiiniiSrok, @NahoditsyaVExplotacii, @NedorabotkaPererabotka, @Kategoriya, @PrikazoZakreplenii, @NomerFormulyara, @TrebuetsyaRemont, @VidTSPK, @PodvidTSPK, @PodvidPodvidaTSPK, @img)", dbConn1);
            cmd.Connection = dbConn1;
            cmd.Parameters.AddWithValue("@PU", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Podrazdeleniye", comboBox2.Text);
            cmd.Parameters.AddWithValue("@PunktPropuska", comboBox3.Text);
            cmd.Parameters.AddWithValue("@VidSoobsheniya", comboBox4.Text);
            cmd.Parameters.AddWithValue("@NaimenovanieIzdeliya", comboBox20.Text);
            cmd.Parameters.AddWithValue("@Zabalans", comboBox14.Text);
            cmd.Parameters.AddWithValue("@DataVipuska", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@NaimenovanieIzgotovitelya", textBox2.Text);
            cmd.Parameters.AddWithValue("@DocumentOPriemke", textBox3.Text);
            cmd.Parameters.AddWithValue("@DataPostavki", dateTimePicker2.Value);
            if (checkBox1.Checked)
            { cmd.Parameters.AddWithValue("@DataVvodaVExplotaciy", "-"); }
            else { cmd.Parameters.AddWithValue("@DataVvodaVExplotaciy", dateTimePicker3.Value); } 

            cmd.Parameters.AddWithValue("@ZavodskoiNomer", textBox4.Text);
            cmd.Parameters.AddWithValue("@InventarniiNomer", textBox5.Text);
            cmd.Parameters.AddWithValue("@SrokSluzhbi", comboBox5.Text);
            cmd.Parameters.AddWithValue("@GarantiiniiSrok", comboBox6.Text);
            cmd.Parameters.AddWithValue("@NahoditsyaVExplotacii", comboBox7.Text);
            cmd.Parameters.AddWithValue("@NedorabotkaPererabotka", comboBox8.Text);
            cmd.Parameters.AddWithValue("@Kategoriya", comboBox9.Text);
            cmd.Parameters.AddWithValue("@PrikazoZakreplenii", textBox6.Text);
            cmd.Parameters.AddWithValue("@NomerFormulyara", textBox7.Text);
            cmd.Parameters.AddWithValue("@TrebuetsyaRemont", comboBox10.Text);
            cmd.Parameters.AddWithValue("@VidTSPK", comboBox11.Text);
            cmd.Parameters.AddWithValue("PodvidTSPK", comboBox12.Text);
            cmd.Parameters.AddWithValue("@PodvidPodvidaTSPK", comboBox13.Text);
            cmd.Parameters.AddWithValue("@img", sqlparam.Value);
            var cmd1 = new SqlCommand("INSERT INTO dbo.Documents (НомерТСПКвБазе, Документ, НомерДокумента, ДатаДокумента, Отправитель, Получатель, ПУ_Отправитель, ПУ_Получатель ) VALUES (@NomerTSPKvBD, @Document, @NomerDocumenta, @DataDocumenta, @Otpravitel, @Poluchatel, @PUOtpravitel ,@PUPoluchatel )", dbConn1);
           // cmd1.Parameters.AddWithValue("@NomerTSPKvBD", textBox9.Text);
            cmd1.Parameters.AddWithValue("@Document", comboBox15.Text);
            cmd1.Parameters.AddWithValue("@NomerDocumenta", textBox8.Text);
            cmd1.Parameters.AddWithValue("@DataDocumenta", dateTimePicker4.Value);
            cmd1.Parameters.AddWithValue("@Otpravitel", comboBox16.Text);
            cmd1.Parameters.AddWithValue("@Poluchatel", comboBox17.Text);
            cmd1.Parameters.AddWithValue("@PUOtpravitel", comboBox18.Text); 
            cmd1.Parameters.AddWithValue("@PUPoluchatel", comboBox19.Text);
            var viborposlednegoID = new SqlCommand("select  НомерТСПКвБазе  from dbo.TSPK   order by НомерТСПКвБазе desc");
            viborposlednegoID.Connection = dbConn1;
            
            
            try
            {
                dbConn1.Open();
                cmd.ExecuteNonQuery();
                GlobalValue.ID = viborposlednegoID.ExecuteScalar().ToString();
                cmd1.Parameters.AddWithValue("@NomerTSPKvBD", GlobalValue.ID);
                cmd1.ExecuteNonQuery();

                MessageBox.Show("Новое ТСПК Добавлено в Базу, добавьте комплектность ТСПК");
                Logs.Write("Добавление ТСПК:" + " Наименование Изделия = " + comboBox20.Text + "; Заводской номер=" + textBox4.Text + "; ПУ=" + comboBox1.Text + "; Подразделение=" + comboBox2.Text + "; ПунктПропуска=" + comboBox3.Text);
                dbConn1.Close();
                AddPartsofTSPK AddPart = new AddPartsofTSPK();
                AddPart.Owner = this;
                AddPart.ShowDialog();
                
            }
            catch
            {
                MessageBox.Show("Ошибка, проверьте правильность ввода!! \n P.S. Добавление ТСПК возможно только под учетной записью администратора программы");
            }

        }

     //   private void checkBox1_CheckedChanged(object sender, EventArgs e)
      //  {
           // if (checkBox1.Checked)
           //     button2.Enabled = false;
           // else button2.Enabled = true;
      //  }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void AddNewTSPK_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "podrazdel.Vocabulary_Podrazdelenie". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PodrazdelenieTableAdapter1.Fill(this.podrazdel.Vocabulary_Podrazdelenie);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "addDocInAddTSPK.Vocabulary_PU". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PUTableAdapter1.Fill(this.addDocInAddTSPK.Vocabulary_PU);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet1.Vocabulary_PU". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PUTableAdapter.Fill(this.tSPKDataSet1.Vocabulary_PU);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet1.Vocabulary_PunktPropuska_". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PunktPropuska_TableAdapter.Fill(this.tSPKDataSet1.Vocabulary_PunktPropuska_);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tSPKDataSet1.Vocabulary_Podrazdelenie". При необходимости она может быть перемещена или удалена.
            this.vocabulary_PodrazdelenieTableAdapter.Fill(this.tSPKDataSet1.Vocabulary_Podrazdelenie);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Изображения (*.Jpeg; *.JPG;)|*.Jpeg; *.JPG;";

            opf.ShowDialog();

            if (opf.FileName == string.Empty) return;
            textBox10.Text = opf.FileName;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                dateTimePicker3.Enabled = false;
                
            }
            else { dateTimePicker3.Enabled = true; }
        }

        private void comboBox20_MouseClick(object sender, MouseEventArgs e)
        {
            
            SqlConnection dbConn1 = new SqlConnection();
            dbConn1 = new SqlConnection(GlobalValue.ConnectionStringToDatabase);
            var cmd2 = new SqlCommand("select Name from dbo.NameTSPK", dbConn1);
            dbConn1.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
            DataSet dataset = new DataSet();
            // adapter.TableMappings.Add("1","2");
            adapter.SelectCommand = cmd2;
            adapter.Fill(dataset);
            comboBox20.DataSource = dataset.Tables[0];
            comboBox20.DisplayMember = "Name";
            //   comboBox2.ValueMember = "1"; 
            dbConn1.Close();
        }




    }
}


