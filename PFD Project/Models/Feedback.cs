namespace PFD_Project.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int Rating { get; set; }
        public string? Description { get; set; }
        public int UserID { get; set; }
    }
}
