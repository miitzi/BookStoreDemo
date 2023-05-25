using BookStoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreDemo.Controllers
{
    public class CategoryController : Controller
    {

        Context context;
        public CategoryController()
        {
            context = new Context();

        }

        public IActionResult Index()
        {
            return View(context.Categories);
        }


        public IActionResult AddCategory() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            try
            {
                context.SaveChanges();
                return RedirectToAction("index", "Category");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = "An error occurred while adding the Category: " + ex.Message;
            }
            return RedirectToAction("AddCategory", "Category");
        }

        public IActionResult EditCategory(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            context.Categories.Update(category);
            try
            {
                context.SaveChanges();
                return RedirectToAction("index", "category");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = "Error: " + ex.Message;
            }

            return View();

        }

        public IActionResult Details(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        public IActionResult Delete(int id) 
        {

            var category = context.Categories.Find(id);
            if (category == null) 
            {
                return NotFound();
            }


            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {

           context.Categories.Remove(category);
            try
            {
                context.SaveChanges();
                return RedirectToAction("index","category");
            }
            catch (Exception ex)
            {

                ViewBag.errorMessage = "Error: " + ex.Message;
            }

            return View();
        }


    }
}
