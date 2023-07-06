
using Asm_Ph21208.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asm_Ph21208.Controllers
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
            ShoppingDbContext db = new ShoppingDbContext();
            List<Product> ketqua = db.Products.ToList();
            return View(ketqua);
        }
        public IActionResult Contact()
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