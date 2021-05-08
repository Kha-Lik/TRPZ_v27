using DAL.Entities;
using DAL.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TicketsDbContext _context;

        public UnitOfWork(IRepository<TrainEntity> trainRepository, IRepository<TicketEntity> ticketRepository,
            TicketsDbContext context)
        {
            TrainRepository = trainRepository;
            TicketRepository = ticketRepository;
            _context = context;
        }

        public IRepository<TrainEntity> TrainRepository { get; }

        public IRepository<TicketEntity> TicketRepository { get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}