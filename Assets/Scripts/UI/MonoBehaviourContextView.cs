using Contacts.Interfaces;

namespace UI
{
    public abstract class MonoBehaviourContextView<T> : MonoBehaviourView where T : class, IViewModel
    {
        public override object Context
        {
            get => TypedContext;
            set
            {
                if (TypedContext != null)
                {
                    OnContextDetached(TypedContext);
                    TypedContext.Deinit();
                }
                TypedContext = value as T;

                if (TypedContext != null)
                {
                    
                    TypedContext.Init();
                    OnContextAttached(TypedContext);
                }
            }
        }
        
        
        public T TypedContext { get; private set; }

        protected abstract void OnContextDetached(T context);
        protected abstract void OnContextAttached(T context);
    }
}