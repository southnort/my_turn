using Game.Events;
using Game.UI;
using System;
using VContainer;
using VContainer.Unity;
using Yrr.UI;

namespace Game
{
    internal sealed class PlayerDieObserver : IInitializable, IDisposable
    {
        [Inject] private UIManager _uiManager;
        [Inject] private EventBus _eventBus;


        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<DestroyEvent>(CheckDestroy);
        }
        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<DestroyEvent>(CheckDestroy);
        }

        private void CheckDestroy(DestroyEvent evnt)
        {
            if (evnt.Entity is Player)
            {
                _uiManager.GoToScreen<GameOverScreen>();
            }
        }
    }
}
