using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerivoxTest.Domain.Models.Entities
{
    public interface IProduct 
    {
        public string Name { get;  }

        public int Calculate(int YearlyConsumption);
    }
}
