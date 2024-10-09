namespace MVCFifa.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        public string TeamId { get; set; }
        public string PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
