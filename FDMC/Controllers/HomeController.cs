using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FDMC.Models;
using FDMC.Data;
using FDMC.ViewModel;

namespace FDMC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var cat = this._context.Cats.ToList();
            var cats = new CatViewModel
            {
                Cats = cat
            };
            
            return View(cats);
        }

     
    }
}
