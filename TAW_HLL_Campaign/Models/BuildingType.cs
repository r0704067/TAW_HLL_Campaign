namespace TAW_HLL_Campaign.Models
{
    public class BuildingType
    {
        public int BuildingTypeID { get; set; }
        public string Name { get; set; }
        public int Tier { get; set; }
        public int? Cost { get; set; }
        public int? Income { get; set; }
        public string? Discription {  get; set; }
    }
}
