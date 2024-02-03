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

        public List<Feedback> GetAllFeedback()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT * FROM FdbkDescription WHERE InUse = 1";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Feedback> feedbackList = new List<Feedback>();
            while (reader.Read())
            {
                feedbackList.Add(
                new Feedback
                {
                    DescID = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    InUse = reader.GetString(2)[0]
                }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return feedbackList;
        }

        public List<Feedback> GetSubFeedbackByDescID(int DescID)
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT * FROM FdbkSubDesc WHERE DescID = @DescID";
            cmd.Parameters.AddWithValue("@DescID", DescID);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Feedback> subFeedbackList = new List<Feedback>();
            while (reader.Read())
            {
                subFeedbackList.Add(
                new Feedback
                {
                    SubID = reader.GetInt32(0),
                    SubDescription = reader.GetString(1),
                    DescID = reader.GetInt32(2)
                }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return subFeedbackList;
        }
    }
}

