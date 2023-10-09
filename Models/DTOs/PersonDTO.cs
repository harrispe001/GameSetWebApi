namespace GameSetWebApi.Models.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateOnly Birthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<TeamDTO> Teams { get; set; } = new List<TeamDTO>();
    }
}
