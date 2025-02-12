using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LemonadeStand.Abstractions.Entities;
using LemonadeStand.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Toolkit.Diagnostics;

namespace LemonadeStand.Services
{
  public class LineItemService : ILineItemService
  {
    private readonly ILogger<LineItemService> _logger;
    private readonly ILineItemRepository _lineItemRepository;
    private readonly IMapper _mapper;
    private const string LINEITEM_INSERT_ERROR_MESSAGE = "Error Message: {0}";

    public LineItemService(ILogger<LineItemService> logger,
            ILineItemRepository lineItemRepository,
            IMapper mapper)
    {
      _logger = logger;
      _lineItemRepository = lineItemRepository;
      _mapper = mapper;
    }

    public async Task<bool> InsertAsync(
        IEnumerable<LemonadeStand.Abstractions.Models.LineItem> lineItems,
        int orderId)
    {
      Guard.IsNotNull(lineItems, nameof(lineItems));

      var isSuccessful = false;
      try
      {
        var elineItem = _mapper.Map<IEnumerable<LineItem>>(lineItems);
        elineItem.Select(x => new LineItem
        {
          OrderId = orderId,
          ProductId = x.ProductId,
        });
        await _lineItemRepository.InsertLineItemAsync(elineItem);
        isSuccessful = true;
      }
      catch (Exception ex)
      {
        _logger.LogError(LINEITEM_INSERT_ERROR_MESSAGE, ex.Message);
      }

      return isSuccessful;
    }
  }
}

