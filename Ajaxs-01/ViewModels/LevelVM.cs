using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ajaxs_01.Models
{
    public class LevelVM
    {
        [Key]
        public String Id { get; set; }
        [Required]
        public int LevelNumber { get; set; }
    }
}
