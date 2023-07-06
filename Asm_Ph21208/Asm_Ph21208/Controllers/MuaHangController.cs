using Microsoft.AspNetCore.Mvc;
using Asm_Ph21208.Models;

namespace Asm_Ph21208.Controllers
{
    public class MuaHangController : Controller
    {
        public IActionResult Index()
        {
            ShoppingDbContext db = new ShoppingDbContext();
            var products = db.Products.ToList();
            return View(products);
        }
        [HttpPost]
        public IActionResult ThanhToan()
        {
            return View();
        }
        public IActionResult MuaHang()
        {
            ShoppingDbContext db = new ShoppingDbContext();
            // Xử lý thanh toán thành công

            // Lấy danh sách sản phẩm được mua từ bảng CartDetail
            var cartDetails = db.CartDetails.ToList();

            foreach (var detail in cartDetails)
            {
                // Trừ số lượng sản phẩm đã mua khỏi bảng Product
                var product = db.Products.Find(detail.IdSP);
                product.AvailableQuantity -= detail.Quantity;

                // Xóa bản ghi sản phẩm đã mua trong bảng CartDetail
                db.CartDetails.Remove(detail);
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            db.SaveChanges();

            return RedirectToAction("ShowGioHang", "GioHang");
        }
    
    }
}
