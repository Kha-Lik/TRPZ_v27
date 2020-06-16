using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DalServices
    {
        public static IServiceCollection AddDal(this IServiceCollection services)
        {
            services.AddScoped<IInMemoryStorage, InMemoryStorage>();
            services.AddTransient<ISerializer, BinarySerializer>();
            return services;
        } 
    }
}