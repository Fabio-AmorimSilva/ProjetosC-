using System.Collections;
using System.Collections.Generic;
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
                return RedirectToPage("/Books");
            }


            return View();

        }

        public IActionResult SearchBook(){

            return View();

        }

        [HttpPost]
        public IActionResult SearchBook(int? id){

            if(!id.HasValue){
                return NotFound("The id is not a valid number");
            }

            var model = db.Books.SingleOrDefault(b => b.Id == id);
            if(model == null){
                return NotFound("Book not found in database.");

            }


            return View(model);

        }

        public IActionResult UpdateBook(){

            return View();
        }

        [HttpPost]
        public IActionResult UpdateBook(Books book){

            var bookId = db.Books.SingleOrDefault(b => b.Id == book.Id);
            if(bookId != null){

                bookId.ISBN = book.ISBN;
                bookId.Title = book.Title;
                bookId.Author = book.Author;
                bookId.Genre = book.Genre;
                bookId.Year = book.Year;

                db.SaveChanges();
                return RedirectToPage("/Books");

            }

            return View();

        }

        public IActionResult DeleteBook(){

            return View();

        }

        [HttpPost]
        public IActionResult DeleteBook(Books book){

            var bookId = db.Books.SingleOrDefault(b => b.Id == book.Id);
            if(bookId != null){
                db.Books.Remove(bookId);
                db.SaveChanges();
                return RedirectToPage("/Books");

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
                return RedirectToPage("/Authors");

            }

            return View();
        }

        public IActionResult SearchAuthor(){

            return View();

        }

        [HttpPost]
        public IActionResult SearchAuthor(int? id){

             if(!id.HasValue){
                return NotFound("The id is not a valid number");
            }

            var model = db.Authors.SingleOrDefault(a => a.Id == id);
            if(model == null){
                return NotFound("Author not found in database.");

            }

            return View(model);

        }


        public IActionResult UpdateAuthor(){

            return View();

        }


        [HttpPost]
        public IActionResult UpdateAuthor(Author author){

            var oldAuthor = db.Authors.SingleOrDefault(old => old.Id == author.Id);
            if(oldAuthor != null){
                oldAuthor.Name = author.Name;
                oldAuthor.Books = author.Books;
                oldAuthor.Country = author.Country;

                db.SaveChanges();
                return RedirectToPage("/Authors");

            }

            return View();
        }

        public IActionResult DeleteAuthor(){

            return View();

        }

        [HttpPost]
        public IActionResult DeleteAuthor(Author author){

            var authorId = db.Authors.SingleOrDefault(a => a.Id == author.Id);
            if(authorId != null){
                db.Authors.Remove(authorId);
                db.SaveChanges();
                return RedirectToPage("/Authors");

            }

            return View();

        }
        
    }
}