using Classwork.DAL;
using Classwork.Models;
using Classwork.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Classwork.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.OrderBy(s=>s.Order).ToList();

            List<Product> products = _context.Products.ToList();

            HomeVM homeVM = new HomeVM
            {
                Sliders=sliders,
                Products= products
            };

            return View(homeVM);
        }

        public IActionResult Detail(int? id)
        {
            Product? product = _context.Products.Include(p=>p.Categories).FirstOrDefault(p => p.Id == id);

            List<Product> products = _context.Products.Include(p=>p.Categories).ToList();

            DetailVM detailVM = new DetailVM
            {
                RelatedProducts = product,
                Products = products

            };


            return View(detailVM);
        }
    }
}
