using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductRepository
	{
		Task<Product> GetByIdAsync(int id);
		Task InsertAsync(Product product);
		Task UpdateAsync(int id, Product product);
		Task DeleteAsync(int id);
		Task<IEnumerable<Product>> GetAllProductsAsync();
	}
}

