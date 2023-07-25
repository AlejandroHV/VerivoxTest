using System.Collections.Generic;

namespace VerivoxTest.Application.Especifications.Responses
{
    public class Response<T>
    {
        public List<T> Payload { get; set; }

        public int ItemCount { get; set; }



    }
}

