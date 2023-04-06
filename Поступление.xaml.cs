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
    /// Логика взаимодействия для Поступление.xaml
    /// </summary>
    public partial class Поступление : Window
    {
        public Поступление()
        {
            InitializeComponent();
            ComboBox1.Items.Add("Ткань");
            ComboBox1.Items.Add("Фурнитура");
            ComboBox1.Text = ComboBox1.Items[0].ToString();
            ComboBox3.Items.Add("Поступление");
            ComboBox3.Items.Add("Списание");
            ComboBox3.Text = ComboBox3.Items[0].ToString();
            using (FactoryEntities1 db = new FactoryEntities1())
            {
                var query = from cloth in db.Cloth
                            select new { cloth.Article };
                ComboBox2.ItemsSource = query.ToList();
            }
        }

        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.Text.ToString() == "Ткань")
            {
                using (FactoryEntities1 db = new FactoryEntities1())
                {
                    var query = from cloth in db.Cloth
                                select new { cloth.Article };
                    ComboBox2.ItemsSource = query.ToList();
                }
            }
            else
            {
                using (FactoryEntities1 db = new FactoryEntities1())
                {
                    var query = from f in db.Furniture
                                select new { f.Article };
                    ComboBox2.ItemsSource = query.ToList();
                }
            }
        }

        private void ComboBox3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBox1.Text.ToString() == "Поступление")
            {

            }
            else
            {

            }
        }
    }
}
