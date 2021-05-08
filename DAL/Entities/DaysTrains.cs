namespace DAL.Entities
{
    public class DaysTrains : BaseEntity
    {
        public DayEntity Day { get; set; }

        public int DayId { get; set; }

        public TrainEntity TrainEntity { get; set; }

        public int TrainEntityId { get; set; }
    }
}