﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMeds.Controllers
{
    public class DailyTaskController : Controller
    {
        public IActionResult Index()
        {
            return View("Profile");
        }

    }
}
