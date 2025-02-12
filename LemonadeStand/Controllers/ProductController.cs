using System;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using LemonadeStand.Abstractions.Struct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LemonadeStand.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase, IProductController
  {
    private readonly IProductService _productService;
    private readonly ILogger<LemonadeTypeController> _logger;
    public ProductController(IProductService productService, ILogger<LemonadeTypeController> logger)
    {
      _logger = logger;
      _productService = productService;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] int id)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }

        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_DELETE_SERVICE);
        await _productService.DeleteAsync(id);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_DELETE_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsAsync()
    {
      try
      {
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_GETALL_SERVICE);
        var oProduct = await _productService.GetAllProductsAsync();
        return Ok(oProduct);
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_GETALL_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }

        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_GETBYID_SERVICE);
        var oProduct = await _productService.GetByIdAsync(id);
        return Ok(oProduct);
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_GETBYID_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromBody] ProductMutation productMutation)
    {
      try
      {
        if (productMutation
            .Amount != 0)

        {
          return BadRequest("amount is zero");
        }

        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_INSERT_SERVICE);
        await _productService.InsertAsync(productMutation);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_INSERT_SERVICE_ERROR);
        return StatusCode(500);
      }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] ProductMutation productMutation)
    {
      try
      {
        if (string.IsNullOrEmpty(id.ToString()))
        {
          return BadRequest("id is empty");
        }

        if (id == 0)
        {
          return BadRequest("id is zero");
        }


        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_UPDATE_SERVICE);
        await _productService.UpdateAsync(id, productMutation);
        return Ok();
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_UPDATE_SERVICE_ERROR);
        return StatusCode(500);
      }
    }
  }
}

