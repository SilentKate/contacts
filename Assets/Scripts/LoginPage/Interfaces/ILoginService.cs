using System;

namespace Contacts.Login.LoginPage
{
    public interface ILoginService
    {
        IObservable<ICredentials> Login(ICredentials credentials);
    }
}