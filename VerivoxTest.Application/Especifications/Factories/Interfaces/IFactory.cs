using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerivoxTest.Application.Especifications.Factories.Interfaces
{
    public interface IFactory<T>
    {
        T? _instance { get; set; }
        T? Create(int entityType);
    }
}
