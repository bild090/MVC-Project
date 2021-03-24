using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentApp.EntityFrameworkCore;
using StudentApp.Core.Models;
using StudentApp.Models;

namespace StudentApp.Repository
{
    
    public class LevelRepository : ILevel
    {
        private readonly StudentContext _context;

        public LevelRepository(StudentContext context)
        {
            _context = context;
        }
        public void Delete(int levelId)
        {
            var level = _context.levels.FirstOrDefault(lev => lev.Id == levelId);
            _context.levels.Remove(level);
            Save();
        }

        public IEnumerable<Level> GetAll()
        {
            return _context.levels.ToList();
        }

        public Level GetById(int levelId)
        {
            return _context.levels.FirstOrDefault(lev => lev.Id == levelId);
        }

        public void Insert(Level level)
        {
            _context.levels.Add(level);
            Save();
        }

        public bool IsExisit(int levelId)
        {
            return _context.levels.Any(lev => lev.Id == levelId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Level level)
        {
            _context.levels.Update(level);
            Save();
        }
    }
}
