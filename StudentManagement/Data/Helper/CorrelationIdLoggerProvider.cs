using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json;
using Org.BouncyCastle.Security;
using System.Security.Authentication.ExtendedProtection;

namespace StudentManagement.Data.Helper
{
    public class CorrelationIdLoggerProvider : ILoggerProvider
    { 
        private readonly HttpContextAccessor _httpContextAccessor;
        public CorrelationIdLoggerProvider()
        {
            _httpContextAccessor =new  HttpContextAccessor();
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new CorrelationIdLogger(_httpContextAccessor);
        }

        public void Dispose()
        {
            
        }
    }

    public class CorrelationIdLogger:ILogger
    {
        private readonly HttpContextAccessor _httpResponseContextAccessor;
        public CorrelationIdLogger(HttpContextAccessor httpContextAccessor)
        {
            _httpResponseContextAccessor = httpContextAccessor;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var correlationId = _httpResponseContextAccessor?.HttpContext?.Request?.Headers["X-Correalation-ID"].ToString()??
                                    Guid.NewGuid().ToString();
            if (string.IsNullOrEmpty(correlationId)||string.IsNullOrWhiteSpace(correlationId))
            {
                correlationId = Guid.NewGuid().ToString();
            }

            var loggerInfo = new LoggerInfo
            {
                Message = "Student Management",
                Description=formatter(state,exception),
                CorrelationId=correlationId,
                RequestId=Guid.NewGuid().ToString(),
                EventTime=DateTime.Now,
                ServiceName="Student Management"
            };
            var message = JsonConvert.SerializeObject(loggerInfo, Formatting.None);
            Console.WriteLine(message);
        }
    }
}
