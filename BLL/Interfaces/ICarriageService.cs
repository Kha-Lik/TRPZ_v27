using System.Collections.Generic;
using BLL.Models;

namespace BLL
{
    public interface ICarriageService
    {
        public ICollection<Carriage> GetSpecifiedCarriages(CarriageClass carriageClass, Train train);
        public Carriage GetCarriageByNum(Train train, int num);
    }
}