using Microsoft.AspNetCore.Mvc;
using RebarExercise.DataAccess;
using RebarExercise.Models;

namespace RebarExercise.Controllers
{
    [Route("api/shakes")]
    [ApiController]
    public class ShakesController : ControllerBase
    {
        private readonly ShakesDataAccess _shakesMenuDataAccess;

        public ShakesController()
        {
            _shakesMenuDataAccess = new ShakesDataAccess();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShakeMenu>>> GetShakes()
        {
            var shakes = await _shakesMenuDataAccess.GetShakesFromMenu();

            return Ok(shakes);
        }

        [HttpGet("{shakeId}")]
        public async Task<ActionResult<ShakeMenu>> GetShake(Guid shakeId)
        {
            var shake = await _shakesMenuDataAccess.GetShakeById(shakeId);
            if (shake == null)
            {
                return NotFound("Shake not found");
            }

            return Ok(shake);
        }

        [HttpPost]
        public async Task<ActionResult> CreateShakeToMenu([FromBody] ShakeMenu shakeMenu)
        {
            if (shakeMenu == null)
            {

                return BadRequest("Invalid shake data.");
            }
            await _shakesMenuDataAccess.CreateShakeToMenu(shakeMenu);

            return Ok("Shake created successfully");
        }
    }
}
