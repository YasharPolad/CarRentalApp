using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public interface IDataResponse<TData> : IResponse
    {
        TData Data { get; }
    }
}
