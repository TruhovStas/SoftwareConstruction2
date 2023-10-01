using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Devices
{
    public class Keyboard : Device
    {
        public KeyboardTypes KeyboardType { get; set; }
        public int Size { get; set; }
        public bool HasRussianKeys { get; set; }
        public override string GetDescription()
        {
            string rus = HasRussianKeys ? "+" : "-";
            return base.GetDescription() + $"\nKeyboard type: {KeyboardType}\nSize: {Size}%\nRussian keys: {rus}";

        }
        public override List<string> GetDescriptionInList()
        {
            var x = base.GetDescriptionInList();
            x.AddRange(new List<string>() { ConnectionType.ToString(), KeyboardType.ToString(), Size.ToString(),
            HasRussianKeys.ToString()});
            return x;
        }
        public Keyboard(int id, string name, double price, string man, ConnectionTypes cType, int size, bool hasr, KeyboardTypes type) : 
            base(id, name, price, man, cType) 
        {
            Size = size;
            HasRussianKeys = hasr;
            KeyboardType = type;
        }
    }

    public enum KeyboardTypes { Membrane, Mechanical, Optical }
}
