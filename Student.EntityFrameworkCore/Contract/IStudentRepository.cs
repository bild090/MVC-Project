using StudentApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StudentApp.EntityFrameworkCore
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        Student GetById(int studentId);
        void Insert(Student student);
        void Update(Student student);
        void Delete(int studentId);
        bool IsExisit(int studentId);
        void Save();
        Student GetStudentLevelObj(int studentId);
        IEnumerable<Student> GetPagging(int excludeRecords, int pageSize);
        int GetRecordsCount();
    }
}
