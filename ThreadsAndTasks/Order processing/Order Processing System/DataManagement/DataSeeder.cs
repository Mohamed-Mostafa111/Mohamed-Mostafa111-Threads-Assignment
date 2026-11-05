using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.DataManagement
{
	public static class DataSeeder
	{
		public static async Task ResetAsync(CancellationToken cancellation)
		{
			if (Directory.Exists(DataFiles.DataDirectory))
			{
				Directory.Delete(DataFiles.DataDirectory,true);
			}
			Directory.CreateDirectory(DataFiles.DataDirectory);
			Directory.CreateDirectory(DataFiles.Invoices);
			Directory.CreateDirectory(DataFiles.Reports);

			await JsonFileStore.WriteAsync(DataFiles.CustomerFile, SeedingData.GetCustomers(), cancellation);
			await JsonFileStore.WriteAsync(DataFiles.ProductsFile, SeedingData.GetProducts(), cancellation);
			await JsonFileStore.WriteAsync(DataFiles.CouponsFile, SeedingData.GetCoupons(), cancellation);
			await JsonFileStore.WriteAsync(DataFiles.Incoming_ordersFile, SeedingData.GetOrders(), cancellation);
			await JsonFileStore.WriteAsync(DataFiles.OrdersFile, new List<object>(), cancellation);
		}
	}
}
