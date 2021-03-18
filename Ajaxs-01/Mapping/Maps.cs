using Ajaxs_01.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajaxs_01.mapper
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
        }
    }
}
