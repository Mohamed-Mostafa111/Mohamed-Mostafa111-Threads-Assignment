using Order_Processing_System.DataManagement;
using Order_Processing_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.Reposetories
{
	public class InvoiceGenerator
	{
		public async Task GenerateAsync(Order order)
		{
			await Task.Run(() =>
			{
				long sum = 0;
				for (int i = 0; i < 20_000_000; i++)
				{
					sum += i;
				}

				string filePath = Path.Combine(DataFiles.Invoices, $"invoice_{order.Id}.txt");
				string content = $"Invoice for Order #{order.Id}\nTotal Amount: {order.TotalAmount}\nStatus: Completed";
				File.WriteAllText(filePath, content);
			});
		}
	}
}
