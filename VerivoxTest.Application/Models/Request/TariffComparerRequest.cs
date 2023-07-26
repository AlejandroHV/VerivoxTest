
using MediatR;
using VerivoxTest.Application.Especifications.Responses;
using VerivoxTest.Application.Models.Responses;

namespace VerivoxTest.Application.Models.Request
{
    public class TariffComparerRequest : IRequest<Response<TariffComparerResponse>>
    {
        public double AnnualConsumption { get; set; }

    }
}
