using Game.Events;
using Game.Turn;
using UnityEngine;
using VContainer;

namespace Game
{
    internal sealed class SceneInitializer : MonoBehaviour
    {
        [Inject] private GameGrid _grid;
        [Inject] private PlayerProvider _playerProvider;
        [Inject] private EnemySystem _enemySystem;
        [Inject] private TurnRunner _turnRunner;
        [Inject] private EventBus _eventBus;
        [Inject] private BarrelsSpawner _barrelsSpawner;

        private void Start()
        {
            _grid.GenerateGrid();
            InitializePlayer();
            _enemySystem.StartSystem();
            _turnRunner.Run();
        }

        private void InitializePlayer()
        {
            var playerSpawnTile = _grid.GetFreeTileInCenter();
            var player = _playerProvider.Player;
            player.SetEventBus(_eventBus);
            player.transform.position = playerSpawnTile.transform.position;
            player.Get<GridCoordinatesComponent>().GridCoordinates = playerSpawnTile.Coordinates;
            _grid.ReserveTile(playerSpawnTile.Coordinates, player);
            _barrelsSpawner.SpawnBarrels();
        }
    }
}
