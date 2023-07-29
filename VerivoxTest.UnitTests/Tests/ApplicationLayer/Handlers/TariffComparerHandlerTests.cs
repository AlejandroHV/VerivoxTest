using Microsoft.Extensions.Logging;
using Moq;
using VerivoxTest.Application.Configurations;
using VerivoxTest.Application.Especifications.Context;
using VerivoxTest.Application.Especifications.Factories.Interfaces;
using VerivoxTest.Application.Handlers;
using VerivoxTest.Application.Models.Request;
using VerivoxTest.Domain.Models.Entities;
using VerivoxTest.Domain.Models.Entities.Implementation;
using VerivoxTest.Domain.Models.Entities.Interfaces;

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
        private Mock<IFactory<IProduct>> _factoryMock;
        private TariffComparerHandler _sut;
        private CancellationToken _cancellationToken;

        [SetUp]
        public void SetUp()
        {
            CancellationTokenSource cts = new();
            _cancellationToken = cts.Token;
            AppSettingsBinding.ShouldUseFactory = true;

            var mockProducts = new List<Product>();
            mockProducts.Add(new Product()
            {
                Active = true,
                Assembly = "VerivoxTest.Domain",
                AssemblyType = "VerivoxTest.Domain.Models.Entities.Implementation.BasicElectricityProduct",
                ProdutType = 0,
                Name = "Basic"
            });

            _contextMock = new Mock<IContext>();
            _contextMock.Setup(x => x.Products).Returns(mockProducts);

            _loggerMock = new Mock<ILogger<TariffComparerHandler>>();
            _factoryMock = new Mock<IFactory<IProduct>>();

            //Mocking the factory to return the instances.
            _factoryMock.Setup(x => x.Create(0)).Returns(new BasicElectricityProduct());
            _factoryMock.Setup(x => x.Create(1)).Returns(new PackagedTariffProduct());
            _factoryMock.Setup(x => x.Create(It.IsNotIn(0, 1))).Returns((IProduct)null);

            _sut = new TariffComparerHandler(_contextMock.Object, _loggerMock.Object, _factoryMock.Object);

            /*If we dont want to mock the factory and test it here. 
             * The factory should be tested on it is own class. 
             * var factoryObject = new ProductFactory();
            _sut = new TariffComparerHandler(_contextMock.Object, _loggerMock.Object, factoryObject);
            */
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
        public void Handle_NonExistentProductImplementation_ShouldThrowTypeLoadException()
        {
            AppSettingsBinding.ShouldUseFactory = false;
            var mockProducts = new List<Product>();
            var badAssembly = "BadAssembly";


            mockProducts.Add(new Product()
            {
                Active = true,
                Assembly = "VerivoxTest.Domain",
                AssemblyType = badAssembly,
                Name = "Basic",
                ProdutType = 0
            });

            _contextMock.Setup(x => x.Products).Returns(mockProducts);
            var request = new TariffComparerRequest();
            request.AnnualConsumption = 3500d;

            AsyncTestDelegate testDelegate = async () => { await _sut.Handle(request, _cancellationToken); };

            Assert.ThrowsAsync<TypeLoadException>(testDelegate);

        }


        [Test]
        public void Handle_BadClassAsembly_ShouldThrowTypeLoadException()
        {
            AppSettingsBinding.ShouldUseFactory = false;
            var mockProducts = new List<Product>();
            var badAssembly = "VerivoxTest.Domain.Models.Entities.Product";
            mockProducts.Add(new Product()
            {
                Active = true,
                Assembly = "VerivoxTest.Domain",
                AssemblyType = badAssembly,
                Name = "Basic",
                ProdutType = 0
            });

            _contextMock.Setup(x => x.Products).Returns(mockProducts);

            var request = new TariffComparerRequest();
            request.AnnualConsumption = 3500d;


            AsyncTestDelegate testDelegate = async () => { await _sut.Handle(request, _cancellationToken); };


            Assert.ThrowsAsync<InvalidCastException>(testDelegate);

        }


    }
}
