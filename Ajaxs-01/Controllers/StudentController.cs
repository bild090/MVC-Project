using Ajaxs_01.Models;
using Ajaxs_01.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajaxs_01.Controllers
{
    public class StudentController : Controller
    {
        private IStudentRepository _StudentRepo;
        private ILevel _levelRepo;
        private readonly IMapper _mapper;

        public StudentController(IMapper mapper, IStudentRepository StudentRepo, ILevel levelRepo)
        {
            _mapper = mapper;
            _StudentRepo = StudentRepo;
            _levelRepo = levelRepo;
        }
        public IActionResult Index()
        {
            var levels = _levelRepo.GetAll();
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
                _StudentRepo.Insert(std);
                _StudentRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
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

                bool isExist = _StudentRepo.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Student Not Exist");
                    return View();
                }

                var student = _StudentRepo.GetStudentLevelObj(id);
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

                bool isExist = _StudentRepo.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Student Not Exist");
                    return View();
                }
                var student = _StudentRepo.GetById(id);
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
                _StudentRepo.Update(std);
                _StudentRepo.Save();
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

                bool isExist = _StudentRepo.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Student Not Exist");
                    return View();
                }
                var student = _StudentRepo.GetById(id);
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

                bool isExist = _StudentRepo.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Student Not Exist");
                    return View();
                }
               
                _StudentRepo.Delete(id);
                _StudentRepo.Save();

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
