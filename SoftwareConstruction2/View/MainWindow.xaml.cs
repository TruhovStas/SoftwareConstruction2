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
using SoftwareConstruction2.Conroller;

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
            for(int i = 1; i < 10; i++) 
            {
                Fabric.CreateMouse();
                TextBox1.Text +=  ProductList.GetProduct(i).Description + "\n\n";
            }
        }
    }
}
