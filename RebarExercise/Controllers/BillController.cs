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

        public BillController(BillDataAccess billDataAccess)
        {
            _billDataAccess = billDataAccess;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bill>>> GetBills()
        {
            try
            {
                var bills = await _billDataAccess.GetBills();
                return Ok(bills);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] Bill bill)
        {
            try
            {
                if (bill == null)
                {
                    return BadRequest("Invalid shake data.");
                }
                await _billDataAccess.CreateBill(bill);
                return Ok("Bill created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
