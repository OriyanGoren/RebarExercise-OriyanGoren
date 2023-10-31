using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebarExercise.DataAccess;
using RebarExercise.Models;

namespace RebarExercise.Controllers
{
    public class BillController : ControllerBase
    {
        private readonly BillDataAccess _billDataAccess;

        public BillController(BillDataAccess billDataAccess)
        {
            _billDataAccess = billDataAccess;
        }

        [HttpGet]
        [Route("api/bills")]
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
        [Route("api/bills")]
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
