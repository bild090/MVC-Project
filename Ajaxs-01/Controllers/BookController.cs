using StudentApp.DTOs;
using StudentApp.Models;
using AutoMapper;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CommunicateWithBooksApi.EntityFrameworkCore.BooksApiContract;
using StudentApp.Domain.Contract;

namespace StudentApp.Controllers
{

    public class BookController : Controller
    {
        private readonly ILevelDomainServices _LevelDomainServices;
        private readonly IBookApi _bookApiRepo;
        private readonly IMapper _mapper;


        public BookController(IBookApi bookApiRepo, IMapper mapper, ILevelDomainServices LevelDomainServices)
        {
            _bookApiRepo = bookApiRepo;
            _mapper = mapper;
            _LevelDomainServices = LevelDomainServices;
        }

        public IActionResult Index()
        {
            try
            {
                var levels = _LevelDomainServices.GetAll().ToList();
                var levelItem = _mapper.Map<List<LevelVM>>(levels);

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
                var level = _LevelDomainServices.GetById(id);
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
