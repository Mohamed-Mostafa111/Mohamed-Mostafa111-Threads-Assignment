using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Order_Processing_System.DataManagement
{
	public static class DataFiles
	{
		public static readonly string DataDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
		public static readonly string CustomerFile = Path.Combine(DataDirectory, "Customers.json");
		public static readonly string ProductsFile = Path.Combine(DataDirectory, "Products.json");
		public static readonly string CouponsFile = Path.Combine(DataDirectory, "Coupons.json");
		public static readonly string Incoming_ordersFile = Path.Combine(DataDirectory, "IncomingOrders.json");
		public static readonly string OrdersFile = Path.Combine(DataDirectory, "Orders.json");
		public static readonly string PaymentsFile = Path.Combine(DataDirectory, "Payments.json");
		public static readonly string EmailsFile = Path.Combine(DataDirectory, "Emails.json");
		public static readonly string Email_retryFile = Path.Combine(DataDirectory, "EmailRetry.json");
		public static readonly string Invoices = Path.Combine(DataDirectory, "Invoices");
		public static readonly string Reports = Path.Combine(DataDirectory, "Reports");

		public static readonly JsonSerializerOptions DefaultOptions = new JsonSerializerOptions
		{
			WriteIndented = true,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			Converters = { new JsonStringEnumConverter() }
		};

	}
}
