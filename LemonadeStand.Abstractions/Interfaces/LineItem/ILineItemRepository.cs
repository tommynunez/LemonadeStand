
using System.Collections.Generic;
using System.Threading.Tasks;
using LemonadeStand.Abstractions.Entities;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ILineItemRepository
	{
		Task InsertLineItemAsync(IEnumerable<LineItem> lineItems);
	}
}

