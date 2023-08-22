using UnityEngine;


namespace Game.Entities
{
    internal sealed class Barrel : Entity
    {
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private ExplosionComponent explosion;

        private void Awake()
        {
            var destroy = new DestroyComponent(() => Destroy(gameObject));
            Add(destroy);

            healthComponent.OnDie.AddListener(explosion.Explode);
            healthComponent.OnDie.AddListener(destroy.Destroy);
            Add(healthComponent);
            

            Add(new GridCoordinatesComponent());
            Add(explosion);
        }
    }
}
