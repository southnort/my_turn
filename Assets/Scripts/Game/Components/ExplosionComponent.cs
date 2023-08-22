using Game.Entities;
using System.Collections.Generic;
using UnityEngine;


namespace Game
{
    internal sealed class ExplosionComponent : MonoBehaviour
    {
        [SerializeField] int explosionDamage = 3;


        internal Entity ThisEntity;
        internal Vector2Int Coordinates;
        internal ExplosionHandler Handler;


        internal void Explode()
        {
            gameObject.SetActive(true);
            var pos = transform.position;
            pos.y += .5f;
            var targets = Physics.OverlapSphere(transform.position, 1f);
            var exploded = new List<IEntity>();


            for (int i = targets.Length - 1; i >= 0; i--)
            {
                var target = targets[i];
                if (target.TryGetComponent<Entity>(out var entity))
                {
                    if (entity.gameObject.name.Equals(ThisEntity.gameObject.name)) continue;

                    if (entity.TryGet<HealthComponent>(out var healt))
                    {
                        healt.Health.Value -= explosionDamage;
                        if (healt.Health.Value > 0)
                            exploded.Add(entity);
                    }
                }
            }

            Handler.HandleExplosion(Coordinates, exploded);
        }
    }
}
