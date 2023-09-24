using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Products
{
    abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get { return GetDescription(); } }
        public double Price { get; set; }
        public double? Sale { get; set; }
        public string Manufacturer { get; set; }
        public virtual string GetDescription()
        {
            return $"ID: {Id}\nName: {Name}\nPrice: {CalculateSale()} р.\nManufacturer: {Manufacturer}";
        }

        public Product(int id, string name, double price, string man) 
        {
            Name = name;
            Price = price;
            Manufacturer = man;
            Id = id;
        }

        public double CalculateSale()
        {
            if(Sale != null) return Price * (double)Sale;
            else return Price;
        }
        public void ApplySale(double sale)
        {
            if (sale > 0 && sale < 100) Sale = sale / 100;
        }
    }
}
