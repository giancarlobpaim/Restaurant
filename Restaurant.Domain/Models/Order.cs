/*
 * Order.cs
 * 
 * Contains all properties of order object.
 * Uses IOrder interface.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */
using Restaurant.Domain.Interfaces;
using System;

namespace Restaurant.Domain.Models
{
    public class Order : IOrder
    {
        #region Constants
        private const string MORNING_ENTREE = "Eggs";
        private const string MORNING_SIDE = "Toast";
        private const string MORNING_DRINK = "Coffee";
        private const string MORNING_DESSERT = "";
        private const string NIGHT_ENTREE = "Steak";
        private const string NIGHT_SIDE = "Potato";
        private const string NIGHT_DRINK = "Wine";
        private const string NIGHT_DESSERT = "Cake";
        #endregion

        #region Properties
        public Enums.TimeOfDay TimeOfDay { get; private set; }
        public string InputString { get; private set; }
        public string OutputString { get; private set; }

        public string Entree { get; private set; }
        public string Side { get; private set; }
        public string Drink { get; private set; }
        public string Dessert { get; private set; }

        public int EntreeCount { get; private set; }
        public int SideCount { get; private set; }
        public int DrinkCount { get; private set; }
        public int DessertCount { get; private set; }

        public bool Error { get; private set; }
        #endregion

        public Order()
        {
            Error = false;
            EntreeCount = 0;
            SideCount = 0;
            DrinkCount = 0;
            DessertCount = 0;
        }

        /// <summary>
        /// Returns the dish counter and, optionally, increments it.
        /// </summary>
        /// <param name="dishType">Dish type counter.</param>
        /// <param name="incrementCounter">True if it will increments the counter, or false if it just returns the counter.</param>
        /// <returns>Returns an integer with the counter.</returns>
        public int DishCounter(Enums.DishTypes dishType, bool incrementCounter = false)
        {
            int dishCounter = 0;
            switch (dishType)
            {
                case Enums.DishTypes.Entree:
                    dishCounter = incrementCounter ? ++EntreeCount : EntreeCount;
                    break;
                case Enums.DishTypes.Side:
                    dishCounter = incrementCounter ? ++SideCount : SideCount;
                    break;
                case Enums.DishTypes.Drink:
                    dishCounter = incrementCounter ? ++DrinkCount : DrinkCount;
                    break;
                case Enums.DishTypes.Dessert:
                    dishCounter = incrementCounter ? ++DessertCount : DessertCount;
                    break;
                case Enums.DishTypes.Error:
                    break;
                default:
                    break;
            }
            return dishCounter;
        }

        /// <summary>
        /// Sets the dish's properties based on time of day property.
        /// </summary>
        public void SetDishes()
        {
            SetDishes(TimeOfDay);
        }

        /// <summary>
        /// Sets the dish's properties based on time of day parameter.
        /// </summary>
        /// <param name="timeOfDay">The time of day value.</param>
        public void SetDishes(Enums.TimeOfDay timeOfDay)
        {
            if (timeOfDay == Enums.TimeOfDay.Morning)
            {
                Entree = MORNING_ENTREE;
                Side = MORNING_SIDE;
                Drink = MORNING_DRINK;
                Dessert = MORNING_DESSERT;
            }
            else if (timeOfDay == Enums.TimeOfDay.Night)
            {
                Entree = NIGHT_ENTREE;
                Side = NIGHT_SIDE;
                Drink = NIGHT_DRINK;
                Dessert = NIGHT_DESSERT;
            }
            else
            {
                Entree = "";
                Side = "";
                Drink = "";
                Dessert = "";
            }
        }

        /// <summary>
        /// Sets true in the error property.
        /// </summary>
        public void SetError()
        {
            Error = true;
        }

        /// <summary>
        /// Sets the inputString value in the InputString property.
        /// </summary>
        /// <param name="inputString">The value which will be setted.</param>
        public void SetInputString(string inputString)
        {
            InputString = inputString;
        }

        /// <summary>
        /// Sets the outputString value in the OutputString property.
        /// If clearBefore parameter is NOT false, outputString will be concatenated to OutputString property.
        /// </summary>
        /// <param name="outputString">Value to be setted in OutputString property.</param>
        /// <param name="clearBefore">Clear property before value be setted, or concatenates them.</param>
        public void SetOutputString(string outputString, bool clearBefore = false)
        {
            try
            {
                if (clearBefore)
                    // Sets without concatenate
                    OutputString = outputString;
                else
                {
                    if (string.IsNullOrEmpty(OutputString) || string.IsNullOrEmpty(outputString))
                        OutputString += outputString;
                    else
                        // If both are NOT empty, OutputString receives a comma and outputString
                        OutputString += $", {outputString}";
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Sets the time of day property.
        /// </summary>
        /// <param name="timeOfDay">TimeOfDay enum value.</param>
        public void SetTimeOfDay(Enums.TimeOfDay timeOfDay)
        {
            TimeOfDay = timeOfDay;
        }


    }
}
