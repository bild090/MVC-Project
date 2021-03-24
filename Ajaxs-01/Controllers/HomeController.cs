using StudentApp.Models;
using StudentApp.Repository;
using AutoMapper;
using StudentApp.Core.Models;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace StudentApp.Controllers
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
    }
}
