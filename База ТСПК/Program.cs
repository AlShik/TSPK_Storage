using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace База_ТСПК
{   static class Logs
    {
       public static void Write(string parameterloga)
        {
            try
            {

                FileStream a = new FileStream("Logs.txt", FileMode.Append);
                StreamWriter SW = new StreamWriter(a);

                SW.WriteLine("{0}-{1}", DateTime.Now.ToString(), parameterloga);

                SW.Close();

            }
            catch
            {
                MessageBox.Show("Ошибка записи лога");
            }
        }
             }
    static class GlobalValue
    {
        public static string val { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string DataBaseSourse { get; set; }
        public static string ConnectionStringToDatabase { get; set; }
        public static string Podrazdelenie { get; set; }
        public static string PU { get; set; }
        public static string PunktPropuska { get; set; }
        public static string ID { get; set; }
        public static int ExelROW { get; set; }
        public static int number { get; set; }
        public static string param { get; set; }
        public static string param1 { get; set; }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginWindow(GlobalValue.Login, GlobalValue.DataBaseSourse, GlobalValue.Password));
        }
    }
}
