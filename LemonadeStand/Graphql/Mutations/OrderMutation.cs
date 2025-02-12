using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Mutations
{
  [ExtendObjectType("Mutation")]
  public class OrderMutation
  {
    public async Task<int> InsertOrderAsync([Service] IOrderService _orderService, Order order)
    {
      try
      {
        var oReturn = await _orderService.InsertOrderAsync(order);
        return oReturn;
      }
      catch (Exception ex)
      {
        return 0;
      }
    }
  }
}

