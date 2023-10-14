using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareConstruction2.Model.Products;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace SoftwareConstruction2.Controller
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

        public static void WriteToBinFile(Product product, string path)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Write))
                {
                    bf.Serialize(stream, product);
                }
            }
            catch { }
        }

        public static Product ReadFromBinFile(string path)
        {
            Product product = null;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {

                    product = (Product)bf.Deserialize(stream);
                }
            }
            catch { }
            return product;
        }

        public static void WriteToJsonFile(Product product, string path)
        {
            try
            {
                string json = JsonConvert.SerializeObject(product, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    Formatting = Formatting.Indented
                });
                File.WriteAllText(path, json);
            }
            catch { }
        }


        public static Product ReadFromJsonFile(string path) 
        {
            Product product = null;
            try
            {
                product = JsonConvert.DeserializeObject<Product>(File.ReadAllText(path), new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            }
            catch { }
            return product;
        }
    }
}
