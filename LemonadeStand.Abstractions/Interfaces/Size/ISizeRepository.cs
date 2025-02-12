using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ISizeRepository
	{
		Task<Size> GetByIdAsync( int id);
		Task<IEnumerable<Size>> GetAllAsync(string search, int pageIndex, int pageSize, string sortField = null);
		Task InsertAsync(Size size);
		Task UpdateAsync(int id, Size size);
		Task DeleteAsync(int id);
		Task<IEnumerable<Size>> GetAllSizesAsync();
	}
}

