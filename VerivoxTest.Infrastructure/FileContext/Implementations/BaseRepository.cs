using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Application.Especifications.Repository;
using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Infrastructure.FileContext.Implementations
{
    /// <summary>
    /// Repository created as an example or initial guideline to create the repository and the UnitOfWork pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
