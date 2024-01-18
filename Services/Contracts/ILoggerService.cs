using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILoggerService
    {
        void LogInfo(string Message);
        void LogWarning(string Message);
        void LogError (string Message);
        void LogDebug(string Message);
    }
}
