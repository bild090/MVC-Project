using StudentApp.Models;
using StudentApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.EntityFrameworkCore
{
    public interface ILevel
    {
        IEnumerable<Level> GetAll();
        Level GetById(int levelId);
        void Insert(Level level);
        void Update(Level level);
        void Delete(int levelId);
        void Save();
        bool IsExisit(int levelId);
    }
}

