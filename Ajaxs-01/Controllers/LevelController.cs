using StudentApp.Models;
using StudentApp.Repository;
using AutoMapper;
using StudentApp.Core.Models;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Controllers
{
    public class LevelController : Controller
    {
        private ILevel _levelRepo;
        private readonly IMapper _mapper;

        public LevelController(IMapper mapper, ILevel levelRepo)
        {
            _mapper = mapper;
            _levelRepo = levelRepo;
        }
        public IActionResult Index()
        {
            try
            {
                var level = _levelRepo.GetAll().OrderBy(lev => lev.LevelNumber);
                var model = _mapper.Map<List<LevelVM>>(level);

                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }
        [HttpPost]
        public IActionResult Create(LevelVM level)
        {
            try
            {
                var lev = _mapper.Map<Level>(level);
                _levelRepo.Insert(lev);
                _levelRepo.Save();
                return RedirectToAction("", "/Level", new { area = "" });
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }

        public IActionResult CreateLevel()
        {
            try
            {
                return View();
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
                bool isExist = _levelRepo.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Level Not Exist");
                    return View();
                }
                var level = _levelRepo.GetById(id);
                var model = _mapper.Map<LevelVM>(level);
                return View(model);
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }

        [HttpPost]
        public IActionResult EditConfirme(LevelVM level)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(level);
                }
                var lev = _mapper.Map<Level>(level);
                _levelRepo.Update(lev);
                _levelRepo.Save();
                return RedirectToAction("", "/Level", new { area = "" });
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
                bool isExist = _levelRepo.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Level Not Exist");
                    return View();
                }
                var level = _levelRepo.GetById(id);
                var model = _mapper.Map<LevelVM>(level);
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
                bool isExist = _levelRepo.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Level Not Exist");
                    return View();
                }
                var level = _levelRepo.GetById(id);
                _levelRepo.Delete(id);
                _levelRepo.Save();

                return RedirectToAction("", "/Level", new { area = "" });
            }
            catch
            {
                ModelState.AddModelError("", "somthing went wrong");
                return View();
            }
        }
    }
}
