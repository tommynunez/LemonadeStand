using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ISizeService
	{
		Task<Size> GetByIdAsync(int id);
		Task<IEnumerable<Size>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null);
		Task InsertAsync(Size size);
		Task UpdateAsync(int id, Size size);
		Task DeleteAsync(int id);
		Task<IEnumerable<Size>> GetAllSizesAsync();
	}
}

