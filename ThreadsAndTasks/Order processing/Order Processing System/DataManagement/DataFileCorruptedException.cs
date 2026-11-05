using System;
using System.Collections.Generic;
using System.Text;

namespace Order_Processing_System.DataManagement
{
	public class DataFileCorruptedException:Exception
	{
		public DataFileCorruptedException(string message) :base(message)
		{
			
		}
	}
}
