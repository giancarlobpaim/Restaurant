/*
 * OrderValidation.cs
 * 
 * Methods to validate order process.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */
using Restaurant.Domain.Interfaces;
using System;

namespace Restaurant.Domain.Validations
{
    public class OrderValidation
    {
        /// <summary>
        /// Validates the time of day, based on the input string stored in the order.
        /// </summary>
        /// <param name="order">The order being processed.</param>
        /// <param name="timeOfDay">The value typed in input string, which will be validated. </param>
        /// <returns>Returns true if a valid value was type, or false if not.</returns>
        public static bool ValidateTimeOfDay(IOrder order, string timeOfDay)
        {
            try
            {
                if (order == null)
                    return false;
                if (timeOfDay.Trim().Equals(Enums.TimeOfDay.Morning.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    order.SetTimeOfDay(Enums.TimeOfDay.Morning);
                    return true;
                }
                else if (timeOfDay.Trim().Equals(Enums.TimeOfDay.Night.ToString(), StringComparison.OrdinalIgnoreCase))
                {
                    order.SetTimeOfDay(Enums.TimeOfDay.Night);
                    return true;
                }
            }
            catch
            {
            }
            order.SetTimeOfDay(Enums.TimeOfDay.Error);
            order.SetError();
            return false;

        }

        /// <summary>
        /// Validate if order does NOT have a dessert on morning - rule #4.
        /// </summary>
        /// <param name="order">The order being processed.</param>
        /// <param name="dishType">The dish to validate.</param>
        /// <returns>Returns true if there is no dessert on morning, or false if yes.</returns>
        public static bool ValidateMorningDessertRule(IOrder order, Enums.DishTypes dishType)
        {
            try
            {
                if (order == null)
                    return false;
                if (order.TimeOfDay == Enums.TimeOfDay.Morning && dishType == Enums.DishTypes.Dessert)
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Validates multiple dishes rules #7 & #8
        /// These rules allows multiple coffees at morning and multiple potatoes at night.
        /// </summary>
        /// <param name="order">The order being processed.</param>
        /// <param name="dishType">The dish type to validate.</param>
        /// <returns>Return true if dish is in one of the rules, and false if not. </returns>
        public static bool ValidateMultipleDishes(IOrder order, Enums.DishTypes dishType)
        {
            try
            {
                if (order == null)
                    return false;
                if (order.TimeOfDay == Enums.TimeOfDay.Morning && dishType == Enums.DishTypes.Drink ||
                    order.TimeOfDay == Enums.TimeOfDay.Night && dishType == Enums.DishTypes.Side)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
