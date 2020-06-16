using System.Collections.Generic;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IInMemoryStorage
    {
        public ICollection<TrainEntity> Trains { get; set; }
        
        public ICollection<TicketEntity> Tickets { get; set; }

        public void Save();
    }
}