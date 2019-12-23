using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.UI.Authorization;
using static WebApplication1.Helpers.Enums;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AuthorizeUser]
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            EcommerceCtx db = new EcommerceCtx();
            ViewBag.Products = db.Products.Select(n => new ProductListModel
            {
                Id = n.Id,
                Name = n.Name,
                Image = n.Image,
                Category = n.CategoryName,
                Date = n.CreateDate.Value,
                Price = n.Price.Value
            }).ToList();

            return View();
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(int Id, string Name, string Image, decimal Price, string CategoryName)
        {
            EcommerceCtx db = new EcommerceCtx();
            Products post = new Products
            {
                Name = Name,
                Image = Image,
                Price = Price,
                CategoryName = CategoryName,
                CreateDate = DateTime.Now
            };

            db.Products.Add(post);
            db.SaveChanges();

            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            EcommerceCtx db = new EcommerceCtx();
            Products post = db.Products.FirstOrDefault(n => n.Id == Id);

            return View(post);
        }

        [HttpPost]
        public IActionResult Edit(int Id, string Name, string Image, decimal Price, string CategoryName)
        {
            EcommerceCtx db = new EcommerceCtx();
            Products product = db.Products.FirstOrDefault(n => n.Id == Id);
            product.Name = Name;
            product.Image = Image;
            product.Price = Price;
            product.CategoryName = CategoryName;

            db.Products.Update(product);
            db.SaveChanges();

            return Redirect("/Admin/Products");
        }

        public IActionResult Delete(int Id)
        {
            EcommerceCtx db = new EcommerceCtx();
            Products post = db.Products.FirstOrDefault(n => n.Id == Id);
            db.Products.Remove(post);
            db.SaveChanges();

            return Redirect("/Admin/Products");
        }

    }
}