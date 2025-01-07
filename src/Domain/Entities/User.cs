namespace Domain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; private set; }
    public string PasswordSalt { get; init; }
    public string Email { get; set; }
    public bool IsAdmin { get; set; }

    public void ChangePassword(string newPasswordHash)
    {
        if (newPasswordHash != PasswordHash) throw new ArgumentException();

        PasswordHash = newPasswordHash;
    }
}