using Classwork.Areas.AdminPanel.ViewModels;
using Classwork.DAL;
using Classwork.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Classwork.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            bool categories = await _context.Categories.AnyAsync(p => p.Name==category.Name);

            if(categories)
            {
                ModelState.AddModelError("Name","This category already exists");
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null || id == 0) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            if (category is null) return NotFound();

            category.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public  IActionResult Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();
            Category category = _context.Categories.FirstOrDefault(s => s.Id == id);
            if (category is null) return NotFound();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id,Category category)
        {
            if (id == null || id < 1) return BadRequest();

            Category exsistCategory =await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);
            if (exsistCategory is null) return NotFound();

            if (!ModelState.IsValid)
            {
                return View();
            }

            bool categories = await _context.Categories.AnyAsync(p=>p.Name == exsistCategory.Name && p.Id != id);
            if(categories)
            {
                ModelState.AddModelError(nameof(Category.Name), "Name already exsist");
                return View();
            }

            exsistCategory.Name = category.Name;

            _context.Categories.Update(exsistCategory);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Category exsistCategory = await _context.Categories.FirstOrDefaultAsync(s => s.Id == id);

            if (exsistCategory is null) return NotFound();

            return View(exsistCategory);
        }
    }
}
