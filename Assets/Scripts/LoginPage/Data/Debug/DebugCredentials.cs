namespace Contacts.Login.LoginPage
{
    public class DebugCredentials : ICredentials
    {
        public string Login { get; }
        public string Password { get; }

        public DebugCredentials(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}