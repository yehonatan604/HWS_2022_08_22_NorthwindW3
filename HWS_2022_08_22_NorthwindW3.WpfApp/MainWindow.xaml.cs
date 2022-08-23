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
using System.Windows.Navigation;
using System.Windows.Shapes;
using HWS_2022_08_22_NorthwindW3.Entities.Models;

namespace HWS_2022_08_22_NorthwindW3.WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly NorthwindContext db = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            var query = from prd in db.Products
                        select new {prd.ProductName, prd.QuantityPerUnit};

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            var query = from prd in db.Products
                        where prd.Discontinued == false
                        select new { prd.ProductId, prd.ProductName };

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            var query = from prd in db.Products
                        where prd.Discontinued == true
                        select new { prd.ProductId, prd.ProductName };

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            var query = from prd in db.Products
                        where prd.UnitPrice == db.Products.Max(p => p.UnitPrice)
                        select new { prd.ProductName, prd.UnitPrice } ;

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            var query = from prd in db.Products
                        where prd.UnitPrice < 20
                        orderby prd.UnitPrice
                        select new { prd.ProductId, prd.ProductName, prd.UnitPrice };

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            var query = from prd in db.Products
                        where prd.UnitPrice > 15 && prd.UnitPrice < 25
                        orderby prd.UnitPrice
                        select new { prd.ProductName, prd.UnitPrice };

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            var query = from prd in db.Products
                        where prd.UnitPrice > db.Products.Average(p => p.UnitPrice)
                        orderby prd.UnitPrice
                        select new { prd.ProductName, prd.UnitPrice };

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            var query = (from prd in db.Products
                        orderby prd.UnitPrice descending
                        select new { prd.ProductName, prd.UnitPrice }).Take(10);

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            int countDis = (from prd in db.Products
                            where prd.Discontinued == false
                            select prd.Discontinued).Count();

            int countCon = (from prd in db.Products
                            where prd.Discontinued == true
                            select prd.Discontinued).Count();

            var query = from count in new List<int>() { countDis, countCon}
                        select new { discontinued = countDis, current = countCon };

            Dgrid.ItemsSource = query.ToList();
        }

        private void Btn10_Click(object sender, RoutedEventArgs e)
        {
            var query = from prd in db.Products
                        where prd.Discontinued == false && prd.UnitsInStock < prd.UnitsOnOrder
                        select new { prd.ProductId, prd.UnitsOnOrder, prd.UnitsInStock };

            Dgrid.ItemsSource = query.ToList();
        }
    }
}
