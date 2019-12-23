using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.UI.Authorization;
using static WebApplication1.Helpers.Enums;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeUser(UserRole.Admin)]
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            EcommerceCtx db = new EcommerceCtx();
            ViewBag.Users = db.Users.ToList();

            return View();
        }

        public IActionResult Delete(int Id)
        {
            EcommerceCtx db = new EcommerceCtx();
            Users user = db.Users.FirstOrDefault(n => n.Id == Id);
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}