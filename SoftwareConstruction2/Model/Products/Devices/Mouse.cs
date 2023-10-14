﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SoftwareConstruction2.Model.Devices
{
    [Serializable]
    public class Mouse : Device
    {
        public double Response { get; set; }
        public int ButtonsAmount { get; set; }
        public override string GetDescription()
        {
            return base.GetDescription() + $"\n{Resource.connectionType}: {ConnectionType}" + $"\n{Resource.responseTime}: {Response} {Resource.ms}\n{Resource.amountOfButtons}: {ButtonsAmount}";
        }
        public override List<string> GetDescriptionInList()
        {
            var x = base.GetDescriptionInList();
            x.AddRange(new List<string>() { ConnectionType.ToString(), Response.ToString(), ButtonsAmount.ToString()});
            return x;
        }
        public Mouse(int id, string name, double price, string man, ConnectionTypes type, double response, int buttonsAmount) : base(id, name, price, man, type)
        {
            Response = response;
            ButtonsAmount = buttonsAmount;
        }
    }
}
