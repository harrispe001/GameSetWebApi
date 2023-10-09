namespace GameSetWebApi.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public ICollection<TeamPerson> TeamPerson { get; set; } = new List<TeamPerson>();
    }
}
