using System.Collections.Generic;
using UnityEngine;
using Yrr.Utils;

namespace Game
{
    internal sealed class GridSpawner : MonoBehaviour
    {
        [SerializeField] private GridTile tilePrefab;
        [SerializeField] private Transform tilesRoot;

        internal List<GridTile> SpawnGrid(IEnumerable<Vector2Int> coordinates, float distanceBetweenTiles)
        {
            tilesRoot.ClearChildren();

            var result = new List<GridTile>();
            foreach (var c in coordinates)
            {
                var tile = Instantiate(tilePrefab, tilesRoot);
                tile.SetCoordinates(c);
                tile.transform.localPosition = new Vector3(
                    c.x * distanceBetweenTiles,
                    0,
                    c.y * distanceBetweenTiles);
                result.Add(tile);
            }

            return result;
        }
    }
}
