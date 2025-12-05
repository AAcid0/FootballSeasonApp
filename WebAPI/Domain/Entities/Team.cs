namespace WebAPI.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public Categories Category { get; set; }
        public int FoundationDate { get; set; }
        public double Budget { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }

    public enum Categories
    {
        A,
        B,
        C
    }
}