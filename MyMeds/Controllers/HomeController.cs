using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMeds.Data;
using MyMeds.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MyMeds.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Logon()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult LoginBtn(LogonModel model, string userId, string password)
        {
            var con = new SqlConnection(@"Data Source=.;Initial Catalog=MyMeds;Integrated Security=True;");
            if (userId == null || password == null) return View("Logon");
            var cmd = new SqlCommand("SELECT * FROM dbo.Logons WHERE UserId=@UserId and Password=@Password", con);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@Password", password);
            var sda = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            var i = cmd.ExecuteNonQuery();
            con.Close();

            return dt.Rows.Count > 0 ? View("Index", model) : View("Logon");
        }
    }
}
