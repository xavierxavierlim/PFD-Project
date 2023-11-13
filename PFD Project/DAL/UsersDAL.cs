using System.Data.SqlClient;
using PFD_Project.Models;

namespace PFD_Project.DAL
{
    public class UsersDAL
    {
        private IConfiguration Configuration { get; set; }
        private SqlConnection conn;

        public UsersDAL()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            string strConn = Configuration.GetConnectionString("PFDConnectionString");

            conn = new SqlConnection(strConn);
        }

        public List<Users> GetAllUsers()
        {
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT * FROM Users ORDER BY UserID";
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            //Read all records until the end, save data into a staff list
            List<Users> userList = new List<Users>();
            while (reader.Read())
            {
                userList.Add(
                new Users
                {
                    UserID = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Pin = reader.GetString(2),
                    Balance = reader.GetDecimal(3),
                    Fingerprint = (byte[])reader.GetValue(4),
                }
                );
            }
            //Close DataReader
            reader.Close();
            //Close the database connection
            conn.Close();
            return userList;
        }

        public string GetUserName(string pin)
        {
            string username = null;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT Name FROM Users WHERE Pin = @pin";
            cmd.Parameters.AddWithValue("@pin", pin);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    username = reader.GetString(0);

                }
            }
            reader.Close();
            conn.Close();
            return username;
        }
    }
}

