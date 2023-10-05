namespace GameSetWebApi.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<TeamPerson> TeamPersons { get; set; } = new List<TeamPerson>();

    }
}
