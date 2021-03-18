using Ajaxs_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajaxs_01.Repository
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int studentId);
        void Insert(Student student);
        void Update(Student student);
        void Delete(int studentId);
        void Save();
        bool IsExisit(int studentId);
        Student GetStudentLevelObj(int studentId);
    }
}
