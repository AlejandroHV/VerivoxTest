
using MediatR;
using VerivoxTest.Domain.Models.Responses;

namespace VerivoxTest.Domain.Models.Request
{
    public class ConsumptionComparerRequest : IRequest<Response<ConsumptionComparerResponse>>
    {
        public int YearlyConsumption { get;set; }

    }
}
