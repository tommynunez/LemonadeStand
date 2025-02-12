using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class LemonadeTypeMutation
  {
    public async Task<bool> InsertLemonadeTypeAsync([Service] ILemonadeTypeService _lemonadeTypeService, LemonadeType lemonadeType)
    {
      try
      {
        await _lemonadeTypeService.InsertAsync(lemonadeType);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> UpdateLemonadeTypeAsync([Service] ILemonadeTypeService _lemonadeTypeService, int id, LemonadeType lemonadeType)
    {
      try
      {
        await _lemonadeTypeService.UpdateAsync(id, lemonadeType);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public async Task<bool> DeleteLemonadeTypeAsync([Service] ILemonadeTypeService _lemonadeTypeService, int id)
    {
      try
      {
        await _lemonadeTypeService.DeleteAsync(id);
        return true;
      }
      catch (Exception ex)
      {
        return false;
      }
    }

  }
}

