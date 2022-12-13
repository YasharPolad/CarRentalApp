using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class SuccessDataResponse<TData> : DataResponse<TData>, IDataResponse<TData>
    {
        public SuccessDataResponse(TData Data) : base(Data, true)
        {
        }
        public SuccessDataResponse(TData Data, string Message) : base(Data, true, Message)
        {
        }
        public SuccessDataResponse(string Message) : base(default, true, Message)
        {
        }

        public SuccessDataResponse() : base(default, true)
        {
        }
    }
}
