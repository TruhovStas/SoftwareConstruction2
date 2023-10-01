using SoftwareConstruction2.Model.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using ProductList;

namespace SoftwareConstruction2.Model.Devices
{
    public abstract class Device : Product
    {
        public ConnectionTypes ConnectionType { get; set; }
        public Device(int id, string name, double price, string man, ConnectionTypes type) : base(id, name, price, man) 
        {
            this.ConnectionType = type;
        }
    }
    public enum ConnectionTypes { USB, TypeC, Bluetooth }
}
