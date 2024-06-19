using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Company.Function
{
    public class TimerTrigger1
    {
        private readonly ILogger _logger;

        public TimerTrigger1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TimerTrigger1>();
        }

        [Function("TimerTrigger1")]
        public void Run([TimerTrigger("0 */1 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if(DateTime.Now.Minute % 2 == 1) {
                throw new NotSupportedException("odd minute execution not supported");
            }

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
