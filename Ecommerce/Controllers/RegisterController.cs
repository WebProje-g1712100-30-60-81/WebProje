using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using static WebApplication1.Helpers.Enums;

namespace WebApplication1.Controllers
{
    public class RegisterController : Controller
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
                bool alreadyRegister = db.Users.Where(n => n.Email == Email).Any();
                if(alreadyRegister)
                {
                    ModelState.AddModelError("hata", "Kullanıcı Zaten Kayıtlı");
                    return View();
                }

                Users newUser = new Users();
                newUser.Name = Name;
                newUser.Lastname = Surname;
                newUser.Email = Email;
                newUser.Password = Password;
                db.Users.Add(newUser);
                db.SaveChanges();

                Roles role = new Roles
                {
                     UserId = newUser.Id,
                     RoleId = (int)UserRole.User
                };
                db.Roles.Add(role);
                db.SaveChanges();

                HttpContext.Session.SetInt32("UserID", newUser.Id);
                HttpContext.Session.SetInt32("UserRole", role.RoleId.Value);
                HttpContext.Session.SetString("UserEmail", newUser.Email);

                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            return View();
        }
    }
}