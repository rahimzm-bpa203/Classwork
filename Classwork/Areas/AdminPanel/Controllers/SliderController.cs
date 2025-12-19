using Classwork.DAL;
using Classwork.Models;
using Classwork.Utilities.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Classwork.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Slider> sliders = _context.Sliders.ToList();

            return View(sliders);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if(!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is incorrect");
                return View();
            }

            slider.ImageUrl = await slider.Photo.CreateFileAsync(_env.WebRootPath, "img");
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");


        }
    }
}
