using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Domain.Models.Request;
using VerivoxTest.Domain.Models.Requests;
using VerivoxTest.Domain.Models.Responses;

namespace VerivoxTest.Application.Handlers
{
    /// <summary>
    /// It will be ideal to have a default handler for the entities stored in the database. 
    /// A handler for a generic. Something Like  "DefaultHandler<TEntity> : IRequestHandler<Request, Response<TEntity>"
    /// </summary>
    public class DefaultHandler : IRequestHandler<Request, Response<string>>
    {

        public Task<Response<string>> Handle(Request request, CancellationToken cancellationToken)
        {

            


            return Task.FromResult(new Response<string> { Payload= new List<string> { "Hello" } });
        }
    }
}
