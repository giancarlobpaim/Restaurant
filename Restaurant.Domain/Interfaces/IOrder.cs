/*
 * IOrder.cs
 * 
 * Interface for the order class.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */
namespace Restaurant.Domain.Interfaces
{
    public interface IOrder
    {
        public Enums.TimeOfDay TimeOfDay { get; }
        public string InputString { get; }
        public string OutputString { get; }

        public string Entree { get; }
        public string Side { get; }
        public string Drink { get; }
        public string Dessert { get; }

        public int EntreeCount { get; }
        public int SideCount { get; }
        public int DrinkCount { get; }
        public int DessertCount { get; }

        public bool Error { get; }

        /// <summary>
        /// Returns the dish counter and, optionally, increments it.
        /// </summary>
        /// <param name="dishType">Dish type counter.</param>
        /// <param name="incrementCounter">True if it will increments the counter, or false if it just returns the counter.</param>
        /// <returns>Returns an integer with the counter.</returns>
        int DishCounter(Enums.DishTypes dishType, bool incrementCounter = false);

        /// <summary>
        /// Sets the dish's properties based on time of day property.
        /// </summary>
        void SetDishes();

        /// <summary>
        /// Sets the dish's properties based on time of day parameter.
        /// </summary>
        /// <param name="timeOfDay">The time of day value.</param>
        void SetDishes(Enums.TimeOfDay timeOfDay);

        /// <summary>
        /// Sets true in the error property.
        /// </summary>
        void SetError();

        /// <summary>
        /// Sets the inputString value in the InputString property.
        /// </summary>
        /// <param name="inputString">The value which will be setted.</param>
        void SetInputString(string inputString);

        /// <summary>
        /// Sets the outputString value in the OutputString property.
        /// If clearBefore parameter is NOT false, outputString will be concatenated to OutputString property.
        /// </summary>
        /// <param name="outputString">Value to be setted in OutputString property.</param>
        /// <param name="clearBefore">Clear property before value be setted, or concatenates them.</param>
        void SetOutputString(string outputString, bool clear = false);

        /// <summary>
        /// Sets the time of day property.
        /// </summary>
        /// <param name="timeOfDay">TimeOfDay enum value.</param>
        void SetTimeOfDay(Enums.TimeOfDay timeOfDay);

    }
}
