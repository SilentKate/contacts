using Ext;
using TMPro;
using UI;
using UI.LoadingHandlers;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Contacts.Login.LoginPage
{
    public class LoginPageView : MonoBehaviourContextView<IPageViewModel>
    {
        [SerializeField] private UILoadingHandler _loginLoadingHandler;
        [SerializeField] private InputFieldLoadingHandler[] _credentialsLoadingHandlers;
        
        [SerializeField] private TMP_InputField _loginField;
        [SerializeField] private TMP_InputField _passwordField;
        [SerializeField] private Button _loginButton;
       
        private CompositeDisposable _subscriptions;

        protected override void OnContextDetached(IPageViewModel context)
        {
            _loginButton.SafeRemoveListener(OnLoginClicked);
        }

        protected override void OnContextAttached(IPageViewModel context)
        {
            _loginButton.SafeAddListener(OnLoginClicked);
            
            _subscriptions = new CompositeDisposable();
            context.Login
                .Subscribe(value => { _loginField.text = value; })
                .AddTo(_subscriptions);
            
            context.Password
                .Subscribe(value => { _passwordField.text = value; })
                .AddTo(_subscriptions);

            context.IsCredentialsProcessing
                .Subscribe(value =>
                {
                    foreach (var handler in _credentialsLoadingHandlers)
                    {
                        handler.SafeIsLoading(value); 
                    }
                })
                .AddTo(_subscriptions);
            
            context.IsLoginProcessing
                .Subscribe(value => { _loginLoadingHandler.SafeIsLoading(value); })
                .AddTo(_subscriptions);
        }

        private void OnLoginClicked()
        {
            TypedContext.TryLogin(_loginField.text, _passwordField.text);
        }
    }
}