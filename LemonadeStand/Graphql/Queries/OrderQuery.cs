using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Graphql.Queries
{
    [ExtendObjectType("Query")]
    public class OrderQuery
    {
        public async Task<IEnumerable<Order>> RetrieveOrders([Service] IOrderService _orderService)
        {
            try
            {
                var oOrder = await _orderService.GetOrdersAsync();

                if(oOrder.Count() > 0)
                {
                    return oOrder.ToList();
                } else
                {
                    return new List<Order>();
                }
            }
            catch (Exception ex)
            {

            }
            return new List<Order>();
        }
    }
}
