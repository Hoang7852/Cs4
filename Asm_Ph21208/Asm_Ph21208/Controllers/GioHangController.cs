
using Asm_Ph21208.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asm_Ph21208.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ILogger<GioHangController> _logger;

        public GioHangController(ILogger<GioHangController> logger)
        {
            _logger = logger;
        }

        public IActionResult ShowGioHang()
        {

            ShoppingDbContext db = new ShoppingDbContext();
            List<CartDetails> ketqua = db.CartDetails.ToList();
            return View(ketqua);
        }
        public IActionResult AddToCart(Guid id, int soLuong)
        {
            //if (!IsUserLoggedIn)
            //{
            //    return RedirectToAction("Login", "TaiKhoan");
            //}
            ShoppingDbContext db = new ShoppingDbContext();
            // Lấy thông tin sản phẩm từ CSDL
            var product = db.Products.Find(id);
            Guid idus = new Guid(HttpContext.Session.GetString("idUser"));
            var existingItem = db.CartDetails.FirstOrDefault(item => item.IdSP == id && item.UserId == idus);

            if (existingItem != null)
            {
                // Sản phẩm đã có trong giỏ hàng, tăng số lượng sản phẩm lên
                existingItem.Quantity += soLuong;
            }
            else
            {

                // Tạo đối tượng CartItem tương ứng
                var item = new CartDetails
                {
                    IdSP = id,
                    UserId = idus,
                    Quantity = soLuong,
                };

                db.CartDetails.Add(item);
            }
                db.SaveChanges();

                // Chuyển hướng đến trang giỏ hàng
                return RedirectToAction("ShowGioHang");
            }
        public IActionResult XoaGioHang(Guid id)
        {
            ShoppingDbContext db = new ShoppingDbContext();
            var gh = db.CartDetails.Find(id);
            db.CartDetails.Remove(gh);
            db.SaveChanges();
            return RedirectToAction("ShowGioHang");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}