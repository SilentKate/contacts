using System;
using UniRx;

namespace Contacts.Login.LoginPage.Data
{
    public class DebugCredentialsProvider : ICredentialsProvider
    {
        public IObservable<ICredentials> GetCredentials()
        {
            var result = new DebugCredentials("ololoshenko", "1234");
            return Observable
                .Return(result).
                Delay(TimeSpan.FromSeconds(5));
        }

        public ICredentials CreateCredentials(string login, string password)
        {
            return new DebugCredentials(login, password);
        }
    }
}