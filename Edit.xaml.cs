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
    /// Interaction logic for Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit()
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
                    int a = Convert.ToInt32(txtProId.Text);
                    using (MyDbContext context = new MyDbContext())
                    {
                        var p1 = context.Products.Find(a);
                        p1.Model = txtModel.Text;
                        p1.Room = txtRoom.Text;
                        p1.Responsible = txtResponsible.Text;
                        p1.MoreInformation = txtMoreInformation.Text;
                        context.Products.Update(p1);
                        context.SaveChanges();
                    }
                }
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
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
