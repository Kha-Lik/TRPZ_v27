using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL
{
    public interface ITrainService
    {
        public ICollection<Train> GetSpecifiedTrains(string source, string destination, DateTime date);
        public Train GetTrainByNum(int num);
    }
}