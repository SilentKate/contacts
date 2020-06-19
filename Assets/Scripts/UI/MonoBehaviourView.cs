using Contacts.Interfaces;
using UnityEngine;

namespace UI
{
    public abstract class MonoBehaviourView : MonoBehaviour, IView
    {
        public abstract object Context { get; set; }
    }
}