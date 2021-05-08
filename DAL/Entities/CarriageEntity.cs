using System.Collections.Generic;

namespace DAL.Entities
{
    public class CarriageEntity : BaseEntity
    {
        public int Number { get; set; }
        public CarriageClass Class { get; set; }
        public ICollection<SeatEntity> Seats { get; set; }

        public TrainEntity Train { get; set; }

        public int TrainId { get; set; }
    }
}