using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Application.Especifications.Responses;

namespace VerivoxTest.Application.Especifications.Requests
{
    public class Request : IRequest<Response<string>>
    {
        public string Id { get; set; }
    }
}
