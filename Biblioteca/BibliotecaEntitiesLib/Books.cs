using System;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaEntitiesLib
{
    public class Books
    {
        [Required]
        public int Id{get; set;}

        [Required]
        public int ISBN{get; set;}
        [Required]
        [StringLength(40)]
        public string Title{get; set;}
        [Required]
        [StringLength(40)]
        public string Author{get; set;}
        [Required]
        [StringLength(20)]
        public string Genre{get; set;}
        [Required]
        public int Year{get; set;}

    }
}
