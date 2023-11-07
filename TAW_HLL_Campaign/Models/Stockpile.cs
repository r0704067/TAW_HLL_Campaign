using System.ComponentModel.DataAnnotations.Schema;

namespace TAW_HLL_Campaign.Models
{
    public class Stockpile
    {
        public int StockpileID { get; set; }
        public int TotalSupplies { get; set; }
        public int TotalVictoryPoints { get; set; }
        public int TeamID { get; set; }
        
    }
}
