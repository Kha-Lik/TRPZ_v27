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
            var carriages = train.Carriages.Where(c => c.Class.Equals(carriageClass));
            return carriages as ICollection<Carriage>;
        }

        public Carriage GetCarriageByNum(Train train, int num)
        {
            return train.Carriages.First(c => c.Number == num);
        }
    }
}