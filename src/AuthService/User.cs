using Shared;

namespace AuthService;

public class User : BaseEntity, IAggregateRoot
{
    public User(string email, string passwordHash, string firstName, string lastName)
    {
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        LastName = lastName;
    }

    private User()
    {
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public string PasswordHash { get; private set; }
    public string Email { get; set; }

    public bool IsAdmin { get; set; } = false;
    public bool IsActive { get; set; } = true;

    public void ChangePassword(string newPasswordHash)
    {
        if (newPasswordHash != PasswordHash) throw new ArgumentException();

        PasswordHash = newPasswordHash;
    }
}