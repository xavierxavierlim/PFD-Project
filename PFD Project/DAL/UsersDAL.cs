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
                    AccountNo = reader.GetString(1),
                    Name = reader.GetString(2),
                    Pin = reader.GetString(3),
                    Balance = reader.GetDecimal(4),
                    PhoneNo = reader.GetString(5)
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

        public int GetUserID(string pin)
        {
            int userID = 0;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT UserID FROM Users WHERE Pin = @pin";
            cmd.Parameters.AddWithValue("@pin", pin);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userID = reader.GetInt32(0);
                }
            }
            reader.Close();
            conn.Close();
            return userID;
        }

        public string GetPin(string accountNo)
        {
            string pin = null;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT Pin FROM Users WHERE AccountNo = @accountNo";
            cmd.Parameters.AddWithValue("@accountNo", accountNo);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    pin = reader.GetString(0);
                }
            }
            reader.Close();
            conn.Close();
            return pin;
        }

        public string GetUserNameByAccountNo(string accountNo)
        {
            string name = null;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT Name FROM Users WHERE AccountNo = @accountNo";
            cmd.Parameters.AddWithValue("@accountNo", accountNo);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = reader.GetString(0);
                }
            }
            reader.Close();
            conn.Close();
            return name;
        }

        public int GetUserIDByAccountNo(string accountNo)
        {
            int UserID = 0;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT UserID FROM Users WHERE AccountNo = @accountNo";
            cmd.Parameters.AddWithValue("@accountNo", accountNo);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    UserID = reader.GetInt32(0);
                }
            }
            reader.Close();
            conn.Close();
            return UserID;
        }

        public decimal GetBalanceByAccountNo(string accountNo)
        {
            decimal balance = 0;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT Balance FROM Users WHERE AccountNo = @accountNo";
            cmd.Parameters.AddWithValue("@accountNo", accountNo);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    balance = reader.GetDecimal(0);
                }
            }
            reader.Close();
            conn.Close();
            return balance;
        }

        public Users GetUsersByUserID(int userID)
        {
            Users user = null;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"SELECT * FROM Users WHERE UserID = @userID";
            cmd.Parameters.AddWithValue("@userID", userID);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                user = new Users
                {
                    UserID = reader.GetInt32(0),
                    AccountNo = reader.GetString(1),
                    Name = reader.GetString(2),
                    Pin = reader.GetString(3),
                    Balance = reader.GetDecimal(4),
                    PhoneNo = reader.GetString(5)
                };
            }
            reader.Close();
            conn.Close();
            return user;
        }

        public void UpdateBalance(decimal balance, int userID)
        {
            Users user = null;
            //Create a SqlCommand object from connection object
            SqlCommand cmd = conn.CreateCommand();
            //Specify the SELECT SQL statement 
            cmd.CommandText = @"UPDATE Users SET Balance = @balance WHERE UserID = @userID";
            cmd.Parameters.AddWithValue("@balance", balance);
            cmd.Parameters.AddWithValue("@userID", userID);
            //Open a database connection
            conn.Open();
            //Execute the SELECT SQL through a DataReader
            cmd.ExecuteNonQuery();
            cmd.ExecuteScalar();
            conn.Close();
        }


    }
}

