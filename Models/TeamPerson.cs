namespace GameSetWebApi.Models
{
    public class TeamPerson
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
