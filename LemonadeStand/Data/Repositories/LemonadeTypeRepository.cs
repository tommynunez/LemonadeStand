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
  public class LemonadeTypeRepository : ILemonadeTypeRepository
  {
    private readonly ILogger<LemonadeTypeRepository> _logger;
    private readonly DatabaseContext _databaseContext;

    public LemonadeTypeRepository(
        ILogger<LemonadeTypeRepository> logger,
        DatabaseContext databaseContext)
    {
      _logger = logger;
      _databaseContext = databaseContext;

    }

    public async Task DeleteAsync(int id)
    {
      var oModel = _databaseContext.LemonadeTypes.FirstOrDefault(x => x.Id == id);
      oModel.Deleted = DateTime.Now;
      _databaseContext.Update(oModel);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }

    public async Task<IEnumerable<LemonadeType>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null)
    {
      IQueryable<LemonadeType> query = _databaseContext.LemonadeTypes.AsQueryable();

      if (!String.IsNullOrWhiteSpace(search))
      {
        search = search.ToLower();

        query = (from lt in _databaseContext.LemonadeTypes
                 where lt.Name.ToString() == search ||
                 lt.Id.ToString() == search
                 select lt);
      }

      //sort the fields
      query = search switch
      {
        "id_asc" => query.OrderBy(x => x.Id).Skip(pageSize * pageIndex).Take(pageSize),
        "id_desc" => query.OrderByDescending(x => x.Id).Skip(pageSize * pageIndex).Take(pageSize),
        "name_asc" => query.OrderBy(x => x.Name).Skip(pageSize * pageIndex).Take(pageSize),
        "name_desc" => query.OrderByDescending(x => x.Name).Skip(pageSize * pageIndex).Take(pageSize),
        "created_asc" => query.OrderBy(x => x.Created).Skip(pageSize * pageIndex).Take(pageSize),
        "created_desc" => query.OrderByDescending(x => x.Created).Skip(pageSize * pageIndex).Take(pageSize),
        "updated_asc" => query.OrderBy(x => x.Udpdated).Skip(pageSize * pageIndex).Take(pageSize),
        "updated_desc" => query.OrderByDescending(x => x.Udpdated).Skip(pageSize * pageIndex).Take(pageSize),
        "deleted_asc" => query.OrderBy(x => x.Deleted).Skip(pageSize * pageIndex).Take(pageSize),
        "deleted_desc" => query.OrderByDescending(x => x.Deleted).Skip(pageSize * pageIndex).Take(pageSize),
        _ => query.OrderBy(x => x.Name).Skip(pageSize * pageIndex).Take(pageSize),
      };

      return await query.ToListAsync();
    }

    public async Task<IEnumerable<LemonadeType>> GetAllLemonadeTypesAsync()
    {
      return await _databaseContext.LemonadeTypes.ToListAsync();
    }

    public async Task<LemonadeType?> GetByIdAsync(int id)
    {
      return await _databaseContext.LemonadeTypes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(LemonadeType lemonadeType)
    {
      await _databaseContext.LemonadeTypes.AddAsync(lemonadeType);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }

    public async Task UpdateAsync(int id, LemonadeType lemonadeType)
    {
      _databaseContext.LemonadeTypes.Update(lemonadeType);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }
  }
}

