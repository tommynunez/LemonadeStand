using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;
using LemonadeStand.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LemonadeStand.Data.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly DatabaseContext _databaseContext;
    private readonly ILogger<ProductRepository> _logger;

    private const string GET_PRODUCT_MESSAGE = "Getting Products";
    private const string GET_PRODUCT_ERROR_MESSAGE = "Error Message {0}";

    public ProductRepository(DatabaseContext databaseContext,
            ILogger<ProductRepository> logger)
    {
      _databaseContext = databaseContext;
      _logger = logger;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
      return await _databaseContext.Products
          .Include(x => x.Sizes)
          .Include(x => x.LemonadeTypes)
          .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(Product product)
    {
      await _databaseContext.Products.AddAsync(product);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }

    public async Task UpdateAsync(int id, Product product)
    {
      _databaseContext.Products.Update(product);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }

    public async Task DeleteAsync(int id)
    {
      var oModel = _databaseContext.Products.FirstOrDefault(x => x.Id == id);
      oModel.Deleted = DateTime.Now;
      _databaseContext.Update(oModel);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
      var eProductList = new List<Product>();

      try
      {
        _logger.LogInformation(GET_PRODUCT_MESSAGE);
        eProductList = await _databaseContext.Products
            .Include(x => x.Sizes)
            .Include(x => x.LemonadeTypes).ToListAsync();
      }
      catch (Exception ex)
      {
        _logger.LogError(GET_PRODUCT_ERROR_MESSAGE, ex.Message);
      }

      return eProductList;
    }
  }
}

