using Order_Processing_System.DataManagement;
using Order_Processing_System.Logging;
using Order_Processing_System.Models;

namespace Order_Processing_System.Reposetories
{
	public static class OrderRepository
	{
		public static async Task SaveOrderAsync(Order order, CancellationToken cancellationToken)
		{

			var OrderFile= await JsonFileStore.ReadAsync<List<Order>>(DataFiles.OrdersFile, cancellationToken);
			var ExistingINDEX= OrderFile.FindIndex(o=>o.Id == order.Id);
			if (ExistingINDEX != -1)
			{
				OrderFile[ExistingINDEX] = order;
			}
			else
			{
				OrderFile.Add(order);
			}
			await JsonFileStore.WriteAsync(DataFiles.OrdersFile, OrderFile, cancellationToken);
			await DelayAndCancellationHelper.DBWrite("OrderRepository", "SaveOrder", cancellationToken);

		}
		public static async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken)
		{
			await DelayAndCancellationHelper.DBquery("OrderRepository", CancellationToken.None);
			var OrderFile= await JsonFileStore.ReadAsync<List<Order>>(DataFiles.Incoming_ordersFile, CancellationToken.None);
			return OrderFile;
		}
		public static async Task<List<Order>> GetByStatusAsync(OrderStatus status,CancellationToken cancellationToken)
		{
			await DelayAndCancellationHelper.DBquery("OrderRepository", cancellationToken);
			var OrderFile= await JsonFileStore.ReadAsync<List<Order>>(DataFiles.OrdersFile, cancellationToken);
			return OrderFile.Where(o=>o.Status== status).ToList();
		}


	}

}
