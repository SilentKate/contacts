using System;
using UniRx;

namespace Contacts.Login.LoginPage.Data
{
    public class DebugLoginService : ILoginService
    {
        public IObservable<ICredentials> Login(ICredentials credentials)
        {
            return Observable
                .Return(credentials)
                .Delay(TimeSpan.FromSeconds(3));
        }
    }
}