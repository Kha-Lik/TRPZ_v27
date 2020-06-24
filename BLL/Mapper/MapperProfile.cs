using System.Linq;
using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TrainEntity, Train>()
                .ForMember(t => t.Cities, opt =>
                    opt.MapFrom(te => te.Cities.Select(c => c.CityEntity)))
                .ForMember(t => t.Dates, opt => 
                    opt.MapFrom(te => te.Dates.Select(d => d.Day)));
            CreateMap<Train, TrainEntity>()
                .ForMember(te => te.Cities, opt =>
                    opt.MapFrom(t => t.Cities.Select(c => new CitiesTrains {CityEntityId = c.Id})))
                .ForMember(te => te.Dates, opt =>
                    opt.MapFrom(t => t.Dates.Select(d => new DaysTrains {DayId = d.Id})));
            CreateMap<CarriageEntity, Carriage>().ReverseMap();
            CreateMap<SeatEntity, Seat>().ReverseMap();
            CreateMap<TicketEntity, Ticket>().ReverseMap();
            CreateMap<City, CityEntity>().ReverseMap();
            CreateMap<Day, DayEntity>().ReverseMap();
        }
    }
}