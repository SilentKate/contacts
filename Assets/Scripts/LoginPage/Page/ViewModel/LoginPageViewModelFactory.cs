using System;
using JetBrains.Annotations;
using Zenject;

namespace Contacts.Login.LoginPage
{
    public class LoginPageViewModelFactory : IFactory<IPageViewModel>
    {
        private readonly ICredentialsProvider _credentialsProvider;
        private readonly ILoginService _loginService;
        
        public LoginPageViewModelFactory(
            [NotNull] ICredentialsProvider credentialsProvider,
            [NotNull] ILoginService loginService)
        {
            _credentialsProvider = credentialsProvider ?? throw new ArgumentNullException(nameof(credentialsProvider));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }
        
        public IPageViewModel Create()
        {
            return new LoginPageViewModel(_credentialsProvider, _loginService);
        }
    }
}