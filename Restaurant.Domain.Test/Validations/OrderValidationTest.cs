using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Models;
using Restaurant.Domain.Validations;

namespace Restaurant.Domain.Test.Validations
{
    [TestClass]
    public class OrderValidationTest
    {

        #region TimeOfDay Validations

        [TestMethod]
        public void TimeOfDayIsTrue()
        {
            IOrder order = new Order();
            Assert.IsTrue(OrderValidation.ValidateTimeOfDay(order, "morning"));
        }

        [TestMethod]
        public void TimeOfDayIsFalseWithNullOrder()
        {
            Assert.IsFalse(OrderValidation.ValidateTimeOfDay(null, "morning"));
        }

        [TestMethod]
        public void TimeOfDayIsFalseWithInvalidTimeOfDay()
        {
            IOrder order = new Order();
            Assert.IsFalse(OrderValidation.ValidateTimeOfDay(order, ""));
        }
        #endregion


        #region Morning Dessert Rule Validation
        [TestMethod]
        public void MorningDessertRuleIsTrue()
        {
            IOrder order = new Order();
            order.SetTimeOfDay(Enums.TimeOfDay.Morning);
            Assert.IsTrue(OrderValidation.ValidateMorningDessertRule(order, Enums.DishTypes.Entree));
        }

        [TestMethod]
        public void MorningDessertRuleIsFalse()
        {
            IOrder order = new Order();
            order.SetTimeOfDay(Enums.TimeOfDay.Morning);
            Assert.IsFalse(OrderValidation.ValidateMorningDessertRule(order, Enums.DishTypes.Dessert));
        }

        [TestMethod]
        public void MorningDessertRuleIsFalseWithNullOrder()
        {
            Assert.IsFalse(OrderValidation.ValidateMorningDessertRule(null, Enums.DishTypes.Entree));
        }
        #endregion


        #region Multiple Dishes Rule
        [TestMethod]
        public void MultipleDishesMorningRuleIsTrue()
        {
            IOrder order = new Order();
            order.SetTimeOfDay(Enums.TimeOfDay.Morning);
            Assert.IsTrue(OrderValidation.ValidateMultipleDishes(order, Enums.DishTypes.Drink));
        }

        [TestMethod]
        public void MultipleDishesNightRuleIsTrue()
        {
            IOrder order = new Order();
            order.SetTimeOfDay(Enums.TimeOfDay.Night);
            Assert.IsTrue(OrderValidation.ValidateMultipleDishes(order, Enums.DishTypes.Side));
        }

        [TestMethod]
        public void MultipleDishesMorningRuleIsFalse()
        {
            IOrder order = new Order();
            order.SetTimeOfDay(Enums.TimeOfDay.Morning);
            Assert.IsFalse(OrderValidation.ValidateMultipleDishes(order, Enums.DishTypes.Entree));
        }

        [TestMethod]
        public void MultipleDishesNightRuleIsFalse()
        {
            IOrder order = new Order();
            order.SetTimeOfDay(Enums.TimeOfDay.Night);
            Assert.IsFalse(OrderValidation.ValidateMultipleDishes(order, Enums.DishTypes.Dessert));
        }

        #endregion


    }
}
