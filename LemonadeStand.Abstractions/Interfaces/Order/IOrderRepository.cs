using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IOrderRepository
	{
		Task<int> InsertOrderAsync(Order order);
		Task<IEnumerable<Order>> GetOrdersAsync();
	}
}

