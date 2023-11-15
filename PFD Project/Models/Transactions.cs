using System.ComponentModel.DataAnnotations;

namespace PFD_Project.Models
{
	public class Transactions
	{
		public int TransactionID { get; set; }
		public int UserID { get; set; }
		public string? TransactionType { get; set; }
		public decimal Amount { get; set; }
		public DateTime? TransactionDate { get; set; }
	}
}
