using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TrainService : ITrainService
    {
        private IInMemoryStorage _inMemoryStorage;
        private IMapper _mapper;

        public TrainService(IInMemoryStorage inMemoryStorage, IMapper mapper)
        {
            _inMemoryStorage = inMemoryStorage;
            _mapper = mapper;
        }

        public ICollection<Train> GetSpecifiedTrains(string source, string destination, DateTime date)
        {
            var trains = _inMemoryStorage.Trains.Where(t =>
                t.Cities.Contains(source) && t.Cities.Contains(destination) && t.Dates.Contains(date.Date));
            return _mapper.Map<ICollection<Train>>(trains);
        }

        public Train GetTrainByNum(int num)
        {
            var train = _inMemoryStorage.Trains.First(t => t.Number == num);
            return _mapper.Map<Train>(train);
        }
    }
}