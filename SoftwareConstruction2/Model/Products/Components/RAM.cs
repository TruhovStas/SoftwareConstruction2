using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Products.Components
{
    [Serializable]
    public class RAM : Components
    {
        public double Frequency { get; set; }
        public int Capacity { get; set; }
        public MemoryTypes MemoryType { get; set; }
        public override string GetDescription()
        {
            return base.GetDescription() + $"\n{Resource.frequency}: {Frequency}\n{Resource.capacity}: {Capacity}\n{Resource.memoryType}: {MemoryType}";
        }
        public override List<string> GetDescriptionInList()
        {
            var x = base.GetDescriptionInList();
            x.AddRange(new List<string>() { Frequency.ToString(), Capacity.ToString(), MemoryType.ToString() });
            return x;
        }
        public RAM(int id, string name, double price, string man, double frequency, int capacity, MemoryTypes memoryType) :
            base(id, name, price, man)
        {
            Frequency = frequency;
            Capacity = capacity;
            MemoryType = memoryType;
        }
    }

    public enum MemoryTypes { DDR3, DDR4, DDR5 }
}
