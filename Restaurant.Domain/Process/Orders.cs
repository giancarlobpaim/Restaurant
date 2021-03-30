/*
 * Orders.cs
 * 
 * Controls the order process.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Validations;

namespace Restaurant.Domain.Process
{
    public static class Orders
    {

        /// <summary>
        /// Process the order dishes typed in the input string.
        /// </summary>
        /// <param name="order">The order which will receive the processed data.</param>
        public static void ProcessOrder(IOrder order)
        {
            // Creates input list
            var inputList = Helpers.CreateInputList(order.InputString);
            if (inputList == null)
            {
                // If inputList is null, sets the order's error property
                order.SetError();
                return;
            }

            // Updates order's time of day
            if (!OrderValidation.ValidateTimeOfDay(order, inputList[0]))
                return;

            // Fill dishes based on order's time of day
            order.SetDishes();

            // Input list dishes processing
            for (int i = 1; i < inputList.Count; i++)
            {
                // If dish processing has an error, then break the processing
                if (!Dishes.ProcessDishes(order, inputList[i])) break;
            }
        }

    }
}
