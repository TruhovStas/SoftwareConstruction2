using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Products
{
    [Serializable]
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get { return GetDescription(); } }
        public double Price { get; set; }
        public string Manufacturer { get; set; }
        public virtual string GetDescription()
        {
            return $"ID: {Id}\nName: {Name}\nPrice: {Price} р.\nManufacturer: {Manufacturer}";
        }

        public virtual List<string> GetDescriptionInList()
        {
            return new List<string>() { Id.ToString(), Name, Price.ToString(), Manufacturer };
        }

        public Product(int id, string name, double price, string man)
        {
            Name = name;
            Price = price;
            Manufacturer = man;
            Id = id;
        }

    }
}
