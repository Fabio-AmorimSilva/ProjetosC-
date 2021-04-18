using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BibliotecaEntitiesLib
{
    public class Author
    {
        [Required]
        public int Id{get; set;} 
        [Required]
        [StringLength(40)]
        public string Name{get; set;}
        [Required]
        [StringLength(40)]
        public string Books{get; set;}
        [Required]
        [StringLength(20)]
        public string Country{get; set;}
        
    }
}