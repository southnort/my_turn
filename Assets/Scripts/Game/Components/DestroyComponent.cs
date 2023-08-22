using System;

namespace Game
{
    internal class DestroyComponent
    {
        public event Action OnDestroy;
        private Action _destroyAction;

        public DestroyComponent(Action destroyAction)
        {
            _destroyAction = destroyAction;
        }

        internal virtual void Destroy()
        {
            OnDestroy?.Invoke();
            _destroyAction?.Invoke();
        }
    }
}
