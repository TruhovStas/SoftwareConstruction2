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
            Log.Information("Object was created:\n" + product.Description + "\n");
        }

        public static void WriteToFileObject(Product product, string path)
        {
            Log.Information("Object :\n" + product.Description + "\nWas wrote in " + path + "\n");
        }

        public static void ReadFromFileObject(Product product, string path)
        {
            Log.Information("Object:\n" + product.Description + "\nWas read from" + path + "\n");
        }

        public static void Exeption(Exception e)
        {
            Log.Error(e.Message + "\n");
        }
    }
}
