using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LemonadeStand.Abstractions.Interfaces;
using LemonadeStand.Abstractions.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Diagnostics;

namespace LemonadeStand.Services
{
  public class OrderService : IOrderService
  {
    private readonly IMapper _autoMapper;
    private readonly ILogger<OrderService> _logger;
    private readonly IOrderRepository _orderRepository;
    private readonly ILineItemService _lineItemService;
    private const string ORDERSERVICE_INSERT_ERROR_MESSAGE = "Error Message {0}";

    public OrderService(IMapper autoMapper,
            ILogger<OrderService> logger,
            IOrderRepository orderRepository,
            ILineItemService lineItemService
        )
    {
      _autoMapper = autoMapper;
      _logger = logger;
      _orderRepository = orderRepository;
      _lineItemService = lineItemService;
    }

    public async Task<int> InsertOrderAsync(Order order)
    {
      var orderId = 0;
      try
      {
        Guard.IsNotNull(order, nameof(order));
        orderId = await _orderRepository.InsertOrderAsync(
            _autoMapper.Map<LemonadeStand.Abstractions.Entities.Order>(order));
        return orderId;
      }
      catch (Exception ex)
      {
        _logger.LogError(ORDERSERVICE_INSERT_ERROR_MESSAGE, ex.Message);
        return 0;
      }

    }

    public async Task<IEnumerable<Order>> GetOrdersAsync()
    {
      var oReturn = await _orderRepository.GetOrdersAsync();
      return _autoMapper.Map<IEnumerable<Order>>(oReturn);
    }
  }
}

