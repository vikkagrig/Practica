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
    /// Логика взаимодействия для Клиент.xaml
    /// </summary>
    public partial class Заказчик : Window
    {
        Авторизация mainWindow;
        Users user;
        public Заказчик(Авторизация mainWindow, Users user)
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
            Изд изделие = new Изд();
            изделие.Show();
        }
    }
}
