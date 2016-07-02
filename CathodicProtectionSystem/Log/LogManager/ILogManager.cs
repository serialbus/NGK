using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.LogManager
{
    public interface ILogManager
    {
        void Info(string message);
        void Error(string message);
        void FatalException(string message, Exception exception);
    }
}