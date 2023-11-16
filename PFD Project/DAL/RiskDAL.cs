using System.Configuration;
using System.Data.SqlClient;
using PFD_Project.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Transactions;
using System.Data.Common;
namespace PFD_Project.DAL
{
    public class RiskDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;
        public RiskDAL()
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
        public void addRisk(int id)
        {
            string currentdatetime = DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day +
               " " + DateTime.Now.Hour + (":") + DateTime.Now.Minute + (":") + DateTime.Now.Second;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"INSERT INTO Risks (RiskType, ReportedDateTime, UserID) OUTPUT INSERTED.RiskID VALUES(@rt, @dt, @uid)";
            cmd.Parameters.AddWithValue("@rt", "Possible Shoulder Surfing");
            cmd.Parameters.AddWithValue("@dt", currentdatetime);
            cmd.Parameters.AddWithValue("@uid", Convert.ToString(id));
            conn.Open();

            cmd.ExecuteScalar();
            conn.Close();
        }
    }
}
