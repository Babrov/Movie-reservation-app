namespace Domain.Entities;

public class User : BaseEntity, IAggregateRoot
{
    public User(string email, string passwordHash, string firstName, string lastName)
    {
        Email = email;
        PasswordHash = passwordHash;
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string PasswordHash { get; private set; }
    public string Email { get; set; }

    public bool IsAdmin { get; set; } = false;

    public void ChangePassword(string newPasswordHash)
    {
        if (newPasswordHash != PasswordHash) throw new ArgumentException();

        PasswordHash = newPasswordHash;
    }
}