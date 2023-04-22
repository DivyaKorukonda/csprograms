using MySql.Data.MySqlClient;
using System;

class MysqlConnection
{
	public static void Main(String[] args)
	{
			connectionString();
	}

	public static void connectionString()
	{	
		try
		{

			MySqlConnection connection; 
			string connectionString = "server = 138.68.140.83;user = Divya;password = Divyasree@1;database= dbDivya";
			using (connection = new MySqlConnection(connectionString))
			{
			    connection.Open();

			    // Perform database operations here...

			}
			string sql = "SELECT * FROM Supermarket";
			connection.Open();
			using (MySqlCommand command = new MySqlCommand(sql, connection))
			{
			    using (MySqlDataReader reader = command.ExecuteReader())
			    {
					Console.WriteLine("__________________________________________________");
				     while (reader.Read())
				     {
						Console.WriteLine("Item Id : " + reader["ItemId"]);
						Console.WriteLine("Item Name : " + reader["ItemName"]);
						Console.WriteLine("Item Price : " + reader["ItemPrice"]);
						Console.WriteLine("Item Quantity : "+ reader["ItemQuantity"]);
						Console.WriteLine("___________________");
					}
			      }
			 }
			 connection.Close();
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
		}
	}
}