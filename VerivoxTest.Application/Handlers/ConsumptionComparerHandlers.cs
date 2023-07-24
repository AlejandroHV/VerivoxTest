using MediatR;
using VerivoxTest.Application.Data.Context;
using VerivoxTest.Domain.Models.Entities;
using VerivoxTest.Domain.Models.Request;
using VerivoxTest.Domain.Models.Responses;

namespace VerivoxTest.Application.Handlers
{
    public class ConsumptionComparerHandler : IRequestHandler<ConsumptionComparerRequest, Response<ConsumptionComparerResponse>>
    {

        IContext _context;

        public ConsumptionComparerHandler(IContext context)
        {
            _context = context;
        }

        public async Task<Response<ConsumptionComparerResponse>> Handle(ConsumptionComparerRequest request, CancellationToken cancellationToken)
        {

            var calculations = new List<ConsumptionComparerResponse>();

            var response = new Response<ConsumptionComparerResponse>();


            var dbProducts = _context.Products.Where(x => x.Active == true);

            foreach (var product in dbProducts)
            {

                var productIntance = Activator.CreateInstance(product.Assembly, product.AssemblyType);

                if (productIntance == null)
                {
                    throw new Exception("Could not create the product");
                }

                var newProduct = (IProduct)productIntance.Unwrap();
                var calculationResult = new ConsumptionComparerResponse()
                {
                    ProductName = newProduct.Name,
                    Consumption = newProduct.Calculate(request.YearlyConsumption)
                };

                calculations.Add(calculationResult);
            }
            response.Payload = calculations;

            return response;
        }
    }
}
