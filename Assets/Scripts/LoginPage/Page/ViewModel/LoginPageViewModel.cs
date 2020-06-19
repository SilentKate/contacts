using System;
using JetBrains.Annotations;
using UniRx;

namespace Contacts.Login.LoginPage
{
    public class LoginPageViewModel : IPageViewModel
    {
        public IReadOnlyReactiveProperty<string> Login => _login;
        private readonly ReactiveProperty<string> _login = new ReactiveProperty<string>();

        public IReadOnlyReactiveProperty<string> Password => _password;
        private readonly ReactiveProperty<string> _password = new ReactiveProperty<string>();

        public IReadOnlyReactiveProperty<bool> IsCredentialsProcessing => _isCredentialsProcessing;
        private readonly ReactiveProperty<bool> _isCredentialsProcessing = new ReactiveProperty<bool>();

        public IReadOnlyReactiveProperty<bool> IsLoginProcessing => _isLoginProcessing;

        private readonly ReactiveProperty<bool> _isLoginProcessing = new ReactiveProperty<bool>();
        
        private readonly ICredentialsProvider _credentialsProvider;
        private readonly ILoginService _loginService;
        private CompositeDisposable _subscriptions;

        public LoginPageViewModel(
            [NotNull] ICredentialsProvider credentialsProvider,
            [NotNull] ILoginService loginService)
        {
            _credentialsProvider = credentialsProvider ?? throw new ArgumentNullException(nameof(credentialsProvider));
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
        }
       
        public void Deinit()
        {
            _subscriptions?.Dispose();
        }

        public void Init()
        {
            _subscriptions = new CompositeDisposable();
            RefreshCredentials();
        }

        public void TryLogin(string login, string password)
        {
            if (!CanStartRequest) return;
            _isLoginProcessing.Value = true;
            
            _login.Value = login;
            _password.Value = password;
            
            _loginService
                .Login(_credentialsProvider.CreateCredentials(_login.Value, _password.Value))
                .Subscribe(CompleteLoginRequest)
                .AddTo(_subscriptions);
        }
        
        private void RefreshCredentials()
        {
            if (!CanStartRequest) return;
            _isCredentialsProcessing.Value = true;
            
            _credentialsProvider
                .GetCredentials()
                .Subscribe(CompleteCredentialsRequest)
                .AddTo(_subscriptions);
        }

        private void CompleteLoginRequest(ICredentials credentials)
        {
            _isLoginProcessing.Value = false;
        }
        
        private void CompleteCredentialsRequest(ICredentials credentials)
        {
            _isCredentialsProcessing.Value = false;
            _login.Value = credentials.Login;
            _password.Value = credentials.Password;
        }

        private bool CanStartRequest => !_isCredentialsProcessing.Value && !_isLoginProcessing.Value;
    }
}