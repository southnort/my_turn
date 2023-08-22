using Game.Entities;
using UnityEngine;


namespace Game
{
    internal sealed class DamageDealer : MonoBehaviour
    {
        [SerializeField] private int damage;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IEntity>(out var entity))
            {
                if (entity.TryGet<HealthComponent>(out var health))
                {
                    health.Health.Value -= damage;
                }
            }
        }
    }
}
