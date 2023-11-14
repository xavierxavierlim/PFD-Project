using System.Configuration;
using System.Data.SqlClient;
using PFD_Project.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace PFD_Project.DAL
{
	public class TransactionsDAL
	{
		private IConfiguration Configuration { get; }
		private SqlConnection conn;

		//Constructor
		public TransactionsDAL()
		{
			//Read ConnectionString from appsettings.json file
			var builder = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json");
			Configuration = builder.Build();
			string strConn = Configuration.GetConnectionString(
			"PFDConnectionString");
			//Instantiate a SqlConnection object with the
			//Connection String read.
			conn = new SqlConnection(strConn);
		}
		public int addTransaction(Transactions transaction)
		{
			SqlCommand cmd = conn.CreateCommand();
			cmd.CommandText = @"INSERT INTO Transactions (UserID, TransactionType, Amount, TransactionDate) OUTPUT INSERTED.TransactionID VALUES (@UserID, @TransactionType, @Amount, @TransactionDate)";

			cmd.Parameters.AddWithValue("@UserID", transaction.UserID);
			cmd.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);
			cmd.Parameters.AddWithValue("@Amount", transaction.Amount);
			cmd.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);

			conn.Open();

			transaction.TransactionID = Convert.ToInt32(cmd.ExecuteScalar());
			conn.Close();
			return transaction.TransactionID;
		}
	}
}
