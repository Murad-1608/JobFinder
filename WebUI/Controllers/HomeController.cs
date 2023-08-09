﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Constants;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Header.Name = "JobFinder";
            return View();
        }
    }
}