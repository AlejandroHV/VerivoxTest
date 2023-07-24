using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Domain.Models.Responses;

namespace VerivoxTest.Domain.Models.Requests
{
    public class Request : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
