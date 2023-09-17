using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sdacha
{
    public partial class Form3 : Form
    {
        private SQLiteConnection DB;
        public Form3()
        {
            InitializeComponent();
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(Database.connection);
            await DB.OpenAsync();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // создание новой таблицы данных
            DataTable table = new DataTable();
            // Создание нового адаптера для работы с данными SQLite
            SQLiteDataAdapter adapter = new SQLiteDataAdapter();
            // Создание нового объекта для чтения данных из SQLite
            SQLiteDataReader sqlReader = null;
            // создание новой команды SQL для выполнения запроса на выборку данных из таблицы пользователей
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{Login_Table.main}] WHERE [{Login_Table.Login}]" +
            $" = '" + textBox1.Text + $"' AND [{Login_Table.Password}] = '" + textBox2.Text + "'", DB);
            try
            {
                // установка команды SQL для адаптера
                adapter.SelectCommand = command;
                // Заполнение таблицы данными, полученными из БД
                _ = adapter.Fill(table);
                // Если найдено несколько строк в таблице, то авторизация прошла успешно
                if (table.Rows.Count > 0)
                {
                    // Выполняем запрос на выборку данных из таблицы пользователей и получаем результат в виде объекта SQLiteDataReader
                    sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                    // Читаем данные из объекта SQLiteDataReader
                    while (await sqlReader.ReadAsync())
                    {
                        // Открываем форму выбора автомобиля для пользователя
                        Form1 newForm = new Form1();
                        newForm.Show();
                        Hide();
                    }
                }
                // Если не найдено ни одной строки в таблице, то авторизация не удалась
                else
                {
                    _ = MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации");
                }
            }
            // Обработка исключительных ситуаций
            catch (Exception ex)
            {
                _ = MessageBox.Show($"{ex.Message}", $"{ex.Source}");
            }
            // Освобождение ресурсов
            finally
            {
                sqlReader?.Close();
            }
        }
    }
}
