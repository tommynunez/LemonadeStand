using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class SizeMutation
  {
    public async Task<bool> InsertSizeAsync([Service] ISizeService _sizeService, Size size)
    {
      try
      {
        await _sizeService.InsertAsync(size);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateSizeAsync([Service] ISizeService _sizeService, int id, Size size)
    {
      try
      {
        await _sizeService.UpdateAsync(id, size);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> DeleteSizeAsync([Service] ISizeService _sizeService, int id)
    {
      try
      {
        await _sizeService.DeleteAsync(id);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }
  }
}

