namespace Tools
{
    using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

    public class Juggler : MonoBehaviour
    {
        public static Juggler Instance => _instance ? _instance : CreateJuggler();
        private static Juggler _instance;

        private readonly List<IAnimateHandler> _animateHandlers = new List<IAnimateHandler>();
        private readonly List<IUpdateHandler> _updateHandlers = new List<IUpdateHandler>();

        private readonly List<IAnimateHandler> _removedAnimateHandlers = new List<IAnimateHandler>();
        private readonly List<IUpdateHandler> _removedUpdateHandlers = new List<IUpdateHandler>();

        private bool _isUpdateInProcess = false;
        private bool _isAnimateInProcess = false;

        private static Juggler CreateJuggler()
        {
            var jugglerObject = new GameObject("Juggler");
            _instance = jugglerObject.AddComponent<Juggler>();
            return _instance;
        }

        public void Add(IAnimateHandler animateHandler, bool safe = false)
        {
            if (safe && _animateHandlers.Contains(animateHandler)) return;
            _animateHandlers.Add(animateHandler);
        }

        public void Add(IUpdateHandler updateHandler, bool safe = false)
        {
            if (safe && _updateHandlers.Contains(updateHandler)) return;
            _updateHandlers.Add(updateHandler);
        }

        public void Remove(IAnimateHandler animateHandler)
        {
            if (_isAnimateInProcess)
            {
                _removedAnimateHandlers.Add(animateHandler);
            }
            else
            {
                _animateHandlers.Remove(animateHandler);
            }
        }

        public void Remove(IUpdateHandler updateHandler)
        {
            if (_isUpdateInProcess)
            {
                _removedUpdateHandlers.Add(updateHandler);
            }
            else
            {
                _updateHandlers.Remove(updateHandler);
            }
        }

        [UsedImplicitly]
        private void Update()
        {
            if (_animateHandlers.Count == 0 && _updateHandlers.Count == 0)
            {
                _isUpdateInProcess = false;
                _isAnimateInProcess = false;
                return;
            }
            
            var dt = Time.deltaTime;

            _isUpdateInProcess = true;
            foreach (var updateHandler in _updateHandlers)
            {
                updateHandler.Update();
            }
            _isUpdateInProcess = false;

            foreach (IUpdateHandler updateHandler in _removedUpdateHandlers)
            {
                _updateHandlers.Remove(updateHandler);
            }
            _removedUpdateHandlers.Clear();

            _isAnimateInProcess = true;
            foreach (var animateHandler in _animateHandlers)
            {
                animateHandler.AdvanceTime(dt);
            }
            _isAnimateInProcess = false;

            foreach (IAnimateHandler animateHandler in _removedAnimateHandlers)
            {
                _animateHandlers.Remove(animateHandler);
            }
            _removedAnimateHandlers.Clear();
        }
    }
}

public interface IAnimateHandler
{
    void AdvanceTime(float dt);
}

public interface IUpdateHandler
{
    void Update();
}