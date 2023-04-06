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
    /// Логика взаимодействия для Кладовщик.xaml
    /// </summary>
    public partial class Кладовщик : Window
    {
        Авторизация mainWindow;
        Users user;
        public Кладовщик(Авторизация mainWindow, Users user)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.user = user;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Visibility = Visibility.Visible;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ткань ткань = new Ткань(this.user, this);
            ткань.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Фурнитура фурнитура = new Фурнитура(this.user, this);
            фурнитура.Show();
            this.Hide();
        }

    }
}
