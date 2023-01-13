using CleanArchitectureTemplate.Application.Common.Interfaces.Services;

namespace CleanArchitectureTemplate.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}