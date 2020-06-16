using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TrainEntity, Train>().ReverseMap();
            CreateMap<CarriageEntity, Carriage>().ReverseMap();
            CreateMap<SeatEntity, Seat>().ReverseMap();
            CreateMap<TicketEntity, Ticket>().ReverseMap();
        }
    }
}