using StudentApp.Domain.Contract;
using StudentApp.Core.Models;
using StudentApp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace StudentApp.Domain.Repository
{
    public class StudentDomainServices : IStudentDomainServices
    {
        private readonly IStudentRepository _StudentRepo;
        public StudentDomainServices(IStudentRepository StudentRepo)
        {
            _StudentRepo = StudentRepo;
        }
        public void Delete(int studentId)
        {
             _StudentRepo.Delete(studentId);
        }

        public IEnumerable<Student> GetAll()
        {
            return _StudentRepo.GetAll();
        }

        public IEnumerable<Student> GetPagging(int excludeRecords, int pageSize)
        {
            return _StudentRepo.GetPagging(excludeRecords, pageSize);
        }

        public Student GetById(int studentId)
        {
            return _StudentRepo.GetById(studentId);
        }

        public Student GetStudentLevelObj(int studentId)
        {
            return _StudentRepo.GetStudentLevelObj(studentId);
        }

        public void Insert(Student student)
        {
            _StudentRepo.Insert(student);  
        }

        public bool IsExisit(int studentId)
        {
            return _StudentRepo.IsExisit(studentId);
        }
        public void Update(Student student)
        {
            _StudentRepo.Update(student);
        }

        public int GetRecordsCount()
        {
            return _StudentRepo.GetRecordsCount();
        }

        public void Save()
        {
            _StudentRepo.Save();
        }
    }
}
