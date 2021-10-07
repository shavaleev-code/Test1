namespace Client.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }
    }

    public static class AuthentificatedUser
    {
        public static int Id { get; set; }

        public static string Email { get; set; }
    }
}
