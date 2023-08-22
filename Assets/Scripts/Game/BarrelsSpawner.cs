using Game.Entities;
using UnityEngine;
using VContainer;


namespace Game
{
    internal sealed class BarrelsSpawner : MonoBehaviour
    {
        [SerializeField] private int barrelsCount = 2;
        [SerializeField] private Barrel barrelPrefab;
        [SerializeField] private Transform spawnRoot;

        [Inject] private GameGrid _grid;
        [Inject] private ExplosionHandler _explosionHandler;

        internal void SpawnBarrels()
        {
            for (int i = 0; i < barrelsCount; i++)
            {
                var barrel = Instantiate(barrelPrefab, spawnRoot);

                var tile = _grid.GetRandomFreeTile();
                _grid.ReserveTile(tile.Coordinates, barrel);
                barrel.transform.position = tile.transform.position;

                barrel.Get<DestroyComponent>().OnDestroy += () => _grid.ReleaseTile(tile.Coordinates);

                var explosion = barrel.Get<ExplosionComponent>();
                explosion.ThisEntity = barrel;
                explosion.Coordinates = tile.Coordinates;
                explosion.Handler = _explosionHandler;
            }
        }
    }
}
