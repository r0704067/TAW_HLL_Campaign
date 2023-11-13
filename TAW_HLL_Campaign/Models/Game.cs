namespace TAW_HLL_Campaign.Models
{
    public enum Status
    {
        Active, Finished
    }
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public int CurrentTurn { get; set; }
        public Status Status { get; set; }
    }
}
