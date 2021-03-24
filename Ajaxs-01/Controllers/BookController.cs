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

        public ActionResult BookList(int id)
        {
            try
            {
                var level =_levelRepo.GetById(id);
                var content = _bookApiRepo.GetBooksList(level.LevelNumber);
                var result = content.ReadAsAsync<IList<BooksResponseDto>>().Result;
                return PartialView("Books", model: result);


                //var level = _levelRepo.GetById(id);
                //HttpClientHandler clientHandler = new HttpClientHandler();
                //clientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                //HttpClient client = new HttpClient(clientHandler);


                //client.BaseAddress = new Uri("https://192.168.100.63:44310/api/");
                ////HTTP GET
                ////var responseTask = client.GetAsync("BookApi/pdf");
                //var responseTask = client.GetAsync("BookApi/" + level.LevelNumber);
                //responseTask.Wait();

                ////var result = responseTask.Result.Content.ReadAsStringAsync();
                //var result = responseTask.Result.Content.ReadAsAsync<IList<BooksResponseDto>>().Result;

                ////return PartialView("Pdf", model: result);
                //return PartialView("_Books", model: result);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                return PartialView("_Error");
            }
        }

        public FileResult DownloadPDF(int id)
        {

            var content = _bookApiRepo.GetPdfFile(id);
            var fileContent =  content.ReadAsByteArrayAsync().Result;
            return File(fileContent, "application/pdf");
        }
    }
}
