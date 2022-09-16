using InventoryWPF.Context;
using InventoryWPF.Models;
using Microsoft.EntityFrameworkCore;
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
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            GetCategory();
            GetAll();
        }
    
        private List<Category> Category { get; set; }
        private void GetCategory()
        {
            using(MyDbContext db = new MyDbContext())
            {
                var item = db.Categories.ToList();
                Category = item;
                DataContext = Category; 
            }
        }
        private void GetAll()
        {
            using(MyDbContext db = new MyDbContext())
            {
                var data = db.Products.ToList();
                foreach (var item in data)
                {
                    DataGrid1.Items.Add(item);
                }
            }

        }
        private void textModel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textModel.Focus();
        }

        private void txtModel_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtModel.Text) && txtModel.Text.Length > 0)
            {
                textModel.Visibility = Visibility.Collapsed;
            }
            else
            {
                textModel.Visibility = Visibility.Visible;
            }
        }

        private void txtRoom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRoom.Text) && txtRoom.Text.Length > 0)
            {
                textRoom.Visibility = Visibility.Collapsed;
            }
            else
            {
                textRoom.Visibility = Visibility.Visible;
            }
        }

        private void textRoom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textRoom.Focus();
        }

        private void txtResponsible_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResponsible.Text) && txtResponsible.Text.Length > 0)
            {
                textResponsible.Visibility = Visibility.Collapsed;
            }
            else
            {
                textResponsible.Visibility = Visibility.Visible;
            }
        }

        private void textResponsible_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textResponsible.Focus();
        }

        private void textMoreInformation_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textMoreInformation.Focus();
        }

        private void txtMoreInformation_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtMoreInformation.Text) && txtMoreInformation.Text.Length > 0)
            {
                textMoreInformation.Visibility = Visibility.Collapsed;
            }
            else
            {
                textMoreInformation.Visibility = Visibility.Visible;
            }
        }

       

        private void Button_Click(object sender, RoutedEventArgs e)
        {        
            using(MyDbContext db = new MyDbContext())
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
                DataGrid1.Items.Clear();    
                GetAll();
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (DataGrid)sender;
            var product = (Product)item.SelectedItem;


            if (product == null)
            {
                GetAll();            
            }
            else
            {
                var proId = product.Id;
                if (deleteCheck.IsChecked == true)
                {
                    using (MyDbContext context = new MyDbContext())
                    {
                        var data = context.Products.Find(proId);
                        txtProId.Text = data.Id.ToString();
                        txtModel.Text = data.Model;
                        txtRoom.Text = data.Room.ToString();
                        txtResponsible.Text = data.Responsible;
                        txtMoreInformation.Text = data.MoreInformation;
                        DataGrid1.Items.Clear();
                    }
                    
                }
                else if (editCheck.IsChecked == true)
                {
                    using (MyDbContext context = new MyDbContext())
                    {       
                        var data = context.Products.Find(proId);
                        txtProId.Text = data.Id.ToString();
                        txtModel.Text = data.Model;
                        txtRoom.Text = data.Room.ToString();
                        txtResponsible.Text = data.Responsible;
                        txtMoreInformation.Text = data.MoreInformation;                       
                        DataGrid1.Items.Clear();
                    }
                }
                else
                {
                    MessageBox.Show($"Agarda siz malumotni o'zgartirmoqchi yoki o'chirmoqchi bo'lsangiz oldin checkBox ni tanlashingiz kerak!");
                    DataGrid1.Items.Clear();                   
                }
            }
        }
        private void Clear()
        {
            txtProId.Clear();
            txtModel.Clear();
            txtRoom.Clear();
            txtResponsible.Clear();
            txtMoreInformation.Clear();
        }

        private void editCheck_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void deleteCheck_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            var proId = Convert.ToInt32(txtProId.Text);
            using (MyDbContext context = new MyDbContext())
            {
                var p1 = context.Products.Find(proId);
                p1.Model = txtModel.Text;
                p1.Room = txtRoom.Text;
                p1.Responsible = txtResponsible.Text;
                p1.MoreInformation = txtMoreInformation.Text;
                context.Products.Update(p1);
                context.SaveChanges();
                DataGrid1.Items.Clear();               
            }           
            Clear();
            GetAll();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

            var proId = Convert.ToInt32(txtProId.Text);
            using (MyDbContext context = new MyDbContext())
            {
                var data = context.Products.Find(proId);
                context.Products.Remove(data);
                context.SaveChanges();
                DataGrid1.Items.Clear();
            }
            Clear();
            GetAll();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var a = txtSearch.Text.ToUpper();
            if ((txtSearch.Text) == null)
            {
                DataGrid1.Items.Clear();
                GetAll();
            }
            else
            {
                DataGrid1.Items.Clear();
                using (MyDbContext db = new MyDbContext())
                {

                    var d11 = db.Products.Where(x => x.Room.Contains(txtSearch.Text)).ToList();
                    foreach (var item in d11)
                    {
                        DataGrid1.Items.Add(item);
                    }
                }
            }
           
        }
    }
}
