using StudentApp.Models;
using AutoMapper;
using StudentApp.Core.Models;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using cloudscribe.Pagination.Models;
using StudentApp.Domain.Contract;
using StudentApp.Domain.DomainServices.Search;

namespace StudentApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStudentDomainServices _IStudentDomainServices;
        private readonly ILevelDomainServices _LevelDomainServices;
        private readonly ISearchStudent _searchStudent;


        public HomeController(IMapper mapper, IStudentDomainServices IStudentDomainServices, ISearchStudent searchStudent
            , ILevelDomainServices LevelDomainServices)
        {
            _mapper = mapper;
            _IStudentDomainServices = IStudentDomainServices;
            _LevelDomainServices = LevelDomainServices;
            _searchStudent = searchStudent;
        }

        public ActionResult Index(int pageNumber = 1, int pageSize = 2)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;
            var students = _IStudentDomainServices.GetPagging(excludeRecords, pageSize);
            var result = _mapper.Map<List<ShowStudentVM>>(students);

            var model = new PagedResult<ShowStudentVM>
            {
                Data = result,
                TotalItems = _IStudentDomainServices.GetRecordsCount(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(model);
        }
        
        public ActionResult Search(StudentSearchVM student, int pageNumber = 1, int pageSize = 2)
        {
            var students = _IStudentDomainServices.GetAll().ToList();

            if (student.Country != null)
            {
                students = _searchStudent.GetCounrty(students, student.Country);
            }

            if(student.Level != null)
            {
                students = _searchStudent.GetLevel(students, (int)student.Level);
            }

            if(student.isActive == true)
            {
                students = _searchStudent.GetActiveStudent(students, (bool)student.isActive);
            }
           
            var result = _mapper.Map<List<ShowStudentVM>>(students);
            var model = new PagedResult<ShowStudentVM>
            {
                Data = result.ToList(),
                TotalItems = result.Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return PartialView("_ShowStudent", model);
        }

        public ActionResult GetLevelList()
        {
            try
            {
                var levels = _LevelDomainServices.GetAll().ToList();
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
    }
}
