using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyMeds.Data;
using MyMeds.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MyMeds.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<MedicationModel> myMedsList = new();

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
            const string procedure = "[SelectUser]";
            var values = new {UserId = userId, Password = password};
            con.Open();
            using var multi = con.QueryMultiple(procedure, values, commandType: CommandType.StoredProcedure);
            model = multi.Read<LogonModel>().Single();
            con.Close();

            const string procedure2 = "[SelectMedicine]";
            var value = new {LogonsId = model.Id};
            con.Open();
            var multi2 = con.Query(procedure2, value, commandType: CommandType.StoredProcedure).ToList();
            foreach (var record in multi2)
            {
                var medsModel = new MedicationModel();
                medsModel.LogonsId = record.LogonsId;
                medsModel.MedicationName = record.MedicationName;
                medsModel.TimeTaken = record.TimeTaken;
                medsModel.Directions = record.Directions;
                medsModel.Id = record.Id;
                medsModel.Prescriber = record.Prescriber;
                medsModel.Refills = record.Refills;
                myMedsList.Add(medsModel);
            }
            con.Close();

            dynamic loginModel = new ExpandoObject();
            loginModel.LogonModel = model;
            loginModel.Medication = myMedsList;
     
            SetAuthCookie(userId);
            ViewBag.Name = model.UserId;

            return model.Id != 0 ? View("Index", loginModel) : View("Logon");
        }

        private async void SetAuthCookie(string userId)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userId),
                new Claim(ClaimTypes.Role, "User")
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.LocalDateTime.AddMinutes(15),
                IsPersistent = true,
                IssuedUtc = DateTimeOffset.UtcNow.LocalDateTime
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}
