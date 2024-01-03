using System.Configuration;
using System.Data.SqlClient;
using PFD_Project.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PFD_Project.DAL
{
    public class FeedbackDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;

        //Constructor
        public FeedbackDAL()
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

        public int addFeedbackStars(Feedback feedback)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Feedback (Rating, UserID) OUTPUT INSERTED.FeedbackID VALUES (@Rating, @UserID)";

            cmd.Parameters.AddWithValue("@Rating", feedback.Rating);
            cmd.Parameters.AddWithValue("@UserID", feedback.UserID);

            conn.Open();

            feedback.FeedbackID = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return feedback.FeedbackID;
        }

        public void addFeedbackDescription(int feedbackID, string description)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE Feedback SET Description = @Description WHERE FeedbackID = @FeedbackID";

            cmd.Parameters.AddWithValue("@Description", description);
            cmd.Parameters.AddWithValue("@FeedbackID", feedbackID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void addFeedbackSpecificDescription(int feedbackID, string specificDescription)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"UPDATE Feedback SET SpecificDescription = @SpecificDescription WHERE FeedbackID = @FeedbackID";

            cmd.Parameters.AddWithValue("@SpecificDescription", specificDescription);
            cmd.Parameters.AddWithValue("@FeedbackID", feedbackID);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}

