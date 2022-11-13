using ApiGest.Application.Common.Interfaces.Services;

namespace ApiGest.Infrastructure.Services
{
    public class DateTimeProvider: IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}