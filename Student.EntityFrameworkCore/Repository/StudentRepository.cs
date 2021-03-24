using StudentApp.Models;
using StudentApp.Core.Models;
using StudentApp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentContext _context;

        public StudentRepository(StudentContext context)
        {
            _context = context;
        }
        public void Delete(int studentId)
        {
            var student = _context.students.FirstOrDefault(s => s.Id == studentId);
             _context.students.Remove(student);
            Save();
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.students.ToList();
        }

        public Student GetById(int studentId)
        {
            return _context.students.FirstOrDefault(s => s.Id == studentId);
        }

        public Student GetStudentLevelObj(int studentId)
        {
            return _context.students.Where(s => s.Id == studentId).Include(lev => lev.Level).FirstOrDefault();
        }

        public void Insert(Student student)
        {
            _context.students.Add(student);
            Save();
        }

        public bool IsExisit(int studentId)
        {
            return _context.students.Any(s => s.Id == studentId);
        }

        public void Save()
        {
             _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Update(student);
            Save();
        }
    }
}
