namespace TAW_HLL_Campaign.Models
{
    public enum Nation
    {
        Americans, Germans
    }
    public class Team
    {
        
        public int TeamID { get; set; }
        public string Name { get; set; }
        public Nation Nation { get; set; }

        public Stockpile? Stockpile { get; set; }
        public ICollection<Sector>? Sectors { get; set; }
    }
}
