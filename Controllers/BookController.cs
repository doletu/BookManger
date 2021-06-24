using BookManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookManager.Controllers
{
    public class BookController : Controller
    {
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listbook = context.Books.ToList();
            return View(listbook);
        }
        
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(x => x.ID == id);
            if (book==null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        
        [Authorize]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {

            BookManagerContext context = new BookManagerContext();
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
            }

            return View("ListBook",context.Books.ToList());
        }

        [Authorize]
        public ActionResult Edit(int id)
        {

            BookManagerContext context = new BookManagerContext();
            Book check = context.Books.SingleOrDefault(x => x.ID == id);
            if (check == null)
            {
                return HttpNotFound();
            }

            return View(check);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Book book)
        {

            BookManagerContext context = new BookManagerContext();
            Book check = context.Books.SingleOrDefault(x => x.ID == book.ID);
            if (check == null)
            {
                return HttpNotFound();
            }
            context.Books.AddOrUpdate(check);
            context.SaveChanges();
            return View(check);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {

            BookManagerContext context = new BookManagerContext();
            Book check = context.Books.SingleOrDefault(x => x.ID == id);
            if (check == null)
            {
                return HttpNotFound();
            }

            return View(check);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Delete(Book book)
        {

            BookManagerContext context = new BookManagerContext();
            Book check = context.Books.SingleOrDefault(x => x.ID == book.ID);
            if (check == null)
            {
                return HttpNotFound();
            }
            context.Books.Remove(check);
            context.SaveChanges();
            return View(check);
        }


        [Authorize]
        public ActionResult Details(int id)
        {

            BookManagerContext context = new BookManagerContext();
            Book check = context.Books.SingleOrDefault(x => x.ID == id);
            if (check == null)
            {
                return HttpNotFound();
            }

            return View(check);
        }
    }
}