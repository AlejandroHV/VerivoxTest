using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerivoxTest.Application.Especifications.Responses
{
    public class ValidationResponse
    {
        public List<string> Messages { get; set; }
        public ValidationResponse()
        {
            Messages = new List<string>();
        }

        public ValidationResponse(List<string> messages)
        {
            Messages = messages;
        }
    }
}
