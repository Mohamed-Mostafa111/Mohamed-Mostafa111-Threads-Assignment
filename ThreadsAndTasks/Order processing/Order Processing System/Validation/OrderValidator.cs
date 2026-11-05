using Order_Processing_System.Models;
using Order_Processing_System.Reposetories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Order_Processing_System.Validation
{
	public static class OrderValidator
	{
		public static async Task<(bool,string Message)> ValidateOrderAsync(Order order,CancellationToken cancellation)
		{
			var Customer= await CustomerRepository.GetByIdAsync(order.CustomerId, cancellation);
			if (Customer==null)
			{
				return (false, $" - Order #{order.Id}:  Customer #{order.CustomerId} not found");
			}
			if (!Customer.IsActive)
			{
				return (false, $" - Order #{order.Id}:  Customer is inactive");
			}
			foreach(var item in order.Items)
			{
				var Product = await ProductRepository.GetByIdAsync(item.ProductId, cancellation);
				if (Product == null)
				{
					return (false, $" - Order #{order.Id}:  Product #{item.ProductId} not found");
				}
				if (item.Quantity>Product.StockQuantity)
				{
					return (false, $" Insufficient stock for '{Product.Name}'");
				}

				var Coupon = await CouponRepository.GetByCodeAsync(order.CouponCode, cancellation);

				if (Coupon == null)
				{
					return (false, $" - Order #{order.Id}:   Coupon '{order.CouponCode}' does not exist");
				}
				if (Coupon.ExpiryDate>=DateTime.Today)
				{
					return (false, $" - Order #{order.Id}:   Coupon '{order.CouponCode}' has expired");
				}
			}

			return (true, "Order is valid");

		}

		// -------------------------- SYNC Methods --------------------------

		public static (bool, string Message) ValidateOrder(Order order)
		{
			var Customer = CustomerRepository.GetById(order.CustomerId);
			if (Customer == null)
			{
				return (false, $" - Order #{order.Id}:  Customer #{order.CustomerId} not found");
			}
			if (!Customer.IsActive)
			{
				return (false, $" - Order #{order.Id}:  Customer is inactive");
			}
			foreach (var item in order.Items)
			{
				var Product = ProductRepository.GetById(item.ProductId);
				if (Product == null)
				{
					return (false, $" - Order #{order.Id}:  Product #{item.ProductId} not found");
				}
				if (item.Quantity > Product.StockQuantity)
				{
					return (false, $" Insufficient stock for '{Product.Name}'");
				}
				var Coupon = CouponRepository.GetByCode(order.CouponCode);
				if (Coupon == null)
				{
					return (false, $" - Order #{order.Id}:   Coupon '{order.CouponCode}' does not exist");
				}
				if (Coupon.ExpiryDate >= DateTime.Today)
				{
					return (false, $" - Order #{order.Id}:   Coupon '{order.CouponCode}' has expired");
				}
			}
			return (true, "Order is valid");
		}
	}
}
