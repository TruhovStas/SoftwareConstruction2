using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Products.Components
{
    internal class RAM : Components
    {
        public double Frequency { get; set; }
        public int Capacity { get; set; }
        public MemoryTypes MemoryType { get; set; }
        public override string GetDescription()
        {
            return base.GetDescription() + $"\nFrequency: {Frequency}\nCapacity: {Capacity}\nMemory type: {MemoryType}";
        }
        public RAM(string name, double price, string man, double frequency, int capacity, MemoryTypes memoryType) : base(name, price, man)
        {
            Frequency = frequency;
            Capacity = capacity;
            MemoryType = memoryType;
        }
    }

    enum MemoryTypes { DDR3, DDR4, DDR5 }
}
