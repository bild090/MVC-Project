using StudentApp.DTOs;
using StudentApp.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : Controller
    {
        private ILevel _levelRepo;

        public ApiController (ILevel levelRepo)
        {
            _levelRepo = levelRepo;
        }

        [HttpGet]
        //public IActionResult GetBooks()
        //{

        //    if (!ModelState.IsValid)
        //        return BadRequest(400);

        //    var levels = _levelRepo.GetAll();

        //    var levelsDto = new List<LevelDto>();

        //    foreach (var level in levels)
        //    {
        //        levelsDto.Add(new LevelDto
        //        {
        //            LevelNumber = level.LevelNumber
        //        });
        //    }
        //    return Ok(levelsDto);
        //}

        public void PDF()
        {
            // Load input PDF file
            String inputFile = "C:\\ers\\ELL-NIC\\neDrive\\etting started with OneDrive.pdf";

            // Initialize a byte array
            byte[] buff = null;

            // Initialize FileStream object
            FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            long numBytes = new FileInfo(inputFile).Length;

            // Load the file contents in the byte array
            buff = br.ReadBytes((int)numBytes);
            fs.Close();

            
        }
    }
}
