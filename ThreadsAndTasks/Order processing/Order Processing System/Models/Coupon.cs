namespace Order_Processing_System.Models
{
	public class Coupon
	{
		public string Code { get; set; }
		public int DiscountPercentage { get; set; }
		public DateTime ExpiryDate { get; set; }
	}
}
