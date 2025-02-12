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
  public class OrderRepository : IOrderRepository
  {
    private readonly DatabaseContext _context;
    private readonly ILogger<OrderRepository> _logger;

    private const string ORDER_INSERT_MESSAGE = "";
    private const string ORDER_INSERT_ERROR_MESSAGE = "Error Message: {0}";

    public OrderRepository(DatabaseContext context,
        ILogger<OrderRepository> logger)
    {
      _context = context;
      _logger = logger;
    }

    public async Task<int> InsertOrderAsync(Order order)
    {
      var returnValue = 0;
      try
      {
        _logger.LogInformation(ORDER_INSERT_MESSAGE);
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
        returnValue = order.Id;
      }
      catch (Exception ex)
      {
        _logger.LogInformation(ORDER_INSERT_ERROR_MESSAGE, ex.Message);
      }
      return returnValue;
    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
      var eOrderList = new List<Order>();

      try
      {
        //_logger.LogInformation(GET_PRODUCT_MESSAGE);
        eOrderList = await _context.Orders
            .Include(x => x.LineItems)
                .ThenInclude(x => x.Product)
                    .ThenInclude(x => x.LemonadeTypes)
                .ThenInclude(x => x.Products)
                    .ThenInclude(x => x.Sizes)
                    .OrderByDescending(x => x.Created)
            .ToListAsync();
      }
      catch (Exception ex)
      {
        //_logger.LogError(GET_PRODUCT_ERROR_MESSAGE, ex.Message);
      }

      return eOrderList;
    }
  }
}