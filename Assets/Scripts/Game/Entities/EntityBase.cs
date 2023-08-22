using Game.Entities;
using Game.Events;
using UnityEngine;

namespace Game
{
    internal abstract class EntityBase : Entity
    {
        [SerializeField] private HealthComponent healthComponent;
        private EventBus _eventBus;

        public void Awake()
        {
            Initialize();
        }

        internal void SetEventBus(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        protected virtual void Initialize()
        {
            Add(new TransformComponent(transform));
            Add(new GridCoordinatesComponent());

            Add(new MoveComponent(transform));
            Add(new RotateComponent(transform));
            Add(new FallComponent(transform));
            Add(healthComponent);


            var destroy = new DestroyComponent(DestroyEntity);
            Add(destroy);

            healthComponent.OnDie.AddListener(destroy.Destroy);
        }

        private void DestroyEntity()
        {
            _eventBus.PublishEvent(new DestroyEvent(this));
            Destroy(gameObject);
        }
    }
}
