using SoftwareConstruction2.Model.Devices;
using SoftwareConstruction2.Model.Products.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SoftwareConstruction2.Controller;
using SoftwareConstruction2.Model.Products;
using ProductList;
using Microsoft.Win32;
using SoftwareConstruction2.Conroller;
using System.IO;

namespace SoftwareConstruction2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RandomMouse.CreateMouse();
            TextBox1.Text += "Объект успешно создан\n";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (TextBox1.Text == string.Empty)
            {
                TextBox1.Text = string.Empty;
                foreach (Product i in ProductList.ProductList.GetAllProducts())
                {
                    TextBox1.Text += i.Description + "\n\n";
                }
            }
            else TextBox1.Text = ProductList.ProductList.GetProduct(int.Parse(TextBox1.Text)).Description;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string path = fileDialog.FileName;
            ProductList.ProductList.AddToList(FileReader.ReadFromTextFile(path));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string path = fileDialog.FileName;
            FileReader.WriteToTextFile(ProductList.ProductList.GetProduct(int.Parse(TextBox1.Text)), path);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.ShowDialog();
            string path = fileDialog.FileName;
            ProductList.ProductList.AddToList(FileReader.ReadFromFile(path));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = string.Empty;
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            List<string> product = new List<string>();
            try
            {
                product = TextBox1.Text.Split('\n').ToList();
            }
            catch { }
            Factory factory = new Factory();
            ProductList.ProductList.AddToList(factory.CreateProduct(product[0], product.GetRange(1, product.Count - 1)));
        }
    }
}
