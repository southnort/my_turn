using UnityEngine;
using VContainer;


namespace Game
{
    internal sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPrefab;
        [SerializeField] private Transform spawnRoot;

        [Inject] private GameGrid _grid;
       


        internal Enemy SpawnEnemy()
        {
            var enemy = Instantiate(enemyPrefab, spawnRoot);

            var tile = _grid.GetRandomFreeTile();            
            enemy.Get<GridCoordinatesComponent>().GridCoordinates = tile.Coordinates;
            _grid.ReserveTile(tile.Coordinates, enemy);
            enemy.transform.position = tile.transform.position;

            return enemy; 
        }
    }
}
