using InventoryWPF.Context;
using InventoryWPF.Models;
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

namespace InventoryWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetAll(1);
        }
        private void GetAll(int id)
        {
            using (MyDbContext db = new MyDbContext())
            {
                var data = (from p in db.Products
                            join c in db.Categories
                            on p.CategoryId equals c.Id
                            where p.CategoryId == id
                            select p).ToList();
                foreach (var item in data)
                {
                    DataGrid1.Items.Add(item);
                }

            }

        }

        List<Customer> customers = new List<Customer>()
        {
            new Customer{Id = 1, Name = "Jonh",Address = Address.Tashkent ,Phone = "+998933759899" },
            new Customer{Id = 2, Name = "Nursulton",Address=Address.Samarqand,Phone= "+998936973133"}
        };


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGrid1.Items.Clear();
            GetAll(1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataGrid1.Items.Clear();
            GetAll(2);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataGrid1.Items.Clear();
            GetAll(3);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            DataGrid1.Items.Clear();
            GetAll(5);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            DataGrid1.Items.Clear();
            GetAll(4);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin admin = new Admin();
            this.Visibility = Visibility.Hidden;
            admin.Show();
        }
    }
}
