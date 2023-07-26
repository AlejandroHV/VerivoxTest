using MediatR;
using Microsoft.Extensions.Logging;
using VerivoxTest.Application.Especifications.Context;
using VerivoxTest.Application.Especifications.Requests;
using VerivoxTest.Application.Especifications.Responses;
using VerivoxTest.Application.Models.Request;
using VerivoxTest.Application.Models.Responses;
using VerivoxTest.Domain.Models.Entities;
using VerivoxTest.Domain.Models.Entities.Interfaces;

namespace VerivoxTest.Application.Handlers
{
    public class TariffComparerHandler : IRequestHandler<TariffComparerRequest, Response<TariffComparerResponse>>
    {

        private IContext _context;
        private readonly ILogger<TariffComparerHandler> _logger;
        public TariffComparerHandler(IContext context, ILogger<TariffComparerHandler> logger)
        {
            _context = context;
            _logger = logger;

        }

        /// <summary>
        /// The idea of creating the intances of the product via reflection is to have a dynamic list of products each one of them with their own calculation method.
        /// Additionally the idea is to have control over which products are active or inactive in the database. The idea is to store the assembly on the database
        /// and the implementation will be a class on the Domain that makes the calculations.
        /// TO DO: Add a mapper to the response.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Response<TariffComparerResponse>> Handle(TariffComparerRequest request, CancellationToken cancellationToken)
        {

            _logger.LogInformation($"Entering {this.GetType().Name} ");
            var calculations = new List<TariffComparerResponse>();

            var response = new Response<TariffComparerResponse>();


            var dbProducts = _context.Products;

            if (!dbProducts.Any())
            {
                return response;
            }

            dbProducts = dbProducts.Where(x => x.Active == true).ToList();

            foreach (var product in dbProducts)
            {
                var productCalculation =await CreateProductInstance(request.AnnualConsumption, product);
                calculations.Add(productCalculation);
            }
            response.Payload = calculations.OrderBy(x=>x.Consumption).ToList();
            response.ItemCount = response.Payload.Count;

            _logger.LogInformation($"Finishing execution of {this.GetType().Name} response {response.Payload}");
            return response;
        }

        private async Task<TariffComparerResponse> CreateProductInstance(double annualConsumption, Product product)
        {
            var productIntance = Activator.CreateInstance(product.Assembly, product.AssemblyType);

            if (productIntance == null)
            {
                throw new Exception("Could not create the product");
            }

            var newProduct = (IProduct)productIntance.Unwrap();
            var calculationResult = new TariffComparerResponse()
            {
                ProductName = newProduct.Name,
                Consumption = await newProduct.Calculate(annualConsumption)
            };
            return calculationResult;
        }
    }
}
