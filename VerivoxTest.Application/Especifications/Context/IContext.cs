using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Application.Especifications.Context
{
    /// <summary>
    /// This is an alternative to the DBContext of entity framework in order to have access to all the data but for the File Context. 
    /// Ideally this will be the unit of work and the instance of the UnitOfWork will be created on the infrastructure project. 
    /// </summary>
    public interface IContext
    {
        List<Product> Products { get; set; }

    }
}
