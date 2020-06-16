using System.Linq;
using BLL.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class SeatService : ISeatService
    {
        public void TakeSeat(Seat seat)
        {
            seat.IsTaken = true;
        }
    }
}