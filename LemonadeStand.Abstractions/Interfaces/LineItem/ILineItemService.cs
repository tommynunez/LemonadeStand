using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ILineItemService
	{
		Task<bool> InsertAsync(IEnumerable<LineItem> lineItems, int orderId);
	}
}

