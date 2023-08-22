using Game.Entities;
using Game.Events;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;
using VContainer;

namespace Game
{
    internal sealed class GameGrid : MonoBehaviour
    {
        [SerializeField] private LevelConfig config;
        [SerializeField] private GridSpawner spawner;
        [Inject] private EventBus _eventBus;

        private GridGenerator _generator = new GridGenerator();

        private Dictionary<Vector2Int, GridTile> _tiles;

        private void Start()
        {
            _eventBus.Subscribe<DestroyEvent>(HandleDestroy);
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe<DestroyEvent>(HandleDestroy);
        }

        private void HandleDestroy(DestroyEvent evnt)
        {
            if (evnt.Entity.TryGet<GridCoordinatesComponent>(out var coord))
            {
                ReleaseTile(coord.GridCoordinates);
            }
        }

        internal void GenerateGrid()
        {
            var coordinates = _generator.GenerateTilesMap(config);
            var tiles = spawner.SpawnGrid(coordinates, config.TileSize);
            _tiles = new Dictionary<Vector2Int, GridTile>();


            int index = 0;
            foreach (var coord in coordinates)
            {
                var tile = tiles.ElementAt(index++);
                _tiles.Add(coord, tile);
            }
        }

        internal GridTile GetFreeTileInCenter()
        {
            var coords = new Vector2Int(config.LevelSize.x / 2, config.LevelSize.y / 2);
            while (!_tiles.ContainsKey(coords))
            {
                if (Random.Range(0f, 1f) < 0.5f)
                    coords.x++;
                else coords.y++;
            }

            return _tiles[coords];
        }

        internal GridTile GetRandomFreeTile()
        {
            Vector2Int coords;
            do
            {
                var x = Random.Range(0, config.LevelSize.x);
                var y = Random.Range(0, config.LevelSize.y);
                coords = new Vector2Int(x, y);
            }
            while (!IsTileExists(coords) || IsTileReserved(coords));

            return _tiles[coords];
        }

        internal void ReserveTile(Vector2Int coords, IEntity entity)
        {
            var tile = _tiles[coords];
            if (tile.EntityOnTile != null)
                Debug.LogError("Tile is reserved by: " + tile.EntityOnTile.ToString());

            tile.EntityOnTile = entity;
        }

        internal void ReleaseTile(Vector2Int coords)
        {
            var tile = _tiles[coords];
            tile.EntityOnTile = null;
        }

        internal bool IsTileExists(Vector2Int targetCoords)
        {
            return _tiles.ContainsKey(targetCoords);
        }

        internal bool IsTileReserved(Vector2Int targetCoords)
        {
            return _tiles.ContainsKey(targetCoords)
                && _tiles[targetCoords].EntityOnTile != null;
        }

        internal Vector3 GetPositionOf(Vector2Int coords)
        {
            if (_tiles.TryGetValue(coords, out var tile))
                return tile.transform.position;


            return new Vector3(coords.x * config.TileSize, 0, coords.y * config.TileSize);
        }
    }
}
