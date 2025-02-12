using System.Collections.Generic;

namespace LemonadeStand.Abstractions.Entities
{
	public class LemonadeType : Base
	{
		public string Name { get; set; }

		public virtual List<Product> Products { get; set; }

		public LemonadeType()
		{
		}
	}
}

