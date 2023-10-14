using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using SoftwareConstruction2.Model.Products;

namespace SoftwareConstruction2.Controller
{
    internal static class Loging
    {
        public static void LoggerInitialize() 
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File("Log.log").CreateLogger();
        }

        public static void CreateObject(Product product)
        {
            Log.Information("Был создан объект:\n" + product.Description + "\n");
        }

        public static void WriteToFileObject(Product product, string path)
        {
            Log.Information("объект:\n" + product.Description + "\nбыл записан в " + path + "\n");
        }

        public static void ReadFromFileObject(Product product, string path)
        {
            Log.Information("объект:\n" + product.Description + "\nбыл считан из " + path + "\n");
        }

        public static void Exeption(Exception e)
        {
            Log.Error(e.Message + "\n");
        }
    }
}
