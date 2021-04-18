using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BibliotecaMvc.Models;
using BibliotecaContextLib;

namespace BibliotecaMvc.Controllers
{
    public class HomeController : Controller
    {

        private Biblioteca db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, Biblioteca injectedContext)
        {
            _logger = logger;
            db = injectedContext;
        }

        public IActionResult Index()
        {
            var model = new TodayDate{
                daynow = DateTime.Now

            };

            return View(model);
        }

        public IActionResult Books(){

          var model = new BooksViewModel{
              Books = db.Books.ToList(),
              Authors = db.Authors.ToList()
              
          };

          return View(model);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
