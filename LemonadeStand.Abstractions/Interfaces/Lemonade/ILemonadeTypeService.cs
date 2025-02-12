using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ILemonadeTypeService
	{
		Task<LemonadeType> GetByIdAsync(int id);
		Task<IEnumerable<LemonadeType>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null);
		Task InsertAsync(LemonadeType lemonadeType);
		Task UpdateAsync(int id, LemonadeType lemonadeType);
		Task DeleteAsync(int id);
		Task<IEnumerable<LemonadeType>> GetAllLemonadeTypesAsync();
	}
}

