using MySql.Data.MySqlClient;
using System;
using System.Data;

class MysqlConnection
{
	public static void Main(String[] args)
	{
		cCRUD oCRUD = new cCRUD();
		while(true)
		{
			Console.WriteLine("\n                    1. Add Item\n                    2. Show All Items\n                    3. Search Item\n                    4. Update Item\n                    5. Delete Item");
			Console.WriteLine("Enter an option from the above list: ");
			int choice = Convert.ToInt32(Console.ReadLine());
			switch(choice)
			{
				case 1:
					oCRUD.CreateItem();
					break;
				case 2:
					oCRUD.ShowItems();
					break;
				case 3:
					oCRUD.SearchItem();
					break;
				case 4:
					oCRUD.UpdateItem();
					break;
				case 5:
					oCRUD.DeleteItem();
					break;
			}
		}
	}
}

class cCRUD
{
	MySqlConnection connection; 
	public cCRUD()
	{
		try
		{
			string connectionString = "server = 138.68.140.83;user = Divya;password = Divyasree@1;database= dbDivya";
			connection = new MySqlConnection(connectionString);
			connection.Open();
		}
		catch(Exception e)
		{
			Console.WriteLine(e);
		}
	}

	public void CreateItem()
	{
		Console.Write("Enter Item Id: ");
		string ItemId = Console.ReadLine();
		Console.Write("Enter Item Name: ");
		string ItemName = Console.ReadLine();
		Console.Write("Enter Item Price: ");
		string ItemPrice = Console.ReadLine();
		Console.Write("Enter Item Quantity: ");
		string ItemQuantity = Console.ReadLine();
		string query =  String.Format("insert into Supermarket values('{0}', '{1}', '{2}', '{3}');", ItemId, ItemName, ItemPrice, ItemQuantity);
		MySqlCommand command = new MySqlCommand(query, connection);
		MySqlDataReader reader = command.ExecuteReader();


		reader.Close();
		//connection.Close();
	}

	public void ShowItems()
	{
		string query = "Select * from Supermarket";
		MySqlCommand command = new MySqlCommand(query, connection);
		MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);	
		DataTable table = new DataTable();
		dataAdapter.Fill(table);
		foreach(DataRow row in table.Rows)
		{
			Console.WriteLine("Item Id: " +row["ItemId"]);
			Console.WriteLine("Item Name: " +row["ItemName"]);
			Console.WriteLine("Item Price: " +row["ItemPrice"]);
			Console.WriteLine("Item Quantity: " +row["ItemQuantity"]);
			Console.WriteLine("__________________________________________________");
		}
	}

	public void SearchItem()
	{
		Console.Write("Enter the Item Id to Check: ");
		String ItemId = Console.ReadLine();
		string query = String.Format("Select * from Supermarket where ItemId ='" +ItemId+"';");
		MySqlCommand command = new MySqlCommand(query, connection);
		command.ExecuteNonQuery();
		// MySqlDataReader reader = command.ExecuteReader();
		// reader.Read();
		MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command);	
		DataTable table = new DataTable();
		dataAdapter.Fill(table);
		foreach(DataRow row in table.Rows)
		{
			Console.WriteLine("Item Id: " +row["ItemId"]);
			Console.WriteLine("Item Name: " +row["ItemName"]);
			Console.WriteLine("Item Price: " +row["ItemPrice"]);
			Console.WriteLine("Item Quantity: " +row["ItemQuantity"]);
			Console.WriteLine("__________________________________________________");
		}
		// reader.Close();
	}

	public void UpdateItem()
	{
		Console.Write("Enter the Item Id to check: ");
		String ItemId = Console.ReadLine();
		MySqlCommand command;
		MySqlDataReader reader;
		Console.WriteLine("1. Update Item Name\n2. Update Item Price\n3. Update Item Quantity");
		Console.WriteLine("Enter an option from the above list: ");
		int option = Convert.ToInt32(Console.ReadLine());
		switch(option)
		{
			case 1:
				Console.Write("Enter Updated Item Name:  ");
				string ItemName = Console.ReadLine();
				string query = String.Format("Update Supermarket set ItemName = '{0}'where ItemId = '{1}';",ItemName,ItemId);
				command = new MySqlCommand(query, connection);
				reader = command.ExecuteReader();
				Console.WriteLine("Name Updated Successfully!!");
				reader.Close();
				break;
			case 2: 
				Console.Write("Enter Updated Item Price: ");
				string ItemPrice = Console.ReadLine();
				string query1 = String.Format("Update Supermarket set ItemPrice = {0} where ItemId = {1};",ItemPrice,ItemId);
				command = new MySqlCommand(query1, connection);
				reader = command.ExecuteReader();
				Console.WriteLine("Price Updated Successfully!!");
				reader.Close();
				break;
			case 3:
				Console.Write("Enter the Updated Item Quantity: ");
				string ItemQuantity = Console.ReadLine();
				string query2 = String.Format("Update Supermarket set ItemQuantity = {0} where ItemId = {1};", ItemQuantity, ItemId);
				command = new MySqlCommand(query2, connection);
				reader = command.ExecuteReader();
				Console.WriteLine("Quantity Updated Successfully!!");
				reader.Close();
				break;
			case 4:
				Console.Write("Invalid Option!! Try again with a valid option");
				break;


		}

	}
	public void DeleteItem()
	{
		Console.Write("Enter the Item Id to check: ");
		String ItemId = Console.ReadLine();
		string query = String.Format("Delete from Supermarket where ItemId = '{0}';", ItemId);
		MySqlCommand command = new MySqlCommand(query, connection);
		MySqlDataReader reader = command.ExecuteReader();
		reader.Read();
		Console.Write("Item Deleted Successfully\n");
		reader.Close();
	}
}