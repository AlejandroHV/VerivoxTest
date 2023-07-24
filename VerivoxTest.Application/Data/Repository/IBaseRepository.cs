using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Application.Data.Repository
{
    public interface IBaseRepository<T> where T : Entity
    {
        List<T> GetAll();
        T GetById(Guid id);
    }
}
