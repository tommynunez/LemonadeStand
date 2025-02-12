using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ISizeController
	{
		Task<ActionResult> GetByIdAsync([FromRoute] int id);
		Task<ActionResult> GetAllAsync(string search, [FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string sortField = null);
		Task<ActionResult> InsertAsync([FromBody] Size size);
		Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] Size size);
		Task<ActionResult> DeleteAsync([FromRoute] int id);
	}
}

