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
    /// Логика взаимодействия для Фурнитура.xaml
    /// </summary>
    public partial class Фурнитура : Window
    {
        Users user;
        Кладовщик clad;
        public Фурнитура(Users user, Кладовщик clad)
        {
            InitializeComponent();
            this.user = user;
            this.clad = clad;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (FactoryEntities1 db = new FactoryEntities1())
            {
                var query = from f in db.Furniture
                            select new { Артикул = f.Article , Название = f.Name, Ширина = f.Width, Длина = f.Lenght, Стоимость = f.Cost , Вес = f.Weight, Количество = f.Quantity};
                DataGrid1.ItemsSource = query.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clad.Show();
            this.Close();
        }

        private void tb1_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGrid1.ItemsSource = null;
            DataGrid1.Items.Clear();
            using (FactoryEntities1 db = new FactoryEntities1())
            {
                var name = db.Products.ToList();
                name = name.Where(p => p.Name.ToLower().Contains(tb1.Text.ToLower())).ToList();
                DataGrid1.ItemsSource = name;
            }
        }
    }
}
