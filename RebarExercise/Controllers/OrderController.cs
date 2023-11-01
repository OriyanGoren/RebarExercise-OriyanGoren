using Microsoft.AspNetCore.Mvc;
using RebarExercise.DataAccess;
using RebarExercise.Models;

namespace RebarExercise.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderDataAccess _orderDataAccess;

        public OrderController(OrderDataAccess orderDataAccess)
        {
            _orderDataAccess = orderDataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            try
            {
                var orders = await _orderDataAccess.GetOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] Order order)
        {
            try
            {

                if (order == null || order.ShakesOrder == null)
                {
                    return BadRequest("Invalid order data.");
                }
                if(order.ShakesOrder.Count > 10)
                {
                    return BadRequest("You cannot order more than 10 shakes.");
                }
                ShakesDataAccess shakeDataAccess = new ShakesDataAccess();
                foreach (ShakeOrder shakeOrder in order.ShakesOrder)
                {
                    var shake = shakeDataAccess.GetShakeFromMenu(shakeOrder.Name);
                    
                    if (shake == null)
                    {
                        return BadRequest("The shake you entered does not appear in the menu.");
                    }
                    else if (shakeOrder.Size == "S")
                    {
                        shakeOrder.Price = shake.PriceSizeS;
                    }
                    else if(shakeOrder.Size == "M")
                    {
                        shakeOrder.Price = shake.PriceSizeM;
                    }
                    else if(shakeOrder.Size == "L")
                    {
                        shakeOrder.Price = shake.PriceSizeL;
                    }
                    else
                    {
                        return BadRequest("The size of the shake entered is incorrect.");
                    }
                }
                order.Date = DateTime.Now;
                order.Price = CalculatePrice(order);
                await _orderDataAccess.CreateOrder(order);
                return Ok("Order created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        private double CalculatePrice(Order order)
        {
            double sumOfPrices = 0;
            foreach (ShakeOrder shake in order.ShakesOrder)
            {
                sumOfPrices += shake.Price;
            }

            return sumOfPrices;
        }

    }
}
