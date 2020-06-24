using System.Linq;
using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public TicketService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public Ticket TakeTicket(Ticket ticket)
        {
            if (_unit.TicketRepository.GetAll().AsEnumerable().LastOrDefault() != null)
                // ReSharper disable once PossibleNullReferenceException
                ticket.Number = ++_unit.TicketRepository.GetAll().AsEnumerable().LastOrDefault().Number;
            else
                ticket.Number = 1;

            var ticketEntity = _mapper.Map<TicketEntity>(ticket);
            _unit.TicketRepository.Create(ticketEntity);
            _unit.Save();
            return ticket;
        }
    }
}