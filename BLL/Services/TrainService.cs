using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class TrainService : ITrainService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public TrainService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public ICollection<Train> GetSpecifiedTrains(string source, string destination, DateTime date)
        {
            var trains = _unit.TrainRepository.GetAll()
                .Include(t => t.Cities)
                .Include(t => t.Dates)
                .Include(t => t.Carriages)
                .ThenInclude(c => c.Seats).Where(t =>
                    t.Cities.Any(c => c.CityEntity.Name.Equals(source)) &&
                    t.Cities.Any(c => c.CityEntity.Name.Equals(destination)) &&
                    t.Dates.Any(d => d.Day.Date.Equals(date.Date))).ToList();
            return _mapper.Map<ICollection<Train>>(trains);
        }

        public Train GetTrainByNum(int num)
        {
            var train = _unit.TrainRepository.GetAll().Include(t => t.Carriages)
                .ThenInclude(c => c.Seats).First(t => t.Number == num);
            return _mapper.Map<Train>(train);
        }
    }
}