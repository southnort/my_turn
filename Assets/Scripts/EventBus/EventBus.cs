using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Events
{
    internal sealed class EventBus
    {
        private readonly Dictionary<Type, IEventHandlersCollection> _handlers = new();

        public void Subscribe<T>(Action<T> handler)
        {
            var eventType = typeof(T);
            if (!_handlers.ContainsKey(eventType))
            {
                _handlers.Add(eventType, new EventHandlersCollection<T>());
            }

            _handlers[eventType].Subscribe(handler);
        }

        public void Unsubscribe<T>(Action<T> handler)
        {
            var eventType = typeof(T);

            if (_handlers.TryGetValue(eventType, out var eventHandlers))
            {
                eventHandlers.Unsubscribe(handler);
            }
        }

        public void PublishEvent<T>(T ev)
        {
            var eventType = ev.GetType();
            Debug.Log(eventType);

            if (!_handlers.TryGetValue(eventType, out var eventHandlers))
            {
                Debug.Log("Is no subscribers");
                return;
            }

            eventHandlers.PublishEvent(ev);
        }

        private interface IEventHandlersCollection
        {
            void Subscribe(Delegate handler);
            void Unsubscribe(Delegate handler);
            void PublishEvent<TEvent>(TEvent ev);
        }


        private sealed class EventHandlersCollection<T> : IEventHandlersCollection
        {
            private readonly List<Delegate> _handlers = new();
            private int _currentIndex = -1;


            void IEventHandlersCollection.Subscribe(Delegate handler)
            {
                _handlers.Add(handler);
            }

            void IEventHandlersCollection.Unsubscribe(Delegate handler)
            {
                var index = _handlers.IndexOf(handler);
                _handlers.RemoveAt(index);

                if (index <= _currentIndex)
                {
                    --_currentIndex;
                }
            }

            void IEventHandlersCollection.PublishEvent<TEvent>(TEvent ev)
            {
                if (ev is not T concreteHandler)
                {
                    return;
                }

                for (_currentIndex = 0; _currentIndex < _handlers.Count; _currentIndex++)
                {
                    var handler = (Action<T>)_handlers[_currentIndex];
                    handler.Invoke(concreteHandler);
                }
                _currentIndex = -1;
            }
        }
    }
}
