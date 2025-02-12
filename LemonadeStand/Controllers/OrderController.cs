using System;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LemonadeStand.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class OrderController : ControllerBase, IOrderController
  {
    private readonly IOrderService _orderService;
    const string ORDER_BAD_REQUEST_MESSAGE = "Order cannot be null";

    public OrderController(IOrderService orderService)
    {
      _orderService = orderService;
    }

    [HttpPost]
    public async Task<ActionResult> InsertOrderAsync([FromBody] Order order)
    {
      if (order == null)
      {
        return BadRequest(ORDER_BAD_REQUEST_MESSAGE);
      }

      try
      {
        var orderId = await _orderService.InsertOrderAsync(order);
      }
      catch (Exception ex)
      {
        return BadRequest();
      }

      return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetOrdersAsync()
    {
      try
      {
        var oReturn = await _orderService.GetOrdersAsync();
        return Ok(oReturn);
      }
      catch (Exception ex)
      {
        return NotFound();
      }
    }
  }
}

