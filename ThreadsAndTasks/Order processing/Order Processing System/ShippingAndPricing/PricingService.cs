using Order_Processing_System.Logging;
using Order_Processing_System.Models;
using Order_Processing_System.Reposetories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.ShippingAndPricing
{
	public class PricingOrder
	{
		private readonly HashSet<int> _failShippingForOrderIds;
		public PricingOrder(IEnumerable<int> failShippingForOrderIds)
		{
			_failShippingForOrderIds = new HashSet<int>(failShippingForOrderIds);
		}
		public async Task<decimal> CalcilateSubtotalAsync(Order order, CancellationToken cancellation)
		{
			await DelayAndCancellationHelper.DBquery("PricingOrder", cancellation);
			// Implementation for calculating subtotal
			decimal subtotal = 0m;
			foreach (var item in order.Items)
			{
				var product = await ProductRepository.GetByIdAsync(item.ProductId, cancellation);
				item.UnitPrice = product?.Price ?? 0m;
				subtotal += item.UnitPrice * item.Quantity;
			}
			return Math.Round(subtotal, 2, MidpointRounding.AwayFromZero);
		}

		public async Task<decimal> GetDiscountAsync(decimal subtotal, Order order, CancellationToken cancellationToken)
		{
			await DelayAndCancellationHelper.ApiRequesting("PricingOrder", "DiscountAPI", cancellationToken);

			int loyaltyDiscount = 0;
			var customer = await CustomerRepository.GetByIdAsync(order.CustomerId, cancellationToken);
			if (customer != null)
			{
				loyaltyDiscount = customer.LoyaltyTier switch
				{
					LoyaltyTier.Silver => 5,
					LoyaltyTier.Gold => 10,
					_ => 0
				};
			}

			int CouponDiscount = 0;
			var Coupon = await CouponRepository.GetByCodeAsync(order.CouponCode, cancellationToken);
			if (Coupon.ExpiryDate<=DateTime.Now)
			{
				CouponDiscount = Coupon.DiscountPercentage;
			}
			decimal totalDiscountPercentage = loyaltyDiscount + CouponDiscount;
			return ( subtotal * (totalDiscountPercentage / 100));
		}

		public async Task<decimal> CalculateShippingCostAsync(Order order,decimal subtotal, CancellationToken cancellationToken)
		{
			await DelayAndCancellationHelper.ApiRequesting("PricingOrder", "ShippingAPI", cancellationToken);

			if (_failShippingForOrderIds.Contains(order.Id))
			{
				throw new ShippingProviderUnavailableException("Shipping provider unavailable");
			}
			int totalQuantity = order.Items.Sum(i => i.Quantity);
			decimal totalWeight = 0;
			foreach(var item in order.Items)
			{
				var product = await ProductRepository.GetByIdAsync(item.ProductId, cancellationToken);
				if (product != null)
				{
					totalWeight += product.weightKg * item.Quantity;
				}
			}
			decimal shippingCost = 0;
			if (subtotal >= 1000)
			{
				shippingCost = 0;
			}
			else
			{
				shippingCost = 5.00m+ (1.50m * totalQuantity) + (2.00m * totalWeight);
			}
			return Math.Round(shippingCost, 2, MidpointRounding.AwayFromZero);
		}
		public async Task PriceOrderAsync(Order order, CancellationToken cancellationToken)
		{
			decimal subTotal = await CalcilateSubtotalAsync(order, cancellationToken);
			order.SubTotal = subTotal;

			var discountTask = GetDiscountAsync(subTotal, order, cancellationToken);
			var shippingTask = CalculateShippingCostAsync(order, subTotal, cancellationToken);

			await Task.WhenAll(discountTask, shippingTask);

			var TotalDiscount = await discountTask;
			decimal shippingCost = await shippingTask;

			order.DiscountAmount = TotalDiscount;
			order.ShippingCost = shippingCost;

			order.TotalAmount = Math.Round(subTotal - TotalDiscount + shippingCost, 2, MidpointRounding.AwayFromZero);
		}

		public async Task PriceOrderSequentialAsync(Order order, CancellationToken cancellationToken)
		{
			decimal subTotal = await CalcilateSubtotalAsync(order, cancellationToken);
			order.SubTotal = subTotal;

			var totalDiscount = await GetDiscountAsync(subTotal, order, cancellationToken);
			decimal shippingCost = await CalculateShippingCostAsync(order, subTotal, cancellationToken);

			order.DiscountAmount = totalDiscount;
			order.ShippingCost = shippingCost;

			order.TotalAmount = Math.Round(subTotal - totalDiscount + shippingCost, 2, MidpointRounding.AwayFromZero);
		}
	}
}
