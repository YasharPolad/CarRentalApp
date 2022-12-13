using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class ErrorResponse : Response, IResponse
    {
        public ErrorResponse() : base(false)
        {
        }

        public ErrorResponse(string Message) : base(false, Message)
        {
        }
    }
}
