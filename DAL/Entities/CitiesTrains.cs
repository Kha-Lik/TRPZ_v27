namespace DAL.Entities
{
    public class CitiesTrains : BaseEntity
    {
        public TrainEntity TrainEntity { get; set; }
        public int TrainEntityId { get; set; }
        public CityEntity CityEntity { get; set; }
        public int CityEntityId { get; set; }
    }
}