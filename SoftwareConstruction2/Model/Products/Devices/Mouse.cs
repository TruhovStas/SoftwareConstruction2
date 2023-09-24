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
            return base.GetDescription() + $"\nResponse time: {Response}sec.\nAmount of buttons: {ButtonsAmount}";
        }
        public Mouse(string name, double price, string man, double response, int buttonsAmount) : base(name, price, man)
        {
            Response = response;
            ButtonsAmount = buttonsAmount;
        }
    }
}
