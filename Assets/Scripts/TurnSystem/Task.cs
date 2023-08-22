using System;

namespace Game.Turn
{
    internal abstract class Task
    {
        private Action<Task> _callback;
        public void Run(Action<Task> callback)
        {
            _callback = callback;
            OnRun();
        }

        protected abstract void OnRun();

        protected virtual void Finish()
        {
            if (_callback is not null)
            {
                var callback = _callback;
                _callback = null;

                callback.Invoke(this);
            }

            OnFinish();
        }

        protected virtual void OnFinish() { }
    }
}
