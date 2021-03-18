using Ajaxs_01.Models;
using Ajaxs_01.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Ajaxs_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private IStudentRepository _StudentRepo;

        public HomeController(IMapper mapper, IStudentRepository StudentRepo)
        {
            _mapper = mapper;
            _StudentRepo = StudentRepo;
        }

        public IActionResult Index()
        {

            var students = _StudentRepo.GetAll().ToList();
            var model = _mapper.Map<List<Student>, List<ShowStudentVM>>(students);
            return View(model);
        }

        //// GET: Home/JqAJAX  
        //[HttpPost]
        //public PartialViewResult AddStudent(Student student)
        //{
        //    var context = new StudentContext();

        //    var std = new Student()
        //    {
        //        Name = student.Name,
        //        Age = student.Age,
        //        IsActive = student.IsActive,
        //        BirthData = student.BirthData,
        //        Level = student.Level,
        //        Country = student.Country,
        //        ZipCode = student.ZipCode

        //    };

        //    context.students.Add(std);
        //    context.SaveChanges();

        //    var students = context.students.ToList();
        //    var model = _mapper.Map<List<Student>, List<ShowStudentVM>>(students);
        //    //string jsonObject = JsonConvert.SerializeObject(st);

        //    return PartialView("_ShowStudent", model);
        //}
    }
}
