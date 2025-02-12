using System.Collections.Generic;

namespace LemonadeStand.Abstractions.Entities
{
	public class Order : Base
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public double TotalCost { get; set; }

		public virtual List<LineItem> LineItems { get; set; }
		public Order()
		{
		}
	}
}

