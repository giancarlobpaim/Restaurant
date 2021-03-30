using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.Process;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Domain.Test.Process
{
    [TestClass]
    public class OrdersTest
    {

        [TestMethod]
        public void ProcessOrderWithNullOrderOrEmtpyInputList()
        {
            Assert.IsFalse(Dishes.ProcessDishes(null, ""));
        }

        public void ProcessOrder()
        {
            IOrder order = new Order();
            var inputList = Helpers.CreateInputList(order.InputString);
            Assert.IsFalse(Dishes.ProcessDishes(null, ""));
        }

    }
}
