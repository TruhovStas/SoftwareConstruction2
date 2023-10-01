using SoftwareConstruction2.Controller;
using SoftwareConstruction2.Model.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductList;

namespace SoftwareConstruction2.Controller
{
    public static class MouseFabric
    {
        private static List<string> ManName = new List<string>()
        {
            "Logitech", "Bloody", "AMD", "Intel", "Nvidia", "Apple", "Samsung", "Noname" 
        };
        private static int IdCounter = 1;
        private static Random ran = new Random();
        public static void CreateMouse()
        {
            string man = ManName[ran.Next(7)];
            ProductList.ProductList.AddToList(new Mouse(IdCounter, RandomName(man), ran.Next(1, 100), man, ran.Next(1, 100), ran.Next(2, 10)));
            IdCounter++;
        }
        private static string RandomName(string man)
        {
            man += "-";
            for(int i = 0; i < 5; i++) 
            {
                man += ran.Next(9).ToString();
            }
            return man;
        }
    }
}
