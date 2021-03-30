/*
 * GenerateOutput.cs
 * 
 * Generates output string with the order process results.
 * 
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */

using Restaurant.Domain;
using Restaurant.Domain.Interfaces;
using System;

namespace Restaurant.InfraStructure.Services
{
    public static class GenerateOutput
    {
        private const string ERROR = "Error";


        /// <summary>
        /// Generates an output with the order processed data.
        /// It will sets the order's OutputString property with the result.
        /// </summary>
        /// <param name="order">The order being processed.</param>
        public static void OutputOrder(IOrder order)
        {
            try
            {
                if (order.TimeOfDay == Enums.TimeOfDay.Error)
                {
                    order.SetOutputString(ERROR);
                    return;
                }

                WriteCounter(order, Enums.DishTypes.Entree);
                WriteCounter(order, Enums.DishTypes.Side);
                WriteCounter(order, Enums.DishTypes.Drink);
                WriteCounter(order, Enums.DishTypes.Dessert);

                if (order.Error)
                    WriteError(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}\r\n{1}", ex.Message, ex.StackTrace);
            }
        }

        /// <summary>
        /// Writes the counter of each dish processed and validated in the order.
        /// </summary>
        /// <param name="order">The order being processed</param>
        /// <param name="dishType">The dish which will be writed.</param>
        private static void WriteCounter(IOrder order, Enums.DishTypes dishType)
        {
            try
            {
                switch (dishType)
                {
                    case Enums.DishTypes.Entree:
                        if (order.EntreeCount > 0)
                        {
                            order.SetOutputString(order.Entree);
                        }
                        break;
                    case Enums.DishTypes.Side:
                        if (order.SideCount > 0)
                        {
                            order.SetOutputString(order.Side + Helpers.FormatCounterOutput(order.SideCount));
                        }
                        break;
                    case Enums.DishTypes.Drink:
                        if (order.DrinkCount > 0)
                        {
                            order.SetOutputString(order.Drink + Helpers.FormatCounterOutput(order.DrinkCount));
                        }
                        break;
                    case Enums.DishTypes.Dessert:
                        if (order.DessertCount > 0)
                        {
                            order.SetOutputString(order.Dessert);
                        }
                        break;
                    case Enums.DishTypes.Error:
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0}\r\n{1}", ex.Message, ex.StackTrace);
            }
        }

        private static void WriteError(IOrder order)
        {
            if (order == null)
                return;

            order.SetOutputString(ERROR);
        }
    }
}
