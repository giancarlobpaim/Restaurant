/*
 * Dishes.cs
 * 
 * Static class to process dishes in the order process.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Validations;
using System;

namespace Restaurant.Domain.Process
{
    public static class Dishes
    {
        /// <summary>
        /// Process dishes in the order list.
        /// It will validate multiple dishes rule and increment the dish's counter.
        /// </summary>
        /// <param name="order">The order wich will be processed.</param>
        /// <param name="inputString">Input string with order info.</param>
        /// <returns>Returns true if process completes ok, or false if not.</returns>
        public static bool ProcessDishes(IOrder order, string inputString)
        {
            try
            {
                if (order == null)
                    return false;

                Enums.DishTypes dishType = GetDishType(inputString);

                if (dishType == Enums.DishTypes.Error)
                {
                    order.SetError();
                    return false;
                }

                if (OrderValidation.ValidateMultipleDishes(order, dishType))
                {
                    // If dish allows multiple choices, increment counter
                    order.DishCounter(dishType, true);
                }
                else
                {
                    // If dish doesn't allow multiple choices, but counter is 0 AND
                    // is not dessert on morning, increment counter
                    if (order.DishCounter(dishType) == 0 && OrderValidation.ValidateMorningDessertRule(order, dishType))
                    {
                        order.DishCounter(dishType, true);
                    }
                    else
                    {
                        // Otherwise, set error in the order
                        order.SetError();
                        return false;
                    }
                }
                return true;

            }
            catch (Exception)
            {
                order.SetError();
                return false;
            }
        }


        /// <summary>
        /// Converts a value from input string to an Enums.DishTypes value.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>Returns an Enums.DishTypes value - Enums.DishTypes.Error if an invalid value was entered.</returns>
        private static Enums.DishTypes GetDishType(string inputString)
        {
            try
            {
                // Gets the dish typed in input string
                int dishType = int.Parse(inputString.Trim());
                if (Enum.IsDefined(typeof(Enums.DishTypes), dishType))
                    return (Enums.DishTypes)dishType;
            }
            catch
            {
            }
            return Enums.DishTypes.Error;
        }
    }
}
