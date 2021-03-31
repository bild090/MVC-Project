using StudentApp.DTOs;
using StudentApp.Models;
using AutoMapper;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CommunicateWithBooksApi.EntityFrameworkCore.BooksApiContract;
using System.IO;
using System.Net;

namespace StudentApp.Controllers
{

    public class BookController : Controller
    {
        private readonly ILevel _levelRepo;
        private readonly IBookApi _bookApiRepo;
        private readonly IMapper _mapper;


        public BookController(ILevel levelRepo, IBookApi bookApiRepo, IMapper mapper)
        {
            _levelRepo = levelRepo;
            _bookApiRepo = bookApiRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                var levels = _levelRepo.GetAll().ToList();
                var levelItem = _mapper.Map<List<LevelVM>>(levels);
                //var levelItem = _mapper.Map<IEnumerable<SelectListItem>>(levels);

                var model = new BookLevelVM()
                {
                    LevelList = levelItem
                };

                return View(model);

            }
            catch (Exception e)
            {
                return View(e);
            }

        }

        public async Task<ActionResult> BookList(int id)
        {
            try
            {
                var level =_levelRepo.GetById(id);
                var content = _bookApiRepo.GetBooksList(level.LevelNumber);
                var result = await content.Result.ReadAsAsync<IList<BooksResponseDto>>();
                return PartialView("Books", model: result);
            }
            catch (Exception)
            {
                return PartialView("_Error");
            }
        }

        public async Task<IActionResult> DownloadPDF(int id)
        {
            try
            {
                var content = _bookApiRepo.GetPdfFile(id);
                var fileContent = await content.Result.ReadAsByteArrayAsync();
                return File(fileContent, "application/pdf");
            }
            catch
            {
                return PartialView("_Error");
            }

        }
    }
}
