using Order_Processing_System.DataManagement;
using Order_Processing_System.Logging;
using Order_Processing_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.Reposetories
{
	public static class CustomerRepository
	{
		public static async Task<Customer?> GetByIdAsync(int customerId, CancellationToken cancellationToken)
		{
			await DelayAndCancellationHelper.DBquery("CustomerRepository", cancellationToken);
			var CustomerFile = await JsonFileStore.ReadAsync<List<Customer>>(DataFiles.CustomerFile, cancellationToken);
			return CustomerFile.FirstOrDefault(c => c.Id == customerId);
		}

		//-------------------------- SYNC Methods --------------------------
		public static Customer? GetById(int customerId)
		{
			DelayAndCancellationHelper.DBquerySYNC("SYNCCustomerRepository");
			var CustomerFile = JsonFileStore.Read<List<Customer>>(DataFiles.CustomerFile);
			return CustomerFile.FirstOrDefault(c => c.Id == customerId);
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
