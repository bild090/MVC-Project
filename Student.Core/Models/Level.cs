using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Core.Models
{
    public class Level
    {
       
        [Key]
        public int Id { get; set; }
        [Required]
        public int LevelNumber { get; set; }
    }
}
