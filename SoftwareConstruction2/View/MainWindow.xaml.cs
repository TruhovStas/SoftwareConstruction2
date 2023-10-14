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
using Microsoft.Win32;
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
            Loging.LoggerInitialize();
            InitializeComponent();
            //Environment.SetEnvironmentVariable()
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RandomMouse.CreateMouse();
            TextBox1.Text += "Объект успешно создан\n";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox1.Text = ProductList.GetProduct(int.Parse(TextBox1.Text)).Description;
            }
            catch
            {
                TextBox1.Text = string.Empty;
                foreach (Product i in ProductList.GetAllProducts())
                {
                    if(i != null) TextBox1.Text += i.Description + "\n\n";
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if ((bool)fileDialog.ShowDialog())
            {
                string path = fileDialog.FileName;
                if (text.IsChecked.Value)
                {
                    ProductList.AddToList(FileReader.ReadFromTextFile(path));
                }
                else if(bin.IsChecked.Value)
                {
                    ProductList.AddToList(FileReader.ReadFromBinFile(path));
                }
                else if(json.IsChecked.Value)
                {
                    ProductList.AddToList(FileReader.ReadFromJsonFile(path));
                }
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();
            if ((bool)fileDialog.ShowDialog())
            {
                try
                {
                    string path = fileDialog.FileName;
                    if (text.IsChecked.Value)
                    {
                        FileReader.WriteToTextFile(ProductList.GetProduct(int.Parse(TextBox1.Text)), path);
                    }
                    else if (bin.IsChecked.Value)
                    {
                        FileReader.WriteToBinFile(ProductList.GetProduct(int.Parse(TextBox1.Text)), path);
                    }
                    else if (json.IsChecked.Value)
                    {
                        FileReader.WriteToJsonFile(ProductList.GetProduct(int.Parse(TextBox1.Text)), path);
                    }

                }
                catch 
                {
                    TextBox1.Text = "Введите ID продукта";
                }
            }
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
                product = TextBox1.Text.Replace("\r", string.Empty).Split('\n').ToList();
            }
            catch (Exception ex) { Loging.Exeption(ex); }
            Factory factory = new Factory();
            ProductList.AddToList(factory.CreateProduct(product[0], product.GetRange(1, product.Count - 1)));
        }
    }
}
