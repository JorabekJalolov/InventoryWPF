using InventoryWPF.Context;
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
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : Window
    {
        public Details( object product)
        {
            InitializeComponent();
            DataContext = product;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow admin = new MainWindow();
            this.Visibility = Visibility.Hidden;
            admin.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var proId = Convert.ToInt32(txtProId.Text);
            using (MyDbContext context = new MyDbContext())
            {
                var data = context.Products.Find(proId);
                context.Products.Remove(data);
                context.SaveChanges();
            }
            MainWindow Mainn = new MainWindow();
            Mainn.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Edit cr = new Edit();          
            var proId = Convert.ToInt32(txtProId.Text);
            using (MyDbContext context = new MyDbContext())
            {
                var data = context.Products.Find(proId); 
                cr.txtProId.Text = data.Id.ToString();
                cr.txtModel.Text = data.Model;
                cr.txtRoom.Text = data.Room.ToString();
                cr.txtResponsible.Text = data.Responsible;
                cr.txtMoreInformation.Text = data.MoreInformation;
            }
            cr.Show();
        }
    }
}
