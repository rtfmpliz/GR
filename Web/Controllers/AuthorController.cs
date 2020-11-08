using Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IRepository<Author> repoAuthor;
        private readonly IRepository<Book> repoBook;

        public AuthorController(IRepository<Author> repoAuthor, IRepository<Book> repoBook)
        {
            this.repoAuthor = repoAuthor;
            this.repoBook = repoBook;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<AuthorListingViewModel> model = new List<AuthorListingViewModel>();
            repoAuthor.GetAll().ToList().ForEach(a =>
            {
                AuthorListingViewModel author = new AuthorListingViewModel
                {
                    Id = a.Id,
                    Name = $"{a.FirstName} {a.LastName}",
                    Email = a.Email
                };
                author.TotalBooks = repoBook.GetAll().Count(x => x.AuthorId == a.Id);
                model.Add(author);
            });
            return View(model);
        }

        [HttpGet]
        public PartialViewResult AddAuthor()
        {
            AuthorBookViewModel model = new AuthorBookViewModel();
            return PartialView("_AddAuthor", model);
        }
        [HttpPost]
        public ActionResult AddAuthor(AuthorBookViewModel model)
        {
            Author author = new Author
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                AddedDate = DateTime.UtcNow,
                IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                ModifiedDate = DateTime.UtcNow,
                Books = new List<Book> {
                new Book {
                    Name = model.BookName,
                        ISBN = model.ISBN,
                        Publisher = model.Publisher,
                        IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                        AddedDate = DateTime.UtcNow,
                        ModifiedDate = DateTime.UtcNow
                }
            }
            };
            repoAuthor.Insert(author);
            return RedirectToAction("Index");
        }
    }
}
