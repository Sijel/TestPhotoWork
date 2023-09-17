using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdacha
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }
    }
    static class Database
    {
        // Строка подключения к базе данных
        public static string connection = @"Data Source=baze.db; Integrated Security=False; MultipleActiveResultSets=True";
    }
    static class Users_table
    {
        // Название таблицы пользователей
        public static string main = "Name";
        public static string Id = "Id";
        public static string NameInfo = "Name ";

    }
    static class Photo_table
    {
        // Название таблицы пользователей
        public static string main = "Photo";
        public static string Id = "Id";
        public static string Photo1 = "Photo1";
        public static string Photo2 = "Photo2";
    }
    static class Login_Table
    {
        // Название таблицы пользователей
        public static string main = "User";
        public static string Id = "ID";
        public static string Login = "Login";
        public static string Password = "Password";
    }
}
