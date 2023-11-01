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
        public Task<ActionResult> GenerateAndSaveDailyBillSummary(string password)
        {
            Bill bill = new Bill();
            if (!IsCorrectPassword(password))
            {

                return Task.FromResult<ActionResult>(BadRequest("Invalid password"));
            }
            var todayOrders = _orderDataAccess.GetOrdersByDate(DateTime.Now);
            bill.NumberOfOrders = todayOrders.Count();
            bill.Price = CalculateTotalPrice(todayOrders);
            Task b = _billDataAccess.CreateBill(bill);

            return Task.FromResult<ActionResult>(Ok(new { bill.NumberOfOrders, bill.Price }));
        }

        private bool IsCorrectPassword(string password)
        {
            return password == "RebarOriyanGoren";
        }

        private double CalculateTotalPrice(List <Order> todayOrders)
        {
            double totalOrderPrice = 0;
            foreach (var order in todayOrders)
            {
                foreach (var shake in order.ShakesOrder)
                {
                    totalOrderPrice += shake.Price* (1 - shake.Discount.Percentage / 100);
                }
            }
            return totalOrderPrice;     
        }
    }
}
