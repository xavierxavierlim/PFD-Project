using System.Drawing;
using System.Transactions;

namespace PFD_Project.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string AccountNo { get; set; }
        public string Name { get; set; }
        public string Pin { get; set; }
        public decimal Balance { get; set; }
    }
}
