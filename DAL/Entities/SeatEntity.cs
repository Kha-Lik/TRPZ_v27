using System;

namespace DAL.Entities
{
    [Serializable]
    public class SeatEntity
    {
        public int Number { get; set; }
        public bool IsTaken { get; set; }
    }
}