using Mecty.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mecty.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TaskFirst()
        {
            return View();
        }
        public IActionResult TaskSecond()
        {
            return View();
        }
        public IActionResult TaskThird()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskFirst(string Predlozhenie)
        {
            int i = 0;
            foreach (char a in Predlozhenie)
            {
                if (a == ' ')
                {
                    i++;
                }
            }
            ViewBag.Probely = i;
            return View();
        }
        [HttpPost]
        public IActionResult TaskSecond(string CisloN)
        {
            double Otvet = 0;
            double j = 1;
            int k = -1;
            try
            {
                for (int i = 1; i <= Convert.ToInt32(CisloN); i++)
                {
                    j = j + 0.1;
                    k = -k;
                    Otvet = Otvet + j * k;
                }
                ViewBag.Vyrazhenie = Math.Round(Otvet, 2);
            }
            catch (Exception)
            {
                ViewBag.Vyrazhenie = "Ввёл не число, алло";
            }

            return View();
        }
        [HttpPost]
        public IActionResult TaskThird(string Slovo)
        {
            if (Slovo == null || Slovo.Length < 2)
            {
                ViewBag.Proveril = "чего-то не то ты ввёл";
            }
            else
            {
                Slovo = Slovo.ToLower();
                string PervaBukovka = Slovo.Substring(Slovo.Length - 1);
                string PoslednaBukovka = Slovo.Substring(0, 1);
                if (PervaBukovka == PoslednaBukovka)
                {
                    ViewBag.Proveril = "Так точно";
                }
                else
                {
                    ViewBag.Proveril = "Неть";
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
