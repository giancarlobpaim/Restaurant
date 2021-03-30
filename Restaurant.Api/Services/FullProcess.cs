/*
 * FullProcess.cs
 * 
 * Executes full order processing.
 * 
 * This consists in three main processes:
 * 
 * 1. get and set input string from the POST method
 * 2. process the order dishes
 * 3. output the results
 * 
 * After complete, returns the output string with the result.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */

using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Process;
using Restaurant.InfraStructure.Services;
using System;

namespace Restaurant.Api.Services
{
    public class FullProcess
    {
        /// <summary>
        /// Executes full process of the order.
        /// It will get and set input string from the POST method, process the order dishes and output the results. 
        /// </summary>
        /// <param name="order">The order which will receive the processed data.</param>
        /// <param name="inputString">The input string with data to be processed.</param>
        /// <returns>Order's OutputString after process is completed.</returns>
        public static string Execute(IOrder order, string inputString)
        {
            try
            {
                order.SetInputString(inputString);
                Orders.ProcessOrder(order);
                GenerateOutput.OutputOrder(order);
                return order.OutputString;
            }
            catch (Exception ex)
            {
                return $"We got a problem: {ex.Message}";
            }
        }
    }
}
