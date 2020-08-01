using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReplayFx.Models;

namespace ReplayFx.Controllers
{
    public class example : Controller
    {
        private readonly ILogger<example> _logger;

        public example(ILogger<example> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return base.View(new Models.example { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
