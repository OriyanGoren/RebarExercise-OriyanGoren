using Microsoft.AspNetCore.Mvc;
using RebarExercise.DataAccess;
using RebarExercise.Models;

namespace RebarExercise.Controllers
{
    [Route("api/bill")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly BillDataAccess _billDataAccess;
        private readonly OrderDataAccess _orderDataAccess;

        public BillController(BillDataAccess billDataAccess, OrderDataAccess orderDataAccess)
        {
            _billDataAccess = billDataAccess;
            _orderDataAccess = orderDataAccess;
        }

        [HttpGet("{password}")]
        public async Task<ActionResult> GetBills(string password)
        {
            Bill bill = new Bill();
            if (!IsCorrectPassword(password))
            {

                return BadRequest("Invalid password");
            }
            var todayOrders = _orderDataAccess.GetOrdersByDate(DateTime.Now);
            double totalOrderPrice = 0;
            foreach (var order in todayOrders)
            {
                foreach (var shake in order.ShakesOrder)
                {
                    totalOrderPrice += shake.Price * (1 - shake.Discount.Percentage / 100);
                }
            }
            bill.NumberOfOrders = todayOrders.Count();
            bill.Price = totalOrderPrice;
            Task b = _billDataAccess.CreateBill(bill);

            return Ok(new { bill.NumberOfOrders, bill.Price });
        }

        private bool IsCorrectPassword(string password)
        {
            return password == "RebarOriyanGoren";
        }
    }
}
