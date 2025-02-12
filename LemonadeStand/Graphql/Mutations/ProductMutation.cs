using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class ProductMutation
  {
    public async Task<bool> InsertProductAsync([Service] IProductService _productService, LemonadeStand.Abstractions.Models.ProductMutation product)
    {
      try
      {
        await _productService.InsertAsync(product);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateProductAsync([Service] IProductService _productService, int id, LemonadeStand.Abstractions.Models.ProductMutation product)
    {
      try
      {
        await _productService.UpdateAsync(id, product);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> DeleteProductAsync([Service] IProductService _productService, int id)
    {
      try
      {
        await _productService.DeleteAsync(id);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}

