using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class ErrorDataResponse<TData> : DataResponse<TData>, IDataResponse<TData>
    {
        public ErrorDataResponse(TData Data) : base(Data, false)
        {
        }
        public ErrorDataResponse(TData Data, string Message) : base(Data, false, Message)
        {
        }
        public ErrorDataResponse(string Message) : base(default, false, Message)
        {
        }

        public ErrorDataResponse() : base(default, false)
        {
        }
    }
}
