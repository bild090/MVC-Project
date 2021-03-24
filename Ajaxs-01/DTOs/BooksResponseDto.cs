using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.DTOs
{
    public class BooksResponseDto
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public bool Availabe { get; set; }
        public String BookType { get; set; }
        [Display(Name ="PDF")]
        public String Pdf { get; set; }
    }
}
