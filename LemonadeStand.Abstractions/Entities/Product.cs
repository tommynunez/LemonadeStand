
using System.Collections.Generic;

namespace LemonadeStand.Abstractions.Entities
{
	public class Product : Base
	{
		public int LemonadeTypeId { get; set; }
		public int SizeId { get; set; }
		public double Amount { get; set; }

		public virtual LemonadeType LemonadeTypes { get; set; }
		public virtual List<LineItem>? LineItems { get; set; }
		public virtual Size Sizes { get; set; }

		public Product()
		{
		}
	}
}

