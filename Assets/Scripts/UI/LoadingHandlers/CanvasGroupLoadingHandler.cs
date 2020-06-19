using UnityEngine;

namespace UI.LoadingHandlers
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CanvasGroupLoadingHandler : UILoadingHandler
    {
        [Range(0, 1)] [SerializeField] private float _activeStateAlpha;
        [Range(0, 1)] [SerializeField] private float _inactiveStateAlpha;
        public override void SetIsLoading(bool value)
        {
            CachedWrapper.alpha = value ? _activeStateAlpha : _inactiveStateAlpha;
            CachedWrapper.blocksRaycasts = value;
        }
        
        private CanvasGroup _cachedWrapper;
        private CanvasGroup CachedWrapper
        {
            get
            {
                if (_cachedWrapper == null)
                {
                    _cachedWrapper = gameObject.GetComponent<CanvasGroup>();
                }
                return _cachedWrapper;
            }
        }
    }
}