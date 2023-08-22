using Game.Entities;
using Game.Events;
using UnityEngine;


namespace Game
{
    internal sealed class Bullet : Entity
    {
        [SerializeField] private Timer timer;
        public int Damage { get; set; }
        private bool _isActive;


        private void Start()
        {
            var destroy = new DestroyComponent(DestroyEntity);
            timer.OnTimerEnd.AddListener(destroy.Destroy);
            Add(destroy);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!_isActive) return;

            if (other.TryGetComponent<IEntity>(out var entity))
            {
                if (entity.TryGet<HealthComponent>(out var health))
                {
                    health.Health.Value -= Damage;
                    Get<DestroyComponent>().Destroy();
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _isActive = true;
        }

        private void DestroyEntity()
        {
            Destroy(gameObject);
        }
    }
}
