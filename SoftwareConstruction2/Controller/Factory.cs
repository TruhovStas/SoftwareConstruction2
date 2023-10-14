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
            CPU cpu = new CPU(id, name, price, manufacturer, frequency, cores, threads);
            Loging.CreateObject(cpu);
            return cpu;
        }
        public CPU CreateCPU(List<string> parameters)
        {
            CPU cpu =  new CPU(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3],
                double.Parse(parameters[4]), int.Parse(parameters[5]), int.Parse(parameters[6]));
            Loging.CreateObject(cpu);
            return cpu;
        }

        public GPU CreateGPU(int id, string name, double price, string manufacturer, double frequency, int vRAM, int cudaCores, bool rTX, int rTXCores, int tensorCores)
        {
            GPU gpu =  new GPU(id, name, price, manufacturer, frequency, vRAM, cudaCores, rTX, rTXCores, tensorCores);
            Loging.CreateObject(gpu);
            return gpu;
        }
        public GPU CreateGPU(List<string> parameters) 
        {
            GPU gpu = new GPU(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3],
                double.Parse(parameters[4]), int.Parse(parameters[5]), int.Parse(parameters[6]), bool.Parse(parameters[7]),
                int.Parse(parameters[8]), int.Parse(parameters[9]));
            Loging.CreateObject(gpu);
            return gpu;
        }

        public RAM CreateRAM(int id, string name, double price, string manufacturer, double frequency, int capacity, MemoryTypes memoryType)
        {
            RAM ram = new RAM(id, name, price, manufacturer, frequency, capacity, memoryType);
            Loging.CreateObject(ram);
            return ram;
        }

        public RAM CreateRAM(List<string> parameters)
        {
            RAM ram = new RAM(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3],
               double.Parse(parameters[4]), int.Parse(parameters[5]), (MemoryTypes)Enum.Parse(typeof(MemoryTypes), parameters[6]));
            Loging.CreateObject(ram);
            return ram;
        }

        public Keyboard CreateKeyboard(int id, string name, double price, string manufacturer, ConnectionTypes cType, int size, bool hasRussianKeys, KeyboardTypes type)
        {
            Keyboard keyboard = new Keyboard(id, name, price, manufacturer, cType, size, hasRussianKeys, type);
            Loging.CreateObject(keyboard);
            return keyboard;
        }

        public Keyboard CreateKeyboard(List<string> parameters)
        {
            Keyboard keyboard = new Keyboard(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3], 
               (ConnectionTypes)Enum.Parse(typeof(ConnectionTypes), parameters[4]),
               int.Parse(parameters[5]), bool.Parse(parameters[6]), (KeyboardTypes)Enum.Parse(typeof(KeyboardTypes), parameters[7]));
            Loging.CreateObject(keyboard);
            return keyboard;
        }

        public Mouse CreateMouse(int id, string name, double price, string manufacturer, ConnectionTypes type, double response, int buttonsAmount)
        {
            Mouse mouse = new Mouse(id, name, price, manufacturer, type, response, buttonsAmount);
            Loging.CreateObject(mouse);
            return mouse;
        }
        
        public Mouse CreateMouse(List<string> parameters)
        {
            Mouse mouse = new Mouse(int.Parse(parameters[0]), parameters[1], double.Parse(parameters[2]), parameters[3],
               (ConnectionTypes)Enum.Parse(typeof(ConnectionTypes), parameters[4]), double.Parse(parameters[5]), int.Parse(parameters[6]));
            Loging.CreateObject(mouse);
            return mouse;
        }
    }

}
