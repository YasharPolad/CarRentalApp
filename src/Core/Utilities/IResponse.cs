using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public interface IResponse
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
