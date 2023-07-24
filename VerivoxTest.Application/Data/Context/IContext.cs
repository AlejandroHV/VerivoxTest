using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Application.Data.Repository;
using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Application.Data.Context
{
    public interface IContext
    {
        List<Product> Products { get; set; }

    }
}
