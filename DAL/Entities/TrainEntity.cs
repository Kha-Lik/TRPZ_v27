using System.Collections.Generic;

namespace DAL.Entities
{
    public class TrainEntity : BaseEntity
    {
        public int Number { get; set; }
        public ICollection<CitiesTrains> Cities { get; set; }
        public ICollection<DaysTrains> Dates { get; set; }
        public ICollection<CarriageEntity> Carriages { get; set; }
    }
}