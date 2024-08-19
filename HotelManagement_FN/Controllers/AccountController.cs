using HotelManagement_FN.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement_FN.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // POST: Account/Login
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tìm kiếm người dùng với tên đăng nhập và mật khẩu trong danh sách
                var user = RegisteredUsers.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);
                if (user != null)
                {
                    // Lưu tên người dùng vào TempData
                    TempData["Username"] = user.Username;

                    // Chuyển hướng đến trang chính nếu đăng nhập thành công
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid login attempt.";
                }
            }

            return View(model);
        }


        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        //tạo một biến tĩnh để lưu danh sách người dùng
        public static List<RegisterViewModel> RegisteredUsers = new List<RegisterViewModel>();
        
        // POST: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem username đã tồn tại chưa
                var existingUser = RegisteredUsers.FirstOrDefault(u => u.Username == model.Username);
                if (existingUser == null)
                {
                    // Thêm người dùng mới vào danh sách
                    RegisteredUsers.Add(model);
                    // Chuyển hướng đến trang đăng nhập sau khi đăng ký thành công
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.ErrorMessage = "Username already exists.";
                }
            }

            return View(model);
        }

        public ActionResult Logout()
        {
            TempData.Clear(); // Xóa toàn bộ bộ nhớ tạm
            return RedirectToAction("Login", "Account");
        }

        // Action để phục vụ view EditUserInfo.cshtml
        [HttpGet]
        public IActionResult EditUserInfo()
        {
            return View(); // Mặc định sẽ trả về View "EditUserInfo.cshtml" trong thư mục "Views/Account"
        }

    }
}
