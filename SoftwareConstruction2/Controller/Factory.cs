using SoftwareConstruction2.Model.Devices;
using SoftwareConstruction2.Model.Products.Components;
using SoftwareConstruction2.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Controller
{
    public class Factory
    {
        public Product CreateProduct(string productType, List<string> parameters)
        {
            switch (productType) 
            {
                case "CPU": return CreateCPU(parameters);
                case "GPU": return CreateGPU(parameters);
                case "RAM": return CreateRAM(parameters);
                case "Keyboard": return CreateKeyboard(parameters);
                case "Mouse": return CreateMouse(parameters);
                default: return null;
            }
        }
        public CPU CreateCPU(int id, string name, double price, string manufacturer, double frequency, int cores, int threads)
        {
            return new CPU(id, name, price, manufacturer, frequency, cores, threads);
        }
        public CPU CreateCPU(List<string> parameters)
        {
            return new CPU(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3],
                double.Parse(parameters[4]), int.Parse(parameters[5]), int.Parse(parameters[6]));
        }

        public GPU CreateGPU(int id, string name, double price, string manufacturer, double frequency, int vRAM, int cudaCores, bool rTX, int rTXCores, int tensorCores)
        {
            return new GPU(id, name, price, manufacturer, frequency, vRAM, cudaCores, rTX, rTXCores, tensorCores);
        }
        public GPU CreateGPU(List<string> parameters) 
        {
            return new GPU(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3],
                double.Parse(parameters[4]), int.Parse(parameters[5]), int.Parse(parameters[6]), bool.Parse(parameters[7]),
                int.Parse(parameters[8]), int.Parse(parameters[9]));
        }

        public RAM CreateRAM(int id, string name, double price, string manufacturer, double frequency, int capacity, MemoryTypes memoryType)
        {
            return new RAM(id, name, price, manufacturer, frequency, capacity, memoryType);
        }

        public RAM CreateRAM(List<string> parameters)
        {
            return new RAM(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3],
               double.Parse(parameters[4]), int.Parse(parameters[5]), (MemoryTypes)Enum.Parse(typeof(MemoryTypes), parameters[6]));
        }

        public Keyboard CreateKeyboard(int id, string name, double price, string manufacturer, ConnectionTypes cType, int size, bool hasRussianKeys, KeyboardTypes type)
        {
            return new Keyboard(id, name, price, manufacturer, cType, size, hasRussianKeys, type);
        }

        public Keyboard CreateKeyboard(List<string> parameters)
        {
            return new Keyboard(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3], 
               (ConnectionTypes)Enum.Parse(typeof(ConnectionTypes), parameters[4]),
               int.Parse(parameters[5]), bool.Parse(parameters[6]), (KeyboardTypes)Enum.Parse(typeof(KeyboardTypes), parameters[7]));
        }

        public Mouse CreateMouse(int id, string name, double price, string manufacturer, ConnectionTypes type, double response, int buttonsAmount)
        {
            return new Mouse(id, name, price, manufacturer, type, response, buttonsAmount);
        }
        
        public Mouse CreateMouse(List<string> parameters)
        {
            return new Mouse(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3],
               (ConnectionTypes)Enum.Parse(typeof(ConnectionTypes), parameters[4]), double.Parse(parameters[5]), int.Parse(parameters[6]));
        }
    }

}
