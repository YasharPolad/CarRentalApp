using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class Response : IResponse
    {
        public Response(bool IsSuccess)
        {
            this.IsSuccess = IsSuccess;
        }
        public Response(bool IsSuccess, string Message)
        {
            this.IsSuccess = IsSuccess;
            this.Message = Message;
        }
        public bool IsSuccess { get; }

        public string Message { get; }
    }
}
