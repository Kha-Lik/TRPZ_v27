using System;

namespace DAL.Entities
{
    public class SeatEntity : BaseEntity
    {
        public int Number { get; set; }
        public bool IsTaken { get; set; }

        public CarriageEntity CarriageEntity { get; set; }

        public int CarriageEntityId { get; set; }
    }
}