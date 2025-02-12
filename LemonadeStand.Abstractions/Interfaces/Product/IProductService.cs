using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductService
	{
		Task<Product> GetByIdAsync(int id);
		Task InsertAsync(ProductMutation product);
		Task UpdateAsync(int id, ProductMutation product);
		Task DeleteAsync(int id);
		Task<IEnumerable<Product>> GetAllProductsAsync();
    }
}

