using StudentApp.Models;
using StudentApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Domain.Contract
{
    public interface ILevelDomainServices
    {
        IEnumerable<Level> GetAll();
        Level GetById(int levelId);
        void Insert(Level level);
        void Update(Level level);
        void Delete(int levelId);
        bool IsExisit(int levelId);
        void Save();
    }
}

