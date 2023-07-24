using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Application.Data.Repository;
using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Infrastructure.FileContext.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {


        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
