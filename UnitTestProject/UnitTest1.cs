using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareConstruction2.Controller;
using SoftwareConstruction2.Model.Devices;
using SoftwareConstruction2.Model.Products;
using System.Collections.Generic;
using ProductList;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Mouse m = new Mouse(1, "mouse", 10, "Bloody", ConnectionTypes.USB, 0.1, 5);
            string desc = m.Description;
            Assert.IsNotNull(desc);
        }
        [TestMethod]
        public void TestMethod2()
        {
            Mouse m = new Mouse(1, "mouse", 10, "Bloody", ConnectionTypes.USB, 0.1, 5);
            ProductList.ProductList.AddToList(m);
            Product result1 = ProductList.ProductList.GetProduct(1);
            Product result2 = ProductList.ProductList.GetProduct("mouse");
            Assert.AreEqual(result2, result1);
        }
        [TestMethod]
        public void TestMethod3()
        {
            RandomMouse.CreateMouse();
            List<Product> products = ProductList.ProductList.GetAllProducts();
            Assert.IsNotNull(products);
        }
    }
}