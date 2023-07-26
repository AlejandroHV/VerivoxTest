using VerivoxTest.Domain.Models.Entities.Implementation;

namespace VerivoxTest.UnitTests.Tests.DomainLayer.Implementation
{
    [TestFixture]
    public class BasicElectrinictyProductTests
    {
        private BasicElectricityProduct _sut;

        [SetUp]
        protected void SetUp()
        {
            _sut = new BasicElectricityProduct();
        }

        [TestCase(3500d, ExpectedResult = 830d)]
        [TestCase(4500d, ExpectedResult = 1050d)]
        [TestCase(6000d, ExpectedResult = 1380d)]
        public async Task<double> Calculate_ValidAnnualConsumptionTariff_CorrectAnualCost(double annualConsumption)
        {

            var cost = await _sut.Calculate(annualConsumption);

            return cost;
        }

        [Test]
        public void Calculate_ZeroAnnualConsumption_ZeroAnnualCost()
        {
            var zeroAnnualConsumption = 0;

            var cost = _sut.Calculate(zeroAnnualConsumption);

            Assert.AreEqual(0, cost.Result);
        }

        [Test]
        public void Calculate_NegativeAnnualConsumption_ZeroAnnualCost()
        {
            var zeroAnnualConsumption = -1050;

            var cost = _sut.Calculate(zeroAnnualConsumption);

            Assert.AreEqual(0, cost.Result);
        }


    }
}
