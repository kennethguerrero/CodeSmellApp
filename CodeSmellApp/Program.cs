namespace CodeSmellApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		// Long Method: This method is doing too many things (validation, calculation, order creation, and saving)
		private void ProcessOrder(string custName, string custAddr, string prodName, int quantity, double price)
		{
			// Inconsistent Naming: Inconsistent variable naming (custName, custAddr)
			// Step 1: Validate customer
			if (custName == null || custAddr == null)
			{
				Console.WriteLine("Invalid customer details.");
				return;
			}

			// Step 2: Calculate total price
			double totalPrice = quantity * price;
			// Conditional Complexity: Complex conditional statement for discount calculation
			if (quantity > 10)
			{
				totalPrice *= 0.9; // Apply discount for bulk orders
			}

			// Step 3: Create order
			Order order = new Order
			{
				CustomerName = custName,
				CustomerAddress = custAddr,
				ProductName = prodName,
				Quantity = quantity,
				TotalPrice = totalPrice
			};

			// Step 4: Save order to database
			try
			{
				Database.SaveOrder(order);
			}
			catch (Exception ex)
			{
				// Lack of Error Handling: Only a basic error message, no proper error handling
				Console.WriteLine("Failed to save order: " + ex.Message);
			}

			Console.WriteLine("Order processed successfully.");
		}

		// Large Class: This class is responsible for too many things related to an order
		private class Order
		{
			// Inconsistent Naming: Use of public fields instead of properties
			public string CustomerName;
			public string CustomerAddress;
			public string ProductName;
			public int Quantity;
			public double TotalPrice;
		}

		static class Database
		{
			// Tight Coupling: Directly depends on Order class
			// Lack of Error Handling: Only throws exceptions without handling them
			public static void SaveOrder(Order order)
			{
				// Simulate saving order to database
				if (order == null)
				{
					throw new ArgumentNullException(nameof(order));
				}
				Console.WriteLine("Order saved to database.");
			}
		}
	}
}
