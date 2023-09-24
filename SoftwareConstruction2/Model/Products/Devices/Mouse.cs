using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Devices
{
    internal class Mouse : Device
    {
        public double Response { get; set; }
        public int ButtonsAmount { get; set; }
        public override string GetDescription()
        {
            return base.GetDescription() + $"\nResponse time: {Response} ms.\nAmount of buttons: {ButtonsAmount}";
        }
        public Mouse(int id, string name, double price, string man, double response, int buttonsAmount) : base(id, name, price, man)
        {
            Response = response;
            ButtonsAmount = buttonsAmount;
        }
    }
}
