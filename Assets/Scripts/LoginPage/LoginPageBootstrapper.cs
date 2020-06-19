using Contacts.Login.LoginPage.Data;
using Zenject;

namespace Contacts.Login.LoginPage
{
    public class LoginPageBootstrapper
    {
        private DiContainer _container;
        public DiContainer Bootstrap()
        {
            if (_container != null) return _container;
            _container = new DiContainer();
            _container
                .Bind<IPageViewModel>()
                .FromFactory<LoginPageViewModelFactory>()
                .AsTransient();
            
            _container
                .Bind<ICredentialsProvider>()
                .To<DebugCredentialsProvider>()
                .AsTransient();
            
            _container
                .Bind<ILoginService>()
                .To<DebugLoginService>()
                .AsTransient();
            
            return _container;
        }
    }
}