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
            bill.NumberOfOrders = todayOrders.Count();
            bill.Price = todayOrders.Sum(order => order.Price);
            
            return Ok(new { bill.NumberOfOrders, bill.Price });
        }

        private bool IsCorrectPassword(string password)
        {
            return password == "RebarOriyanGoren";
        }
    }
}
