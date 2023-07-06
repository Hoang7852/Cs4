using Microsoft.AspNetCore.Mvc;
using Asm_Ph21208.Models;

namespace Asm_Ph21208.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        [Area("Admin")]
        [HttpGet]
        public IActionResult Index()
        {
            ShoppingDbContext db = new ShoppingDbContext();
            var Product=db.Products.ToList();
            return View(Product);
        }
        public IActionResult ThemMoi()
        {
            return  View("~/Areas/Admin/Views/HomeAdmin/ThemMoi.cshtml");
        }
        [HttpPost]
        public IActionResult ThemMoi(Product sanPham, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imageFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                imageFile.CopyTo(stream);
                sanPham.img = imageFile.FileName;
            }

            ShoppingDbContext db = new ShoppingDbContext();

            // Kiểm tra trùng lặp
            var existingProduct = db.Products.FirstOrDefault(p => p.Name == sanPham.Name && p.Supplier == sanPham.Supplier);
            if (existingProduct != null)
            {
                ModelState.AddModelError("", "Sản phẩm đã tồn tại trong hệ thống.");
                return View("~/Areas/Admin/Views/HomeAdmin/ThemMoi.cshtml", sanPham);
            }

            db.Products.Add(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Xoa(Guid id)
        {
            ShoppingDbContext db = new ShoppingDbContext();
            var sp = db.Products.Find(id);
            db.Products.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
        }

        public IActionResult CapNhap(Guid id)
        {
            ShoppingDbContext db = new ShoppingDbContext();
            var sanPhamModel = db.Products.Find(id);
            return View("~/Areas/Admin/Views/HomeAdmin/CapNhap.cshtml",sanPhamModel);
        }
        [HttpPost]
        public IActionResult CapNhap(Product sanPham)
        {
            ShoppingDbContext db = new ShoppingDbContext();

            // Kiểm tra trùng lặp
            var existingProduct = db.Products.FirstOrDefault(p => p.Name == sanPham.Name && p.Supplier == sanPham.Supplier && p.ID != sanPham.ID);
            if (existingProduct != null)
            {
                ModelState.AddModelError("", "Sản phẩm đã tồn tại trong hệ thống.");
                return View("~/Areas/Admin/Views/HomeAdmin/CapNhap.cshtml", sanPham);
            }

            var udtSanPham = db.Products.Find(sanPham.ID);
            udtSanPham.Name = sanPham.Name;
            udtSanPham.Price = sanPham.Price;
            udtSanPham.AvailableQuantity = sanPham.AvailableQuantity;
            udtSanPham.Status = sanPham.Status;
            udtSanPham.img = sanPham.img;
            udtSanPham.Supplier = sanPham.Supplier;
            udtSanPham.Description = sanPham.Description;
            var id = db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
