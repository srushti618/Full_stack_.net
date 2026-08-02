public class LoginFailedException : Exception 
{
    public LoginFailedException() : base("Login failed after 3 attempts.") { }
}