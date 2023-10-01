using SoftwareConstruction2.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Devices
{
    public abstract class Device : Product
    {
        public ConnectionTypes ConnectionType { get; set; }
        public Device(int id, string name, double price, string man) : base(id, name, price, man) { }
    }
    public enum ConnectionTypes { USB, TypeC, Bluetooth }
}
