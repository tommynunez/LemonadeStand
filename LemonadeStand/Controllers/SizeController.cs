using System;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using LemonadeStand.Abstractions.Struct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LemonadeStand.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SizeController : Controller, ISizeController
  {
    private readonly ILogger<SizeController> _logger;
    private readonly ISizeService _sizeService;


    public SizeController(ILogger<SizeController> logger,
        ISizeService sizeService)
    {
      _logger = logger;
      _sizeService = sizeService;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }

        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_DELETE_SERVICE);
        await _sizeService.DeleteAsync(id);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_DELETE_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpGet]
    public async Task<ActionResult> GetAllAsync([FromQuery] string search, [FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string sortField = null)
    {
      try
      {

        if (string.IsNullOrEmpty(search.ToString()))
        {
          return BadRequest("search is empty");
        }

        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_GETALL_SERVICE);
        var oSize = await _sizeService.GetAllAsync(search, pageIndex, pageSize, sortField);
        return Ok(oSize);
      }
      catch (Exception ex)
      {
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_GETALL_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync([FromRoute] int id)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }

        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_GETBYID_SERVICE);
        var oSize = await _sizeService.GetByIdAsync(id);
        return Ok(oSize);
      }
      catch (Exception ex)
      {
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_GETBYID_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpPost]
    public async Task<ActionResult> InsertAsync([FromBody] Size size)
    {
      try
      {
        if (string.IsNullOrEmpty(size.Name))
        {
          return BadRequest("name is empty");
        }

        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_INSERT_SERVICE);
        await _sizeService.InsertAsync(size);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_INSERT_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] Size size)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }


        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_UPDATE_SERVICE);
        await _sizeService.UpdateAsync(id, size);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(SizeLogMessages.SIZE_INVOKE_UPDATE_SERVICE_ERROR);
        return StatusCode(500);
      }
    }
  }
}

