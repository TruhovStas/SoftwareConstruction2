using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Devices
{
    [Serializable]
    public class Keyboard : Device
    {
        public KeyboardTypes KeyboardType { get; set; }
        public int Size { get; set; }
        public bool HasRussianKeys { get; set; }
        public override string GetDescription()
        {
            string rus = HasRussianKeys ? "+" : "-";
            return base.GetDescription() + $"\n{Resource.connectionType}: {ConnectionType}" + $"\n{Resource.keyboardType}: {KeyboardType}\n{Resource.size}: {Size}%\n{Resource.russianKkeys}: {rus}";

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
