using System;

namespace Contacts.Login.LoginPage
{
    public interface ICredentialsProvider
    {
        IObservable<ICredentials> GetCredentials();
        ICredentials CreateCredentials(string login, string password);
    } 
    
    public interface ICredentials
    {
        string Login { get; }
        string Password { get; }
    }
}