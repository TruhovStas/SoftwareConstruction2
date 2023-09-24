using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareConstruction2.Model.Products.Components
{
    abstract class Components : Product
    {
        public Components(string name, double price, string man) : base(name, price, man) { }
    }
}
