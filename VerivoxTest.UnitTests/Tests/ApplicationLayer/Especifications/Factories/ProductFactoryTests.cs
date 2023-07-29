

using VerivoxTest.Application.Especifications.Factories;
using VerivoxTest.Application.Models.Enums;
using VerivoxTest.Domain.Models.Entities.Implementation;

namespace VerivoxTest.UnitTests.Tests.ApplicationLayer.Especifications.Factories
{
    [TestFixture]
    public class ProductFactoryTests
    {
        private ProductFactory _sut;
        [SetUp]
        public void SetUp()
        {
            _sut = new ProductFactory();
        }

       

        [Test]
        public void Create_BasicProductTypeInt_IsBasicProductObject()
        {
            var basicProductType = (int)ProductTypeEnum.BasicTarif;

            var productInstance = _sut.Create(basicProductType);


            Assert.That(productInstance, Is.TypeOf<BasicElectricityProduct>());
        }

        [Test]
        public void Create_PackagedProductTypeInt_IsPackagedProductObject()
        {
            var packagedProductType = (int)ProductTypeEnum.PackagedTariff;

            var productInstance = _sut.Create(packagedProductType);


            Assert.That(productInstance, Is.TypeOf<PackagedTariffProduct>());

        }


        [Test]
        public void Create_InvalidProductType_ReturnsNull()
        {
            var invalidProductType = 3;

            var productInstance = _sut.Create(invalidProductType);


            Assert.That(productInstance, Is.Null);

        }

    }
}
