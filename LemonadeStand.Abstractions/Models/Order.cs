using System.Collections.Generic;

namespace LemonadeStand.Abstractions.Models
{
	public class Order
	{
		public int? Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public double TotalCost { get; set; }
		public List<LineItem> LineItems { get; set; } = new List<LineItem>();

		public Order()
		{
		}
	}
}

