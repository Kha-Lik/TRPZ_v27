using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    [Serializable]
    public class TrainEntity
    {
        public int Number { get; set; }
        public ICollection<string> Cities { get; set; }
        public ICollection<DateTime> Dates { get; set; }
        public ICollection<CarriageEntity> Carriages { get; set; }
    }
}