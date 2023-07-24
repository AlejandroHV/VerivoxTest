using VerivoxTest.Domain.Models.Entities;

namespace VerivoxTest.Domain.Models.Entities.Implementation
{
    public class BasicElectricityProduct : IProduct
    {
        public string Name { get { return "Basic Electricity Tariff"; } }
        public BasicElectricityProduct()
        {

        }

        public int Calculate(int annualConsumption)
        {
            var anualCost = 0;
            if (annualConsumption != 0)
            {
                anualCost = (5 * 12) + (annualConsumption * 22) / 100;
            }


            return anualCost;
        }

    }
}

