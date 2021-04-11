using StudentApp.Models;
using AutoMapper;
using StudentApp.Core.Models;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using StudentApp.Domain.Contract;

namespace StudentApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IStudentDomainServices _IStudentDomainServices;
        private readonly ILevelDomainServices _LevelDomainServices;


        public StudentController(IMapper mapper, IStudentDomainServices IStudentDomainServices
            , ILevelDomainServices LevelDomainServices)
        {
            _mapper = mapper;
            _IStudentDomainServices = IStudentDomainServices;
            _LevelDomainServices = LevelDomainServices;
        }
        public IActionResult Index()
        {
            var levels = _LevelDomainServices.GetAll();
            var levelsItem = levels.Select(lev => new SelectListItem
            {
                Value = lev.Id.ToString(),
                Text = lev.LevelNumber.ToString()
            });

            var model = new StudentVM()
            {
                LevelList = levelsItem
            };

            return View(model);
        }
        [HttpPost]
        public IActionResult CreateStudent(StudentVM student)
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "somthing went wrong");
                    return View("Index");
                }
                var std = _mapper.Map<Student>(student);
                _IStudentDomainServices.Insert(std);
                _IStudentDomainServices.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            try
            {

                bool isExist = _IStudentDomainServices.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Student Not Exist");
                    return View();
                }

                var student = _IStudentDomainServices.GetStudentLevelObj(id);
                var model = _mapper.Map<StudentVM>(student);
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {

                bool isExist = _IStudentDomainServices.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Student Not Exist");
                    return View();
                }
                var student = _IStudentDomainServices.GetById(id);
                var model = _mapper.Map<StudentVM>(student);
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }

        [HttpPost]
        public IActionResult EditConfirme(StudentVM student)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(student);
                }
               
                var std = _mapper.Map<Student>(student);
                _IStudentDomainServices.Update(std);
                _IStudentDomainServices.Save();
                return RedirectToAction("", "/", new { area = "" });
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {

                bool isExist = _IStudentDomainServices.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Student Not Exist");
                    return View();
                }
                var student = _IStudentDomainServices.GetById(id);
                var model = _mapper.Map<StudentVM>(student);
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirme(int id)
        {
            try
            {

                bool isExist = _IStudentDomainServices.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Student Not Exist");
                    return View();
                }
               
                _IStudentDomainServices.Delete(id);
                _IStudentDomainServices.Save();

                return RedirectToAction("", "/", new { area = "" });
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }
    }
}
