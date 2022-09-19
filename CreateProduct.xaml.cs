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
using System.Windows.Shapes;

namespace InventoryWPF
{
    /// <summary>
    /// Interaction logic for CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {
        public CreateProduct()
        {
            InitializeComponent();
            GetCategory();
        }
        private List<Category> Category { get; set; }
        private void GetCategory()
        {
            using (MyDbContext db = new MyDbContext())
            {
                var item = db.Categories.ToList();
                Category = item;
                DataContext = Category;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (!(txtModel.Text == "") && !(txtRoom.Text == "") && !(txtResponsible.Text == "") && !(txtMoreInformation.Text == "") && !(txtCategory.Text == ""))
            {
                using (MyDbContext db = new MyDbContext())
                {
                    var d1 = db.Categories.FirstOrDefault(a => a.Name.Equals(txtCategory.Text));
                    Product product = new Product()
                    {
                        Model = txtModel.Text,
                        Room = txtRoom.Text,
                        Responsible = txtResponsible.Text,
                        MoreInformation = txtMoreInformation.Text,
                        CategoryId = d1.Id
                    };
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                MainWindow Mainn = new MainWindow();
                Mainn.Show();
            }
            else
            {
                MessageBox.Show("Is Null");
            }


           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
