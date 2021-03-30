/*
 * Enums.cs
 * 
 * Contains all enums used in domain.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */

namespace Restaurant.Domain
{
    /// <summary>
    /// This class contains all enums used in domain.
    /// </summary>
    public class Enums
    {
        public enum TimeOfDay
        {
            Error,
            Morning,
            Night
        }

        public enum DishTypes
        {
            Entree = 1,
            Side = 2,
            Drink = 3,
            Dessert = 4,
            Error = 9
        }

    }
}
