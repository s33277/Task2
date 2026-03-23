using APBD_TASK2.Enum;

namespace APBD_TASK2.Models
{
    public class User
    {
        private static int _nextId = 1;
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        private string Email { get; set; } = null!;
        public UserType Type { get; set; }

        public User(string firstName, string lastName, string email, UserType type)
        {
            Id = _nextId++;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Type = type;
        }

        public int MaxActiveRentals => Type switch
        {
            UserType.Student => 2,
            UserType.Employee => 5,
            _ => 0
        };
    }
}

