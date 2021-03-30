/*
 * Helpers.cs
 * 
 * Contains all helper methods used in domain class.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */

using System;
using System.Collections.Generic;

namespace Restaurant.Domain
{
    public static class Helpers
    {
        /// <summary>
        /// Creates a list with the input string splitted values.
        /// </summary>
        /// <param name="inputString">Input string with the order dishes.</param>
        /// <returns>List with order dishes.</returns>
        public static List<string> CreateInputList(string inputString)
        {
            try
            {
                List<string> ret = new List<string>();
                ret.AddRange(inputString.Split(","));
                return ret;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Formats an integer in specific output format.
        /// </summary>
        /// <param name="counter">Integer value to be formatted.</param>
        /// <returns>Formatted string with the integer value.</returns>
        public static string FormatCounterOutput(int counter)
        {
            try
            {
                return counter < 2 ? string.Empty : $"(x{counter})";
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
