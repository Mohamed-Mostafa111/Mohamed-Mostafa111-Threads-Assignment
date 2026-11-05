using Order_Processing_System.DataManagement;
using Order_Processing_System.Logging;
using Order_Processing_System.Models;

namespace Order_Processing_System.Reposetories
{
	public static class CouponRepository
	{
		public static async Task<Coupon?> GetByCodeAsync(string couponCode, CancellationToken cancellationToken)
		{
			await DelayAndCancellationHelper.DBquery("CouponRepository", cancellationToken);

			var CouponFile = await JsonFileStore.ReadAsync<List<Coupon>>(DataFiles.CouponsFile, cancellationToken);
			var Coupon= CouponFile.FirstOrDefault(c => c.Code == couponCode);
			return Coupon;

		}

		// ---------------------- SYNC Method -------------------------
		public static  Coupon? GetByCode(string couponCode)
		{
			 DelayAndCancellationHelper.DBquerySYNC("SYNCCouponRepository");

			var CouponFile = JsonFileStore.Read<List<Coupon>>(DataFiles.CouponsFile);
			var Coupon = CouponFile.FirstOrDefault(c => c.Code == couponCode);
			return Coupon;
		}
	}

	//public class IncomingOrderRepository
	//{
	//	public static async Task<List<Report>> GetAllAsync(CancellationToken cancellationToken = default)
	//	{
	//		await DelayAndCancellationHelper.DBquery("IncomingOrderRepository", cancellationToken);
	//		return await JsonFileStore.ReadAsync<List<OrderItem>>(DataFiles.Incoming_ordersFile, cancellationToken);
	//	}
	//}

}
