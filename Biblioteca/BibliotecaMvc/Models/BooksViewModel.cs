using System.Collections.Generic;
using BibliotecaEntitiesLib;

namespace BibliotecaMvc.Models
{
    public class BooksViewModel
    {
        public IList<Books> Books{get; set;}
        public IList<Author> Authors{get; set;}
    }
}