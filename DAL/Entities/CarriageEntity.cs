using System.Collections.Generic;

namespace DAL.Entities
{
    public class CarriageEntity
    {
        public int Number { get; set; }
        public CarriageClass Class { get; set; }
        public ICollection<SeatEntity> Seats { get; set; }
    }
}