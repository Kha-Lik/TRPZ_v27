using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<TrainEntity> TrainRepository { get; }

        public IRepository<TicketEntity> TicketRepository { get; }

        void Save();
    }
}