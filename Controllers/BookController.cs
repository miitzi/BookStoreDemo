using BookStoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace BookStoreDemo.Controllers
{
    public class BookController : Controller
    {
        Context context;
        public BookController()
        {
            context = new Context();

        }
        public IActionResult Index()
        {
            var books = context.Books.Include(b => b.Category).ToList();
            return View(books);
        }

        public IActionResult AddBook()
        {
            var categories = context.Categories.ToList();

            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName");

            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            context.Books.Add(book);
            try
            {
                context.SaveChanges();
                return RedirectToAction("index", "Book");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = "An error occurred while adding the Book: " + ex.Message;
            }
            return RedirectToAction("AddBook", "Book");
        }


        public IActionResult EditBook(int id)
        {
            var book = context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            var categories = context.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName");

            return View(book);
        }


        [HttpPost]
        public IActionResult EditBook(Book book)
        {
            context.Books.Update(book);
            try
            {
                context.SaveChanges();
                return RedirectToAction("index", "Book");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = "Error: " + ex.Message;
            }

            return View();

        }

        public IActionResult Details(int id) 
        {
            var book = context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            var categories = context.Categories.ToList();
            ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName");

            return View(book);
        }


        public IActionResult Delete(int id) 
        {
            var book = context.Books.Find(id);
            if (book == null) 
            {
                return NotFound();
            }
            //var categories = context.Categories.ToList();
            //ViewBag.CategoryList = new SelectList(categories, "CategoryId", "CategoryName");

            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            context.Books.Remove(book);
            try
            {
                context.SaveChanges();
                return RedirectToAction("index", "Book");
            }
            catch (Exception ex)
            {
                ViewBag.errorMessage = "Error: " + ex.Message;
            }

            return View();
        }

    }
}
