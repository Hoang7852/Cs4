
using Asm_Ph21208.Models;
using Asm_Ph21208.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asm_Ph21208.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ILogger<SanPhamController> _logger;

        public SanPhamController(ILogger<SanPhamController> logger)
        {
            _logger = logger;
        }

        public IActionResult ChiTiet(Guid id)
        {
            ShoppingDbContext db = new ShoppingDbContext();
            Product ketqua = db.Products.Find(id);
            return View(ketqua);
        }
        public IActionResult Product()
        {
            ShoppingDbContext db = new ShoppingDbContext();
            List<Product> ketqua =db.Products.ToList();
            return View(ketqua);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}