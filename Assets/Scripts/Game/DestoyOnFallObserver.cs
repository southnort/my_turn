using Game.Entities;
using UnityEngine;

namespace Game
{
    internal sealed class DestoyOnFallObserver : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IEntity>(out var entity))
            {
                if (entity.TryGet<DestroyComponent>(out var destroy))
                {
                    destroy.Destroy();
                }
            }
        }
    }
}
