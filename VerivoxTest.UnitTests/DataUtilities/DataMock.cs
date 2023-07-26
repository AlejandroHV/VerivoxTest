using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerivoxTest.Application.Especifications.Responses;
using VerivoxTest.Application.Models.Responses;

namespace VerivoxTest.UnitTests.DataUtilities
{
    public static class DataMock
    {

        public static Response<TariffComparerResponse> CreateTariffResponse(double consumption, string productName)
        {
            var payload =new  List<TariffComparerResponse>();
            payload.Add(new TariffComparerResponse() { Consumption = consumption, ProductName = productName });

            var response = new Response<TariffComparerResponse>();
            response.Payload = payload;

            return response;
        }
    }
}
