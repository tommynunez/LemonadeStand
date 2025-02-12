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
  public class LemonadeTypeController : Controller, ILemonadeTypeController
  {
    private readonly ILogger<LemonadeTypeController> _logger;
    private readonly ILemonadeTypeService _lemonadeTypeService;

    public LemonadeTypeController(ILogger<LemonadeTypeController> logger,
        ILemonadeTypeService lemonadeTypeService)
    {
      _logger = logger;
      _lemonadeTypeService = lemonadeTypeService;
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

        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_DELETE_SERVICE);
        await _lemonadeTypeService.DeleteAsync(id);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_DELETE_SERVICE_ERROR);
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

        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_GETALL_SERVICE);
        var oSize = await _lemonadeTypeService.GetAllAsync(search, pageIndex, pageSize, sortField);
        return Ok(oSize);
      }
      catch (Exception ex)
      {
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_GETALL_SERVICE_ERROR);
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

        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_GETBYID_SERVICE);
        var oSize = await _lemonadeTypeService.GetByIdAsync(id);
        return Ok(oSize);
      }
      catch (Exception ex)
      {
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_GETBYID_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpPost]
    public async Task<ActionResult> InsertAsync([FromBody] LemonadeType lemonadeType)
    {
      try
      {
        if (string.IsNullOrEmpty(lemonadeType.Name))
        {
          return BadRequest("name is empty");
        }

        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_INSERT_SERVICE);
        await _lemonadeTypeService.InsertAsync(lemonadeType);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_INSERT_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpPut]
    public async Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] LemonadeType lemonadeType)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }


        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_UPDATE_SERVICE);
        await _lemonadeTypeService.UpdateAsync(id, lemonadeType);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(LemonadeTypeLogMessages.LEMONADETYPE_INVOKE_UPDATE_SERVICE_ERROR);
        return StatusCode(500);
      }
    }
  }
}

