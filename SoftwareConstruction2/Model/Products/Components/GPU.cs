using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Products.Components
{
    [Serializable]
    public class GPU : Components
    {
        public double Frequency { get; set; }
        public int VRAM { get; set; }
        public int CudaCores { get; set; }
        public bool RTX { get; set; }
        public int RTXCores { get; set; }
        public int TensorCores { get; set; }
        public override string GetDescription()
        {
            string rtx = RTX ? "\nRTX cores" + RTXCores.ToString() : "";
            return base.GetDescription() + $"\nFrequency: {Frequency}\nVRAM: {VRAM}\nCuda cores: {CudaCores}\nTensor cores:{TensorCores}" + rtx;
        }
        public override List<string> GetDescriptionInList()
        {
            var x = base.GetDescriptionInList();
            x.AddRange(new List<string>() { Frequency.ToString(), VRAM.ToString(), CudaCores.ToString(),
            RTX.ToString(), RTXCores.ToString(), TensorCores.ToString()});
            return x;
        }
        public GPU(int id, string name, double price, string man, double frequency, int vRAM, int cudaCores, bool rTX, int rTXCores, int tensorCores) :
            base(id, name, price, man)
        {
            Frequency = frequency;
            VRAM = vRAM;
            CudaCores = cudaCores;
            RTX = rTX;
            RTXCores = rTXCores;
            TensorCores = tensorCores;
        }
    }
}
