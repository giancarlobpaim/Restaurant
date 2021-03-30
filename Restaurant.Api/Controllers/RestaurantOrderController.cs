/*
 * RestaurantOrderController.cs
 * 
 * Controller for Order in Restaurant.Api.
 * 
 * Created by: Giancarlo Barbieri Paim
 * Date: 3/28/21
 */

using Microsoft.AspNetCore.Mvc;
using Restaurant.Domain.Interfaces;

namespace Restaurant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantOrderController : ControllerBase
    {
        public readonly IOrder order;
        string returnString = "You must send the order with the POST method.";

        public RestaurantOrderController(IOrder order)
        {
            this.order = order;
        }
        
        [HttpGet]
        public string Get()
        {
            return returnString;
        }

        [HttpPost]
        [Consumes("text/plain")]
        public string Post([FromBody] string body)
        {
            returnString = Services.FullProcess.Execute(order, body);
            return returnString;
        }
    }
}
