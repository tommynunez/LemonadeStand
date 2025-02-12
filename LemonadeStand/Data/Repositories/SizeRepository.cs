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
  public class SizeRepository : ISizeRepository
  {
    private readonly ILogger<SizeRepository> _logger;
    private readonly DatabaseContext _databaseContext;

    public SizeRepository(ILogger<SizeRepository> logger,
        DatabaseContext databaseContext)
    {
      _logger = logger;
      _databaseContext = databaseContext;
    }

    public async Task DeleteAsync(int id)
    {
      var oModel = _databaseContext.Sizes.FirstOrDefault(x => x.Id == id);
      oModel.Deleted = DateTime.Now;
      _databaseContext.Update(oModel);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }

    public async Task<IEnumerable<Size>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null)
    {
      IQueryable<Size> query = _databaseContext.Sizes.AsQueryable();

      if (!String.IsNullOrWhiteSpace(search))
      {
        search = search.ToLower();

        query = (from lt in _databaseContext.Sizes
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

    public async Task<IEnumerable<Size>> GetAllSizesAsync()
    {
      return await _databaseContext.Sizes.ToListAsync();
    }

    public async Task<Size> GetByIdAsync(int id)
    {
      var oReturn = await _databaseContext.Sizes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
      return oReturn;
    }

    public async Task InsertAsync(Size size)
    {
      await _databaseContext.Sizes.AddAsync(size);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }

    public async Task UpdateAsync(int id, Size size)
    {
      _databaseContext.Sizes.Update(size);
      await _databaseContext.SaveChangesAsync();
      _databaseContext.ChangeTracker.Clear();
    }
  }
}

