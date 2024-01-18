using NLog;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LoggerManager : ILoggerService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        void ILoggerService.LogDebug(string Message)=>
        
           logger.Debug(Message);
        

        void ILoggerService.LogError(string Message)
        =>
             logger.Error(Message);
        

        void ILoggerService.LogInfo(string Message)
        
            => logger.Info(Message);
        

        void ILoggerService.LogWarning(string Message)
       => logger.Warn(Message);
    }
}
