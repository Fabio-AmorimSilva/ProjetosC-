using System.Linq;
using System.Threading.Tasks;
using BibliotecaContextLib;
using BibliotecaEntitiesLib;
using BibliotecaMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BibliotecaMvc.Controllers.LibraryControllers
{
    public class LibraryController : Controller
    {
        private Biblioteca db;
        private readonly ILogger<LibraryController> _logger;

        public LibraryController(ILogger<LibraryController> logger, Biblioteca injectedContext){

            _logger = logger;
            db = injectedContext;

        }

        //Chamadas assíncronas para otimizar o programa

         public async Task<IActionResult> Books(){

          var model = new BooksViewModel{
              Books = await db.Books.ToListAsync()
                            
          };

          return View(model);

        }

        public async Task<IActionResult> Authors(){

            var model = new AuthorsViewModel{
                Authors = await db.Authors.ToListAsync()
            };

            return View(model);
        }

        public IActionResult AddB(){
    
           return View();
        }


        [HttpPost]
        public IActionResult AddB(Books book){

            if(ModelState.IsValid){
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToPage("/AddB");
            }


            return View();

        }

        public IActionResult UpdateBook(){

            return View();
        }

        [HttpPost]
        public IActionResult UpdateBook(Books book){

            var bookId = db.Books.Where(b => b.Id == book.Id).First();
            if(bookId != null){

                bookId.ISBN = book.ISBN;
                bookId.Title = book.Title;
                bookId.Author = book.Author;
                bookId.Genre = book.Genre;
                bookId.Year = book.Year;

                db.SaveChanges();

            }

            return View();

        }

        public IActionResult DeleteBook(){

            return View();

        }

        [HttpPost]
        public IActionResult DeleteBook(Books book){

            var bookId = db.Books.Where(b => b.Id == book.Id).First();
            if(bookId != null){
                db.Books.Remove(bookId);
                db.SaveChanges();

            }

            return View();

        }

        public IActionResult AddA(){

            return View();

        }

        [HttpPost]
        public IActionResult AddA(Author author){

            if(ModelState.IsValid){
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToPage("/AddA");

            }

            return View();
        }

        public IActionResult DeleteAuthor(){

            return View();

        }

        [HttpPost]
        public IActionResult DeleteAuthor(Author author){

            var authorId = db.Authors.Where(a => a.Id == author.Id).First();
            if(authorId != null){
                db.Authors.Remove(authorId);
                db.SaveChanges();

            }

            return View();

        }
        
    }
}