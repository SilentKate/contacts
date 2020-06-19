using TMPro;
using UnityEngine;

namespace UI.LoadingHandlers
{
    [RequireComponent(typeof(TMP_InputField))]
    public class InputFieldLoadingHandler : UILoadingHandler
    {

        public override void SetIsLoading(bool value)
        {
            CachedWrapper.readOnly = value;
        }

        private TMP_InputField _cachedWrapper;
        private TMP_InputField CachedWrapper
        {
            get
            {
                if (_cachedWrapper == null)
                {
                    _cachedWrapper = gameObject.GetComponent<TMP_InputField>();
                }
                return _cachedWrapper;
            }
        }
    }
}