using System.Linq;
using AutoMapper;
using BLL.Models;
using DAL;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TicketService : ITicketService
    {
        private IInMemoryStorage _inMemoryStorage;
        private ITrainService _trainService;
        private ICarriageService _carriageService;
        private IMapper _mapper;

        public TicketService(IInMemoryStorage inMemoryStorage, IMapper mapper, ITrainService trainService, ICarriageService carriageService)
        {
            _inMemoryStorage = inMemoryStorage;
            _mapper = mapper;
            _trainService = trainService;
            _carriageService = carriageService;
        }

        public Ticket TakeTicket(Ticket ticket)
        {
            if (_inMemoryStorage.Tickets.LastOrDefault() != null)
                // ReSharper disable once PossibleNullReferenceException
                ticket.Number = ++_inMemoryStorage.Tickets.LastOrDefault().Number;
            else
                ticket.Number = 1;

            var seat = _carriageService.GetCarriageByNum(_trainService.GetTrainByNum(ticket.TrainNumber),
                ticket.CarriageNumber).Seats.First(s => s.Number == ticket.Seat);
            seat.IsTaken = true;

            var ticketEntity = _mapper.Map<TicketEntity>(ticket);
            _inMemoryStorage.Tickets.Add(ticketEntity);
            return ticket;
        }
    }
}