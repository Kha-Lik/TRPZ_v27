using System.Collections.Generic;

namespace BLL.Models
{
    public class Carriage
    {
        public int Number { get; set; }
        public CarriageClass Class { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}