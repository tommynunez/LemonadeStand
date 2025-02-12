using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LemonadeStand.Abstractions.Entities
{
	public class Base
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public DateTime Created { get; set; } = DateTime.Now;
		public DateTime Udpdated { get; set; } = DateTime.Now;
		public DateTime? Deleted { get; set; } = null;

		public Base()
		{
		}
	}
}

