using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class SuccessResponse : Response, IResponse
    {
        public SuccessResponse() : base(true)
        {
        }

        public SuccessResponse(string Message) : base(true, Message)
        {
        }
    }
}
