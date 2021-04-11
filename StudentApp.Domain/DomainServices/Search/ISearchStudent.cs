using StudentApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Domain.DomainServices.Search
{
    public interface ISearchStudent
    {
        List<Student> GetCounrty(List<Student> students, String country);
        List<Student> GetLevel(List<Student> students, int level);
        List<Student> GetActiveStudent(List<Student> students, bool isActive);

    }
}
