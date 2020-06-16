using BLL.Mapper;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class BllServices
    {
        public static IServiceCollection AddBll(this IServiceCollection services)
        {
            services.BindMapper();
            services.AddTransient<ICarriageService, CarriageService>()
                .AddTransient<ITrainService, TrainService>()
                .AddTransient<ITicketService, TicketService>()
                .AddTransient<ISeatService, SeatService>();
            return services;
        }
    }
}