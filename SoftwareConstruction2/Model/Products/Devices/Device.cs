using SoftwareConstruction2.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Devices
{
    abstract class Device : Product
    {
        public ConnectionTypes ConnectionType { get; set; }
        public Device(string name, double price, string man) : base(name, price, man) { }
    }
    enum ConnectionTypes { USB, TypeC, Bluetooth }
}
