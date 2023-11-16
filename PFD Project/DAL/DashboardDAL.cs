using System.Configuration;
using System.Data.SqlClient;
using PFD_Project.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
namespace PFD_Project.DAL
{
    public class DashboardDAL
    {
        private IConfiguration Configuration { get; }
        private SqlConnection conn;

        public DashboardDAL()
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
        public FeedbackCountData getFeedback()
        {
            FeedbackCountData newData = new FeedbackCountData();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT SUM(CASE WHEN Description is null THEN 1 ELSE 0 END) AS 'Null',SUM(CASE WHEN Description = 'Slow Transaction Processing' THEN 1 ELSE 0 END) AS 'Slow Transaction Processing',SUM(CASE WHEN Description = 'Difficulty Using ATM' THEN 1 ELSE 0 END) AS 'Difficulty Using ATM',SUM(CASE WHEN Description = 'Display Uninteractive' THEN 1 ELSE 0 END) AS 'Display Uninteractive',SUM(CASE WHEN Description = 'Inadequate Lighting' THEN 1 ELSE 0 END) AS 'Inadequate Lighting',SUM(CASE WHEN Description = 'Transaction Errors' THEN 1 ELSE 0 END) AS 'Transaction Errors',SUM(CASE WHEN Description = 'Accessibility Issues' THEN 1 ELSE 0 END) AS 'Accessibility Issues',SUM(CASE WHEN Description = 'Security Issues' THEN 1 ELSE 0 END) AS 'Security Issues',SUM(CASE WHEN Description = 'Hygiene Issues' THEN 1 ELSE 0 END) AS 'Hygiene Issues' FROM Feedback;";
            DataTable dt = new DataTable();
            SqlDataAdapter cmd1 = new SqlDataAdapter(cmd);
            cmd1.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                newData.data1 = "0";
                newData.data2 = "0";
                newData.data3 = "0";
                newData.data4 = "0";
                newData.data5 = "0";
                newData.data6 = "0";
                newData.data7 = "0";
                newData.data8 = "0";
                newData.data9 = "0";
            }
            else
            {
                newData.data1 = dt.Rows[0]["Null"].ToString();
                newData.data2 = dt.Rows[0]["Slow Transaction Processing"].ToString();
                newData.data3 = dt.Rows[0]["Difficulty Using ATM"].ToString();
                newData.data4 = dt.Rows[0]["Display Uninteractive"].ToString();
                newData.data5 = dt.Rows[0]["Inadequate Lighting"].ToString();
                newData.data6 = dt.Rows[0]["Transaction Errors"].ToString();
                newData.data7 = dt.Rows[0]["Accessibility Issues"].ToString();
                newData.data8 = dt.Rows[0]["Security Issues"].ToString();
                newData.data9 = dt.Rows[0]["Hygiene Issues"].ToString();
            }
            return (newData);
        }
        public SatCountData getSatisfaction()
        {
            SatCountData newData = new SatCountData();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = @"SELECT SUM(CASE WHEN Rating = 1 THEN 1 ELSE 0 END) As 'One', SUM(CASE WHEN Rating = 2 THEN 1 ELSE 0 END) As 'Two', SUM(CASE WHEN Rating = 3 THEN 1 ELSE 0 END) As 'Three', SUM(CASE WHEN Rating = 4 THEN 1 ELSE 0 END) As 'Four', SUM(CASE WHEN Rating = 5 THEN 1 ELSE 0 END) As 'Five' FROM Feedback;";
            DataTable dt = new DataTable();
            SqlDataAdapter cmd1 = new SqlDataAdapter(cmd);
            cmd1.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                newData.data1 = 0;
                newData.data2 = 0;
                newData.data3 = 0;
                newData.data4 = 0;
                newData.data5 = 0;
            }
            else
            {
                newData.data1 = Convert.ToInt32(dt.Rows[0]["One"]);
                newData.data2 = Convert.ToInt32(dt.Rows[0]["Two"]);
                newData.data3 = Convert.ToInt32(dt.Rows[0]["Three"]);
                newData.data4 = Convert.ToInt32(dt.Rows[0]["Four"]);
                newData.data5 = Convert.ToInt32(dt.Rows[0]["Five"]);
            }

            return (newData);
        }
    }
}
