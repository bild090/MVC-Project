using Ajaxs_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ajaxs_01.Repository
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

