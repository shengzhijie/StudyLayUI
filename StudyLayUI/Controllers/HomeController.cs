using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudyLayUI.Models;

namespace StudyLayUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _environment;

        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetInitData()
        {
            var jsonPath=Path.Combine(_environment.WebRootPath, @"lib\layui\getList.json");
            var str = await System.IO.File.ReadAllTextAsync(jsonPath);
            return Content(str);
        }

        public async Task<IActionResult> GetMembers()
        {
            var jsonPath = Path.Combine(_environment.WebRootPath, @"lib\layui\getMembers.json");
            var str = await System.IO.File.ReadAllTextAsync(jsonPath);
            return Content(str);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            return Json(new object());
        }
    }
}
