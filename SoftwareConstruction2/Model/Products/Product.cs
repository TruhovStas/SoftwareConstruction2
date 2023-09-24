using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Products
{
    abstract class Product
    {
        public string Name { get; set; }
        public string Description { get { return GetDescription(); } }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public virtual string GetDescription()
        {
            return $"Name: {Name}\nPrice: {Price} р.\nManufacturer: {Manufacturer}";
        }

        public Product(string name, double price, string man) 
        {
            Name = name;
            Price = price;
            Manufacturer = man;
        }
    }
}
