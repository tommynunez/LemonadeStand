using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;
using LemonadeStand.Abstractions.Interfaces;
using Microsoft.Extensions.Logging;

namespace LemonadeStand.Data.Repositories
{
  public class LineItemRepository : ILineItemRepository
  {
    private readonly DatabaseContext _databaseContext;
    private readonly ILogger<LineItem> _logger;

    public LineItemRepository(DatabaseContext databaseContext,
            ILogger<LineItem> logger)
    {
      _databaseContext = databaseContext;
      _logger = logger;
    }

    public async Task InsertLineItemAsync(IEnumerable<LineItem> lineItems)
    {
      await _databaseContext.AddRangeAsync(lineItems);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }
  }
}

