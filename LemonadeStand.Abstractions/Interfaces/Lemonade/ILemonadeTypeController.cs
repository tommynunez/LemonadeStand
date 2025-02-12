using System.Threading.Tasks;
using LemonadeStand.Abstractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace LemonadeStand.Abstractions.Interfaces
{
	public interface ILemonadeTypeController
	{
		Task<ActionResult> GetByIdAsync([FromRoute] int id);
		Task<ActionResult> GetAllAsync([FromQuery] string search, [FromQuery] int pageIndex, [FromQuery] int pageSize, [FromQuery] string sortField = null);
		Task<ActionResult> InsertAsync([FromBody] LemonadeType lemonadeType);
		Task<ActionResult> UpdateAsync([FromRoute] int id, [FromBody] LemonadeType lemonadeType);
		Task<ActionResult> DeleteAsync([FromRoute] int id);
	}
}

