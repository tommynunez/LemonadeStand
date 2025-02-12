using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using AutoMapper;
using Microsoft.Toolkit.Diagnostics;
using LemonadeStand.Abstractions.Struct;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace LemonadeStand.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<ProductService> _logger;

    public ProductService(IProductRepository productRepository,
        ILogger<ProductService> logger,
        IMapper mapper)
    {
      _logger = logger;
      _mapper = mapper;
      _productRepository = productRepository;

    }

    public async Task DeleteAsync(int id)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_DELETE_SERVICE);
        await _productRepository.DeleteAsync(id);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductLogMessages.PRODUCT_INVOKE_DELETE_SERVICE_ERROR);
      }
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
      var oReturn = await _productRepository.GetAllProductsAsync();
      return _mapper.Map<IEnumerable<Product>>(oReturn);
    }

    public async Task<Product> GetByIdAsync(int id)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_GETBYID_SERVICE);
        var oModel = await _productRepository.GetByIdAsync(id);
        Guard.IsNotNull(oModel, nameof(oModel));
        return _mapper.Map<Product>(oModel);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductLogMessages.PRODUCT_INVOKE_GETBYID_SERVICE_ERROR);
        return new Product();
      }
    }

    public async Task InsertAsync(ProductMutation product)
    {
      try
      {
        Guard.IsNotNull<ProductMutation>(product, nameof(product));
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_INSERT_SERVICE);
        var oEntity = _mapper.Map<LemonadeStand.Abstractions.Entities.Product>(product);
        await _productRepository.InsertAsync(oEntity);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductLogMessages.PRODUCT_INVOKE_INSERT_SERVICE_ERROR);
      }
    }

    public async Task UpdateAsync(int id, ProductMutation product)
    {
      try
      {
        Guard.IsNotEqualTo<int>(id, 0, nameof(id));
        Guard.IsNotNull<ProductMutation>(product, nameof(product));
        _logger.LogInformation(ProductLogMessages.PRODUCT_INVOKE_UPDATE_SERVICE);
        var oEntity = _mapper.Map<LemonadeStand.Abstractions.Entities.Product>(product);
        await _productRepository.UpdateAsync(id, oEntity);
      }
      catch (Exception ex)
      {
        _logger.LogError(ProductLogMessages.PRODUCT_INVOKE_UPDATE_SERVICE_ERROR);
      }
    }
  }
}

