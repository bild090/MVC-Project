using FluentValidation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class LevelVM
    {
        [Key]
        public String Id { get; set; }
        [Required]
        public int LevelNumber { get; set; }
    }

    public class BookLevelVM
    {
        [Display(Name = "Select Level")]
        public int Id { get; set; }
        [Required]
        public int LevelNumber { get; set; }
        public List<LevelVM> LevelList { get; set; }
    }

    public class LevelVMValidator : AbstractValidator<LevelVM>
    {
        public LevelVMValidator()
        {
            RuleFor(bl => bl.LevelNumber).InclusiveBetween(1, 6);
        }
    }
}
