namespace TAW_HLL_Campaign.Models
{
    public class Sector
    {   public int SectorId { get; set; }
        public string Name { get; set; }
        public int SuppliesIncome { get; set; }
        public int VictoryPoints { get; set; }
        public int BuildSlots {  get; set; }
        public int? TeamID { get; set; }
    }
}
