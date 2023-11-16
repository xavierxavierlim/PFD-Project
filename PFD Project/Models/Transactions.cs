using System.ComponentModel.DataAnnotations;

namespace PFD_Project.Models
{
	public class Transactions
	{
		public int TransactionID { get; set; }
		public int UserID { get; set; }

		[Display(Name="Transaction Type")]
		public string? TransactionType { get; set; }

		public decimal Amount { get; set; }

		[Display(Name = "Transaction Date")]
		public DateTime? TransactionDate { get; set; }
	}
}
