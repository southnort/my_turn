using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    internal sealed class GridGenerator
    {
        internal IEnumerable<Vector2Int> GenerateTilesMap(LevelConfig config)
        {
            HashSet<Vector2Int> coordinates = new();

            var totalCount = config.LevelSize.x * config.LevelSize.y;
            var tilesCount = Mathf.Min(totalCount, config.TilesCount);

            while (tilesCount > 0)
            {
                var coordinateX = Random.Range(0, config.LevelSize.x);
                var coordinateY = Random.Range(0, config.LevelSize.y);

                var vector = new Vector2Int(coordinateX, coordinateY);
                if (!coordinates.Contains(vector))
                {
                    coordinates.Add(vector);
                    tilesCount--;
                }
            }

            return coordinates;
        }
    }
}
