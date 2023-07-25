using VerivoxTest.Domain.Models.Entities.Interfaces;

namespace VerivoxTest.Domain.Models.Entities.Implementation
{
    public class PackagedTariffProduct : IProduct
    {
        public string Name { get { return "Packaged Tariff"; } }
        public PackagedTariffProduct()
        {

        }

        public async Task<double> Calculate(double annualConsumption)
        {
            var anualCost = 0d;
            if (annualConsumption > 0)
            {
                anualCost = 800;
                var res = annualConsumption - 4000;
                if (res > 0)
                {
                    anualCost += (res * 30) / 100;
                }

            }

            return anualCost;

        }

    }
}