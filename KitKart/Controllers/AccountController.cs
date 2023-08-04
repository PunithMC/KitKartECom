using KitKart.Context;
using KitKart.Models;
using KitKart.ViewModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Humanizer;

namespace KitKart.Controllers
{
    public class AccountController : Controller
    {
        private KartContext _context;
        public AccountController()
        {
            _context = new KartContext();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Users user)
        {
            if (!ModelState.IsValid)
            {
                return View("Register", user);
            }

            if(_context.users.Where(u=>u.email == user.email || u.username == user.username).Any())
            {
                ModelState.AddModelError("email","UserEmail or UserName Already Exists");
                return View("Register", user);
            }

            _context.users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View("Login", user);
            }

            var loginUser = _context.users.Where(u => u.email == user.email && u.password == user.password && u.isActive == true).FirstOrDefault();

            if(loginUser == null)
            {
                ModelState.AddModelError("email", "email or passwor is Incorrect!...");
                return View("Login", user);
            }
            else
            {
                //Session["email"] = loginUser.username;
                HttpContext.Session.SetString("email", loginUser.email);
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("email");
            return RedirectToAction("Index", "Home");
        }
    }
}
