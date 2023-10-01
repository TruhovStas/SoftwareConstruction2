using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductList;
using System.IO;

namespace SoftwareConstruction2.Conroller
{
    internal static class FileReader
    {
        public static Product ReadFromTextFile(string path)
        {
            List<string> product = new List<string>();
            try
            {
                string text = File.ReadAllText(path);
                product = text.Split('\n').ToList();
            }
            catch { }
            Factory factory = new Factory();
            return factory.CreateProduct(product[0], product.GetRange(1, product.Count - 1));
            
        }

        public static Product ReadFromFile(string path) 
        {
            List<string> product = new List<string>();
            try
            {
                byte[] bytes = File.ReadAllBytes(path);
                string text = Encoding.UTF8.GetString(bytes);
                product = text.Split('\n').ToList();
            }
            catch { }
            Factory factory = new Factory();
            return factory.CreateProduct(product[0], product.GetRange(1, product.Count - 1));
        }

        public static void WriteToTextFile(Product product, string path)
        {
            List<string> description = product.GetDescriptionInList();
            string text = product.GetType().Name + "\n";
            foreach (var item in description) 
            {
                text += item + "\n";
            }
            try
            {
                File.WriteAllText(path, text);
            }
            catch { }
        }
    }
}
