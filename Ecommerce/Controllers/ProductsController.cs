    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index(int id)
        {
            EcommerceCtx db = new EcommerceCtx();
            ProductListModel product = db.Products.Where(n => n.Id == id).Select(n => new ProductListModel
            {
                Id = n.Id,
                Name = n.Name,
                Image = n.Image,
                Category = n.CategoryName,
                Date = n.CreateDate.Value,
                Price = n.Price.Value
            }).FirstOrDefault();


            return View(product);
        }
    }
}