using VerivoxTest.Domain.Models.Entities.Interfaces;

namespace VerivoxTest.Domain.Models.Entities.Implementation
{
    public class BasicElectricityProduct : IProduct
    {
        public string Name { get { return "Basic Electricity Tariff"; } }
        public BasicElectricityProduct()
        {

        }

        public async Task<double> Calculate(double annualConsumption)
        {
            var anualCost = 0d;
            if (annualConsumption > 0)
            {
                anualCost = 60 + (annualConsumption * 22) / 100;
            }


            return anualCost;
        }

    }
}

