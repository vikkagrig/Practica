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
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Window
    {
        public Авторизация()
        {
            InitializeComponent();
        }
        Заказчик заказчик;
        Кладовщик кладовщик;
        Менеджер менеджер;
        Директор директор;

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Window window = new Регистрация();
            window.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
                using (FactoryEntities1 db = new FactoryEntities1())
                {
                    foreach (Users user in db.Users)
                    {
                        if (user.Login == TextBox1.Text && user.Password == TextBox2.Text && user.Role == "Заказчик")
                        {
                            заказчик = new Заказчик(this, user);
                            заказчик.Show();
                            this.Visibility = Visibility.Hidden;
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            break;
                        }
                        else if (user.Login == TextBox1.Text && user.Password == TextBox2.Text && user.Role == "Кладовщик")
                        {
                            кладовщик = new Кладовщик(this, user);
                            кладовщик.Show();
                            this.Visibility = Visibility.Hidden;
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            break;
                        }
                        else if (user.Login == TextBox1.Text && user.Password == TextBox2.Text && user.Role == "Менеджер")
                        {
                            менеджер = new Менеджер(this, user);
                            менеджер.Show();
                            this.Visibility = Visibility.Hidden;
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            break;
                        }
                        else if (user.Login == TextBox1.Text && user.Password == TextBox2.Text && user.Role == "Директор")
                        {
                            директор = new Директор(this, user);
                            директор.Show();
                            this.Visibility = Visibility.Hidden;
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            break;
                        }
                    }
                    if (this.Visibility == Visibility.Visible)
                    {
                        MessageBox.Show("Логин или пароль введены неверно");
                    } 
                }
            }
            else 
                MessageBox.Show("Не все поля заполнены");
        }
    }
}
