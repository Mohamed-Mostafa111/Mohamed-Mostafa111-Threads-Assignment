using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.Models
{
	public sealed class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public decimal weightKg { get; set; }
	}
}
