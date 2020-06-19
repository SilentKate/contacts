using Contacts.Interfaces;
using UI;
using UnityEngine;
using Zenject;

namespace Contacts.Login.LoginPage
{
    public class LoginPageLoader : MonoBehaviour
    {
        [SerializeField] private MonoBehaviourView _view;
        
        private LoginPageBootstrapper _bootstrapper;

        private void OnDestroy()
        {
            _bootstrapper = null;
            if (_view != null)
            {
                _view.Context = null;
            }
        }

        private void Awake()
        {
            _bootstrapper = new LoginPageBootstrapper();
            if (_view == null) return;
            var viewModel = _bootstrapper.Bootstrap().Resolve<IPageViewModel>();
            _view.Context = viewModel;
        }
    }
}