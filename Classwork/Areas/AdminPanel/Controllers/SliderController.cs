using Classwork.DAL;
using Classwork.Models;
using Classwork.Utilities.Extentions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "File type is incorrect");
                return View();
            }

            slider.ImageUrl = await slider.Photo.CreateFileAsync(_env.WebRootPath, "img");

            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider is null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {
            if (id == null || id < 1) return BadRequest();
            Slider exsistSlider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (exsistSlider is null) return NotFound();

            if(!ModelState.IsValid)
            {
                return View(exsistSlider);
            }

            if (slider.Photo != null)
            {
                if (!slider.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "File type is incorrect");
                    return View();
                }
                exsistSlider.ImageUrl.FileDeleteAsync(_env.WebRootPath, "img");
                exsistSlider.ImageUrl = await slider.Photo.CreateFileAsync(_env.WebRootPath, "img");

            }
            exsistSlider.Order = slider.Order;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Delete (int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
            if (slider is null) return NotFound();

            slider.ImageUrl.FileDeleteAsync(_env.WebRootPath, "img");
            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");

        }




    }
}
