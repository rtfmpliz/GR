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
    public class BookController : Controller
    {
        private readonly IRepository<Author> repoAuthor;
        private readonly IRepository<Book> repoBook;

        public BookController(IRepository<Author> repoAuthor,
            IRepository<Book> repoBook)
        {
            this.repoAuthor = repoAuthor;
            this.repoBook = repoBook;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<BookListingViewModel> model = new List<BookListingViewModel>();
            repoBook.GetAll().ToList().ForEach(b => {
                BookListingViewModel book = new BookListingViewModel
                {
                    Id = b.Id,
                    BookName = b.Name,
                    Publisher = b.Publisher,
                    ISBN = b.ISBN
                };
                Author author = repoAuthor.Get(b.AuthorId);
                book.AuthorName = $"{author.FirstName} {author.LastName}";
                model.Add(book);
            });
            return View("Index", model);
        }
    }
}
