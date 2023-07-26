using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerivoxTest.Application.Especifications.Context;
using VerivoxTest.Application.Handlers;
using VerivoxTest.Application.Models.Request;
using VerivoxTest.Application.Models.Responses;
using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.UnitTests.Tests.ApplicationLayer.Handlers
{
    /// <summary>
    /// TO DO: 
    /// Add tests to check invalid namespace. 
    /// Add tests where the mocks are not properly mocked or defined. 
    /// Add tests around the creation of the instances. 
    /// Add tests to validate the count.
    /// </summary>
    [TestFixture]
    public class TariffComparerHandlerTests
    {
        private Mock<IContext> _contextMock;
        private Mock<ILogger<TariffComparerHandler>> _loggerMock;
        private TariffComparerHandler _sut;
        private CancellationToken _cancellationToken;

        [SetUp]
        public void SetUp()
        {
            CancellationTokenSource cts = new();
            _cancellationToken = cts.Token;

            var mockProducts = new List<Product>();
            mockProducts.Add(new Product() { Active = true, Assembly = "VerivoxTest.Domain", AssemblyType = "VerivoxTest.Domain.Models.Entities.Implementation.BasicElectricityProduct", Name = "Basic" });
            
            _contextMock = new Mock<IContext>();
            _contextMock.Setup(x => x.Products).Returns(mockProducts);

            _loggerMock = new Mock<ILogger<TariffComparerHandler>>();

            
            _sut = new TariffComparerHandler(_contextMock.Object, _loggerMock.Object);


        }

        [Test]
        public void Handle_MockingAllTheExternalDependencies_ShouldReturnConsumptions()
        {
           
            var request = new TariffComparerRequest();
            request.AnnualConsumption = 3500d;

            var actual = _sut.Handle(request, _cancellationToken);

            Assert.That(actual.Result.Payload, Is.Not.Null);

        }

        [TestCase(3500d, ExpectedResult = 830d)]
        [TestCase(4500d, ExpectedResult = 1050d)]
        [TestCase(6000d, ExpectedResult = 1380d)]
        public double Handle_DifferentConsumptions_ShouldReturnConsumptions(double annualConsumption)
        {
           
            var request = new TariffComparerRequest();
            request.AnnualConsumption = annualConsumption;

            var actual = _sut.Handle(request, _cancellationToken);

            return actual.Result.Payload.FirstOrDefault().Consumption;

        }

        [Test]
        public void Handle_ContextMockProductsEmptyList_ReturnNull()
        {
            _contextMock.Setup(x => x.Products).Returns(new List<Product>());
            
            var request = new TariffComparerRequest();
            request.AnnualConsumption = 3500d;

            var actual = _sut.Handle(request, _cancellationToken);

            Assert.That(actual.Result.Payload, Is.Null);

        }

        [Test]
        public void Handle_MockingAllTheExternalDependencie_ShouldReturnConsumptions()
        {
           
            var request = new TariffComparerRequest();
            request.AnnualConsumption = 3500d;

            var actual = _sut.Handle(request, _cancellationToken);

            Assert.That(actual.Result.Payload, Is.Not.Null);

        }

    }
}
