using UI.LoadingHandlers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ext
{
    public static class UIExtentions
    {
        public static void SafeAddListener(this Button button, UnityAction clicked)
        {
            if (button == null) return;
            button.onClick.AddListener(clicked);
        }
        
        public static void SafeRemoveListener(this Button button, UnityAction clicked)
        {
            if (button == null) return;
            button.onClick.RemoveListener(clicked);
        }

        public static void SafeSetActive(this MonoBehaviour target, bool value)
        {
            if (target == null) return;
            target.gameObject.SetActive(value);
        }
        
        public static void SafeSetText(this InputField target, string value)
        {
            if (target == null) return;
            target.text = value;
        }

        public static void SafeIsLoading(this ILoadingUIHandler handler, bool value)
        {
            if (handler == null) return;
            handler.SetIsLoading(value);
        }
    }
}