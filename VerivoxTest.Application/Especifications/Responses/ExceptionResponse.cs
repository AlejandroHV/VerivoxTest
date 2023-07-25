namespace VerivoxTest.Application.Especifications.Responses
{
    public class ExceptionResponse
    {

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string ExceptionMessage { get; set; }

        public ExceptionResponse()
        {

        }

        public ExceptionResponse(string message, string stackTrace, string exceptionMessage)
        {
            Message = message;
            StackTrace = stackTrace;
            ExceptionMessage = exceptionMessage;
        }

    }
}

