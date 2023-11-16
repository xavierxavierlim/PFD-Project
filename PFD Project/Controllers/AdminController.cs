using Microsoft.AspNetCore.Mvc;
using PFD_Project.Models;
using System.Diagnostics;
using PFD_Project.DAL;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Web.Helpers;
using System.Data;

namespace PFD_Project.Controllers
{
    public class AdminController : Controller
    {
        private DashboardDAL dashboardContext = new DashboardDAL();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FeedbackBarChart()
        {
            FeedbackCountData newData = dashboardContext.getFeedback();
            return View(newData);
        }
        public ActionResult SatisfactionPieChart()
        {
            SatCountData newData = dashboardContext.getSatisfaction();
            return View(newData);
        }
    }
}
