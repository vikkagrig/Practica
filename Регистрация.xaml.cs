using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Швейная_фабрика
{
    /// <summary>
    /// Логика взаимодействия для Регистрация.xaml
    /// </summary>
    public partial class Регистрация : Window
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox1.Text != "" && TextBox1.Text != "")
            {
                using (FactoryEntities1 db = new FactoryEntities1())
                {
                    Users user = new Users()
                    {
                        Login = TextBox1.Text,
                        Password = TextBox2.Text,
                        Role = "Заказчик"
                    };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                MessageBox.Show("Пользователь с логином " + TextBox1.Text + " зарегистрировался");
                Window window = new Авторизация();
                window.Show();
                this.Close();
            }
            else
                MessageBox.Show("Не все поля заполнены");
        }
    }
}
