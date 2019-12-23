using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Name, string Surname, string Email, string Password)
        {
            if (ModelState.IsValid)
            {
                EcommerceCtx db = new EcommerceCtx();
                Users hasUser = db.Users.Include(n => n.Roles).Where(n => n.Email == Email && n.Password == Password).FirstOrDefault();
                if (hasUser != null)
                {
                    HttpContext.Session.SetInt32("UserID", hasUser.Id);
                    HttpContext.Session.SetInt32("UserRole", hasUser.Roles.FirstOrDefault().RoleId.Value);
                    HttpContext.Session.SetString("UserEmail", hasUser.Email);
                    return Redirect("/Admin");
                }
                else
                {
                    ModelState.AddModelError("hata", "Kullanıcı Bulunamadı");
                    return View();
                }
            }
            return View();
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}