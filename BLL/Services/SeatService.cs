using BLL.Models;

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