using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
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
            var orders = await _orderDataAccess.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<Order>> GetOrder(Guid orderId)
        {
            var order = await _orderDataAccess.GetOrderById(orderId);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder([FromBody] Order order)
        {
            DateTime orderReceivedTime = DateTime.Now;
            bool isValidOrder = CheckValidShakes(order);
            if (!isValidOrder)
            {
                return BadRequest("Invalid order data.");
            }
            CalculateOrderPrice(order);
            SetOrderDate(order);
            await _orderDataAccess.CreateOrder(order);
            DateTime orderProcessedTime = DateTime.Now;
            TimeSpan processingTime = orderProcessedTime - orderReceivedTime;

            return Ok($"Order created successfully. Processing time: {processingTime}");
        }

        private bool CheckValidShakes(Order order)
        {
            if (!IsValidOrder(order))
            {
                return false;
            }
            if (order.ShakesOrder.Count > 10)
            {
                return false;
            }
            if (!ValidateShakes(order))
            {
                return false;
            }

            return true;
        }


        private bool IsValidOrder(Order order)
        {
            return order != null && order.ShakesOrder != null;
        }

        private bool ValidateShakes(Order order)
        {
            ShakesDataAccess shakeDataAccess = new ShakesDataAccess();
            foreach (ShakeOrder shakeOrder in order.ShakesOrder)
            {
                var shake = shakeDataAccess.GetShakeFromMenu(shakeOrder.Name);

                if (shake == null)
                {

                    return false;
                }
                else if (shakeOrder.Size == "S")
                {
                    shakeOrder.Price = shake.PriceSizeS;
                }
                else if (shakeOrder.Size == "M")
                {
                    shakeOrder.Price = shake.PriceSizeM;
                }
                else if (shakeOrder.Size == "L")
                {
                    shakeOrder.Price = shake.PriceSizeL;
                }
                else
                {

                    return false;
                }
            }

            return true;
        }

        private void CalculateOrderPrice(Order order)
        {
            double sumOfPrices = 0;
            foreach (ShakeOrder shake in order.ShakesOrder)
            {
                sumOfPrices += shake.Price;
            }
            order.Price = sumOfPrices;
        }

        private void SetOrderDate(Order order)
        {
            order.Date = DateTime.Now;
        }
    }
}
