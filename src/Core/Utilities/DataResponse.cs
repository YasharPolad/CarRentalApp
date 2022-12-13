using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class DataResponse<TData> : Response, IDataResponse<TData>
    {
        public DataResponse(TData Data, bool IsSuccess) : base(IsSuccess)
        {
            this.Data = Data;
        }

        public DataResponse(TData Data ,bool IsSuccess, string Message) : base(IsSuccess, Message)
        {
            this.Data = Data;
        }

        public TData Data { get; }
    }
}
