using FluentValidation;
using StudentApp.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Models
{
    public class StudentVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Plase Enter valid Name")]
        public String Name { get; set; }
        [Required]
        //[Range(6, 18, ErrorMessage = "Plase Enter age from 6 to 18")]
        //[RegularExpression(@"^([6-9])|(1[0-8])$", ErrorMessage = "Age must be Number start with no Zero")]
        public int Age { get; set; }

        [Required]
        public int LevelId { get; set; }
        public IEnumerable<SelectListItem> LevelList { get; set; }
        [Required]
        [Display(Name = "Student enrolled")]
        public bool IsActive { get; set; }
        [Required]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthData { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]*$")]
        public String Country { get; set; }
        [Required]
        [RegularExpression(@"^[1-9]{5}$", ErrorMessage = "Zipcode must be Number and enter 5 numbers")]
        public int ZipCode { get; set; }
        public Level Level { get; set; }
    }

    public class StudentVMValidator : AbstractValidator<StudentVM>
    {
        public StudentVMValidator()
        {
            RuleFor(s => s.Id).NotNull();
            RuleFor(s => s.Name).Length(3, 50);
            RuleFor(s => s.Age).InclusiveBetween(6, 18);
            RuleFor(s => s.IsActive).NotNull();
            RuleFor(s => s.BirthData).NotNull();
            RuleFor(s => s.Country).NotNull().Length(3, 50);
            RuleFor(s => s.ZipCode).NotNull();
            RuleFor(s => s.LevelId).NotNull();
        }
    }

    public class ShowStudentVM
    { 
        public String Id { get; set; }
        public String Name { get; set; }
        public int Age { get; set; }
        public String Country { get; set; }
        [Display(Name = "Student enrolled")]
        public bool IsActive { get; set; }
        [Display(Name= "Level")]
        public Level Level { get; set; }
    }

    public class StudentSearchVM
    {
        public String? Country { get; set; }
        public int? Level { get; set; }
        public bool? isActive { get; set; }
    }
}
