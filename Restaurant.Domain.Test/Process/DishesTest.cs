using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.Process;

namespace Restaurant.Domain.Test.Process
{
    [TestClass]
    public class DishesTest
    {
        [TestMethod]
        public void ProcessDishesWithNullOrderOrEmtpyInputList()
        {
            Assert.IsFalse(Dishes.ProcessDishes(null, ""));
        }

        [TestMethod]
        public void ProcessDishes()
        {
            IOrder order = new Order();
            Assert.IsTrue(Dishes.ProcessDishes(order, "1"));
        }



    }
}
