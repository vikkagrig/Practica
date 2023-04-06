using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Швейная_фабрика
{
    /// <summary>
    /// Логика взаимодействия для Изделие.xaml
    /// </summary>
    public partial class Изделие : Window
    {
        Менеджер менеджер;
        Директор директор;
        Users user;
        public Изделие(Менеджер менеджер, Users users)
        {
            InitializeComponent();
            this.менеджер = менеджер;
            this.user = users;
        }
        public Изделие(Директор директор, Users users)
        {
            InitializeComponent();
            this.директор = директор;
            this.user = users;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (FactoryEntities1 db = new FactoryEntities1())
            {
                var query = from product in db.Products
                select new { Артикул = product.Article, Название = product.Name, Ширина = product.Width, Длина = product.Lenght, Стоимость = product.Cost, Количество = product.Quantity };
                DataGrid1.ItemsSource = query.ToList();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(user.Role == "Менеджер")
            {
                менеджер.Visibility = Visibility.Visible;
                this.Close();
            }
            else if(user.Role == "Директор")
            {
                директор.Visibility = Visibility.Visible;
                this.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Изд изд = new Изд();
            изд.Show();
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
