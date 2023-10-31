﻿using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateOrder([FromBody] Order order)
        {
            try
            {
                if (order == null)
                {
                    return BadRequest("Invalid shake data.");
                }
                await _orderDataAccess.CreateOrder(order);
                return Ok("Order created successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
