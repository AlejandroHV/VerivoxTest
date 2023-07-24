using VerivoxTest.Domain.Models.Entities;


namespace VerivoxTest.Domain.Models.Entities.Implementation
{
    public class PackagedTariffProduct : IProduct
    {
        public string Name { get { return "Packaged Tariff"; } }
        public PackagedTariffProduct()
        {

        }

        public int Calculate(int annualConsumption)
        {
            var anualCost = 0;
            if (annualConsumption != 0)
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