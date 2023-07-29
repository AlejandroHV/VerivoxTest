using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Application.Especifications.Factories.Interfaces;
using VerivoxTest.Application.Models.Enums;
using VerivoxTest.Domain.Models.Entities.Implementation;
using VerivoxTest.Domain.Models.Entities.Interfaces;

namespace VerivoxTest.Application.Especifications.Factories
{
    public class ProductFactory : IFactory<IProduct>
    {
        public IProduct? _instance { get; set; }

        public ProductFactory() { }


        public IProduct? Create(int entityType)
        {
            var entityEnumType = (ProductTypeEnum)entityType;
            switch (entityEnumType)
            {

                case ProductTypeEnum.BasicTarif:

                    _instance = new BasicElectricityProduct();
                    break;
                case ProductTypeEnum.PackagedTariff:
                    _instance = new PackagedTariffProduct();
                    break;
                default:
                    _instance = null;
                    break;

            }
            return _instance;
        }
    }
}
