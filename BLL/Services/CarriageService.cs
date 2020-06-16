using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Models;

namespace BLL.Services
{
    public class CarriageService : ICarriageService
    {

        public ICollection<Carriage> GetSpecifiedCarriages(CarriageClass carriageClass, Train train)
        {
            var carriages = train.Carriages.Where(c => c.Class == carriageClass).ToList();
            return carriages;
        }

        public Carriage GetCarriageByNum(Train train, int num)
        {
            return train.Carriages.First(c => c.Number == num);
        }
    }
}