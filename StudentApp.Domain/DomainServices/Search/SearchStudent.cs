using StudentApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentApp.Domain.DomainServices.Search
{
    public class SearchStudent : ISearchStudent
    {

        public List<Student> GetCounrty(List<Student> students, String country)
        {
            return students.Where(s => s.Country.Contains(country)).ToList();
        }
        public List<Student> GetLevel(List<Student> students, int level)
        {
            return students.Where(s => s.Level.LevelNumber == level).ToList();
        }
        public List<Student> GetActiveStudent(List<Student> students, bool isActive)
        {
            return students.Where(s => s.IsActive == isActive).ToList();
        }
    }
}
