using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RebarExercise.DataAccess;
using RebarExercise.Models;

namespace RebarExercise.Controllers
{
    [Route("api/ShakesFromMenu")]
    [ApiController]
    public class ShakesMenuController : ControllerBase
    {
        private readonly ShakesMenuDataAccess _shakesMenuDataAccess;

        public ShakesMenuController()
        {
            _shakesMenuDataAccess = new ShakesMenuDataAccess();
        }

        
        // GET: api/ShakesFromMenu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShakesMenu>>> GetShakesFromMenu()
        {
            try
            {
                var shakes = await _shakesMenuDataAccess.GetShakesFromMenu();
                return Ok(shakes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

        // POST: api/ShakesFromMenu
        [HttpPost]
        public async Task<ActionResult> CreateShakeToMenu(ShakesMenu shakeMenu)
        {
            try
            {
                if (shakeMenu == null)
                {
                    return BadRequest("Invalid shake data.");
                }

                // Add the shake to the menu
                await _shakesMenuDataAccess.CreateShakeToMenu(shakeMenu);
                return Ok("Shake created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }
        
    }
}
