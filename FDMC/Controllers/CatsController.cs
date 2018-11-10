using FDMC.Data;
using FDMC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDMC.Controllers
{
    public class CatsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CatsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Details(int id)
        {
            var cat = this._context.Cats.Where(c => c.Id == id)
                .FirstOrDefault();
            if (cat == null)
            {
                return this.NotFound();
            }

            return View(cat);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Cat model)
        {
            var cat = new Cat()
            {
                Age = model.Age,
                Breed = model.Breed,
                ImageUrl = model.ImageUrl,
                Name = model.Name
            };
            this._context.Add(cat);
            this._context.SaveChanges();
            return this.Redirect("/Cats/Details/" + cat.Id);
        }
    }
}
