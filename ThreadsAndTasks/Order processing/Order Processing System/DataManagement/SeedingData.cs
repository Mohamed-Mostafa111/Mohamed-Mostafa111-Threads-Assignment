using Order_Processing_System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.DataManagement
{
	public static class SeedingData
	{
		public static List<Customer> GetCustomers()
		{
			return new List<Customer>
			{
				new Customer { Id = 1, Name = "Ahmed Ali", Email = "ahmed.ali@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Gold },
				new Customer { Id = 2, Name = "Sara Mohamed", Email = "sara.mohamed@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Silver },
				new Customer { Id = 3, Name = "Omar Hassan", Email = "omar.hassan@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Bronze },
				new Customer { Id = 4, Name = "Mona Ibrahim", Email = "mona.ibrahim@example.com", IsActive = false, LoyaltyTier = LoyaltyTier.Silver },
				new Customer { Id = 5, Name = "Youssef Adel", Email = "youssef.adel@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Gold },
				new Customer { Id = 6, Name = "Nour Khaled", Email = "nour.khaled@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Bronze },
				new Customer { Id = 7, Name = "Karim Samir", Email = "karim.samir@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Silver },
				new Customer { Id = 8, Name = "Laila Mahmoud", Email = "laila.mahmoud@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Gold },
				new Customer { Id = 9, Name = "Hassan Tarek", Email = "hassan.tarek@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Bronze },
				new Customer { Id = 10, Name = "Dina Fathy", Email = "dina.fathy@example.com", IsActive = true, LoyaltyTier = LoyaltyTier.Silver }
			};
		}
		public static List<Product> GetProducts()
		{
			return new List<Product>
		   {
				new Product { Id = 1, Name = "Laptop", Price = 1200.00m, StockQuantity = 10, weightKg = 2.2m }, 
				new Product { Id = 2, Name = "Smartphone", Price = 800.00m, StockQuantity = 15, weightKg = 0.4m }, 
				new Product { Id = 3, Name = "Wireless Mouse", Price = 25.00m, StockQuantity = 2, weightKg = 0.1m },
				new Product { Id = 4, Name = "Mechanical Keyboard", Price = 90.00m, StockQuantity = 1, weightKg = 0.9m }, 
				new Product { Id = 5, Name = "USB-C Hub", Price = 45.00m, StockQuantity = 30, weightKg = 0.2m }, 
				new Product { Id = 6, Name = "Headphones", Price = 150.00m, StockQuantity = 12, weightKg = 0.3m }, 
				new Product { Id = 7, Name = "27\" Monitor", Price = 350.00m, StockQuantity = 6, weightKg = 5.0m }, 
				new Product { Id = 8, Name = "Webcam", Price = 70.00m, StockQuantity = 20, weightKg = 0.2m } 
		   };
		}
		public static List<Coupon> GetCoupons()
		{
			return new List<Coupon>
			{
				new Coupon { Code = "SAVE10", DiscountPercentage = 10, ExpiryDate = DateTime.Now.AddDays(180) },
				new Coupon { Code = "WELCOME15", DiscountPercentage = 15, ExpiryDate = DateTime.Now.AddDays(90) },
				new Coupon { Code = "FLASH20", DiscountPercentage = 20, ExpiryDate = DateTime.Now.AddDays(7) },
				new Coupon { Code = "OLD20", DiscountPercentage = 20, ExpiryDate = DateTime.Now.AddDays(-30) }
			};
		}
		public static List<Order> GetOrders()
		{
			return new List<Order>
			{
				new Order
				{
					Id = 1,
					CustomerId = 1,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 1, Quantity = 1 },
						new OrderItem { ProductId = 3, Quantity = 1 }
					},
					CouponCode = "SAVE10",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 2,
					CustomerId = 2,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 2, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 3,
					CustomerId = 3,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 5, Quantity = 2 },
						new OrderItem { ProductId = 8, Quantity = 1 }
					},
					CouponCode = "WELCOME15",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 4,
					CustomerId = 4,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 6, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 5,
					CustomerId = 5,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 7, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 6,
					CustomerId = 6,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 5, Quantity = 1 }
					},
					CouponCode = "FLASH20",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 7,
					CustomerId = 7,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 6, Quantity = 1 },
						new OrderItem { ProductId = 8, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 8,
					CustomerId = 8,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 1, Quantity = 1 }
					},
					CouponCode = "SAVE10",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 9,
					CustomerId = 9,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 3, Quantity = 5 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 10,
					CustomerId = 10,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 4, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 11,
					CustomerId = 1,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 4, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 12,
					CustomerId = 2,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 2, Quantity = 1 }
					},
					CouponCode = "OLD20",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 13,
					CustomerId = 3,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 6, Quantity = 2 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 14,
					CustomerId = 5,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 8, Quantity = 2 },
						new OrderItem { ProductId = 5, Quantity = 1 }
					},
					CouponCode = "WELCOME15",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 15,
					CustomerId = 99,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 2, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 16,
					CustomerId = 6,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 7, Quantity = 1 },
						new OrderItem { ProductId = 5, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 17,
					CustomerId = 7,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 2, Quantity = 1 }
					},
					CouponCode = "SAVE10",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 18,
					CustomerId = 8,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 6, Quantity = 1 }
					},
					CouponCode = "FAKE50",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 19,
					CustomerId = 9,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 8, Quantity = 1 }
					},
					CouponCode = null,
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				},
				new Order
				{
					Id = 20,
					CustomerId = 10,
					Items = new List<OrderItem>
					{
						new OrderItem { ProductId = 1, Quantity = 1 },
						new OrderItem { ProductId = 6, Quantity = 1 }
					},
					CouponCode = "FLASH20",
					SubTotal = 0,
					DiscountAmount = 0,
					ShippingCost = 0m,
					TotalAmount = 0,
					Status = OrderStatus.Pending,
					CreatedAt = DateTime.Now,
					FailureReason = null,
					TransactionId = null
				}
			};
		}

	}
}
