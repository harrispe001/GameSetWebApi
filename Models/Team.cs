namespace GameSetWebApi.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public ICollection<TeamPerson> TeamPersons { get; set; } = new List<TeamPerson>();
    }
}
