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
            MouseFabric.CreateMouse();
            TextBox1.Text += "Объект успешно создан\n";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBox1.Text = string.Empty;
            foreach (Product i in ProductList.GetAllProducts())
            {
                TextBox1.Text += i.Description + "\n\n";
            }
        }
    }
}
