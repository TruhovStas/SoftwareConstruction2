using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductList
{
    public static class ProductList
    {
        private static List<Product> productList = new List<Product>();

        public static void AddToList(Product product) { productList.Add(product); }
        public static List<Product> GetAllProducts() { return productList; }
        public static void ClearList() { productList.Clear(); }
        public static Product GetProduct(int id) { return productList.FirstOrDefault(x => x.Id == id); }
        public static Product GetProduct(string name) { return productList.FirstOrDefault(x => x.Name == name); }

        public static void DeleteProduct(int id)
        {
            productList.Remove(GetProduct(id));
        }
        public static void DeleteProduct(string name)
        {
            productList.Remove(GetProduct(name));
        }
    }
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
            return new List<string>() {Id.ToString(), Name, Price.ToString(), Manufacturer };
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
