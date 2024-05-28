using LearningManagement.Areas.Admin.Models;
using LearningManagement.Data;
using LearningManagement.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Project_Amado.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        public AppDbContext _dbContext;

        public CategoryController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var categories = _dbContext.Categories.ToList();

            var model = new CategoryIndexVM
            {
                Categories = categories
            };
            return View(model);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(CategoryAddVM model)
        {
            if (!ModelState.IsValid) return NotFound();

            var categories = _dbContext.Categories.ToList();
            foreach(var category in categories)
            {
                if(model.Category == category.Name)
                {
                    model.ErrorMessage = "Category is already exists!";
                    return View(model);
                }
            }

            var newCategory = new Category
            {
                Name = model.Category,
            };

            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public ActionResult Edit(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return View();

            var model = new CategoryAddVM
            {
                Category = category.Name
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, CategoryAddVM editedCategory)
        {
            if (!ModelState.IsValid) return NotFound();

            if (id != editedCategory.Id) return BadRequest();

            var category = _dbContext.Categories.FirstOrDefault(x => x.Id == id);

            if (category is null) return NotFound();

            bool duplicate = _dbContext.Categories.Any(c => c.Name == editedCategory.Category && editedCategory.Category != category.Name);
            if (duplicate)
            {
                editedCategory.ErrorMessage = "You cannot duplicate category name";
                return View(editedCategory);
            }
            category.Name = editedCategory.Category;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            var foundCategory = _dbContext.Categories.FirstOrDefault(c => c.Id == id);
            if (foundCategory is null)  return NotFound(); 
            
            _dbContext.Categories.Remove(foundCategory);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
