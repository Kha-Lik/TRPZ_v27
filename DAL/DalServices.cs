using System.Configuration;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DalServices
    {
        public static IServiceCollection AddDal(this IServiceCollection services)
        {
            services.AddDbContext<TicketsDbContext>(o =>
                o.UseSqlServer(ConfigurationManager.ConnectionStrings["Tickets"].ConnectionString));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        } 
    }
}