namespace _6Lab.Models
{
    public class PersonModelSimple
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; } = DateOnly.MinValue;
    }
}
