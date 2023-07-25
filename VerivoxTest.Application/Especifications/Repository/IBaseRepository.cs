using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Application.Especifications.Repository
{
    /// <summary>
    /// The intention of having this base repository is to implement the Unit of Work Pattern and use this repository inside.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : Entity
    {
        List<T> GetAll();
        T GetById(Guid id);
    }
}
