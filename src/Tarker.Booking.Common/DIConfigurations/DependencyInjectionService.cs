using Microsoft.Extensions.DependencyInjection;

namespace Tarker.Booking.Common.DIConfigurations
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddCommon(this IServiceCollection services)
        {
            return services;
        }
    }
}
