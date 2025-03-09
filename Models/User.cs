namespace ELNET01.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Fixes Warning
        public string Email { get; set; } = string.Empty; // Fixes Warning
    }
}
