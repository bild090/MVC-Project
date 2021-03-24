using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Core.Models
{
      public class Student
      {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public DateTime BirthData { get; set; }
        [Required]
        public String Country { get; set; }
        [Required]
        public int ZipCode { get; set; }
        [Required]
        public int LevelId { get; set; }
        public Level Level { get; set; }
      }

    
}
