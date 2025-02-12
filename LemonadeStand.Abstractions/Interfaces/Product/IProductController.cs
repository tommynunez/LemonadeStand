using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface IProductController
	{
		Task<IActionResult> GetProductsAsync();
		Task<IActionResult> GetByIdAsync([FromRoute] int id);
		Task<IActionResult> InsertAsync([FromBody] ProductMutation productMutation);
		Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] ProductMutation productMutation);
		Task<IActionResult> DeleteAsync([FromRoute] int id);
	}
}

