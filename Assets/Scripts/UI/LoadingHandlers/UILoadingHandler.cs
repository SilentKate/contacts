using UnityEngine;

namespace UI.LoadingHandlers
{
    public abstract class UILoadingHandler : MonoBehaviour, ILoadingUIHandler
    {
        public abstract void SetIsLoading(bool value);
    }
}