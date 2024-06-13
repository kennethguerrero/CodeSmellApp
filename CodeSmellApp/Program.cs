namespace CodeSmellApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string custName = "Juan Dela Cruz";
			string custAddr = "Manila, Philippines";
			string prodName = "Laptop";
			int quantity = 5;
			double price = 50000.00;

			CustomerOrderManager manager = new CustomerOrderManager();
			manager.ProcessOrder(custName, custAddr, prodName, quantity, price);

			Console.ReadLine(); // Pause to view output
		}

		class CustomerOrderManager
		{
			public void ProcessOrder(string custName, string custAddr, string prodName, int quantity, double price)
			{
				if (custName == null || custAddr == null)
				{
					Console.WriteLine("Invalid customer details.");
					return;
				}

				double totalPrice = quantity * price;
				if (quantity > 10)
				{
					totalPrice *= 0.9; // Apply discount for bulk orders
				}

				Order order = new Order
				{
					CustomerName = custName,
					CustomerAddress = custAddr,
					ProductName = prodName,
					Quantity = quantity,
					TotalPrice = totalPrice
				};

				try
				{
					Database.SaveOrder(order);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Failed to save order: " + ex.Message);
				}

				Console.WriteLine("Order processed successfully.");
			}
		}

		class Order
		{
			public string CustomerName;
			public string CustomerAddress;
			public string ProductName;
			public int Quantity;
			public double TotalPrice;
		}

		static class Database
		{
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
