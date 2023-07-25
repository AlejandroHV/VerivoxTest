using MediatR;
using VerivoxTest.Application.Especifications.Requests;
using VerivoxTest.Application.Especifications.Responses;

namespace VerivoxTest.Application.Handlers
{
    /// <summary>
    /// It will be ideal to have a default handler for the entities stored in the database. 
    /// A handler for a generic. Something Like  "DefaultHandler<TEntity> : IRequestHandler<Request, Response<TEntity>"
    /// </summary>
    public class DefaultHandler : IRequestHandler<Request, Response<string>>
    {

        public  async Task<Response<string>> Handle(Request request, CancellationToken cancellationToken)
        {

            return new Response<string> { Payload= new List<string> { "Hello" } };
        }
    }
}
