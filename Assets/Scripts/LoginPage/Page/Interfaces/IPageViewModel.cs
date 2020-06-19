using Contacts.Interfaces;
using UniRx;

namespace Contacts.Login.LoginPage
{
    public interface IPageViewModel : IViewModel
    {
        IReadOnlyReactiveProperty<string> Login { get; }
        IReadOnlyReactiveProperty<string> Password { get; }
        
        IReadOnlyReactiveProperty<bool> IsCredentialsProcessing { get; }
        IReadOnlyReactiveProperty<bool> IsLoginProcessing { get; }

        void TryLogin(string login, string password);
    }
}