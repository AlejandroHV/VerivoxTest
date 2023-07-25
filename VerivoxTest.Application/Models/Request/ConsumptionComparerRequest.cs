
using MediatR;
using VerivoxTest.Application.Especifications.Responses;
using VerivoxTest.Application.Models.Responses;

namespace VerivoxTest.Application.Models.Request
{
    public class ConsumptionComparerRequest : IRequest<Response<ConsumptionComparerResponse>>
    {
        public double AnnualConsumption { get; set; }

    }
}
