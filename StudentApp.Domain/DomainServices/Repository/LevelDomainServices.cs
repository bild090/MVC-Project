using System.Collections.Generic;
using System.Linq;
using StudentApp.EntityFrameworkCore;
using StudentApp.Core.Models;
using StudentApp.Domain.Contract;

namespace StudentApp.Domain.Repository
{

    public class LevelDomainServices : ILevelDomainServices
    {
        private readonly ILevel _StudentRepo;
        public LevelDomainServices(ILevel StudentRepo)
        {
            _StudentRepo = StudentRepo;
        }
        public void Delete(int levelId)
        {
            _StudentRepo.Delete(levelId);
        }

        public IEnumerable<Level> GetAll()
        {
            return _StudentRepo.GetAll();
        }

        public Level GetById(int levelId)
        {
            return _StudentRepo.GetById(levelId);
        }

        public void Insert(Level level)
        {
            _StudentRepo.Insert(level);
        }

        public bool IsExisit(int levelId)
        {
            return _StudentRepo.IsExisit(levelId);
        }

        public void Save()
        {
            _StudentRepo.Save();
        }

        public void Update(Level level)
        {
            _StudentRepo.Update(level);
        }
    }
}
