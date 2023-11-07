namespace TAW_HLL_Campaign.Models
{
    public class Team
    {
        
        public int TeamID { get; set; }
        public string Name { get; set; }

        public Stockpile? Stockpile { get; set; }
        public ICollection<Sector>? Sectors { get; set; }
    }
}
