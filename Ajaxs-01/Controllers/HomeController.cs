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
using Ajaxs_01.Paging;

namespace StudentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILevel _levelRepo;
        private IStudentRepository _StudentRepo;

        private readonly StudentContext _context;

        public HomeController(IMapper mapper, IStudentRepository StudentRepo, ILevel levelRepo, StudentContext context)
        {
            _mapper = mapper;
            _StudentRepo = StudentRepo;
            _levelRepo = levelRepo;
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetStudentList(StudentSearchVM? student, int? pageNumber=1)
        {
            var students = _StudentRepo.GetAll().ToList();

            if (student.Country != null)
            {
                students = _StudentRepo.GetCounrty(students, student.Country);
            }

            if(student.Level != null)
            {
                students = _StudentRepo.GetLevel(students, (int)student.Level);
            }

            if(student.isActive == true)
            {
                students = _StudentRepo.GetActiveStudent(students, (bool)student.isActive);
            }

            var model = _mapper.Map<List<ShowStudentVM>>(students);
            return PartialView("_ShowStudent", PaginatedList<ShowStudentVM>.CreateAsync(model.AsQueryable(), (int)pageNumber, 2));

            //var model = _mapper.Map<List<ShowStudentVM>>(students);
            //return PartialView("_ShowStudent", model);
        }

        public ActionResult GetLevelList()
        {
            try
            {
                var levels = _levelRepo.GetAll().ToList();
                var levelItem = _mapper.Map<List<LevelVM>>(levels);

                var model = new BookLevelVM()
                {
                    LevelList = levelItem
                };
                return PartialView("_LevelList", model);
            }
            catch
            {
                return PartialView("Failed To Load Level");
            }
        }

        public ActionResult Page(int? pageNumber = 1)
        {
            var students = _StudentRepo.GetAll().ToList();
            var model = _mapper.Map<List<ShowStudentVM>>(students);
            return PartialView("_ShowStudent", PaginatedList<ShowStudentVM>.CreateAsync(model.AsQueryable(), (int)pageNumber, 2));
        }
    }
}
