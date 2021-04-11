using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
