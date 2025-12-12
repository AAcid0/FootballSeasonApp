namespace WebAPI.Domain.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public long DocumentNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public Team Team { get; set; } = new Team();
        public int Age { get; set; }
        public int GoalsScored { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public int Position { get; set; }
        public bool IsInjured { get; set; }
    }
}