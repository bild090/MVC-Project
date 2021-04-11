using StudentApp.Models;
using AutoMapper;
using StudentApp.Core.Models;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using StudentApp.Domain.Contract;

namespace StudentApp.Controllers
{
    public class LevelController : Controller
    {
        private readonly ILevelDomainServices _LevelDomainServices;
        private readonly IMapper _mapper;

        public LevelController(IMapper mapper, ILevel levelRepo, ILevelDomainServices LevelDomainServices)
        {
            _mapper = mapper;
            _LevelDomainServices = LevelDomainServices;
        }
        public IActionResult Index()
        {
            try
            {
                var level = _LevelDomainServices.GetAll().OrderBy(lev => lev.LevelNumber);
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
                _LevelDomainServices.Insert(lev);
                _LevelDomainServices.Save();
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
                bool isExist = _LevelDomainServices.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Level Not Exist");
                    return View();
                }
                var level = _LevelDomainServices.GetById(id);
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
                _LevelDomainServices.Update(lev);
                _LevelDomainServices.Save();
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
                bool isExist = _LevelDomainServices.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Level Not Exist");
                    return View();
                }
                var level = _LevelDomainServices.GetById(id);
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
                bool isExist = _LevelDomainServices.IsExisit(id);
                if (!isExist)
                {
                    ModelState.AddModelError("", "Level Not Exist");
                    return View();
                }
                var level = _LevelDomainServices.GetById(id);
                _LevelDomainServices.Delete(id);
                _LevelDomainServices.Save();

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
