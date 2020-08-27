﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ICSharpCode.AvalonEdit.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReplayFx.Models;

namespace ReplayFx.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Uploadfile([FromBody] string val)
        {
            Console.WriteLine(val);

            //File inputFile = new File("farrago.txt");
            //File outputFile = new File("outagain.txt");
            //FileReader in = new FileReader(inputFile);
            //FileWriter out = new FileWriter(outputFile);

            return View();
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
            return View(new Error { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}