using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerivoxTest.Domain.Models.Entities.Interfaces
{
    public interface IProduct
    {
        public string Name { get; }

        public Task<double> Calculate(double YearlyConsumption);
    }
}
