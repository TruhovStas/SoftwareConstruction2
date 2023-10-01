using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductList;

namespace SoftwareConstruction2.Model.Products.Components
{
    public abstract class Components : Product
    {
        public Components(int id, string name, double price, string man) : base(id, name, price, man) { }
    }
}
