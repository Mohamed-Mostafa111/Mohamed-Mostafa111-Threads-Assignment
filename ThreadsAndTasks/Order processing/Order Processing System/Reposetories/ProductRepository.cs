using Order_Processing_System.DataManagement;
using Order_Processing_System.Logging;
using Order_Processing_System.Models;

namespace Order_Processing_System.Reposetories
{
	public static class ProductRepository
	{

		public static async Task<Product?> GetByIdAsync(int productId, CancellationToken cancellationToken)
		{
			await DelayAndCancellationHelper.DBquery("ProductRepository", cancellationToken);
			var ProductFile= await JsonFileStore.ReadAsync<List<Product>>(DataFiles.ProductsFile, cancellationToken);
			return ProductFile.FirstOrDefault(p => p.Id == productId);
		}

		public static async Task<bool> ReserveStockAsync(int productId, int quantity, CancellationToken cancellationToken)
		{
			await DelayAndCancellationHelper.DBWrite("ProductRepository", "ReserveStock", cancellationToken);
			var ProductFile = await JsonFileStore.ReadAsync<List<Product>>(DataFiles.ProductsFile, cancellationToken);

			var product = ProductFile.FirstOrDefault(p => p.Id == productId);

			if (product != null&&product.StockQuantity >= quantity)
			{
				product.StockQuantity -= quantity;

				await JsonFileStore.WriteAsync(DataFiles.ProductsFile, ProductFile, cancellationToken);
				return true;
			}
			return false;
		}

		//-------------------------- SYNC Methods --------------------------

		public static Product? GetById(int productId)
		{
			DelayAndCancellationHelper.DBquerySYNC("SYNCProductRepository");
			var ProductFile = JsonFileStore.Read<List<Product>>(DataFiles.ProductsFile);
			return ProductFile.FirstOrDefault(p => p.Id == productId);
		}

		// -------------------------- Cover from Race Conditions --------------------------

		private static readonly SemaphoreSlim _Lock = new SemaphoreSlim(1, 1);
		public static async Task<bool> ReserveStockAsyncWithLock(int productId, int quantity, CancellationToken cancellationToken)
		{
			await _Lock.WaitAsync();
			try
			{
				await DelayAndCancellationHelper.DBWrite("ProductRepository", "ReserveStock", cancellationToken);
				var ProductFile = await JsonFileStore.ReadAsync<List<Product>>(DataFiles.ProductsFile, cancellationToken);
				var product = ProductFile.FirstOrDefault(p => p.Id == productId);
				if (product != null && product.StockQuantity >= quantity)
				{
				    product.StockQuantity -= quantity;

					await JsonFileStore.WriteAsync(DataFiles.ProductsFile, ProductFile, cancellationToken);
					return true;
				}
				return false;
			}
			finally
			{
				_Lock.Release();
			}
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
