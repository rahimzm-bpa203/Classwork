using Classwork.Areas.AdminPanel.ViewModels;
using Classwork.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Classwork.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context ,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<GetProductVM> getProductVMs =  await _context.Products.Include(p=>p.Categories)
                .Select(p=> new GetProductVM
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryNames = p.Categories.Select(c => c.Name).ToList()
                }
                ).ToListAsync();


            return View(getProductVMs);
        }
    }
}
