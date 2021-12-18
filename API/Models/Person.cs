namespace TwitterApp.Models;

public class SignUpModel
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public GenderType Gender { get; set; }
    public DateTime Birthday { get; set; }
    public string Password { get; set; }
}

public enum GenderType
{
    Male, Female
}

public class SignInModel
{
    public string UserName { get; set; }
    public string Password { get; set; }
}