
using Asm_Ph21208.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Asm_Ph21208.Controllers
{
    public class TaiKhoanController : Controller
    {
        private readonly ILogger<TaiKhoanController> _logger;

        public TaiKhoanController(ILogger<TaiKhoanController> logger)
        {
            _logger = logger;
        }
        //=======

       

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string userName,string passWord)
        {
            ShoppingDbContext db = new ShoppingDbContext();
            var listUser = db.Users.ToList();
            var user = listUser.FirstOrDefault(x=>x.Username == userName && x.Password == passWord);
            if (userName=="admin"&&passWord=="admin")
            {
                return RedirectToAction("Index", "HomeAdmin1");
            }
            if (user == null)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại hoặc kí tự nhập phải hơn 6");
                return View();
            }
            else
            {
                HttpContext.Session.SetString("idUser",user.Id.ToString()); // đưa  id của user vào session 
                Guid id = new Guid(HttpContext.Session.GetString("idUser")); // lấy ra rồi ép kiểu = guid
                return RedirectToAction("ShowGioHang","GioHang");
            }
        }
        [Route("TaiKhoan/AddUser")]
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser( User user)
        {
            ShoppingDbContext db = new ShoppingDbContext();
            db.Users.Add(user);
            db.SaveChanges();
            Cart cart = new Cart();
            cart.UserId = user.Id;
            cart.Description = "";
            db.Carts.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Login");
        }
        private bool IsValidUsername(string username)
{
    if (string.IsNullOrEmpty(username))
    {
        return false;
    }

    if (username.Length < 6)
    {
        return false;
    }

    foreach (char c in username)
    {
        if (!char.IsLetterOrDigit(c))
        {
            return false;
        }
    }

    return true;
}

private bool IsValidPassword(string password)
{
    if (string.IsNullOrEmpty(password))
    {
        return false;
    }

    if (password.Length < 6)
    {
        return false;
    }

    foreach (char c in password)
    {
        if (!char.IsLetterOrDigit(c))
        {
            return false;
        }
    }

    return true;
}
        public IActionResult Login1(string userName1,string passWord1)
        {
            ShoppingDbContext db = new ShoppingDbContext();
            var listUser = db.Users.ToList();
            var user = listUser.FirstOrDefault(x => x.Username == userName1 && x.Password == passWord1 && userName1.Length > 6 && passWord1.Length > 6);
            
                if (userName1 == "admin" && passWord1 == "admin")
            {
                return RedirectToAction("Index", "HomeAdmin1");
            }
            if (user == null)
            {
                ModelState.AddModelError("", "Tài khoản không tồn tại");
                return View();
            }
            else
            {
                HttpContext.Session.SetString("idUser", user.Id.ToString()); // đưa  id của user vào session 
                Guid id = new Guid(HttpContext.Session.GetString("idUser")); // lấy ra rồi ép kiểu = guid
                return RedirectToAction("ShowGioHang", "GioHang");
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}