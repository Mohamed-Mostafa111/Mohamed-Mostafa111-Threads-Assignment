using Order_Processing_System.Models;
using Order_Processing_System.Reposetories;
using Order_Processing_System.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Order_Processing_System.Phases
{
	public static class Phase1Runner
	{
		public static async Task RunAsync(CancellationToken cancellation)
		{
			// ---------------- SYNC Methods to load Incoming Orders -----------------
			await DataManagement.DataSeeder.ResetAsync(cancellation);
			var IncomingOrders = await OrderRepository.GetAllAsync(cancellation);
			var SyncStpwatch = Stopwatch.StartNew();
			bool isFaliure;
			string FaluireMessage = "";
			foreach(var order in IncomingOrders)
			{
				(isFaliure,FaluireMessage)=OrderValidator.ValidateOrder(order);
				if (!isFaliure)
				{
					order.FailureReason = FaluireMessage;
					order.Status = OrderStatus.Rejected;
					await OrderRepository.SaveOrderAsync(order, cancellation);
				}
			}
			SyncStpwatch.Stop();
			double seconds = SyncStpwatch.Elapsed.TotalSeconds;

			// ---------------- ASYNC Methods to load Incoming Orders -----------------
			await DataManagement.DataSeeder.ResetAsync(cancellation);
			IncomingOrders =await OrderRepository.GetAllAsync(cancellation);

			var AsyncStpwatch = Stopwatch.StartNew();
			foreach(var order in IncomingOrders)
			{
				(isFaliure,FaluireMessage)=await OrderValidator.ValidateOrderAsync(order, cancellation);
				if (!isFaliure)
				{
					order.FailureReason = FaluireMessage;
					order.FailureReason = FaluireMessage;
					order.Status = OrderStatus.Rejected;
					await OrderRepository.SaveOrderAsync(order, cancellation);
				}
			}
			AsyncStpwatch.Stop();
			double asyncSeconds = AsyncStpwatch.Elapsed.TotalSeconds;

			var allsavedOrders = await OrderRepository.GetAllAsync(cancellation);
			var ValidatedOrders= await OrderRepository.GetByStatusAsync(OrderStatus.Validated, cancellation);
			var RejectedOrders = await OrderRepository.GetByStatusAsync(OrderStatus.Rejected, cancellation);
			Console.WriteLine("===== Validation Summary =====");
			Console.WriteLine($"Total Orders: {allsavedOrders.Count}");
			Console.WriteLine($"Validated:    {ValidatedOrders.Count}");
			Console.WriteLine($"Rejected:     {RejectedOrders.Count}");
			foreach (var order in RejectedOrders)
			{
				Console.WriteLine($"- Order #{order.Id}:  {order.FailureReason}");
			}

			Console.WriteLine($"Sync Time:  {SyncStpwatch:F1} seconds");
			Console.WriteLine($"Async Time: {AsyncStpwatch:F1} seconds");
			Console.WriteLine($"orders.json now contains {allsavedOrders.Count} records.");
		}
	}
}
