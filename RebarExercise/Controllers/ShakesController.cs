using Microsoft.AspNetCore.Mvc;
using RebarExercise.DataAccess;
using RebarExercise.Models;

namespace RebarExercise.Controllers
{
    [Route("api/shakes")]
    [ApiController]
    public class ShakesController : ControllerBase
    {
        private readonly ShakesDataAccess _shakesDataAccess;

        public ShakesController()
        {
            _shakesDataAccess = new ShakesDataAccess();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShakeMenu>>> GetShakes()
        {
            var shakes = await _shakesDataAccess.GetShakesFromMenu();

            return Ok(shakes);
        }

        [HttpGet("{shakeId}")]
        public async Task<ActionResult<ShakeMenu>> GetShake(Guid shakeId)
        {
            var shake = await _shakesDataAccess.GetShakeById(shakeId);
            if (shake == null)
            {
                return NotFound("Shake not found");
            }

            return Ok(shake);
        }

        [HttpPost]
        public async Task<ActionResult> CreateShake([FromBody] ShakeMenu shakeMenu)
        {
            if (shakeMenu == null)
            {

                return BadRequest("Invalid shake data.");
            }
            var existingShake = _shakesDataAccess.GetShakeByName(shakeMenu.Name);
            if (existingShake != null)
            {

                return BadRequest("Shake already exists in the menu.");
            }

            await _shakesDataAccess.CreateShakeToMenu(shakeMenu);

            return Ok("Shake created successfully");
        }
    }
}
