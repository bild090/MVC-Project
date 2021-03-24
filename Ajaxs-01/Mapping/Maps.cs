using StudentApp.Models;
using AutoMapper;
using StudentApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentApp.mapper
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Student, StudentVM>()
          .ForMember(a => a.LevelList, m => m.Ignore())
                .ReverseMap();
            CreateMap<Student, ShowStudentVM>().ReverseMap();
            CreateMap<Level, LevelVM>().ReverseMap();
            CreateMap<Level, IEnumerable<SelectListItem>>().ReverseMap();
        }
    }
}
