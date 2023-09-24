using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareConstruction2.Model.Products;

namespace SoftwareConstruction2.Controller
{
    internal static class ProductList
    {
        private static List<Product> productList = new List<Product>();

        public static void AddToList(Product product) { productList.Add(product); }
        public static List<Product> GetAllProducts() { return productList; }
        public static void ClearList() {  productList.Clear(); }
        public static Product GetProduct(int id) { return productList.FirstOrDefault(x => x.Id == id); }
        public static Product GetProduct(string name) { return productList.FirstOrDefault(x => x.Name == name); }

        public static void DeleteProduct(int id )
        {
            productList.Remove(GetProduct(id));  
        }
        public static void DeleteProduct(string name)
        {
            productList.Remove(GetProduct(name));
        }
    }
}
