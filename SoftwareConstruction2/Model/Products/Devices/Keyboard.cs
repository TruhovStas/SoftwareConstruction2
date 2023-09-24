using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Devices
{
    internal class Keyboard : Device
    {
        public KeyboardTypes KeyboardType { get; set; }
        public int Size { get; set; }
        public bool HasRussianKeys { get; set; }
        public override string GetDescription()
        {
            string rus = HasRussianKeys ? "+" : "-";
            return base.GetDescription() + $"\nKeyboard type: {KeyboardType}\nSize: {Size}%\nRussian keys: {rus}";
        }
        public Keyboard(string name, double price, string man, int size, bool hasr, KeyboardTypes type) : base(name, price, man) 
        {
            Size = size;
            HasRussianKeys = hasr;
            KeyboardType = type;
        }
    }

    enum KeyboardTypes { Membrane, Mechanical, Optical }
}
