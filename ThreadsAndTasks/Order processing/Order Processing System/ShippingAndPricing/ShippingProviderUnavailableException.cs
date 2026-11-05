using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.ShippingAndPricing
{
	public class ShippingProviderUnavailableException:Exception
	{
	  public ShippingProviderUnavailableException(string Message):base(Message)
	  {

	  }
	}
}
