using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IOrderService
	{
		Task<int> InsertOrderAsync(Order order);
		Task<IEnumerable<Order>> GetOrdersAsync();
	}
}

