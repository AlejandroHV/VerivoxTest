using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Domain.Models.Entities.Implementation;

namespace VerivoxTest.UnitTests.Domain.Implementation
{
    [TestFixture]
    public class PackagedTariffProductTests
    {
        private PackagedTariffProduct _sut;

        [SetUp]
        protected void SetUp()
        {
            _sut = new PackagedTariffProduct();
        }

        [TestCase(3500, ExpectedResult = 800)]
        [TestCase(4500, ExpectedResult = 950)]
        [TestCase(6000, ExpectedResult = 1400)]
        public async Task<double> Calculate_ValidAnnualConsumptionTariff_CorrectAnualCost(int annualConsumption)
        {

            var cost =await _sut.Calculate(annualConsumption);

            return cost;
        }

        [Test]
        public void Calculate_ZeroAnnualConsumption_ZeroAnnualCost()
        {
            var zeroAnnualConsumption = 0;

            var cost =  _sut.Calculate(zeroAnnualConsumption);

            Assert.AreEqual(0,cost.Result);
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
